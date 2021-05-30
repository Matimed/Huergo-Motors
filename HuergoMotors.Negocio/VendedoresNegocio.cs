using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VendedoresNegocio
    {
        DAO.VendedoresDAO vendedoresDAO = new DAO.VendedoresDAO();

        public List<VendedorDTO> CargarTabla()
        {
            return vendedoresDAO.CargarTabla();
        }

        public List<VendedorDTO> Buscar(string filtro)
        {
            return vendedoresDAO.Buscar(filtro);
        }

        public VendedorDTO CargarDTO(int id, string nombre, string apellido, string sucursal)
        {
            try
            {
                VendedorDTO vendedorDTO = new VendedorDTO();
                vendedorDTO.Id = id;
                vendedorDTO.Apellido = apellido;
                vendedorDTO.Nombre = nombre;
                vendedorDTO.Sucursal = sucursal;
                return vendedorDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EliminarElemento(int id)
        {
            return vendedoresDAO.EliminarElemento(id);
        }

        public int ModificarElemento(VendedorDTO vendedorDTO)
        {
            return vendedoresDAO.ModificarElemento(vendedorDTO);
        }

        public int AgregarElemento(VendedorDTO vendedorDTO)
        {
            return vendedoresDAO.AgregarElementos(vendedorDTO);
        }
    }
}
