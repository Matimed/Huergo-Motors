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

    }
}
