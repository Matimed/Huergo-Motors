using HuergoMotors.DTO;
using System.Collections.Generic;
using System.Data;

namespace HuergoMotors.DAO
{
    public class VehiculosDAO
    {
        HelperDAO helperDAO = new HelperDAO();
        //public List<VehiculosDTO> CargarListaDTOs(DataTable dataTable)
        //{
        //    List<VehiculosDTO> listaVehiculos = new List<VehiculosDTO>();
        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        VehiculosDTO vehiculoDTO = new VehiculosDTO();
        //        vehiculoDTO.Id = (int)dataRow["Id"];
        //        vehiculoDTO.Tipo = (string)dataRow["Tipo"];
        //        vehiculoDTO.Modelo = (string)dataRow["Modelo"];
        //        vehiculoDTO.PrecioVenta = (decimal)dataRow["PrecioVenta"];
        //        vehiculoDTO.Stock = (int)dataRow["Stock"];
        //        listaVehiculos.Add(vehiculoDTO);
        //    }
        //    return listaVehiculos;
        //}

        public List<VehiculosDTO> CargarDatos()
        {
            return helperDAO.CargarDatos<VehiculosDTO>();
            //return CargarListaDTOs(HelperDAO.CargarDataTable("SELECT * FROM Vehiculos"));
        }

        public VehiculosDTO CargarDatos(int id)
        {
            return helperDAO.CargarDatos<VehiculosDTO>($"Id = {id}")[0];
            //return CargarListaDTOs(HelperDAO.CargarDataTable($"SELECT * FROM Vehiculos WHERE Id={id}"))[0];
        }

        public List<VehiculosDTO> Buscar(string filtro)
        {
            return helperDAO.CargarDatos<VehiculosDTO>(
                $"Tipo LIKE '%{filtro}%' OR Modelo LIKE '%{filtro}%' OR PrecioVenta LIKE '%{filtro}%'");
            //return CargarListaDTOs(HelperDAO.CargarDataTable($"SELECT * FROM Vehiculos WHERE Tipo LIKE '%{filtro}%'" +
            //         $" or Modelo LIKE '%{filtro}%' or PrecioVenta LIKE '%{filtro}%' "));
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
            return HelperDAO.EditarDB($"INSERT INTO Vehiculos (Tipo, Modelo, PrecioVenta, Stock) " +
                        $"VALUES ('{vehiculoDTO.Tipo}', '{vehiculoDTO.Modelo}', {vehiculoDTO.PrecioVenta}, {vehiculoDTO.Stock})");
        }
    }
}
