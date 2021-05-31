using System.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace HuergoMotors.DAO
{
    public class HelperDAO
    {
        private static string ConnectionString = "Server=sql5078.site4now.net;Database=DB_9CF8B6_HuergoMotors2021;User Id=DB_9CF8B6_HuergoMotors2021_admin;Password=huergo2021;";

        public static NumberFormatInfo NFI()
        {
            //Escribe el número con puntos en lugar de comas para no dar error en la DB en los decimal
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };
            return numberFormatInfo;
        }

        public List<T> CargarDatos<T>() where T : new()
        {
            string tabla = typeof(T).Name;
            tabla = tabla.Remove(tabla.Length - 3);
            return CargarListaDTOs<T>(CargarDataTable($"SELECT * FROM {tabla}"));
        }
        public List<T> CargarDatos<T>(string condicion) where T : new()
        {
            string tabla = typeof(T).Name;
            tabla = tabla.Remove(tabla.Length - 3);
            return CargarListaDTOs<T>(CargarDataTable($"SELECT * FROM {tabla} WHERE {condicion}"));
        }
        public List<T> CargarDatos<T>(string campos, string tablas) where T : new()
        {
            return CargarListaDTOs<T>(CargarDataTable($"SELECT {campos} FROM {tablas}"));
        }
        public List<T> CargarDatos<T>(string campos, string tablas, string condicion) where T : new()
        {
            return CargarListaDTOs<T>(CargarDataTable($"SELECT {campos} FROM {tablas} WHERE {condicion}"));
        }

        public int AgregarElemento<T>(T dto)
        {
            var datos = GenerarDatos(dto);
            using (datos.command)
            {
                datos.command.CommandText = $"INSERT INTO {datos.tabla} ({datos.campos}) VALUES ({datos.parametros})";
                return EditarDB(datos.command);
            }
        }

        public int EliminarElemento<T>(int id)
        {
            string tabla = typeof(T).Name;
            tabla = tabla.Remove(tabla.Length - 3);
            return EditarDB($"DELETE FROM {tabla} WHERE Id={id}");
        }

        private DataTable CargarDataTable(string query)
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
        private List<T> CargarListaDTOs<T>(DataTable dataTable) where T : new()
        {
            try
            {
                List<T> listaDTOs = new List<T>();
                var propiedades = typeof(T).GetProperties().Where(p => p.CanWrite); //Solo trae las propiedades que se puedan escribir

                //Recorro todas las filas (registros) del DataTable. Cada fila sera un dto de la lista.
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    T dto = new T();

                    //Por cada dto, recorro todas las propiedades que tenga, y las completo con las celdas de la fila.
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        object valor = dataRow[propiedad.Name];
                        propiedad.SetValue(dto, valor, null);
                    }
                    listaDTOs.Add(dto);
                }
                return listaDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar los DTO", ex);
            }
        }


        private (string tabla, string campos, string parametros, SqlCommand command) GenerarDatos<T> (T dto)
        {
            string tabla = typeof(T).Name;
            tabla = tabla.Remove(tabla.Length - 3);
            string campos = "";
            string parametros = "";
            var propiedades = typeof(T).GetProperties().Where(p => p.CanWrite);
            using (SqlCommand command = new SqlCommand())
            {
                foreach (PropertyInfo prop in propiedades)
                {
                    if (prop.Name == "Id") continue; //Si es el Id, paso al que sigue.
                    campos += prop.Name + ',';
                    parametros += "@" + prop.Name + ',';
                    object valor = prop.GetValue(dto, null);
                    command.Parameters.AddWithValue("@" + prop.Name, valor);
                }
                campos = campos.TrimEnd(',');
                parametros = parametros.TrimEnd(',');
                return (tabla, campos, parametros, command);
            }
        }
        private static int EditarDB(SqlCommand command)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    command.Connection = conexion;
                    return command.ExecuteNonQuery(); ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar realizar cambios en la base de datos", ex);
            }
        }
        public static int EditarDB(string query)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar realizar cambios en la base de datos", ex);
            }
        }



        //Borar:

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

        //public void Create<T>(T dto)
        //{
        //    string tabla = typeof(T).Name;
        //    tabla = tabla.Remove(tabla.Length - 3);
        //    string campos = "";
        //    string parametros = "";
        //    var propiedades = typeof(T).GetProperties();

        //    using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            foreach (PropertyInfo prop in propiedades)
        //            {
        //                if (prop.Name == "Id") continue; //Si es el Id, paso al que sigue.

        //                campos += prop.Name + ',';
        //                parametros += "@" + prop.Name + ',';

        //                object valor = prop.GetValue(dto, null);
        //                cmd.Parameters.AddWithValue("@" + prop.Name, valor);
        //            }

        //            campos = campos.TrimEnd(',');
        //            parametros = parametros.TrimEnd(',');

        //            string query = $"INSERT INTO {tabla} ({campos}) VALUES ({parametros})";

        //            cmd.CommandText = query;
        //            cmd.Connection = conn;
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
