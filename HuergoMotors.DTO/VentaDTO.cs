using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuergoMotors.DTO
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
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
