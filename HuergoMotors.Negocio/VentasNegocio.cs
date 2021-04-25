using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HuergoMotors.Negocio
{
    public class VentasNegocio
    {
        DAO.VentasDAO ventasDAO = new DAO.VentasDAO();
        public DataTable CargarDTVendedor()
        {
            return ventasDAO.CargarDTVendedores();
        }
        public DataTable CargarDTModelo()
        {
            return ventasDAO.CargarDTModelos();
        }
        public DataTable CargarDTAccesorios(int id)
        {
            return ventasDAO.CargarDTAccesorios(id);
        }

        public DataTable ToDataTable (DTO.AccesorioDTO accesorioDTO)
        {
            DataTable dataTable;
            
        }

    }
}
