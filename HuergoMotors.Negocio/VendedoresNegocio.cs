using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VendedoresNegocio
    {
        DAO.VendedoresDAO vendedoresDAO = new DAO.VendedoresDAO();

        public List<VendedoresDTO> CargarTabla()
        {
            return vendedoresDAO.CargarDatos();
        }

        public List<VendedoresDTO> Buscar(string filtro)
        {
            return vendedoresDAO.Buscar(filtro);
        }

        public VendedoresDTO CargarDTO(int id, string nombre, string apellido, string sucursal)
        {
            try
            {
                VendedoresDTO vendedorDTO = new VendedoresDTO();
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

        public int ModificarElemento(VendedoresDTO vendedorDTO)
        {
            return vendedoresDAO.ModificarElemento(vendedorDTO);
        }

        public int AgregarElemento(VendedoresDTO vendedorDTO)
        {
            return vendedoresDAO.AgregarElementos(vendedorDTO);
        }
    }
}
