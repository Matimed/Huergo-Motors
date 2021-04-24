using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HuergoMotors.Negocio
{
    public class AccesoriosAltaNegocio
    {
       DAO.AccesoriosAltaDAO accesoriosAltaDAO = new DAO.AccesoriosAltaDAO();
        public DataTable CargarTabla(int id)
        {
            return accesoriosAltaDAO.CargarTabla(id);
        }

        public DataTable CargarCombo ()
        {
            return accesoriosAltaDAO.CargarCombo();
        }

        public DTO.AccesorioDTO BDCargarDTO(int id)
        {
            try
            {
                DTO.AccesorioDTO accesorioDTO = new DTO.AccesorioDTO();
                CargarDTO(accesorioDTO, CargarTabla(id).Rows[0].ItemArray);
                return accesorioDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDTO(DTO.AccesorioDTO accesorioDTO, object item)
        {
            try
            {
                accesorioDTO.Precio = HelperNegocio.ConvertirNumeroRacional((string)((DataRow)item)["Precio"]);
                accesorioDTO.Id = (int)((DataRow)item)["IdVehiculo"];
                accesorioDTO.IdVehiculo = (int)((DataRow)item)["IdVehiculo"];
                accesorioDTO.Tipo = (string)((DataRow)item)["Tipo"];
                accesorioDTO.Nombre = (string)((DataRow)item)["Nombre"];
                accesorioDTO.ModeloVehiculo = (string)((DataRow)item)["Modelo"];
            }
           catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDTO(DTO.AccesorioDTO accesorioDTO, int idVehiculo, string modeloVehiuclo, string precio, string nombre, string tipo)
        {
            try
            {
                HelperNegocio.ValidarTextosVacios(modeloVehiuclo, precio, nombre, tipo);
                accesorioDTO.Precio = HelperNegocio.ConvertirNumeroRacional(precio);
                accesorioDTO.IdVehiculo = idVehiculo;
                accesorioDTO.Tipo = tipo;
                accesorioDTO.Nombre = nombre;
                accesorioDTO.ModeloVehiculo = modeloVehiuclo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarElemento(DTO.AccesorioDTO accesorioDTO)
        {
            return accesoriosAltaDAO.ModificarElemento(accesorioDTO);
        }
        
        public int AgregarElemento(DTO.AccesorioDTO accesorioDTO)
        {
            return accesoriosAltaDAO.AgregarElemento(accesorioDTO);
        }
    }
}
