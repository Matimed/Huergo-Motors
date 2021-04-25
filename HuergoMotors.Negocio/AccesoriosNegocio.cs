using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HuergoMotors.DAO;

namespace HuergoMotors.Negocio
{
    public class AccesoriosNegocio
    {
        AccesoriosDAO accesoriosDAO = new AccesoriosDAO();
        public DataTable CargarTabla()
        {
            return accesoriosDAO.CargarTabla();
        }

        public int EliminarElemento (int id)
        {
            return accesoriosDAO.EliminarElemento(id);
        }
        public DataTable Buscar(string filtro)
        {
            return accesoriosDAO.Buscar(filtro);
        }

        public DataTable CargarTabla(int id)
        {
            return accesoriosDAO.CargarTabla(id);
        }

        public DataTable CargarCombo()
        {
            return accesoriosDAO.CargarCombo();
        }

        public DTO.AccesorioDTO BDCargarDTO(int id)
        {
            try
            {
                DTO.AccesorioDTO accesorioDTO = new DTO.AccesorioDTO();
                CargarDTO(accesorioDTO, CargarTabla(id));
                return accesorioDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDTO(DTO.AccesorioDTO accesorioDTO, DataTable accesorioDT)
        {
            try
            {
                accesorioDTO.Precio = (decimal)accesorioDT.Rows[0]["Precio"];
                accesorioDTO.Id = (int)accesorioDT.Rows[0]["Id"];
                accesorioDTO.IdVehiculo = (int)accesorioDT.Rows[0]["IdVehiculo"];
                accesorioDTO.Tipo = (string)accesorioDT.Rows[0]["Tipo"];
                accesorioDTO.Nombre = (string)accesorioDT.Rows[0]["Nombre"];
                accesorioDTO.ModeloVehiculo = (string)accesorioDT.Rows[0]["Modelo"];
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
                HelperNegocio.ValidarTextosVacios(modeloVehiuclo ,precio, nombre, tipo);
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
            return accesoriosDAO.ModificarElemento(accesorioDTO);
        }

        public int AgregarElemento(DTO.AccesorioDTO accesorioDTO)
        {
            return accesoriosDAO.AgregarElemento(accesorioDTO);
        }
    }
}

