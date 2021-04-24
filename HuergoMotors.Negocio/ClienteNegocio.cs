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
            
        public DTO.ClienteDTO Seleccionar(object fila)
        {
            DTO.ClienteDTO clienteDTO = new DTO.ClienteDTO();
            clienteDTO.Id = (int)((DataRowView)fila)["Id"];
            clienteDTO.Nombre = (string)((DataRowView)fila)["Nombre"];
            clienteDTO.Direccion = (string)((DataRowView)fila)["Direccion"];
            clienteDTO.Telefono = (string)((DataRowView)fila)["Telefono"];
            clienteDTO.Email = (string)((DataRowView)fila)["Email"];
            return clienteDTO;
        }
        //return clienteDTO;
    }
}
