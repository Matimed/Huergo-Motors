using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuergoMotors.DTO;


namespace HuergoMotors.DAO
{
    public class ClientesDAO
    {
        public List<ClienteDTO> CargarListaDTOs(DataTable dataTable)
        {
            List<ClienteDTO> listaClientes = new List<ClienteDTO>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                ClienteDTO ckienteDTO = new ClienteDTO();
                ckienteDTO.Id = (int)dataRow["Id"];
                ckienteDTO.Direccion = (string)dataRow["Direccion"];
                ckienteDTO.Email = (string)dataRow["Email"];
                ckienteDTO.Nombre = (string)dataRow["Nombre"];
                ckienteDTO.Telefono = (string)dataRow["Telefono"];
                listaClientes.Add(ckienteDTO);
            }
            return listaClientes;
        }

        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT * FROM Clientes");
        }

        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Clientes WHERE Nombre LIKE '%{filtro}%'" +
                     $" or Direccion LIKE '%{filtro}%' or Telefono LIKE '%{filtro}%' or Email LIKE '%{filtro}%'");
        }

        public DataTable CargarTabla(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Clientes WHERE Id={id}");
        }

        public int ModificarElemento(ClienteDTO clienteDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Clientes SET Nombre='{clienteDTO.Nombre}', Direccion='{clienteDTO.Direccion}', " +
                                $"Email='{clienteDTO.Email}', Telefono='{clienteDTO.Telefono}' WHERE Id={clienteDTO.Id}");
        }

        public int AgregarElemento(ClienteDTO clienteDTO)
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
