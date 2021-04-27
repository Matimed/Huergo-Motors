using System.Collections.Generic;
using System.Data;
using HuergoMotors.DTO;

namespace HuergoMotors.DAO
{
    public class AccesoriosDAO
    {
        public List<AccesorioDTO> CargarListaDTOs(DataTable dataTable)
        {
            List<AccesorioDTO> listaAccesorios = new List<AccesorioDTO>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                AccesorioDTO accesorioDTO = new AccesorioDTO();
                accesorioDTO.Id = (int)dataRow["Id"];
                accesorioDTO.Tipo = (string)dataRow["Tipo"];
                accesorioDTO.Modelo = (string)dataRow["Modelo"];
                accesorioDTO.Nombre = (string)dataRow["Nombre"];
                accesorioDTO.Precio = (decimal)dataRow["Precio"];
                accesorioDTO.IdVehiculo = (int)dataRow["IdVehiculo"];
                listaAccesorios.Add(accesorioDTO);
            }
            return listaAccesorios;
        }

        public List<AccesorioDTO> CargarTabla()
        {
            return CargarListaDTOs(HelperDAO.CargarDataTable("SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
            "FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id;"));
        }

        public List<AccesorioDTO> Buscar(string filtro)
        {
            return CargarListaDTOs(HelperDAO.CargarDataTable($"SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
            $"FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id " +
            $"WHERE a.Tipo LIKE '%{filtro}%' or a.Nombre LIKE '%{filtro}%' or a.Precio " +
            $"LIKE '%{filtro}%' or b.Modelo LIKE '%{filtro}%'"));
        }

        public AccesorioDTO CargarTabla(int id)
        {
            return CargarListaDTOs(HelperDAO.CargarDataTable($"SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
                    $"FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id WHERE a.Id={id}"))[0];
        }

        public List<AccesorioDTO> CargarTablaIdVehiculo(int id)
        {
            return CargarListaDTOs(HelperDAO.CargarDataTable($"SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
                    $"FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id WHERE a.IdVehiculo={id}"));
        }

        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Accesorios Where Id={id} ");
        }

        public int ModificarElemento(AccesorioDTO accesorioDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Accesorios SET Nombre='{accesorioDTO.Nombre}', Tipo='{accesorioDTO.Tipo}'," +
                                $" Precio='{accesorioDTO.Precio}', IdVehiculo= '{accesorioDTO.IdVehiculo}' WHERE Id={accesorioDTO.Id}");
        }

        public int AgregarElemento(AccesorioDTO accesorioDTO)
        {
            return HelperDAO.EditarDB($"INSERT INTO Accesorios (Nombre, Tipo, Precio, IdVehiculo)" +
                        $" VALUES ('{accesorioDTO.Nombre}', '{accesorioDTO.Tipo}', '{accesorioDTO.Precio}', '{accesorioDTO.IdVehiculo}')");
        }
    }
  
}
