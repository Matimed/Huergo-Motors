using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
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



        public static void MostrarOperacionExitosa(Form form, Modo modo, int resultados)
        {
            try
            {
                OperacionExitosa(modo, resultados);
                form.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar realizar cambios en la base de datos", ex);
            }
        }

        public static DataTable LeerCombo(ComboBox combo, string campo, string tabla)
        {
            try
            {
                int id = (int)combo.SelectedValue;
                return HuergoMotors.Negocio.HelperNegocio.LeerCombo(id, campo, tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un ComboBox", ex);
            }
        }

        public static string LeerDatoCombo(ComboBox combo, string campo, string tabla)
        {
            try
            {
                DataTable dataTable = LeerCombo(combo, campo, tabla);
                return HuergoMotors.Negocio.HelperNegocio.LeerDatoCombo(dataTable, campo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un dato del ComboBox", ex);
            }
        }

        public static int LeerNumeroCombo(ComboBox combo, string campo, string tabla)
        {
            try
            {
                DataTable dataTable = LeerCombo(combo, campo, tabla);
                return HuergoMotors.Negocio.HelperNegocio.LeerNumeroCombo(dataTable, campo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un numero del ComboBox", ex);
            }
        }

        public static void OperacionExitosa(Modo modo, int result)
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





        //Funciones para borrar
        public static void CargarCombo(ComboBox combo, string query, string displaymember)
        {
            try
            {
                combo.DisplayMember = displaymember;
                combo.ValueMember = "Id";
                combo.DataSource = HuergoMotors.Negocio.HelperNegocio.CargarDataTable(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar un ComboBox", ex);
            }
        }

    
    }
}

