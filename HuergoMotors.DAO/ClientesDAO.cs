using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuergoMotors.DAO
{
    public class ClientesDAO
    {

        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT * FROM Clientes");
        }

        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Clientes WHERE Nombre LIKE '%{filtro}%'" +
                     $" or Direccion LIKE '%{filtro}%' or Telefono LIKE '%{filtro}%' or Email LIKE '%{filtro}%'");
        }

        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Clientes Where Id={id} ");
        }

        public DataTable CargarTabla(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Clientes WHERE Id={id}");
        }

        public int ModificarElemento(DTO.ClienteDTO clienteDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Clientes SET Nombre='{clienteDTO.Nombre}', Direccion='{clienteDTO.Direccion}', " +
                                $"Email='{clienteDTO.Email}', Telefono='{clienteDTO.Telefono}' WHERE Id={clienteDTO.Id}");
        }

        public int AgregarElemento(DTO.ClienteDTO clienteDTO)
        {
            return HelperDAO.EditarDB($"INSERT INTO Clientes (Nombre, Direccion, Email, Telefono) " +
                        $"VALUES ('{clienteDTO.Nombre}', '{clienteDTO.Direccion}', '{clienteDTO.Email}', '{clienteDTO.Telefono}')");
        }
    }

}
