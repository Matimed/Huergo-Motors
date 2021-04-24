using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HuergoMotors.Negocio
{
    public class VehiculosNegocio
    {
        DAO.VehiculosDAO vehiculosDAO = new DAO.VehiculosDAO();
        public DataTable CargarTabla()
        {
            return vehiculosDAO.CargarTabla();
        }

        public int EliminarElemento(int id)
        {
            return vehiculosDAO.EliminarElemento(id);
        }

        public DataTable Buscar(string filtro)
        {
            return vehiculosDAO.Buscar(filtro);
        }

        public DataTable CargarTabla(int id)
        {
            return vehiculosDAO.CargarTabla(id);
        }

        public int ModificarElemento(DTO.VehiculoDTO vehiculoDTO)
        {
            return vehiculosDAO.ModificarElemento(vehiculoDTO);
        }

        public int AgregarElemento(DTO.VehiculoDTO vehiculoDTO)
        {
            return vehiculosDAO.AgregarElemento(vehiculoDTO);
        }

        public DTO.VehiculoDTO BDCargarDTO(int id)
        {
            try
            {
                DTO.VehiculoDTO vehiculoDTO = new DTO.VehiculoDTO();
                CargarDTO(vehiculoDTO, CargarTabla(id).Rows[0].ItemArray);
                return vehiculoDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDTO(DTO.VehiculoDTO vehiculoDTO, object item)
        {
            try
            {
                vehiculoDTO.Id = (int)((DataRow)item)["Id"];
                vehiculoDTO.Tipo = (string)((DataRow)item)["Tipo"];
                vehiculoDTO.Modelo = (string)((DataRow)item)["Modelo"];
                vehiculoDTO.PrecioVenta = (decimal)((DataRow)item)["PrecioVenta"];
                vehiculoDTO.Stock = (int)((DataRow)item)["Stock"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDTO(DTO.VehiculoDTO vehiculoDTO, string modelo, string precio, string stock, string tipo)
        {
            try
            {
                HelperNegocio.ValidarTextosVacios(modelo, precio, stock, tipo);
                vehiculoDTO.PrecioVenta = HelperNegocio.ConvertirNumeroRacional(precio);
                vehiculoDTO.Stock = HelperNegocio.ConvertirNumeroNatural(stock);
                vehiculoDTO.Tipo = tipo;
                vehiculoDTO.Modelo = modelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
