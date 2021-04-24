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
                DataTable dt = CargarTabla(id);
                CargarDTO(accesorioDTO, dt);
                return accesorioDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDTO(DTO.AccesorioDTO accesorioDTO, DataTable dt)
        {
            try
            {
                HelperNegocio.ValidarTextosVacios(dt, "Tipo", "Nombre", "Precio", "Modelo", "Id", "IdVehiulo");
                accesorioDTO.Precio = HelperNegocio.ConvertirNumeroRacional((string)dt.Rows[0]["Precio"]);
                accesorioDTO.Id = (int)dt.Rows[0]["IdVehiculo"];
                accesorioDTO.IdVehiculo = (int)dt.Rows[0]["IdVehiculo"];
                accesorioDTO.Tipo = (string)dt.Rows[0]["Tipo"];
                accesorioDTO.Nombre = (string)dt.Rows[0]["Nombre"];
                accesorioDTO.ModeloVehiculo = (string)dt.Rows[0]["Modelo"];
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
