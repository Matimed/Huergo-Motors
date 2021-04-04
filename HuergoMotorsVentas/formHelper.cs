using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuergoMotorsVentas
{
    public static class FormsHelper
    {
        public enum Modo
        {
            agregar,
            modificar
        }
        public static void OperacionExitosa(Modo modo, int result)
        {
            switch (modo)
            {
                case FormsHelper.Modo.agregar:
                    MessageBox.Show($"{result} registro/s agregados correctamente",
                    "Los registros fueron agregados exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case FormsHelper.Modo.modificar:
                    MessageBox.Show($"{result} registro/s actualizados correctamente",
                    "Actualización completada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
        // Agregar funcion para carteles de confirmacion de modificacion y agregar
        public static void CargarCombo(ComboBox combo, string query, string displaymember, string valuemember)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, frmMDI.ConnectionString))
                {
                    da.Fill(dt);
                }
                combo.DisplayMember = displaymember;
                combo.ValueMember = valuemember;
                combo.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar un combo", ex);
            }
        }
       
    }
}
