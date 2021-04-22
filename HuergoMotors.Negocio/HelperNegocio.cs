using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuergoMotors.Negocio
{
    class HelperNegocio
    {
        public static NumberFormatInfo nfi()
        {
            //Escribe el número con puntos en lugar de comas para no dar error en la DB en los decimal
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            return numberFormatInfo;
        }

        public enum Modo
        {
            Agregar,
            Modificar,
            Eliminar
        }
    }
}
