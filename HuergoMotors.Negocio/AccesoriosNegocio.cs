using System;
using System.Collections.Generic;
using HuergoMotors.DAO;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class AccesoriosNegocio
    {
        AccesoriosDAO accesoriosDAO = new AccesoriosDAO();

        public List<AccesorioDTO> CargarTabla()
        {
            return accesoriosDAO.CargarListaDTOs(accesoriosDAO.CargarTabla());
        }

        public List<AccesorioDTO> Buscar(string filtro)
        {
            return accesoriosDAO.CargarListaDTOs(accesoriosDAO.Buscar(filtro));
        }

        public List<AccesorioDTO> CargarTablaIdVehiculo(int id)
        {
            return accesoriosDAO.CargarTablaIdVehiculo(id);
        }

        public AccesorioDTO CargarTabla(int id)
        {
            return accesoriosDAO.CargarTabla(id);
        }

        public AccesorioDTO CargarDTO(int id, int idVehiculo, string modeloVehiuculo, string precio, string nombre, string tipo)
        {
            try
            {
                AccesorioDTO accesorioDTO = new AccesorioDTO();
                HelperNegocio.ValidarTextosVacios(modeloVehiuculo ,precio, nombre, tipo);
                HelperNegocio.ValidarID(id);
                accesorioDTO.Id = id;
                accesorioDTO.Precio = HelperNegocio.ConvertirNumeroRacional(precio);
                accesorioDTO.IdVehiculo = idVehiculo;
                accesorioDTO.Tipo = tipo;
                accesorioDTO.Nombre = nombre;
                accesorioDTO.Modelo = modeloVehiuculo;
                return accesorioDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarElemento(AccesorioDTO accesorioDTO)
        {
            return accesoriosDAO.ModificarElemento(accesorioDTO);
        }

        public int AgregarElemento(AccesorioDTO accesorioDTO)
        {
            return accesoriosDAO.AgregarElemento(accesorioDTO);
        }

        public int EliminarElemento(int id)
        {
            return accesoriosDAO.EliminarElemento(id);
        }
    }
}

