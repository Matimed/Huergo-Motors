using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HuergoMotors.Negocio
{
    public static class HelperNegocio
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

        public static void ValidarTextosVacios(params string[] textosValidar)
        {
            try
            {
                foreach (string textoValidar in textosValidar)
                {
                    if (string.IsNullOrEmpty(textoValidar))
                    {
                        throw new Exception("No se pueden dejar campos sin completar");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ValidarTextosVacios(DataTable dt, params string[] campos)
        {
            try
            {
                foreach (string campo in campos)
                {
                    if (dt.Rows[0].IsNull(campo))
                    {
                        throw new Exception("Error al Validar DataTable. Se encontraron campos vácios");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static decimal ConvertirNumeroRacional(string numeroValidar)
        {
            try
            {
                decimal numeroRacional;
                if (!decimal.TryParse(numeroValidar, out numeroRacional) | numeroRacional < 0)
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
        public static int ConvertirNumeroNatural(string numeroValidar)
        {
            try
            {
                int numeroNatural;
                if (!int.TryParse(numeroValidar, out numeroNatural) | numeroNatural < 0)
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

        public static void ValidarEmail(string email)
        {
            try
            {
                string rgxEmail = @"\A(?:[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'+/=?^_`{|}~-]+)@(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                if (!Regex.IsMatch(email, rgxEmail)) throw new Exception("Email Invalido");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ValidarTelefono(string telefono)
        {
            try
            {
                string rgxTelefono = @"^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$";
                if (!Regex.IsMatch(telefono, rgxTelefono)) throw new Exception("Telefono Invalido");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable LeerCombo(int id, string campo, string tabla)
        {
            try
            {
                return DAO.HelperDAO.LeerCombo(id, campo, tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un ComboBox", ex);
            }
        }

        public static string LeerDatoCombo(DataTable dataTable, string campo)
        {
            try
            {
                return (string)dataTable.Rows[0][campo];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un dato del ComboBox", ex);
            }
        }

        public static int LeerNumeroCombo(DataTable dataTable, string campo)
        {
            try
            {
                return (int)dataTable.Rows[0][campo];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un numero del ComboBox", ex);
            }
        }
    }
}
