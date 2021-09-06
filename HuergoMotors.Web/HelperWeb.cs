using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.DTO;
using HuergoMotors.Web.UserControls;

namespace HuergoMotors.Web
{
    public static class HelperWeb
    {
        public static T GenerarDTO<T>(ControlCollection controls) where T : DTOBase, new()
        {
            T dto = new T();

            List<UserControlCampoTexto> camposTexto = GenerarListaControl<UserControlCampoTexto>(controls);
            if (camposTexto.Any())
            {
                dto = GenerarCampoTextoDTO(camposTexto, dto);
            }

            List<UserControlCampoDropDown> camposDropDown = GenerarListaControl<UserControlCampoDropDown>(controls);
            if (camposDropDown.Any())
            {
                dto = GenerarCampoDropDownDTO(camposDropDown, dto);
            }

            return dto;
        }

        public static T GenerarDTO<T>(ControlCollection controls, int Id) where T : DTOBase, new()
        {
            T dto = GenerarDTO<T>(controls);
            dto.Id = Id;
            return dto;
        }

        public static void LeerDTO<T>(ControlCollection controls, T dto) where T : DTOBase, new()
        {
            List<UserControlCampoTexto> camposTexto = GenerarListaControl<UserControlCampoTexto>(controls);
            if (camposTexto.Any())
            {
                LeerCampoTextoDTO(camposTexto, dto);
            }

            List<UserControlCampoDropDown> camposDropDown = GenerarListaControl<UserControlCampoDropDown>(controls);
            if (camposDropDown.Any())
            {
                LeerCampoDropDownDTO(camposDropDown, dto);
            }
        }



        private static List<T> GenerarListaControl<T>(ControlCollection controls) where T : Control
        {
            List<T> lista = new List<T>();
            ObtenerControles<T>(controls, lista);
            return lista;
        }

        private static void ObtenerControles<T>(ControlCollection controles, List<T> controlesResultantes) where T : Control
        {
            foreach (Control control in controles)
            {
                if (control is T)
                    controlesResultantes.Add((T)control);

                if (control.HasControls())
                    ObtenerControles(control.Controls, controlesResultantes);
            }
        }


        private static T GenerarCampoTextoDTO<T>(List<UserControlCampoTexto> campos, T dto)
        {
            foreach (UserControlCampoTexto campo in campos)
            {
                if (!campo.ReadOnly)
                {
                    if(!campo.Nullable) ValidarCampoVacio(campo);
                    PropertyInfo propiedad = dto.GetType().GetProperty(campo.Propiedad);
                    switch (propiedad.PropertyType.Name)
                    {
                        case "String":
                            propiedad.SetValue(dto, campo.Valor, null);
                            break;

                        case "Int32":
                            propiedad.SetValue(dto, ConvertirNumeroNatural(campo.Valor), null);
                            break;

                        case "Decimal":
                            propiedad.SetValue(dto, ConvertirNumeroRacional(campo.Valor), null);
                            break;
                        case "DateTime":
                            propiedad.SetValue(dto, ConvertirFecha(campo.Valor), null);
                            break;
                        default:
                            throw new Exception("Tipo de dato no reconocido");
                    }
                }
            }
            return dto;
        }

        private static void LeerCampoTextoDTO<T>(List<UserControlCampoTexto> campos, T dto)
        {
            foreach (UserControlCampoTexto campo in campos)
            {
                if (dto.GetType().GetProperty(campo.Propiedad) != null)
                {
                    PropertyInfo propiedad = dto.GetType().GetProperty(campo.Propiedad);
                    if (propiedad.PropertyType.Name == "String")
                    {
                        campo.Valor = (string)propiedad.GetValue(dto);
                    }
                    else if (propiedad.PropertyType.Name == "Int32" | propiedad.PropertyType.Name == "Decimal")
                    {
                        campo.Valor = propiedad.GetValue(dto).ToString();
                    }
                }
            }
        }

        private static T GenerarCampoDropDownDTO<T>(List<UserControlCampoDropDown> campos, T dto)
        {
            foreach (UserControlCampoDropDown campo in campos)
            {
                ValidarCampoVacio(campo);
                int id = ConvertirNumeroNatural(campo.Valor);
                ValidarID(id);
                PropertyInfo propiedad = dto.GetType().GetProperty(campo.Propiedad);
                propiedad.SetValue(dto, id, null);
            }
            return dto;
        }

        private static void LeerCampoDropDownDTO<T>(List<UserControlCampoDropDown> campos, T dto)
        {
            foreach (UserControlCampoDropDown campo in campos)
            {
                if (dto.GetType().GetProperty(campo.Propiedad) != null)
                {
                    PropertyInfo propiedad = dto.GetType().GetProperty(campo.Propiedad);
                    if (propiedad.PropertyType.Name == "String")
                    {
                        campo.Valor = (string)propiedad.GetValue(dto);
                    }
                    else if (propiedad.PropertyType.Name == "Int32" | propiedad.PropertyType.Name == "Decimal")
                    {
                        campo.Valor = propiedad.GetValue(dto).ToString();
                    }
                }
            }
        }



        public static int ConvertirNumeroNatural(string texto)
        {
            if (!int.TryParse(texto, out int numeroNatural) | numeroNatural < 0)
            {
                throw new Exception($"Tipo de dato inválido. Se esperaba un numero entero.");
            }
            return numeroNatural;
        }

        public static decimal ConvertirNumeroRacional(string texto)
        {
            if (!decimal.TryParse(texto, out decimal numeroRacional) | numeroRacional < 0)
            {
                throw new Exception($"Tipo de dato inválido. Se esperaba un numero racional.");
            }
            return numeroRacional;
        }

        public static DateTime ConvertirFecha(string texto)
        {
            var formats = new[] { "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy" };
            DateTime fecha;
            if (!DateTime.TryParseExact(texto, formats, null, DateTimeStyles.None, out fecha))
            {
                throw new Exception($"Tipo de dato inválido. Se esperaba una fecha válida.");
            }
            return fecha;
        }


        public static void DisplayDropDown(DropDownList dropDown, string displaymember)
        {
            try
            {
                dropDown.DataTextField = displaymember;
                dropDown.DataValueField = "Id";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar el drop down list", ex);
            }
        }


        private static void ValidarCampoVacio(UserControlCampoBase campo)
        {
            if (string.IsNullOrEmpty(campo.Valor))
            {
                throw new Exception($"No se pueden dejar el campo '{campo.Text}' sin completar");
            }
        }

        private static void ValidarID(int id)
        {
            if (id < 0) throw new Exception("Ningun elemento seleccionado");
        }

    }
}