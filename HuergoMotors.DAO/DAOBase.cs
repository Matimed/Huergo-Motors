using System.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using HuergoMotors.DTO;

namespace HuergoMotors.DAO
{
    public class DAOBase<T> where T : DTOBase, new()
    {
        public static string ConnectionString = "Server=sql5078.site4now.net;Database=DB_9CF8B6_HuergoMotors2021;User Id=DB_9CF8B6_HuergoMotors2021_admin;Password=huergo2021;";
        public static NumberFormatInfo NFI()
        {
            //Escribe el número con puntos en lugar de comas para no dar error en la DB en los decimal
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };
            return numberFormatInfo;
        }


        public void Referenciado (int id)
        {
            throw new NotImplementedException();
        }
        //Funicones de lectura
        public List<T> CargarDatos()
        {
            return GenerearListaDTOs($"SELECT * FROM {NombreTabla()}");
        }
        public List<T> CargarDatos(string condicion)
        {
            return GenerearListaDTOs($"SELECT * FROM {NombreTabla()} WHERE {condicion}");
        }
        public List<T> Buscar(string filtro)
        {
            return GenerearListaDTOs($"SELECT * FROM {NombreTabla()} WHERE " + QuerySearch(ListaPropiedades(), filtro));
        }
        public T BuscarId(int id)
        {
            return GenerearListaDTOs($"SELECT * FROM {NombreTabla()} WHERE Id = {id}")[0];
        }


        /// <summary>
        /// Devuelve True si hay una venta que referencia al objeto y false si no se encontro ninguna
        /// </summary>
        public bool ReferenciaVentas(string condicion)
        {
            return CargarDataTable($"SELECT * FROM Ventas WHERE {condicion}").Rows.Count > 0;
        }
        public bool ReferenciaVentasAccesorios(string condicion)
        {
            return CargarDataTable($"SELECT * FROM VentasAccesorios WHERE {condicion}").Rows.Count > 0;
        }


        //Funciones exclusivas de JOINS
        public List<T> CargarDatos(string campos, string tablas)
        {
            return GenerearListaDTOs($"SELECT {campos} FROM {tablas}");
        }
        public List<T> CargarDatos(string campos, string tablas, string condicion)
        {
            return GenerearListaDTOs($"SELECT {campos} FROM {tablas} WHERE {condicion}");
        }
        public List<T> Buscar(string campos,string tablas, string filtro)
        {
            return CargarDatos(campos, tablas, QuerySearch(campos.Split(','), filtro));

        }


        //Funciones de ABM
        public int AgregarElemento(T dto)
        {
            using (SqlCommand command = CargarParametros(dto))
            {
                command.CommandText = QueryCreate(ListaPropiedades());
                return EditarDB(command);
            }
        }
        public void AgregarElemento(T dto,  SqlTransaction trans)
        {
            using (SqlCommand command = CargarParametros(dto))
            {
                command.CommandText = QueryCreate(ListaPropiedades());
                EditarDB(command, trans);
            }
        }

        public int ModificarElemento(T dto)
        {
            using (SqlCommand command = CargarParametros(dto))
            {
                command.CommandText = QueryUpdate(ListaPropiedades()) + $" WHERE Id= {dto.Id}";
                return EditarDB(command);
            }
        }
        public int ModificarElemento(T dto, string[] listaPropiedades, SqlTransaction transaction)
        {
            using (SqlCommand command = CargarParametros(dto))
            {
                command.CommandText = QueryUpdate(listaPropiedades) + $" WHERE Id= {dto.Id}";
                return EditarDB(command, transaction);
            }
        }

        public int EliminarElemento(int id)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = $"DELETE FROM {NombreTabla()} WHERE Id={id}";
                return EditarDB(command);
            }
        }



        //Organizacion de los datos
        public List<T>GenerearListaDTOs(string query)
        {
            return CargarListaDTOs(CargarDataTable(query));
        }
        private List<T> CargarListaDTOs(DataTable dataTable)
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
                        if (valor != DBNull.Value)
                        { 
                            propiedad.SetValue(dto, valor, null);
                        }
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

        private string[] ListaPropiedades()
        {
            List<string> nombrePropiedades = new List<string>();
            var propiedades = typeof(T).GetProperties().Where(p => p.CanWrite);
            foreach (PropertyInfo prop in propiedades)
            {
                if (prop.Name == "Id") continue; //Si es el Id, paso al que sigue.
                nombrePropiedades.Add(prop.Name);
            }
            return nombrePropiedades.ToArray();
        }

        private string NombreTabla()
        {
            string tabla = typeof(T).Name;
            return tabla.Remove(tabla.Length - 3);
        }



        //Formulación de los querys
        private string QueryCreate(string[] propiedades)
        {   
            string campos = "";
            string parametros = "";
            foreach (string propiedad in propiedades)
            {
                campos += propiedad + ',';
                parametros += "@" + propiedad + ',';
            }
            campos = campos.TrimEnd(',');
            parametros = parametros.TrimEnd(',');
            return ($"INSERT INTO {NombreTabla()} ({campos}) VALUES({parametros})");
        }

        private string QueryUpdate(string[] propiedades)
        {
            string update = $"UPDATE {NombreTabla()} SET ";
            foreach (string propiedad in propiedades)
            {
                update += $"{propiedad} = @{propiedad},";
            }
            return update.TrimEnd(',');
        }

        private string QuerySearch(string[] propiedades, string filtro)
        {
            string search = string.Empty;
            foreach (string propiedad in propiedades)
            {
                search += $" {propiedad} LIKE '%{filtro}%' OR";
            }
            return search.Remove(search.Length - 3);
        }



        //Comunicacion con la DB
        private int EditarDB(SqlCommand command)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    command.Connection = conexion;
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar realizar cambios en la base de datos", ex);
            }
        }

        public int EditarDB(SqlCommand command, SqlTransaction trans)
        {
            try
            {
                command.Connection = trans.Connection;
                command.Transaction = trans;
                return command.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar realizar cambios en la base de datos", ex);
            }
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

        private SqlCommand CargarParametros(T dto)
        {
            var propiedades = typeof(T).GetProperties().Where(p => p.CanWrite);
            using (SqlCommand command = new SqlCommand())
            {
                foreach (PropertyInfo prop in propiedades)
                {
                    if (prop.Name == "Id") continue; //Si es el Id, paso al que sigue.
                    object valor = prop.GetValue(dto, null);
                    command.Parameters.AddWithValue("@" + prop.Name, valor);
                }
                return command;
            }
        }
    }
}
