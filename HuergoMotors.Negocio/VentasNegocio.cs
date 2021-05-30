using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VentasNegocio
    {
        DAO.VentasDAO ventasDAO = new DAO.VentasDAO();
        public decimal precioTotalAccesorios;

        public List<VentaDTO> CargarTablaVentas()
        {
            return ventasDAO.CargarTablaVentas();
        }

        public List<VentaAccesorioDTO> CargarTablaVentasAccesorios(int id)
        {
            return ventasDAO.CargarTablaVentasAccesorios(id);
        }

        public List<VentaDTO> Buscar(string filtro)
        {
            return ventasDAO.Buscar(filtro);
        }

        public VentaDTO CargarDTO(ClienteDTO clienteDTO,VehiculoDTO vehiculoDTO,
            VendedorDTO vendedorDTO, DateTime fecha, string observaciones)
        {
            try
            {
                VentaDTO ventaDTO = new VentaDTO();
                ventaDTO.IdCliente = clienteDTO.Id;
                ventaDTO.IdVehiculo = vehiculoDTO.Id;
                ventaDTO.IdVendedor = vendedorDTO.Id;
                ventaDTO.Observaciones = observaciones;
                ventaDTO.Total = vehiculoDTO.PrecioVenta;
                ventaDTO.Cliente = clienteDTO.Nombre;
                ventaDTO.Fecha = fecha;
                ventaDTO.Vehiculo = vehiculoDTO.Modelo;
                ventaDTO.Vendedor = vendedorDTO.NombreCompleto;
                return ventaDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ConfirmarVenta(VentaDTO venta, List<AccesorioDTO> accesorios)
        {
            ventasDAO.ConfirmarVenta(venta, accesorios);
        }
    }
}
