using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VentasNegocio
    {
        DAO.VentasDAO ventasDAO = new DAO.VentasDAO();
        public decimal precioTotalAccesorios;

        public List<VentasRDTO> CargarTablaVentas()
        {
            return ventasDAO.CargarTablaVentas();
        }

        public List<VentasAccesoriosRDTO> CargarTablaVentasAccesorios(int id)
        {
            return ventasDAO.CargarTablaVentasAccesorios(id);
        }

        public List<VentasRDTO> Buscar(string filtro)
        {
            return ventasDAO.Buscar(filtro);
        }

       
        
        public void ConfirmarVenta(VentasDTO venta, List<AccesoriosDTO> accesorios)
        {
            ventasDAO.ConfirmarVenta(venta, accesorios);
        }
    }
}
