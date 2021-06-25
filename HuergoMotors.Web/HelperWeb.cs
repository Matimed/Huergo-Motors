using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.DTO;

namespace HuergoMotors.Web
{
    public static class HelperWeb
    {
        public static int ConvertirNumeroNatural(TextBox textBox)
        {
            try
            {
                if (!int.TryParse(textBox.Text, out int numeroNatural) | numeroNatural < 0)
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

        public static decimal ConvertirNumeroRacional(TextBox textBox)
        {
            try
            {
                if (!decimal.TryParse(textBox.Text, out decimal numeroRacional) | numeroRacional < 0)
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

        public static T GenerarDTO<T>(ControlCollection controls) where T : DTOBase, new()
        {
            T dto = new T();
            List<TextBox> textBoxes = new List<TextBox>();
            GenerarListaControles<TextBox>(controls, textBoxes);
            foreach (TextBox textBox in textBoxes)
            {
                    ValidarTextBoxVacio(textBox);
                    PropertyInfo propiedad = dto.GetType().GetProperty(textBox.ID.Replace("txt", ""));
                    switch (propiedad.PropertyType.Name)
                    {
                        case "String":
                            propiedad.SetValue(dto, (textBox).Text, null);
                            break;

                        case "Int32":
                            propiedad.SetValue(dto, ConvertirNumeroNatural(textBox), null);
                            break;

                        case "Decimal":
                            propiedad.SetValue(dto, ConvertirNumeroRacional(textBox), null);
                            break;
                        default:
                            throw new Exception("Tipo de dato no reconocido");
                    }
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
            List<TextBox> textBoxes = new List<TextBox>();
            GenerarListaControles<TextBox>(controls, textBoxes);
            foreach (TextBox textBox in textBoxes)
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
        }

        private static void GenerarListaControles<T>(ControlCollection controles, List<T> controlesResultantes) where T : Control
        {
            foreach (Control control in controles)
            {
                if (control is T)
                    controlesResultantes.Add((T)control);

                if (control.HasControls())
                    GenerarListaControles(control.Controls, controlesResultantes);
            }
        }

        private static void ValidarTextBoxVacio(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                throw new Exception($"No se pueden dejar el campo {textBox.ID.Replace("txt", "")} sin completar");
            }
        }
    }
}