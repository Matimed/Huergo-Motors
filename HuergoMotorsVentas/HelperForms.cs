using System;
using System.Windows.Forms;

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

    }
}

