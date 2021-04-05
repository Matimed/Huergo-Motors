using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuergoMotorsVentas
{
    public static class Helper
    {
        public enum Modo
        {
            Agregar,
            Modificar,
            Eliminar
        }

        public static void OperacionExitosa(Modo modo, int result)
        {
            switch (modo)
            {
                case Modo.Agregar:
                    MessageBox.Show($"{result} registro/s agregados correctamente",
                    "Los registros fueron agregados exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case Modo.Modificar:
                    MessageBox.Show($"{result} registro/s actualizados correctamente",
                    "Actualización completada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case Modo.Eliminar:
                    MessageBox.Show($"{result} registro/s eliminados correctamente",
                    "Eliminacion completada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        public static void Conexion(Form form, Modo modo, string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(frmMDI.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int result = cmd.ExecuteNonQuery();
                    OperacionExitosa(modo, result);
                }
                form.DialogResult = DialogResult.OK;
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
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(query, frmMDI.ConnectionString))
                {
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los datos desde la base de datos", ex);
            }
        }

       
        public static DialogResult ConfirmacionModificacion()
        {
                DialogResult resp = MessageBox.Show("Los datos guardados se sobrescribiran ¿Esta seguro de que quiere continuar?",
                                 "Sobrescribir los datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return resp;
        }

        public static DialogResult ConfirmacionEliminación(string nombre, string apellido)
        {
            DialogResult resp = MessageBox.Show("Seguro que desea borrar a " + nombre +" " + apellido + "? Esta operacion no se puede revertir",
                     "Eliminar permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return resp;
        }

       
        //Funcion CargarABM en desarrollo(con errores) :


        //public static void CargarABM(Form form, DataGridView gv, Modo modo, string select)
        //{
        //    Form f = new frmAccesoriosAlta(modo);
        //    if (modo == Modo.Modificar)
        //    {
        //        object item = gv.SelectedRows[0].DataBoundItem;
        //        int id = (int)((DataRowView)item)["Id"];
        //        f.CargarDatos(id);
        //    }
        //    form.ShowDialog();

        //    if (form.DialogResult == DialogResult.OK)
        //    {
        //        gv.DataSource = CargarDataTable(select);
        //    }
        //}

        public static void CargarCombo(ComboBox combo, string query, string displaymember, string valuemember)
        {
            CargarDataTable(query);
            combo.DisplayMember = displaymember;
            combo.ValueMember = valuemember;
            combo.DataSource = CargarDataTable(query);
        }
    }
}
