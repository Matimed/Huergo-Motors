﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HuergoMotors.Negocio
{
    public class ClientesAltaNegocio
    {
        DAO.ClientesAltaDAO clientesAltaDAO = new DAO.ClientesAltaDAO();
        public DataTable CargarTabla(int id)
        {
            return clientesAltaDAO.CargarTabla(id);
        }

        public int ModificarElemento(DTO.ClienteDTO clienteDTO)
        {
            return clientesAltaDAO.ModificarElemento(clienteDTO);
        }

        public int AgregarElemento(DTO.ClienteDTO clienteDTO)
        {
            return clientesAltaDAO.AgregarElemento(clienteDTO);
        }

        public DTO.ClienteDTO BDCargarDTO(int id)
        {
            try
            {
                DTO.ClienteDTO clienteDTO = new DTO.ClienteDTO();
                CargarDTO(clienteDTO, CargarTabla(id).Rows[0].ItemArray);
                return clienteDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDTO(DTO.ClienteDTO clienteDTO, object item)
        {
            try
            {
                clienteDTO.Id = (int)((DataRow)item)["Id"];
                clienteDTO.Nombre = (string)((DataRow)item)["Nombre"];
                clienteDTO.Direccion = (string)((DataRow)item)["Direccion"];
                clienteDTO.Email = (string)((DataRow)item)["Email"];
                clienteDTO.Telefono = (string)((DataRow)item)["Telefono"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarDTO(DTO.ClienteDTO clienteDTO, string nombre, string direccion, string email, string telefono)
        {
            try
            {
                HelperNegocio.ValidarEmail(email);
                HelperNegocio.ValidarTelefono(telefono);
                HelperNegocio.ValidarTextosVacios(direccion, email, nombre, telefono);
                clienteDTO.Direccion = direccion;
                clienteDTO.Email = email;
                clienteDTO.Nombre = nombre;
                clienteDTO.Telefono = telefono;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
