using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuergoMotors.DTO
{
    class VehiculoDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
    }
}
