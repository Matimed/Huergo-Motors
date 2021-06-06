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
            return clientesDAO.CargarDatos();
        }

        public List<ClientesDTO> Buscar(string filtro)
        {
            return clientesDAO.Buscar(filtro);
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
