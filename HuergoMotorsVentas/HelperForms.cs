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

        public static void EditarDB(Form form, Modo modo, string query)
        {
            try
            {
                int resultados = HuergoMotors.Negocio.HelperNegocio.EditarDB(query);
                OperacionExitosa(modo, resultados);
                form.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar realizar cambios en la base de datos", ex);
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

        public static void ValidarNumerosRacionales(TextBox textbox1)
        {
            try
            {
                double numero;
                if (!double.TryParse(textbox1.Text, out numero) | numero < 0)
                {
                    throw new Exception($"Tipo de dato inválido. Se esperaba un numero racional en {textbox1.Text}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ValidarNumerosNaturales(TextBox textbox1)
        {
            try
            {
                int numero;
                if (!int.TryParse(textbox1.Text, out numero) | numero < 0)
                {
                    throw new Exception($"Tipo de dato inválido. Se esperaba un numero entero en {textbox1.Text}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ValidarTextosVacios(TextBox textbox1, TextBox textbox2, TextBox textbox3)
        {
            try
            {
                if (string.IsNullOrEmpty(textbox1.Text) | string.IsNullOrEmpty(textbox2.Text) | string.IsNullOrEmpty(textbox3.Text))
                {
                    throw new Exception("No se pueden dejar campos sin completar");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ValidarTextosVacios(TextBox textbox1, TextBox textbox2, TextBox textbox3, TextBox textbox4)
        {
            try
            {
                if (string.IsNullOrEmpty(textbox1.Text) | string.IsNullOrEmpty(textbox2.Text) | string.IsNullOrEmpty(textbox3.Text) | string.IsNullOrEmpty(textbox4.Text))
                {
                    throw new Exception("No se pueden dejar campos sin completar");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ValidarTextosVacios(TextBox textbox1, TextBox textbox2,
            TextBox textbox3, TextBox textbox4, TextBox textbox5, TextBox textbox6)
        {
            try
            {
                if (string.IsNullOrEmpty(textbox1.Text) | string.IsNullOrEmpty(textbox2.Text) | string.IsNullOrEmpty(textbox3.Text) |
                    string.IsNullOrEmpty(textbox4.Text) | string.IsNullOrEmpty(textbox5.Text) | string.IsNullOrEmpty(textbox6.Text))
                {
                    throw new Exception("No se pueden dejar campos sin completar");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ValidarTextBoxVacios(params TextBox[] textboxes)
        {
            foreach (TextBox tx in textboxes)
            {
                if (string.IsNullOrEmpty(tx.Text))
                {
                    throw new Exception("No se pueden dejar campos sin completar");
                }
            }
        }

    }
}

