using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.DTO;

namespace HuergoMotors.Web
{
    public static class HelperWeb
    {
        public static T GenerarDTO<T>(ControlCollection controls) where T : DTOBase, new()
        {
            T dto = new T();

            //Metodo para poder usar el UserControl CampoTexto:
            //foreach (UserControlCampoTexto campo in GenerarListaControl<UserControlCampoTexto>(controls))
            //{
            //    ValidarCampoVacio(campo);
            //    PropertyInfo propiedad = dto.GetType().GetProperty(campo.ID.Replace("ct", ""));
            //    switch (propiedad.PropertyType.Name)
            //    {
            //        case "String":
            //            propiedad.SetValue(dto, campo.Valor, null);
            //            break;

            //        case "Int32":
            //            propiedad.SetValue(dto, ConvertirNumeroNatural(campo.Valor), null);
            //            break;

            //        case "Decimal":
            //            propiedad.SetValue(dto, ConvertirNumeroRacional(campo.Valor), null);
            //            break;
            //        default:
            //            throw new Exception("Tipo de dato no reconocido");
            //    }
            //}

            foreach (TextBox textBox in GenerarListaControl<TextBox>(controls))
            {
                ValidarTextBoxVacio(textBox);
                PropertyInfo propiedad = dto.GetType().GetProperty(textBox.ID.Replace("txt", ""));
                switch (propiedad.PropertyType.Name)
                {
                    case "String":
                        propiedad.SetValue(dto, (textBox).Text, null);
                        break;

                    case "Int32":
                        propiedad.SetValue(dto, ConvertirNumeroNatural(textBox.Text), null);
                        break;

                    case "Decimal":
                        propiedad.SetValue(dto, ConvertirNumeroRacional(textBox.Text), null);
                        break;
                    default:
                        throw new Exception("Tipo de dato no reconocido");
                }
            }

            foreach (DropDownList dropDown in GenerarListaControl<DropDownList>(controls))
            {
                int id = ConvertirNumeroNatural(dropDown.SelectedValue);
                ValidarID(id);
                PropertyInfo propiedad = dto.GetType().GetProperty(dropDown.ID.Replace("ddl", ""));
                propiedad.SetValue(dto, id, null);
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
            
            foreach (TextBox textBox in GenerarListaControl<TextBox>(controls))
            {
                    PropertyInfo propiedad = dto.GetType().GetProperty(textBox.ID.Replace("txt", ""));
                    if (propiedad.PropertyType.Name == "String")
                    {
                        textBox.Text = (string)propiedad.GetValue(dto);
                    }
                    else if (propiedad.PropertyType.Name == "Int32" | propiedad.PropertyType.Name == "Decimal")
                    {
                        textBox.Text = propiedad.GetValue(dto).ToString();
                    }
            }
            foreach (DropDownList dropDown in GenerarListaControl<DropDownList>(controls))
            {
                PropertyInfo propiedad = dto.GetType().GetProperty(dropDown.ID.Replace("ddl", ""));
                dropDown.SelectedValue = propiedad.GetValue(dto).ToString();
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



        public static int ConvertirNumeroNatural(string texto)
        {
            try
            {
                if (!int.TryParse(texto, out int numeroNatural) | numeroNatural < 0)
                {
                    throw new Exception($"Tipo de dato inválido. Se esperaba un numero entero.");
                }
                return numeroNatural;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal ConvertirNumeroRacional(string texto)
        {
            try
            {
                if (!decimal.TryParse(texto, out decimal numeroRacional) | numeroRacional < 0)
                {
                    throw new Exception($"Tipo de dato inválido. Se esperaba un numero racional.");
                }
                return numeroRacional;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        private static void ValidarTextBoxVacio(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                throw new Exception($"No se pueden dejar el campo {textBox.ID.Replace("txt", "")} sin completar");
            }
        }

        private static void ValidarCampoVacio(UserControlCampoTexto campo)
        {
            if (string.IsNullOrEmpty(campo.Valor))
            {
                throw new Exception($"No se pueden dejar el campo {campo.ID.Replace("ct", "")} sin completar");
            }
        }

        private static void ValidarID(int id)
        {
            if (id < 0) throw new Exception("Ningun elemento seleccionado");
        }

    }
}