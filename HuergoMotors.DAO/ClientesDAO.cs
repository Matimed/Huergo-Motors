using System.Collections.Generic;
using System.Data;
using HuergoMotors.DTO;


namespace HuergoMotors.DAO
{
    public class ClientesDAO
    {
        HelperDAO helperDAO = new HelperDAO();
        //public List<ClientesDTO> CargarListaDTOs(DataTable dataTable)
        //{
        //    List<ClientesDTO> listaClientes = new List<ClientesDTO>();
        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        ClientesDTO ckienteDTO = new ClientesDTO();
        //        ckienteDTO.Id = (int)dataRow["Id"];
        //        ckienteDTO.Direccion = (string)dataRow["Direccion"];
        //        ckienteDTO.Email = (string)dataRow["Email"];
        //        ckienteDTO.Nombre = (string)dataRow["Nombre"];
        //        ckienteDTO.Telefono = (string)dataRow["Telefono"];
        //        listaClientes.Add(ckienteDTO);
        //    }
        //    return listaClientes;
        //}

        public List<ClientesDTO> CargarDatos()
        {
            return helperDAO.CargarDatos<ClientesDTO>();
            //return CargarListaDTOs(HelperDAO.CargarDataTable("SELECT * FROM Clientes"));
        }

        public List<ClientesDTO> Buscar(string filtro)
        {
            return helperDAO.CargarDatos<ClientesDTO>(
                $"Nombre LIKE '%{filtro}%' OR Direccion LIKE '%{filtro}%' OR Telefono LIKE '%{filtro}%' OR Email LIKE '%{filtro}%'");
            
            //return CargarListaDTOs(HelperDAO.CargarDataTable($"SELECT * FROM Clientes WHERE Nombre LIKE '%{filtro}%'" +
            //         $" or Direccion LIKE '%{filtro}%' or Telefono LIKE '%{filtro}%' or Email LIKE '%{filtro}%'"));
        }

        public int ModificarElemento(ClientesDTO clienteDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Clientes SET Nombre='{clienteDTO.Nombre}', Direccion='{clienteDTO.Direccion}', " +
                                $"Email='{clienteDTO.Email}', Telefono='{clienteDTO.Telefono}' WHERE Id={clienteDTO.Id}");
        }

        public int AgregarElemento(ClientesDTO clienteDTO)
        {
            return HelperDAO.EditarDB($"INSERT INTO Clientes (Nombre, Direccion, Email, Telefono) " +
                        $"VALUES ('{clienteDTO.Nombre}', '{clienteDTO.Direccion}', '{clienteDTO.Email}', '{clienteDTO.Telefono}')");
        }
        
        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Clientes Where Id={id} ");
        }
    }

}
