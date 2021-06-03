using System.Collections.Generic;
using System.Data;
using HuergoMotors.DTO;

namespace HuergoMotors.DAO
{
    public class VendedoresDAO
    {
        DAOBase helperDAO = new DAOBase();

        public List<VendedoresDTO> CargarDatos()
        {
            return helperDAO.CargarDatos<VendedoresDTO>();
        }

     
        public List<VendedoresDTO> Buscar(string filtro)
        {
            return helperDAO.CargarDatos<VendedoresDTO>($"Apellido LIKE '%{filtro}%' OR Nombre LIKE '%{filtro}%' OR Sucursal LIKE '%{filtro}%'");
        }

        public int EliminarElemento(int id)
        {
            return helperDAO.EliminarElemento<VendedoresDTO>(id);
        }

        public int ModificarElemento(VendedoresDTO vendedorDTO)
        {
            return helperDAO.ModificarElemento(vendedorDTO, vendedorDTO.Id);
            //return HelperDAO.EditarDB($"UPDATE Vendedores SET Nombre='{vendedorDTO.Nombre}', " +
            //    $"Apellido='{vendedorDTO.Apellido}', Sucursal='{vendedorDTO.Sucursal}' WHERE Id={vendedorDTO.Id}");
        }

        public int AgregarElementos(VendedoresDTO vendedorDTO)
        {
            return helperDAO.AgregarElemento(vendedorDTO);
            //return HelperDAO.EditarDB($"INSERT INTO Vendedores (Nombre, Apellido, Sucursal) VALUES" +
            //                $" ('{vendedorDTO.Nombre}', '{vendedorDTO.Apellido}', '{vendedorDTO.Sucursal}')");
        }
    }
}
