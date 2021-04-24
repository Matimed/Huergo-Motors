using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HuergoMotors.DAO
{
    public class AccesoriosDAO
    {
         
        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
            "FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id;");
        }

        public int EliminarId(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Accesorios Where Id={id} ");
        }

        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
            $"FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id " +
            $"WHERE a.Tipo LIKE '%{filtro}%' or a.Nombre LIKE '%{filtro}%' or a.Precio " +
            $"LIKE '%{filtro}%' or b.Modelo LIKE '%{filtro}%'");
        }
    }
  
}
