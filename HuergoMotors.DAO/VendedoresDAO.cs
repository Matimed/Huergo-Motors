using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuergoMotors.DTO;

namespace HuergoMotors.DAO
{
    public class VendedoresDAO
    {
        public List<VendedorDTO> CargarListaDTOs(DataTable dataTable)
        {
            List<VendedorDTO> listaVendedores = new List<VendedorDTO>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                VendedorDTO vendedorDTO = new VendedorDTO();
                vendedorDTO.Id = (int)dataRow["Id"];
                vendedorDTO.Nombre = (string)dataRow["Nombre"];
                vendedorDTO.Sucursal = (string)dataRow["Sucursal"];
                vendedorDTO.Apellido = (string)dataRow["Apellido"];
                vendedorDTO.NombreCompleto = vendedorDTO.Nombre + " " + vendedorDTO.Apellido;
                listaVendedores.Add(vendedorDTO);
            }
            return listaVendedores;
        }

        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT * FROM Vendedores");
        }

        public DataTable CargarTabla(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Vendedores WHERE Id={id}");
        }

        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Vendedores WHERE Apellido LIKE '%{filtro}%'" +
                    $" or Nombre LIKE '%{filtro}%' or Sucursal LIKE '%{filtro}%'");
        }

        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Vendedores Where Id={id} ");
        }

        public int ModificarElemento(VendedorDTO vendedorDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Vendedores SET Nombre='{vendedorDTO.Nombre}', " +
                $"Apellido='{vendedorDTO.Apellido}', Sucursal='{vendedorDTO.Sucursal}' WHERE Id={vendedorDTO.Id}");
        }

        public int AgregarElementos(VendedorDTO vendedorDTO)
        {
            return HelperDAO.EditarDB($"INSERT INTO Vendedores (Nombre, Apellido, Sucursal) VALUES" +
                            $" ('{vendedorDTO.Nombre}', '{vendedorDTO.Apellido}', '{vendedorDTO.Sucursal}')");
        }
    }
}
