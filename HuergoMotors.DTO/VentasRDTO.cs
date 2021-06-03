using System;

namespace HuergoMotors.DTO
{
    public class VentasRDTO : DTOBase
    {
        public DateTime Fecha { get; set; }
        public int IdVehiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public string Observaciones { get; set; }
        public decimal Total { get; set; }
        public string Vehiculo { get; set; }
        public string Cliente { get; set; }
        public string Vendedor { get; set; }
    }
}
