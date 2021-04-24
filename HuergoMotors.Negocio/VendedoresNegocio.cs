using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HuergoMotors.Negocio
{
    public class VendedoresNegocio
    {
        DAO.VendedoresDAO vendedoresDAO = new DAO.VendedoresDAO();

        public DataTable CargarTabla()
        {
            return vendedoresDAO.CargarTabla();
        }

        public int EliminarElemento(int id)
        {
            return vendedoresDAO.EliminarElemento(id);
        }
        public DataTable Buscar(string filtro)
        {
            return vendedoresDAO.Buscar(filtro);
        }
    }
}
