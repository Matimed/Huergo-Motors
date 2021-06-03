using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.DAO
{
    public class AccesoriosDAO : DAOBase<AccesoriosDTO>
    {
        public static string Campos = "a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo";
        public static string Tablas = "Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id";

        DAOBase<AccesoriosRDTO> daoJoins = new DAOBase<AccesoriosRDTO>();

        public List<AccesoriosRDTO> CargarTabla()
        {
            return daoJoins.CargarDatos(Campos, Tablas);
        }

        public List<AccesoriosDTO> BuscarIdVehiculo(int id)
        {
            return CargarDatos($"IdVehiculo = {id}");
        }

        public new List<AccesoriosRDTO> Buscar(string filtro)
        {
            return daoJoins.CargarDatos(Campos, Tablas,
                $"a.Tipo LIKE '%{filtro}%' OR a.Nombre LIKE '%{filtro}%' OR a.Precio LIKE '%{filtro}%' OR b.Modelo LIKE '%{filtro}%'");
        }
    }
  
}
