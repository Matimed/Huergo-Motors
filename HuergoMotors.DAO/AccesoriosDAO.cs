using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HuergoMotors.DAO
{
    public class AccesoriosDAO
    {
         
        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
            "FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id;");
        }


        public int EliminarElemento(int id)
        {
            return HelperDAO.EditarDB($"DELETE FROM Accesorios Where Id={id} ");
        }

        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
            $"FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id " +
            $"WHERE a.Tipo LIKE '%{filtro}%' or a.Nombre LIKE '%{filtro}%' or a.Precio " +
            $"LIKE '%{filtro}%' or b.Modelo LIKE '%{filtro}%'");
        }

        public DataTable CargarTabla(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
                    $"FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id WHERE a.Id={id}");
        }


        public DataTable CargarCombo()
        {
            return HelperDAO.CargarDataTable("SELECT Id, Modelo FROM Vehiculos");
        }

        public int ModificarElemento(DTO.AccesorioDTO accesorioDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Accesorios SET Nombre='{accesorioDTO.Nombre}', Tipo='{accesorioDTO.Tipo}'," +
                                $" Precio='{accesorioDTO.Precio}', IdVehiculo= '{accesorioDTO.IdVehiculo}' WHERE Id={accesorioDTO.Id}");
        }

        public int AgregarElemento(DTO.AccesorioDTO accesorioDTO)
        {
            return HelperDAO.EditarDB($"INSERT INTO Accesorios (Nombre, Tipo, Precio, IdVehiculo)" +
                        $" VALUES ('{accesorioDTO.Nombre}', '{accesorioDTO.Tipo}', '{accesorioDTO.Precio}', '{accesorioDTO.IdVehiculo}')");
        }
    }
  
}
