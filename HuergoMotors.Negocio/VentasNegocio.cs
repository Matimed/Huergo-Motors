using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VentasNegocio
    {
        DAO.VentasDAO ventasDAO = new DAO.VentasDAO();
        public decimal precioTotalAccesorios;

        public List<VentasDTO> CargarTablaVentas()
        {
            return ventasDAO.CargarTablaVentas();
        }

        public List<VentasAccesoriosDTO> CargarTablaVentasAccesorios(int id)
        {
            return ventasDAO.CargarTablaVentasAccesorios(id);
        }

        public List<VentasDTO> Buscar(string filtro)
        {
            return ventasDAO.Buscar(filtro);
        }

        public VentasDTO CargarDTO(ClientesDTO clienteDTO,VehiculosDTO vehiculoDTO,
            VendedoresDTO vendedorDTO, DateTime fecha, string observaciones)
        {
            try
            {
                VentasDTO ventaDTO = new VentasDTO();
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
        
        public void ConfirmarVenta(VentasDTO venta, List<AccesoriosDTO> accesorios)
        {
            ventasDAO.ConfirmarVenta(venta, accesorios);
        }
    }
}
