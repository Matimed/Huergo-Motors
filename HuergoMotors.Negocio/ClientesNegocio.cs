using System;
using System.Collections.Generic;
using HuergoMotors.DAO;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class ClientesNegocio
    {
        ClientesDAO clientesDAO = new ClientesDAO();

        public List<ClientesDTO> CargarTabla()
        {
            return clientesDAO.CargarTabla();
        }

        public List<ClientesDTO> Buscar(string filtro)
        {
            return clientesDAO.Buscar(filtro);
        }

        public ClientesDTO CargarDTO(int id, string nombre, string direccion, string email, string telefono)
        {
            try
            {
                ClientesDTO clienteDTO = new ClientesDTO();
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
            
        public int ModificarElemento(ClientesDTO clienteDTO)
        {
            return clientesDAO.ModificarElemento(clienteDTO);
        }

        public int AgregarElemento(ClientesDTO clienteDTO)
        {
            return clientesDAO.AgregarElemento(clienteDTO);
        }
    }
}
