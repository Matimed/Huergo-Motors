using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HuergoMotors.DAO;
using HuergoMotors.DTO;

namespace HuergoMotors.Negocio
{
    public class AccesoriosNegocio
    {
        AccesoriosDAO accesoriosDAO = new AccesoriosDAO();
        public List<AccesorioDTO> CargarTabla()
        {
            return accesoriosDAO.CargarListaDTOs(accesoriosDAO.CargarTabla());
        }

        public List<AccesorioDTO> Buscar(string filtro)
        {
            return accesoriosDAO.CargarListaDTOs(accesoriosDAO.Buscar(filtro));
        }

        public List<AccesorioDTO> CargarTabla(int id)
        {
            return accesoriosDAO.CargarListaDTOs(accesoriosDAO.CargarTabla(id));
        }

        public List<AccesorioDTO> CargarCombo()
        {
            return accesoriosDAO.CargarListaDTOs(accesoriosDAO.CargarCombo());
        }

        public void CargarDTO(AccesorioDTO accesorioDTO, int idVehiculo, string modeloVehiuclo, string precio, string nombre, string tipo)
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

        public int EliminarElemento(int id)
        {
            return accesoriosDAO.EliminarElemento(id);
        }
    }
}

