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

        //Funicones de lectura
        public List<T> CargarDatos()
        {
            return CargarListaDTOs(CargarDataTable($"SELECT * FROM {NombreTabla()}"));
        }
        public List<T> CargarDatos(string condicion)
        {
            return CargarListaDTOs(CargarDataTable($"SELECT * FROM {NombreTabla()} WHERE {condicion}"));
        }
        public List<T> Buscar(string filtro)
        {
            return CargarListaDTOs(CargarDataTable(QuerySearch(ListaPropiedades(), filtro)));
        }
        public T BuscarId(int id)
        {
            return CargarListaDTOs(CargarDataTable($"SELECT * FROM {NombreTabla()} WHERE Id = {id})"))[0];
        }


        //Funciones exclusivas de JOINS
        public List<T> CargarDatos(string campos, string tablas)
        {
            return CargarListaDTOs(CargarDataTable($"SELECT {campos} FROM {tablas}"));
        }
        public List<T> CargarDatos(string campos, string tablas, string condicion)
        {
            return CargarListaDTOs(CargarDataTable($"SELECT {campos} FROM {tablas} WHERE {condicion}"));
        }


        //Funciones de ABM
        public int AgregarElemento(T dto)
        {
            var propiedades = QueryCreate(ListaPropiedades());
            using (SqlCommand command = CargarParametros(dto))
            {
                command.CommandText = $"INSERT INTO {NombreTabla()} ({propiedades.campos}) VALUES ({propiedades.parametros})";
                return EditarDB(command);
            }
        }
        public void AgregarElemento(T dto,  SqlTransaction trans)
        {
            var propiedades = QueryCreate(ListaPropiedades());
            using (SqlCommand command = CargarParametros(dto))
            {
                command.CommandText = $"INSERT INTO {NombreTabla()} ({propiedades.campos}) VALUES ({propiedades.parametros})";
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
        public int ModificarElemento(T dto, List<string> listaPropiedades, SqlTransaction transaction)
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

        private List<string> ListaPropiedades()
        {
            List<string> nombrePropiedades = new List<string>();
            var propiedades = typeof(T).GetProperties().Where(p => p.CanWrite);
            foreach (PropertyInfo prop in propiedades)
            {
                if (prop.Name == "Id") continue; //Si es el Id, paso al que sigue.
                nombrePropiedades.Add(prop.Name);
            }
            return nombrePropiedades;
        }

        private string NombreTabla()
        {
            string tabla = typeof(T).Name;
            return tabla.Remove(tabla.Length - 3);
        }



        //Creacion de los querys
        private (string campos, string parametros) QueryCreate(List<string> propiedades)
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
            return (campos, parametros);
        }

        private string QueryUpdate(List<string> propiedades)
        {
            string update = $"UPDATE {NombreTabla()} SET ";
            foreach (string propiedad in propiedades)
            {
                update += $"{propiedad} = @{propiedad},";
            }
            return update.TrimEnd(',');
        }

        private string QuerySearch(List<string> propiedades, string filtro)
        {
            string search = $"SELECT * FROM {NombreTabla()} WHERE";
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
