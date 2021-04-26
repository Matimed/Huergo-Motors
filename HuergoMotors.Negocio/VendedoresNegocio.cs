using System;
using System.Collections.Generic;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class VendedoresNegocio
    {
        DAO.VendedoresDAO vendedoresDAO = new DAO.VendedoresDAO();

        //public VendedorDTO BDCargarDTO(int id)
        //{

        //    DataTable dt = CargarTabla(id);

        //    object linea = dt.Rows[0].ItemArray;
        //    try
        //    {
        //        DTO.VendedorDTO vendedorDTO = new DTO.VendedorDTO();
        //        CargarDTO(vendedorDTO, CargarTabla(id));
        //        return vendedorDTO;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public List<VendedorDTO> CargarTabla()
        {
            return vendedoresDAO.CargarListaDTOs(vendedoresDAO.CargarTabla());
        }

        public List<VendedorDTO> CargarTabla(int id)
        {
            return vendedoresDAO.CargarListaDTOs(vendedoresDAO.CargarTabla(id));
        }

        public List<VendedorDTO> Buscar(string filtro)
        {
            return vendedoresDAO.CargarListaDTOs(vendedoresDAO.Buscar(filtro));
        }

        public VendedorDTO CargarDTO(int id, string nombre, string apellido, string sucursal)
        {
            try
            {
                VendedorDTO vendedorDTO = new VendedorDTO();
                HelperNegocio.ValidarTextosVacios(nombre, apellido, sucursal);
                HelperNegocio.ValidarID(id);
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
