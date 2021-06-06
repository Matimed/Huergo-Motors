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

        public List<AccesoriosDTO> BuscarIdVehiculo(int id)
        {
            return accesoriosDAO.BuscarIdVehiculo(id);
        }

        public AccesoriosDTO BuscarId(int id)
        {
            return accesoriosDAO.BuscarId(id);
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

