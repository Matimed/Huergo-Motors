using HuergoMotors.DTO;
using System.Collections.Generic;
using System.Data;

namespace HuergoMotors.DAO
{
    public class VehiculosDAO
    {
        HelperDAO helperDAO = new HelperDAO();

        public List<VehiculosDTO> CargarDatos()
        {
            return helperDAO.CargarDatos<VehiculosDTO>();
        }

        public VehiculosDTO CargarDatos(int id)
        {
            return helperDAO.CargarDatos<VehiculosDTO>($"Id = {id}")[0];
        }

        public List<VehiculosDTO> Buscar(string filtro)
        {
            return helperDAO.CargarDatos<VehiculosDTO>(
                $"Tipo LIKE '%{filtro}%' OR Modelo LIKE '%{filtro}%' OR PrecioVenta LIKE '%{filtro}%'");
        }

        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Vehiculos Where Id={id} ");
        }

        public int ModificarElemento(VehiculosDTO vehiculoDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Vehiculos SET Tipo='{vehiculoDTO.Tipo}', Modelo='{vehiculoDTO.Modelo}', " +
                $"PrecioVenta='{vehiculoDTO.PrecioVenta}',Stock='{vehiculoDTO.Stock}' WHERE Id={vehiculoDTO.Id}");
        }

        public int AgregarElemento(VehiculosDTO  vehiculoDTO)
        {
            return helperDAO.AgregarElemento(vehiculoDTO);
            //return HelperDAO.EditarDB($"INSERT INTO Vehiculos (Tipo, Modelo, PrecioVenta, Stock) " +
            //            $"VALUES ('{vehiculoDTO.Tipo}', '{vehiculoDTO.Modelo}', {vehiculoDTO.PrecioVenta}, {vehiculoDTO.Stock})");
        }
    }
}
