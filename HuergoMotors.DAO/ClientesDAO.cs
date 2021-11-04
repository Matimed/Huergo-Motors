using HuergoMotors.DTO;
using System;
using System.Collections.Generic;

namespace HuergoMotors.DAO
{
    public class ClientesDAO : DAOBase<ClientesDTO> 
    {
        public new void Referenciado(int id)
        {
            if (ReferenciaVentas($"IdCliente = {id}"))
                throw new Exception("No se puede borrar un cliente que tenga ventas asociadas");
        }
        public ClientesDTO BuscarCliente(string email, string clave)
        {
            List<ClientesDTO> clientes = GenerearListaDTOs($"SELECT * FROM Clientes WHERE Email = '{email}' AND Clave = '{clave}'");
            if (clientes.Count == 1) { return clientes[0]; }
            else { return null; }
        }


    }
}
