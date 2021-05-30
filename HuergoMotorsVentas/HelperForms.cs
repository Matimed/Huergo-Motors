using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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

        public static void ValidarTextosVacios(params string[] textosValidar)
        {
            try
            {
                foreach (string textoValidar in textosValidar)
                {
                    if (string.IsNullOrEmpty(textoValidar))
                    {
                        throw new Exception("No se pueden dejar campos sin completar");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ValidarID(int id)
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
        public static void ValidarDTOVacio<T>(T DTO)
        {
            string tabla = typeof(T).Name;
            tabla = tabla.Remove(tabla.Length - 3);
            if (DTO == null) throw new Exception($"Debe seleccionar un {tabla}");
        }

        public static decimal ConvertirNumeroRacional(string numeroValidar)
        {
            try
            {
                if (!decimal.TryParse(numeroValidar, out decimal numeroRacional) | numeroRacional < 0)
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
        public static int ConvertirNumeroNatural(string numeroValidar)
        {
            try
            {
                if (!int.TryParse(numeroValidar, out int numeroNatural) | numeroNatural < 0)
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
    }
}

