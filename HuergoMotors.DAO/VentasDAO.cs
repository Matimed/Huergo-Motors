using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuergoMotors.DAO
{
    public class VentasDAO
    {
        public DataTable CargarDTVendedores()
        {
            return HelperDAO.CargarDataTable("SELECT Id, Nombre + ' ' + Apellido AS Vendedor FROM Vendedores");
        }
        public DataTable CargarDTModelos()
        {
            return HelperDAO.CargarDataTable("SELECT  Id, Modelo FROM Vehiculos");
        }
        public DataTable CargarDTAccesorios(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT Nombre, Id FROM Accesorios WHERE idVehiculo = {id}");
        }
    }
}
