using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HuergoMotors.Negocio
{
    public class AccesoriosAltaNegocio
    {
        AccesoriosAltaNegocio accesoriosAltaNegocio = new AccesoriosAltaNegocio();
        public DataTable CaragarTabla(int id)
        {
            return accesoriosAltaNegocio.CaragarTabla(id);
        }

        public void CargarDTO(DataTable dt, DTO.AccesorioDTO accesorioDTO)
        {
            if (!dt.Rows[0].IsNull("Tipo")) accesorioDTO.Tipo = (string)dt.Rows[0]["Tipo"];
            if (!dt.Rows[0].IsNull("Nombre")) accesorioDTO.Nombre = (string)dt.Rows[0]["Nombre"];
            if (!dt.Rows[0].IsNull("Precio")) accesorioDTO.Precio = (decimal)dt.Rows[0]["Precio"];
            if (!dt.Rows[0].IsNull("Modelo")) accesorioDTO.ModeloVehiculo = (string)dt.Rows[0]["Modelo"];
        }
    }
}
