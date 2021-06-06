using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VehiculosNegocio
    {
        DAO.VehiculosDAO vehiculosDAO = new DAO.VehiculosDAO();
        AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();
      
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
                if (accesoriosNegocio.BuscarIdVehiculo(id).Count > 0)
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
