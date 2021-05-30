using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HuergoMotors.Negocio
{
    public static class HelperNegocio
    {
        
        public static NumberFormatInfo NFI()
        {
            
            return DAO.HelperDAO.NFI();
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
        public static void ValidarID(int id)
        {
            if (id < 0) throw new Exception("Ningun elemento seleccionado");
        }
        public static decimal ConvertirNumeroRacional(string numeroValidar)
        {
            try
            {
                if (!decimal.TryParse(numeroValidar, out decimal numeroRacional) | numeroRacional < 0)
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
                if (!int.TryParse(numeroValidar, out int numeroNatural) | numeroNatural < 0)
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
    }
}
