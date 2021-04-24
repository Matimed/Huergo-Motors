using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HuergoMotors.DAO;

namespace HuergoMotors.Negocio
{
    public class AccesoriosNegocio
    {
        AccesoriosDAO accesoriosDAO = new AccesoriosDAO();
        public DataTable CargarTabla()
        {
            return accesoriosDAO.CargarTabla();
        }

        public int EliminarElemento (int id)
        {
            return accesoriosDAO.EliminarElemento(id);
        }
        public DataTable Buscar(string filtro)
        {
            return accesoriosDAO.Buscar(filtro);
        }
    }
}
