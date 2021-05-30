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

        public VentasRDTO CargarDTO(ClientesDTO clienteDTO,VehiculosDTO vehiculoDTO,
            VendedoresDTO vendedorDTO, DateTime fecha,decimal total, string observaciones)
        {
            try
            {
                VentasRDTO ventaDTO = new VentasRDTO();
                ventaDTO.IdCliente = clienteDTO.Id;
                ventaDTO.IdVehiculo = vehiculoDTO.Id;
                ventaDTO.IdVendedor = vendedorDTO.Id;
                ventaDTO.Observaciones = observaciones;
                ventaDTO.Total = total;
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
        
        public void ConfirmarVenta(VentasRDTO venta, List<AccesoriosRDTO> accesorios)
        {
            ventasDAO.ConfirmarVenta(venta, accesorios);
        }
    }
}
