﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HuergoMotors.Negocio
{
    public class VentasNegocio
    {
        public DataTable dataTableAccesorios;
        public decimal precioTotalAccesorios;


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
        public void ConfirmarVenta(DTO.ClienteDTO clienteDTO, DTO.VehiculoDTO vehiculoDTO,
            DTO.VendedorDTO vendedorDTO, DateTime dateNow, string observaciones, DataTable accesorios)
        {
            try
            {
                try
                {
                    ValidarClienteSeleccionado(clienteDTO);
                    ValidarVehiculoSeleccionado(vehiculoDTO);
                    ValidarVendedorSeleccionado(vendedorDTO);

                    if (vehiculoDTO.Stock < 1) throw new Exception("No hay stock del vehiculo seleccionado");


                    if (dateNow.Date > DateTime.Now.Date) throw new Exception
                            ("La fecha no puede ser posterior a la actual del sistema");


                }
                catch (Exception ex)
                {
                    throw new Exception("Eror al validar los datos: ", ex);
                }
                string fecha = dateNow.ToString("yyyyMMdd");
                ventasDAO.ConfirmarVenta(clienteDTO, vehiculoDTO, vendedorDTO,
                    fecha, observaciones, vehiculoDTO.PrecioVenta.ToString(HelperNegocio.NFI()), accesorios);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        DAO.VentasDAO ventasDAO = new DAO.VentasDAO();
        public DataTable CargarDTVendedor()
        {
            return ventasDAO.CargarDTVendedores();
        }
        public DataTable CargarDTModelo()
        {
            return ventasDAO.CargarDTModelos();
        }
        public DataTable CargarDTAccesorios(int id)
        {
            return ventasDAO.CargarDTAccesorios(id);
        }

 

    }
}