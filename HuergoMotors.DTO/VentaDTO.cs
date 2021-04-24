using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuergoMotors.DTO
{
    class VentaDTO
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public int IdVehiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public string Ovservaciones { get; set; }
        public double Total { get; set; }
    }
}
