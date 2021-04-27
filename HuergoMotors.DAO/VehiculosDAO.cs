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

        public List<VehiculoDTO> CargarTabla()
        {
            return CargarListaDTOs(HelperDAO.CargarDataTable("SELECT * FROM Vehiculos"));
        }

        public VehiculoDTO CargarTabla(int id)
        {
            return CargarListaDTOs(HelperDAO.CargarDataTable($"SELECT * FROM Vehiculos WHERE Id={id}"))[0];
        }

        public List<VehiculoDTO> Buscar(string filtro)
        {
            return CargarListaDTOs(HelperDAO.CargarDataTable($"SELECT * FROM Vehiculos WHERE Tipo LIKE '%{filtro}%'" +
                     $" or Modelo LIKE '%{filtro}%' or PrecioVenta LIKE '%{filtro}%' "));
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
