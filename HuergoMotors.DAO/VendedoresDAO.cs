using HuergoMotors.DTO;
using System;

namespace HuergoMotors.DAO
{
    public class VendedoresDAO : DAOBase<VendedoresDTO>  
    {
        public void Referenciado(int id)
        {
            if (ReferenciaVentas($"IdVendedor = {id}"))
                throw new Exception("No se puede borrar un vendedor que tenga ventas asociadas");
        }
    }
}
