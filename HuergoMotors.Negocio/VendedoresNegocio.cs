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

       
        public int EliminarElemento(int id)
        {
            vendedoresDAO.Referenciado(id);
            return vendedoresDAO.EliminarElemento(id);
        }

        public int ModificarElemento(VendedoresDTO vendedorDTO)
        {
            return vendedoresDAO.ModificarElemento(vendedorDTO);
        }

        public int AgregarElemento(VendedoresDTO vendedorDTO)
        {
            return vendedoresDAO.AgregarElemento(vendedorDTO);
        }
    }
}
