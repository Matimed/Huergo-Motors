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

       //ToDo: Funcion para validar todos los registros. Validar stock antes y despues de confirmar venta
       //ToDo: Sacar algunos throw porque si no hay un try-catch afuera va a dar el mismo error 2 veces.
        public static DialogResult ConfirmacionModificacion()
        {
                DialogResult resp = MessageBox.Show("Los datos guardados se sobrescribiran ¿Esta seguro de que quiere continuar?",
                                 "Sobrescribir los datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return resp;
        }

        public static DialogResult ConfirmacionEliminación(string nombre, string apellido)
        {
            DialogResult resp = MessageBox.Show("Seguro que desea borrar a " + nombre +" " + apellido + "? Esta operacion no se puede revertir",
                     "Eliminar permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return resp;
        }

        public static void CargarCombo(ComboBox combo, string query, string displaymember, string valuemember)
        {
            CargarDataTable(query);
            combo.DisplayMember = displaymember;
            combo.ValueMember = valuemember;
            combo.DataSource = CargarDataTable(query);
        }
    }
}
