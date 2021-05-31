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

        public VentasDTO CargarDTO(int idCliente,int idVehiculo,
            int idVendedor, DateTime fecha,decimal total, string observaciones)
        {
            try
            {
                VentasDTO ventaDTO = new VentasDTO();
                ventaDTO.IdCliente = idCliente;
                ventaDTO.IdVehiculo = idVehiculo;
                ventaDTO.IdVendedor = idVendedor;
                ventaDTO.Observaciones = observaciones;
                ventaDTO.Total = total;
                ventaDTO.Fecha = fecha;
                return ventaDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ConfirmarVenta(VentasDTO venta, List<AccesoriosDTO> accesorios)
        {
            ventasDAO.ConfirmarVenta(venta, accesorios);
        }
    }
}
