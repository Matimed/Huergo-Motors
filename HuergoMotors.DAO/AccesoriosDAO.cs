using System.Collections.Generic;
using System.Data;
using HuergoMotors.DTO;

namespace HuergoMotors.DAO
{
    public class AccesoriosDAO
    {
        HelperDAO helperDAO = new HelperDAO();
        public static string Campos = "a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo";
        public static string Tablas = "Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id";

        public List<AccesoriosRDTO> CargarTabla()
        {
            return helperDAO.CargarDatos<AccesoriosRDTO>(Campos, Tablas);
        }
        public AccesoriosDTO CargarTabla(int id)
        {
            return helperDAO.CargarDatos<AccesoriosDTO>($"Id={id}")[0];
        }

        public List<AccesoriosDTO> CargarTablaIdVehiculo(int id)
        {
            return helperDAO.CargarDatos<AccesoriosDTO>($"IdVehiculo={id}");
        }
        public List<AccesoriosRDTO> Buscar(string filtro)
        {
            return helperDAO.CargarDatos<AccesoriosRDTO>(Campos, Tablas,
                $"a.Tipo LIKE '%{filtro}%' OR a.Nombre LIKE '%{filtro}%' OR a.Precio LIKE '%{filtro}%' OR b.Modelo LIKE '%{filtro}%'");
        }

        public int EliminarElemento(int id)
        {
            return helperDAO.EliminarElemento<AccesoriosDTO>(id);
        }

        public int ModificarElemento(AccesoriosDTO accesorioDTO)
        {
            return HelperDAO.EditarDB($"UPDATE Accesorios SET Nombre='{accesorioDTO.Nombre}', Tipo='{accesorioDTO.Tipo}'," +
                                $" Precio='{accesorioDTO.Precio.ToString(HelperDAO.NFI())}', IdVehiculo= '{accesorioDTO.IdVehiculo}' WHERE Id={accesorioDTO.Id}");
        }
        public int AgregarElemento(AccesoriosDTO accesorioDTO)
        {
            return helperDAO.AgregarElemento(accesorioDTO);
            //return HelperDAO.EditarDB($"INSERT INTO Accesorios (Nombre, Tipo, Precio, IdVehiculo)" +
            //            $" VALUES ('{accesorioDTO.Nombre}', '{accesorioDTO.Tipo}', '{accesorioDTO.Precio}', '{accesorioDTO.IdVehiculo}')");
        }
    }
  
}
