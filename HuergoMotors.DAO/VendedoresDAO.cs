using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuergoMotors.DAO
{
    public class VendedoresDAO
    {
        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT * FROM Vendedores");
        }

        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Vendedores Where Id={id} ");
        }
        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Vendedores WHERE Apellido LIKE '%{filtro}%'" +
                    $" or Nombre LIKE '%{filtro}%' or Sucursal LIKE '%{filtro}%'");
        }
    }
}
