using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuergoMotors.Negocio
{
    public class HelperNegocio
    {
        public static NumberFormatInfo nfi()
        {
            //Escribe el número con puntos en lugar de comas para no dar error en la DB en los decimal
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            return numberFormatInfo;
        }

        public static int EditarDB(string query)
        {
            try
            {
                return DAO.HelperDAO.EditarDB(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar realizar cambios en la base de datos", ex);
            }
        }

        public static DataTable CargarDataTable(string query)
        {
            try
            {
                return DAO.HelperDAO.CargarDataTable(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los datos desde la base de datos", ex);
            }
        }

    }
}
