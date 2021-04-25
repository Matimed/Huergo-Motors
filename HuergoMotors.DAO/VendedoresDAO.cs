using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuergoMotors.DAO
{
    public class VendedoresDAO
    {
        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT * FROM Vendedores");
        }
        public DataTable CargarTabla(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Vendedores WHERE Id={id}");
        }
        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Vendedores Where Id={id} ");
        }
        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Vendedores WHERE Apellido LIKE '%{filtro}%'" +
                    $" or Nombre LIKE '%{filtro}%' or Sucursal LIKE '%{filtro}%'");
        }
        public int ModificarElemento(DTO.VendedorDTO vendedorDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Vendedores SET Nombre='{vendedorDTO.Nombre}', " +
                $"Apellido='{vendedorDTO.Apellido}', Sucursal='{vendedorDTO.Sucursal}' WHERE Id={vendedorDTO.Id}");
        }
        public int AgregarElementos(DTO.VendedorDTO vendedorDTO)
        {
            return HelperDAO.EditarDB($"INSERT INTO Vendedores (Nombre, Apellido, Sucursal) VALUES" +
                            $" ('{vendedorDTO.Nombre}', '{vendedorDTO.Apellido}', '{vendedorDTO.Sucursal}')");
        }
    }
}
