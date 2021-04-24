using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HuergoMotors.Negocio
{
    public class ClientesAltaNegocio
    {
        DAO.ClientesAltaDAO clientesAltaDAO = new DAO.ClientesAltaDAO();
        public DataTable CargarTabla(int id)
        {
            return clientesAltaDAO.CargarTabla(id);
        }

        public int ModificarElemento(string nombre, string direccion, string email, string telefono, int id)
        {
            return clientesAltaDAO.ModificarElemento(nombre, direccion, email, telefono, id);
        }

        public int AgregarElemento(string nombre, string direccion, string email, string telefono)
        {
            return clientesAltaDAO.AgregarElemento(nombre, direccion, email, telefono);
        }
    }
}
