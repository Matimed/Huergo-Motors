using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuergoMotorsVentas
{
    public static class Helper
    {
        //ToDo: Cargar imagenes de forma dinamica
        //ToDo: Comprimir imagenes

        public static string ConnectionString = "Server=sql5078.site4now.net;Database=DB_9CF8B6_HuergoMotors2021;User Id=DB_9CF8B6_HuergoMotors2021_admin;Password=huergo2021;";

        public enum Modo
        {
            Agregar,
            Modificar,
            Eliminar
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

        public static void Conexion(Form form, Modo modo, string query)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        int resultados = comando.ExecuteNonQuery();
                        OperacionExitosa(modo, resultados);
                    }
                }
                form.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar realizar cambios en la base de datos", ex);
            }
        }

        //ToDo: Agregar Try-Catch faltantes
        public static DataTable CargarDataTable(string query)
        {
            try
            {
                using (DataTable dataTable = new DataTable())
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, ConnectionString))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los datos desde la base de datos", ex);
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


        public static void CargarCombo(ComboBox combo, string query, string displaymember)
        {
            try
            {
                combo.DisplayMember = displaymember;
                combo.ValueMember = "Id";
                combo.DataSource = CargarDataTable(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar un ComboBox", ex);
            }
        }
        public static DataTable LeerCombo(ComboBox combo, string campo, string tabla)
        {
            try
            {
                int id = (int)combo.SelectedValue;
                DataTable dt = CargarDataTable($"SELECT {campo} FROM {tabla} WHERE ID = {id}");
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un ComboBox", ex);
            }
        }
       

        //ToDo:  Validar stock antes y despues de confirmar venta
        public static void ValidarNumerosNaturales(TextBox textbox1)
        {
            try
            {
                int numero;
                if (!int.TryParse(textbox1.Text, out numero) | numero<0)
                {
                    throw new Exception($"Tipo de dato inválido. Se esperaba un numero entero en {textbox1.Text}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ValidarNumerosRacionales(TextBox textbox1)
        {
            try
            {
                double numero;
                if (!double.TryParse(textbox1.Text, out numero) | numero<0)
                {
                    throw new Exception($"Tipo de dato inválido. Se esperaba un numero racional en {textbox1.Text}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool VerificarCombosCargados(ComboBox combo)
        {
            try
            {
                if (string.IsNullOrEmpty(combo.Text))
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
    }
}
