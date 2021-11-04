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
        public List<VentasRDTO> CargarTablaVentasCliente(int id)
        {
            return ventasDAO.CargarTablaVentasCliente(id);
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

        public void ConfirmarVentaAccesorios(VentasDTO venta, List<AccesoriosDTO> accesoriosVenta)
        {
            ventasDAO.ConfirmarVentaAccesorios(venta, accesoriosVenta);
        }
    }
}
