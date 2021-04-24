using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuergoMotors.DAO
{
    public class AccesoriosAltaDAO
    {
        public DataTable CargarTabla(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
                    $"FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id WHERE a.Id={id}");
        }

        public int ModificarElemento(string tipo, string nombre, string precio, int idVehiculo, int id)
        {
            return HelperDAO.EditarDB($"UPDATE Accesorios SET Nombre='{nombre}', Tipo='{tipo}'," +
                                $" Precio='{precio}', IdVehiculo= '{idVehiculo}' WHERE Id={id}");
        }

        public int AgregarElemento(string tipo, string nombre, string precio, int idVehiculo)
        {
            return HelperDAO.EditarDB($"INSERT INTO Accesorios (Nombre, Tipo, Precio, IdVehiculo)" +
                        $" VALUES ('{nombre}', '{tipo}', '{precio}', '{idVehiculo}')");
        }
    }
}
