using HuergoMotors.DTO;
using System.Collections.Generic;
using System.Data;

namespace HuergoMotors.DAO
{
    public class VehiculosDAO
    {
        public List<VehiculoDTO> CargarListaDTOs(DataTable dataTable)
        {
            List<VehiculoDTO> listaVehiculos = new List<VehiculoDTO>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                VehiculoDTO vehiculoDTO = new VehiculoDTO();
                vehiculoDTO.Id = (int)dataRow["Id"];
                vehiculoDTO.Tipo = (string)dataRow["Tipo"];
                vehiculoDTO.Modelo = (string)dataRow["Modelo"];
                vehiculoDTO.PrecioVenta = (decimal)dataRow["PrecioVenta"];
                vehiculoDTO.Stock = (int)dataRow["Stock"];
                listaVehiculos.Add(vehiculoDTO);
            }
            return listaVehiculos;
        }

        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT * FROM Vehiculos");
        }

        public DataTable CargarTabla(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Vehiculos WHERE Id={id}");
        }

        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Vehiculos WHERE Tipo LIKE '%{filtro}%'" +
                     $" or Modelo LIKE '%{filtro}%' or PrecioVenta LIKE '%{filtro}%' "); ;
        }

        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Vehiculos Where Id={id} ");
        }

        public int ModificarElemento(VehiculoDTO vehiculoDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Vehiculos SET Tipo='{vehiculoDTO.Tipo}', Modelo='{vehiculoDTO.Modelo}', " +
                $"PrecioVenta='{vehiculoDTO.PrecioVenta}',Stock='{vehiculoDTO.Stock}' WHERE Id={vehiculoDTO.Id}");
        }

        public int AgregarElemento(VehiculoDTO  vehiculoDTO)
        {
            return HelperDAO.EditarDB($"INSERT INTO Vehiculos (Tipo, Modelo, PrecioVenta, Stock) " +
                        $"VALUES ('{vehiculoDTO.Tipo}', '{vehiculoDTO.Modelo}', {vehiculoDTO.PrecioVenta}, {vehiculoDTO.Stock})");
        }

    }
}
