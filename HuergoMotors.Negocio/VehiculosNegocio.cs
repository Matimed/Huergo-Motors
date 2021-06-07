using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VehiculosNegocio
    {
        DAO.VehiculosDAO vehiculosDAO = new DAO.VehiculosDAO();

      
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
            vehiculosDAO.Referenciado(id);
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
