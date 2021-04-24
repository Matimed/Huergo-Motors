using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuergoMotors.DAO
{
    public class VehiculosDAO
    {

        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT * FROM Vehiculos");
        }

        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Vehiculos Where Id={id} ");
        }

        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Vehiculos WHERE Tipo LIKE '%{filtro}%'" +
                     $" or Modelo LIKE '%{filtro}%' or PrecioVenta LIKE '%{filtro}%' ");
        }

    }
}
