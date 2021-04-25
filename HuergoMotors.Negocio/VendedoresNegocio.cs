using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HuergoMotors.Negocio
{
    public class VendedoresNegocio
    {
        DAO.VendedoresDAO vendedoresDAO = new DAO.VendedoresDAO();

        public DataTable CargarTabla()
        {
            return vendedoresDAO.CargarTabla();
        }
        public DataTable CargarTabla(int id)
        {
            return vendedoresDAO.CargarTabla(id);
        }
        public int EliminarElemento(int id)
        {
            return vendedoresDAO.EliminarElemento(id);
        }
        public DataTable Buscar(string filtro)
        {
            return vendedoresDAO.Buscar(filtro);
        }


        public DTO.VendedorDTO BDCargarDTO(int id)
        {

            DataTable dt = CargarTabla(id);

            object linea = dt.Rows[0].ItemArray;
            try
            {
                DTO.VendedorDTO vendedorDTO = new DTO.VendedorDTO();
                CargarDTO(vendedorDTO, CargarTabla(id).Rows[0].ItemArray);
                return vendedorDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public void CargarDTO(DTO.VendedorDTO vendedorDTO, object item)
        {
            try
            {
                vendedorDTO.Id = (int)((DataRow)item)["Id"];
                vendedorDTO.Nombre = (string)((DataRow)item)["Nombre"];
                vendedorDTO.Apellido = (string)((DataRow)item)["Apellido"];
                vendedorDTO.Sucursal = (string)((DataRow)item)["Sucursal"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarDTO(DTO.VendedorDTO vendedorDTO, string nombre, string apellido, string sucursal)
        {
            try
            {
                HelperNegocio.ValidarTextosVacios(nombre, apellido, sucursal);
                vendedorDTO.Apellido = apellido;
                vendedorDTO.Nombre = nombre;
                vendedorDTO.Sucursal = sucursal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarElemento(DTO.VendedorDTO vendedorDTO)
        {
            return vendedoresDAO.ModificarElemento(vendedorDTO);
        }
        public int AgregarElemento(DTO.VendedorDTO vendedorDTO)
        {
            return vendedoresDAO.AgregarElementos(vendedorDTO);
        }
    }
}
