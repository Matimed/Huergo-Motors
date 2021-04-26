using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VentasNegocio
    {
        DAO.VentasDAO ventasDAO = new DAO.VentasDAO();
        public DataTable dataTableAccesorios;
        public decimal precioTotalAccesorios;

        public List<VentaDTO> CargarTablaVentas()
        {
            return ventasDAO.CargarListaDTOs(ventasDAO.CargarTablaVentas());
        }

        public List<VentaDTO> CargarTablaVentasAccesorios(int id)
        {
            return ventasDAO.CargarListaDTOs(ventasDAO.CargarTablaVentasAccesorios(id));
        }

        public List<VentaDTO> Buscar(string filtro)
        {
            return ventasDAO.CargarListaDTOs(ventasDAO.Buscar(filtro));
        }

        public void ValidarClienteSeleccionado(DTO.ClienteDTO clienteDTO)
        {
            if (clienteDTO == null) throw new Exception("Debe seleccionar un cliente");
        }
        public void ValidarVehiculoSeleccionado(DTO.VehiculoDTO vehiculoDTO)
        {
            if (vehiculoDTO == null) throw new Exception("Debe seleccionar un vehiculo");
        }
        public void ValidarVendedorSeleccionado(DTO.VendedorDTO vendedorDTO)
        {
            if (vendedorDTO == null) throw new Exception("Debe seleccionar un vendedor");
        }

        public VentaDTO CargarDTO(ClienteDTO clienteDTO,VehiculoDTO vehiculoDTO,
            VendedorDTO vendedorDTO, DateTime fecha, string observaciones)
        {
            try
            {
                ValidarClienteSeleccionado(clienteDTO);
                ValidarVehiculoSeleccionado(vehiculoDTO);
                ValidarVendedorSeleccionado(vendedorDTO);
                
                if (vehiculoDTO.Stock < 1) throw new Exception("No hay stock del vehiculo seleccionado");


                if (fecha.Date > DateTime.Now.Date) throw new Exception
                        ("La fecha no puede ser posterior a la actual del sistema");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar los datos: ", ex);
            }
            try
            {
                VentaDTO ventaDTO = new VentaDTO();
                ventaDTO.IdCliente = clienteDTO.Id;
                ventaDTO.IdVehiculo = vehiculoDTO.Id;
                ventaDTO.IdVendedor = vendedorDTO.Id;
                ventaDTO.Observaciones = observaciones;
                ventaDTO.Total = vehiculoDTO.PrecioVenta;
                ventaDTO.Cliente = clienteDTO.Nombre;
                ventaDTO.Fecha = fecha.ToString("yyyyMMdd");
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
