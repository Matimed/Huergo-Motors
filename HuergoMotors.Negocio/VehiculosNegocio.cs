using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VehiculosNegocio
    {
        DAO.VehiculosDAO vehiculosDAO = new DAO.VehiculosDAO();
        AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();
        public VehiculoDTO CargarDTO(int id, string modelo, string precio, string stock, string tipo)
        {
            try
            {
                VehiculoDTO vehiculoDTO = new VehiculoDTO();
                vehiculoDTO.Id = id;
                vehiculoDTO.PrecioVenta = HelperNegocio.ConvertirNumeroRacional(precio);
                vehiculoDTO.Stock = HelperNegocio.ConvertirNumeroNatural(stock);
                vehiculoDTO.Tipo = tipo;
                vehiculoDTO.Modelo = modelo;
                return vehiculoDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VehiculoDTO CargarTabla(int id)
        {
            return vehiculosDAO.CargarTabla(id);
        }

        public List<VehiculoDTO> CargarTabla()
        {
            return vehiculosDAO.CargarTabla();
        }

        public List<VehiculoDTO> Buscar(string filtro)
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

        public int ModificarElemento(VehiculoDTO vehiculoDTO)
        {
            return vehiculosDAO.ModificarElemento(vehiculoDTO);
        }

        public int AgregarElemento(VehiculoDTO vehiculoDTO)
        {
            return vehiculosDAO.AgregarElemento(vehiculoDTO);
        }
    }
}
