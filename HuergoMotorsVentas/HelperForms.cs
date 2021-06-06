using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using HuergoMotors.DTO;
using System.Linq;

namespace HuergoMotorsForms
{
    public static class HelperForms
    {
        public enum Modo
        {
            Agregar,
            Modificar,
            Eliminar
        }

        public static void OperacionExitosa(Form form, Modo modo, int result)
        {
            try
            {
                switch (modo)
                {
                    case Modo.Agregar:
                        MessageBox.Show($"{result} registro/s agregados correctamente",
                        "Los registros fueron agregados exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case Modo.Modificar:
                        MessageBox.Show($"{result} registro/s actualizados correctamente",
                        "Actualización completada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case Modo.Eliminar:
                        MessageBox.Show($"{result} registro/s eliminados correctamente",
                        "Eliminacion completada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                form.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar realizar cambios en la base de datos", ex);
            }
        }
 
        public static DialogResult ConfirmacionModificacion()
        {
            DialogResult resp = MessageBox.Show("Los datos guardados se sobrescribiran ¿Esta seguro de que quiere continuar?",
                             "Sobrescribir los datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return resp;
        }

        public static DialogResult ConfirmacionEliminación(string nombre)
        {
            DialogResult resp = MessageBox.Show("Seguro que desea borrar a " + nombre + "? Esta operacion no se puede revertir",
                     "Eliminar permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return resp;
        }

        public static DialogResult ConfirmacionEliminación(string nombre, string apellido)
        {
            DialogResult resp = MessageBox.Show("Seguro que desea borrar a " + nombre + " " + apellido + "? Esta operacion no se puede revertir",
                     "Eliminar permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return resp;
        }

        public static bool VerificarCombosCargados(params ComboBox[] comboBoxes)
        {
            try
            {
                foreach (ComboBox comboBox in comboBoxes)
                {
                    if (string.IsNullOrEmpty(comboBox.Text))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los combos", ex);
            }
        }

        public static void DisplayCombo(ComboBox combo, string displaymember)
        {
            try
            {
                combo.DisplayMember = displaymember;
                combo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar un ComboBox", ex);
            }
        }


        public static T GenerarDTO<T>(Control.ControlCollection controls) where T : DTOBase, new()
        {  
            T dto = new T();
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    ValidarTextBoxVacio((TextBox)control);
                    PropertyInfo propiedad = dto.GetType().GetProperty(control.Name.Replace("txt", ""));
                    switch (propiedad.PropertyType.Name)
                    {
                        case "String":
                            propiedad.SetValue(dto, control.Text, null);
                            break;

                        case "Int32":
                            propiedad.SetValue(dto, ConvertirNumeroNatural((TextBox)control), null);
                            break;

                        case "Decimal":
                            propiedad.SetValue(dto, ConvertirNumeroRacional((TextBox)control), null);
                            break;
                        default:
                            throw new Exception("Tipo de dato no reconocido");
                    }
                }
                if (control is ComboBox)
                {
                    ValidarID((int)((ComboBox)control).SelectedValue);
                    PropertyInfo propiedad = dto.GetType().GetProperty(control.Name.Replace("cbo", ""));
                    propiedad.SetValue(dto, (int)((ComboBox)control).SelectedValue, null);
                }
            }
            return dto;
        }
        public static T GenerarDTO<T>(Control.ControlCollection controls, T dto) where T : DTOBase, new()
        {
            ValidarID(dto.Id);
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    ValidarTextBoxVacio((TextBox)control);
                    PropertyInfo propiedad = dto.GetType().GetProperty(control.Name.Replace("txt", ""));
                    switch (propiedad.PropertyType.Name)
                    {
                        case "String":
                            propiedad.SetValue(dto, control.Text, null);
                            break;

                        case "Int32":
                            propiedad.SetValue(dto, ConvertirNumeroNatural((TextBox)control), null);
                            break;

                        case "Decimal":
                            propiedad.SetValue(dto, ConvertirNumeroRacional((TextBox)control), null);
                            break;
                        default:
                            throw new Exception("Tipo de dato no reconocido");
                    }
                }
                if (control is ComboBox)
                {
                    ValidarID((int)((ComboBox)control).SelectedValue);
                    PropertyInfo propiedad = dto.GetType().GetProperty(control.Name.Replace("cbo", ""));
                    propiedad.SetValue(dto, (int)((ComboBox)control).SelectedValue, null);
                }
            }
            return dto;
        }


        public static T ConvertRdtoToDto<T, R>(R rdto) where T : DTOBase, new() 
        {
            T dto = new T();
            var propiedadesDTO = typeof(T).GetProperties().Where(p => p.CanWrite);
            var propiedadesRDTO = typeof(R).GetProperties();
            foreach (PropertyInfo propDTO in propiedadesDTO)
            {
                foreach (PropertyInfo propRDTO in propiedadesRDTO)
                {
                    if (propDTO.Name == propRDTO.Name)
                    {
                        propDTO.SetValue(dto, propRDTO.GetValue(rdto), null);
                    }
                }
            }
            return dto;
        }


        //Validaciones
        private static void ValidarTextBoxVacio(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                throw new Exception($"No se pueden dejar el campo {textBox.Name.Replace("txt","")} sin completar");
            }
        }
        private static decimal ConvertirNumeroRacional(TextBox textBox)
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
        private static int ConvertirNumeroNatural(TextBox textBox)
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
        private static void ValidarID(int id)
        {
            if (id < 0) throw new Exception("Ningun elemento seleccionado");
        }


        public static void ValidarEmail(string email)
        {
            try
            {
                string rgxEmail = @"\A(?:[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'+/=?^_`{|}~-]+)@(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                if (!Regex.IsMatch(email, rgxEmail)) throw new Exception("Email Invalido");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ValidarTelefono(string telefono)
        {
            try
            {
                string rgxTelefono = @"^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$";
                if (!Regex.IsMatch(telefono, rgxTelefono)) throw new Exception("Telefono Invalido");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ValidarDTOVacio<T>(T dto)
        {
            string tabla = typeof(T).Name;
            tabla = tabla.Remove(tabla.Length - 3);
            if (dto == null) throw new Exception($"Debe seleccionar un {tabla}");
        }


    }
}

