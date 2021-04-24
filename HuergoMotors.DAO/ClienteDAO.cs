using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuergoMotors.DAO
{
    public class ClienteDAO
    {

        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT * FROM Clientes");
        }

        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Clientes WHERE Nombre LIKE '%{filtro}%'" +
                     $" or Direccion LIKE '%{filtro}%' or Telefono LIKE '%{filtro}%' or Email LIKE '%{filtro}%'");
        }

        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Clientes Where Id={id} ");
        }
    }

}
