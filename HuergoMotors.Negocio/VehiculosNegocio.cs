using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HuergoMotors.Negocio
{
    public class VehiculosNegocio
    {
        DAO.VehiculosDAO vehiculosDAO = new DAO.VehiculosDAO();
        public DataTable CargarTabla()
        {
            return vehiculosDAO.CargarTabla();
        }

        public int EliminarElemento(int id)
        {
            return vehiculosDAO.EliminarElemento(id);
        }

        public DataTable Buscar(string filtro)
        {
            return vehiculosDAO.Buscar(filtro);
        }

    }
}
