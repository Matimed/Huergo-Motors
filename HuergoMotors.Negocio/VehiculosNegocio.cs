using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VehiculosNegocio
    {
        DAO.VehiculosDAO vehiculosDAO = new DAO.VehiculosDAO();
        AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();
        public VehiculosDTO CargarDTO(int id, string modelo, decimal precio, int stock, string tipo)
        {
            try
            {
                VehiculosDTO vehiculoDTO = new VehiculosDTO();
                vehiculoDTO.Id = id;
                vehiculoDTO.PrecioVenta = precio;
                vehiculoDTO.Stock = stock;
                vehiculoDTO.Tipo = tipo;
                vehiculoDTO.Modelo = modelo;
                return vehiculoDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VehiculosDTO BuscarId(int id)
        {
            return vehiculosDAO.BuscarId(id);
        }

        public List<VehiculosDTO> CargarTabla()
        {
            return vehiculosDAO.CargarDatos();
        }

        public List<VehiculosDTO> Buscar(string filtro)
        {
            return vehiculosDAO.Buscar(filtro);
        }

        public int EliminarElemento(int id)
        {
            try
            {
                if (accesoriosNegocio.CargarTablaIdVehiculo(id).Count > 0)
                    throw new Exception("No se puede borrar un vehiculo que tenga accesorios");
            }
            catch (Exception ex)
            {
                throw ex;
            }
                return vehiculosDAO.EliminarElemento(id);
        }

        public int ModificarElemento(VehiculosDTO vehiculoDTO)
        {
            return vehiculosDAO.ModificarElemento(vehiculoDTO);
        }

        public int AgregarElemento(VehiculosDTO vehiculoDTO)
        {
            return vehiculosDAO.AgregarElemento(vehiculoDTO);
        }
    }
}
