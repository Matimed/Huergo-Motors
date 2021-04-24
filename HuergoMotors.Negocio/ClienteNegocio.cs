using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuergoMotors.DAO;

namespace HuergoMotors.Negocio
{
    public class ClienteNegocio
    {
        ClienteDAO clientesDAO = new ClienteDAO();
        public DataTable CargarTabla()
        {
            return clientesDAO.CargarTabla();
        }

        public DataTable Buscar(string filtro)
        {
            return clientesDAO.Buscar(filtro);
        }

        public int EliminarElemento(int id)
        {
            return clientesDAO.EliminarElemento(id);
        }

        public DataTable Seleccionar(DataTable clientesdatatable)
        {
            ClienteForms cliente = new ClienteForms();
            cliente.Id = (int)gv.SelectedRows[0].Cells["Id"].Value;
            cliente.Nombre = (string)gv.SelectedRows[0].Cells["Nombre"].Value;
            cliente.Direccion = (string)gv.SelectedRows[0].Cells["Direccion"].Value;
            cliente.Telefono = (string)gv.SelectedRows[0].Cells["Telefono"].Value;
            cliente.Email = (string)gv.SelectedRows[0].Cells["Email"].Value;

            ClienteSeleccionado = cliente;

        }
    }
}
