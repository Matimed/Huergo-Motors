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
    public static class HelperDAO
    {
        public static string ConnectionString = "Server=sql5078.site4now.net;Database=DB_9CF8B6_HuergoMotors2021;User Id=DB_9CF8B6_HuergoMotors2021_admin;Password=huergo2021;";

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
        }

        public static int EditarDB(string query)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        int resultados = comando.ExecuteNonQuery();
                        return resultados;
                    }
                }
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

        public static DataTable LeerCombo(int id, string campo, string tabla)
        {
            try
            {
                return CargarDataTable($"SELECT {campo} FROM {tabla} WHERE ID = {id}"); ;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un ComboBox", ex);
            }
        }



    }
}
