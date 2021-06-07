using HuergoMotors.DTO;
using System;

namespace HuergoMotors.DAO
{
    public class VehiculosDAO : DAOBase<VehiculosDTO> 
    {
        AccesoriosDAO accesoriosDAO = new   AccesoriosDAO();
        public void Referenciado(int id)
        {
            if (accesoriosDAO.BuscarIdVehiculo(id).Count > 0)
                throw new Exception("No se puede borrar un vehiculo que tenga accesorios");

            if (ReferenciaVentas($"IdVehiculo = {id}"))
                throw new Exception("No se puede borrar un vehiculo que tenga ventas asociadas");
        }
    }
}
