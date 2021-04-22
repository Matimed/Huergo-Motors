using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuergoMotors.DAO
{
    public static string ConnectionString = "Server=sql5078.site4now.net;Database=DB_9CF8B6_HuergoMotors2021;User Id=DB_9CF8B6_HuergoMotors2021_admin;Password=huergo2021;";
    class HelperDAO
    {
        public static void EditarDB(string query, SqlConnection conexion, SqlTransaction transaction)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Transaction = transaction;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar la siguiente operacion: " + query, ex);
            }
            // DAO
        }
        public static void EditarDB(Form form, Modo modo, string query)
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
            // DAO
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
            // DAO
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
            // DAO
        }

    }
}
