using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuergoMotorsVentas
{
    public static class Helper
    { 


    
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

        public static bool VerificarCombosCargados(ComboBox combo1, ComboBox combo2)
        {
            try
            {
                if (string.IsNullOrEmpty(combo1.Text) | string.IsNullOrEmpty(combo2.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los combos", ex);
            }
        }
    }
}
