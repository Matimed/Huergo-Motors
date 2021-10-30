using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.DAO
{
    public class AccesoriosDAO : DAOBase<AccesoriosDTO>
    {
        public static string Campos = "a.Id,a.Nombre,a.Tipo,a.Precio,a.IdVehiculo,a.Foto,b.Modelo";
        public static string Tablas = "Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id";

        DAOBase<AccesoriosRDTO> daoJoins = new DAOBase<AccesoriosRDTO>();

        public List<AccesoriosRDTO> CargarTabla()
        {
            return daoJoins.CargarDatos(Campos, Tablas);
        }

        public new void Referenciado(int id)
        {
            if (ReferenciaVentasAccesorios($"IdAccesorio = {id}"))
                throw new Exception("No se puede borrar un accesorio que tenga ventas asociadas");
        }

        public List<AccesoriosRDTO> Filtrar(string filtro, decimal minimo, decimal maximo)
        {
            string condicion = "";
            if (minimo != 0)
            {
                condicion += $" AND Precio > {minimo}";
            }
            if (maximo != 0)
            {
                condicion += $" AND Precio < {maximo}";
            }
            return daoJoins.Buscar(Campos, Tablas, filtro, condicion);
        }

        public List<AccesoriosDTO> BuscarIdVehiculo(int id)
        {
            return CargarDatos($"IdVehiculo = {id}");
        }

        public new List<AccesoriosRDTO> Buscar(string filtro)
        {
            return daoJoins.Buscar(Campos, Tablas, filtro);      
        }
    }
  
}
