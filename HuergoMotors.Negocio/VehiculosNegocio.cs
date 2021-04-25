using System;
using System.Collections.Generic;
using System.Data;
using HuergoMotors.DTO;
using System.Linq;
using System.Text;


namespace HuergoMotors.Negocio
{
    public class VehiculosNegocio
    {
        DAO.VehiculosDAO vehiculosDAO = new DAO.VehiculosDAO();

        public void CargarDTO(int id, string modelo, string precio, string stock, string tipo)
        {
            try
            {
                VehiculoDTO vehiculoDTO = new VehiculoDTO();
                HelperNegocio.ValidarTextosVacios(modelo, precio, stock, tipo);
                HelperNegocio.ValidarID(id);
                vehiculoDTO.Id = id;
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

        public List<VehiculoDTO> CargarTabla()
        {
            return vehiculosDAO.CargarListaDTOs(vehiculosDAO.CargarTabla());
        }

        public VehiculoDTO CargarTabla(int id)
        {
            return vehiculosDAO.CargarListaDTOs(vehiculosDAO.CargarTabla(id))[0];
        }

        public List<VehiculoDTO> Buscar(string filtro)
        {
            return vehiculosDAO.CargarListaDTOs(vehiculosDAO.Buscar(filtro));
        }

        public int EliminarElemento(int id)
        {
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
