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
