using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuergoMotors.Negocio
{
    public class ClienteNegocio
    {
        public static void ValidarTextosVacios(TextBox textbox1, TextBox textbox2,
        TextBox textbox3, TextBox textbox4, TextBox textbox5, TextBox textbox6)
        {
            try
            {
                if (string.IsNullOrEmpty(textbox1.Text) | string.IsNullOrEmpty(textbox2.Text) | string.IsNullOrEmpty(textbox3.Text) |
                    string.IsNullOrEmpty(textbox4.Text) | string.IsNullOrEmpty(textbox5.Text) | string.IsNullOrEmpty(textbox6.Text))
                {
                    throw new Exception("No se pueden dejar campos sin completar");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // NEGOCIO
        }
        public static void ValidarTextosVacios(TextBox textbox1, TextBox textbox2, TextBox textbox3, TextBox textbox4)
        {
            try
            {
                if (string.IsNullOrEmpty(textbox1.Text) | string.IsNullOrEmpty(textbox2.Text) | string.IsNullOrEmpty(textbox3.Text) | string.IsNullOrEmpty(textbox4.Text))
                {
                    throw new Exception("No se pueden dejar campos sin completar");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // NEGOCIO
        }

        public static void ValidarTextosVacios(TextBox textbox1, TextBox textbox2, TextBox textbox3)
        {
            try
            {
                if (string.IsNullOrEmpty(textbox1.Text) | string.IsNullOrEmpty(textbox2.Text) | string.IsNullOrEmpty(textbox3.Text))
                {
                    throw new Exception("No se pueden dejar campos sin completar");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // NEGOCIO
        }
        public static bool VerificarCombosCargados(ComboBox combo)
        {
            try
            {
                if (string.IsNullOrEmpty(combo.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los combos", ex);
            }
            // NEGOCIO
        }

        public static void ValidarNumerosRacionales(TextBox textbox1)
        {
            try
            {
                double numero;
                if (!double.TryParse(textbox1.Text, out numero) | numero < 0)
                {
                    throw new Exception($"Tipo de dato inválido. Se esperaba un numero racional en {textbox1.Text}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // NEGOCIO
        }

        public static void ValidarNumerosNaturales(TextBox textbox1)
        {
            try
            {
                int numero;
                if (!int.TryParse(textbox1.Text, out numero) | numero < 0)
                {
                    throw new Exception($"Tipo de dato inválido. Se esperaba un numero entero en {textbox1.Text}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // NEGOCIO
        }
        public static System.Data.DataTable LeerCombo(ComboBox combo, string campo, string tabla)
        {
            try
            {
                int id = (int)combo.SelectedValue;
                DataTable dt = CargarDataTable($"SELECT {campo} FROM {tabla} WHERE ID = {id}");
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un ComboBox", ex);
            }
            // NEGOCIO
        }

        public static string LeerDatoCombo(ComboBox combo, string campo, string tabla)
        {
            try
            {
                DataTable dt = LeerCombo(combo, campo, tabla);
                string result = (string)dt.Rows[0][campo];
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un dato del ComboBox", ex);
            }
            // NEGOCIO
        }

        public static int LeerNumeroCombo(ComboBox combo, string campo, string tabla)
        {
            try
            {
                DataTable dt = LeerCombo(combo, campo, tabla);
                int result = (int)dt.Rows[0][campo];
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer un numero del ComboBox", ex);
            }
            // NEGOCIO
        }
    }
}
