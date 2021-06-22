using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HuergoMotors.Web
{
    public static class HelperWeb
    {
        public static int ConvertirNumeroNatural(TextBox textBox)
        {
            try
            {
                if (!int.TryParse(textBox.Text, out int numeroNatural) | numeroNatural < 0)
                {
                    throw new Exception($"Tipo de dato inválido. Se esperaba un numero entero.");
                }
                return numeroNatural;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal ConvertirNumeroRacional(TextBox textBox)
        {
            try
            {
                if (!decimal.TryParse(textBox.Text, out decimal numeroRacional) | numeroRacional < 0)
                {
                    throw new Exception($"Tipo de dato inválido. Se esperaba un numero racional.");
                }
                return numeroRacional;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}