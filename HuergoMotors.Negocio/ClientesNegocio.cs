using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuergoMotors.DAO;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class ClientesNegocio
    {
        ClientesDAO clientesDAO = new ClientesDAO();

        public List<ClienteDTO> CargarTabla()
        {
            return clientesDAO.CargarListaDTOs(clientesDAO.CargarTabla());
        }

        public List<ClienteDTO> CargarTabla(int id)
        {
            return clientesDAO.CargarListaDTOs(clientesDAO.CargarTabla(id));
        }

        public List<ClienteDTO> Buscar(string filtro)
        {
            return clientesDAO.CargarListaDTOs(clientesDAO.Buscar(filtro));
        }

        public ClienteDTO CargarDTO(int id, string nombre, string direccion, string email, string telefono)
        {
            try
            {
                ClienteDTO clienteDTO = new ClienteDTO();
                HelperNegocio.ValidarEmail(email);
                HelperNegocio.ValidarTelefono(telefono);
                HelperNegocio.ValidarTextosVacios(direccion, email, nombre, telefono);
                HelperNegocio.ValidarID(id);
                clienteDTO.Id = id;
                clienteDTO.Direccion = direccion;
                clienteDTO.Email = email;
                clienteDTO.Nombre = nombre;
                clienteDTO.Telefono = telefono;
                return clienteDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EliminarElemento(int id)
        {
            return clientesDAO.EliminarElemento(id);
        }
            
        public int ModificarElemento(ClienteDTO clienteDTO)
        {
            return clientesDAO.ModificarElemento(clienteDTO);
        }

        public int AgregarElemento(ClienteDTO clienteDTO)
        {
            return clientesDAO.AgregarElemento(clienteDTO);
        }
    }
}
