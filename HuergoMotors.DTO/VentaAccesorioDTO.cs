using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuergoMotors.DTO
{
    public class VentaAccesorioDTO
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdAccesorio { get; set; }
        public double Precio { get; set; }
    }
}
