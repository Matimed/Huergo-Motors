﻿using System;

namespace HuergoMotors.DTO
{
    public class VentasDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdVehiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public string Observaciones { get; set; }
        public decimal Total { get; set; }
    }
}
