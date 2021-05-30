using System;
using System.Collections.Generic;
using HuergoMotors.DAO;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class AccesoriosNegocio
    {
        AccesoriosDAO accesoriosDAO = new AccesoriosDAO();

        public List<AccesoriosRDTO> CargarTabla()
        {
            return accesoriosDAO.CargarTabla();
        }

        public List<AccesoriosRDTO> Buscar(string filtro)
        {
            return accesoriosDAO.Buscar(filtro);
        }

        public List<AccesoriosRDTO> CargarTablaIdVehiculo(int id)
        {
            return accesoriosDAO.CargarTablaIdVehiculo(id);
        }

        public AccesoriosRDTO CargarTabla(int id)
        {
            return accesoriosDAO.CargarTabla(id);
        }

        public AccesoriosRDTO CargarDTO(int id, int idVehiculo, string modeloVehiuculo, decimal precio, string nombre, string tipo)
        {
            try
            {
                AccesoriosRDTO accesorioDTO = new AccesoriosRDTO();
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

        public int ModificarElemento(AccesoriosRDTO accesorioDTO)
        {
            return accesoriosDAO.ModificarElemento(accesorioDTO);
        }

        public int AgregarElemento(AccesoriosRDTO accesorioDTO)
        {
            return accesoriosDAO.AgregarElemento(accesorioDTO);
        }

        public int EliminarElemento(int id)
        {
            return accesoriosDAO.EliminarElemento(id);
        }
    }
}

