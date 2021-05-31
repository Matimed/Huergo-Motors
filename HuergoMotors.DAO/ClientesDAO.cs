using System.Collections.Generic;
using System.Data;
using HuergoMotors.DTO;


namespace HuergoMotors.DAO
{
    public class ClientesDAO
    {
        HelperDAO helperDAO = new HelperDAO();

        public List<ClientesDTO> CargarDatos()
        {
            return helperDAO.CargarDatos<ClientesDTO>();
        }

        public List<ClientesDTO> Buscar(string filtro)
        {
            return helperDAO.CargarDatos<ClientesDTO>(
                $"Nombre LIKE '%{filtro}%' OR Direccion LIKE '%{filtro}%' OR Telefono LIKE '%{filtro}%' OR Email LIKE '%{filtro}%'");
        }

        public int ModificarElemento(ClientesDTO clienteDTO)
        {
            return helperDAO.EditarDB($"UPDATE Clientes SET Nombre='{clienteDTO.Nombre}', Direccion='{clienteDTO.Direccion}', " +
                                $"Email='{clienteDTO.Email}', Telefono='{clienteDTO.Telefono}' WHERE Id={clienteDTO.Id}");
        }

        public int AgregarElemento(ClientesDTO clienteDTO)
        {
            return helperDAO.AgregarElemento(clienteDTO);
        }
        
        public int EliminarElemento(int id)
        {
            return helperDAO.EliminarElemento<ClientesDTO>(id);
        }
    }

}
