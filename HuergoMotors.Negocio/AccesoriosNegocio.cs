using System;
using System.Collections.Generic;
using HuergoMotors.DAO;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class AccesoriosNegocio
    {
        AccesoriosDAO accesoriosDAO = new AccesoriosDAO();

        public List<AccesoriosDTO> CargarTabla()
        {
            return accesoriosDAO.CargarTabla();
        }

        public List<AccesoriosDTO> Buscar(string filtro)
        {
            return accesoriosDAO.Buscar(filtro);
        }

        public List<AccesoriosDTO> CargarTablaIdVehiculo(int id)
        {
            return accesoriosDAO.CargarTablaIdVehiculo(id);
        }

        public AccesoriosDTO CargarTabla(int id)
        {
            return accesoriosDAO.CargarTabla(id);
        }

        public AccesoriosDTO CargarDTO(int id, int idVehiculo, string modeloVehiuculo, decimal precio, string nombre, string tipo)
        {
            try
            {
                AccesoriosDTO accesorioDTO = new AccesoriosDTO();
                accesorioDTO.Id = id;
                accesorioDTO.Precio = precio;
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

        public int ModificarElemento(AccesoriosDTO accesorioDTO)
        {
            return accesoriosDAO.ModificarElemento(accesorioDTO);
        }

        public int AgregarElemento(AccesoriosDTO accesorioDTO)
        {
            return accesoriosDAO.AgregarElemento(accesorioDTO);
        }

        public int EliminarElemento(int id)
        {
            return accesoriosDAO.EliminarElemento(id);
        }
    }
}

