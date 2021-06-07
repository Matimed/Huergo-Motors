using HuergoMotors.DTO;
using System;

namespace HuergoMotors.DAO
{
    public class ClientesDAO : DAOBase<ClientesDTO> 
    {
        public void Referenciado(int id)
        {
            if (ReferenciaVentas($"IdCliente = {id}"))
                throw new Exception("No se puede borrar un cliente que tenga ventas asociadas");
        }
    }
}
