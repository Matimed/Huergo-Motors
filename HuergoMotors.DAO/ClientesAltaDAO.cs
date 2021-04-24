using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuergoMotors.DAO
{
     public class ClientesAltaDAO
    {
        public DataTable CargarTabla(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT * FROM Clientes WHERE Id={id}");
        }

        public int ModificarElemento(string nombre,string direccion , string email, string telefono ,int id )
        {
            return HelperDAO.EditarDB($"UPDATE Clientes SET Nombre='{nombre}', Direccion='{direccion}', " +
                                $"Email='{email}', Telefono='{telefono}' WHERE Id={id}");
        }

        public int AgregarElemento(string nombre, string direccion, string email, string telefono)
        {
            return HelperDAO.EditarDB($"INSERT INTO Clientes (Nombre, Direccion, Email, Telefono) " +
                        $"VALUES ('{nombre}', '{direccion}', '{email}', '{telefono}')");
        }

    }
}
