using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuergoMotors.DTO
{
    public class AccesorioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public double Precio { get; set; }
        public int IdVehiculo { get; set; }
    }
}
