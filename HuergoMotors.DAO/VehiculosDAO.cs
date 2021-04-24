using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuergoMotors.DAO
{
    public class VehiculosDAO
    {

        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT * FROM Vehiculos");
        }

        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Vehiculos Where Id={id} ");
        }

        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Vehiculos WHERE Tipo LIKE '%{filtro}%'" +
                     $" or Modelo LIKE '%{filtro}%' or PrecioVenta LIKE '%{filtro}%' ");
        }
        public DataTable CargarTabla(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Vehiculos WHERE Id={id}");
        }

        public int ModificarElemento(DTO.VehiculoDTO vehiculoDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Vehiculos SET Tipo='{vehiculoDTO.Tipo}', Modelo='{vehiculoDTO.Modelo}', " +
                $"PrecioVenta='{vehiculoDTO.PrecioVenta}',Stock='{vehiculoDTO.Stock}' WHERE Id={vehiculoDTO.Id}");
        }

        public int AgregarElemento(DTO.VehiculoDTO  vehiculoDTO)
        {
            return HelperDAO.EditarDB($"INSERT INTO Vehiculos (Tipo, Modelo, PrecioVenta, Stock) " +
                        $"VALUES ('{vehiculoDTO.Tipo}', '{vehiculoDTO.Modelo}', {vehiculoDTO.PrecioVenta}, {vehiculoDTO.Stock})");
        }

    }
}
