using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace HuergoMotorsVentas
{


    public partial class frmAccesorios : Form
    {
        private static string AccesoriosSelect = "SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
            "FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id;";

        public frmAccesorios()
        {
            InitializeComponent();
        }

       
        private void RecargarDatos(string query)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(query, frmMDI.ConnectionString))
            {
                da.Fill(dt);
            }
            gv.DataSource = dt;
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                CargarABM(Helper.Modo.modificar);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para modificar",
                    "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarABM(Helper.Modo modo)
        {

            frmAccesoriosAlta f = new frmAccesoriosAlta(modo);
            if (modo == Helper.Modo.modificar)
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];
                f.CargarDatos(id);
            }
            f.ShowDialog();

            if (f.DialogResult == DialogResult.OK)
            {
                RecargarDatos(AccesoriosSelect);
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            CargarABM(Helper.Modo.agregar);
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];
                string tipo = (string)((DataRowView)item)["Tipo"];
                DialogResult resp = MessageBox.Show("Seguro que desea borrar el " + tipo + "? Esta operacion no se puede revertir",
                    "Eliminar permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    try
                    {
                        string delete = $"DELETE FROM Accesorios Where Id={id} ";
                        using (SqlConnection conn = new SqlConnection(frmMDI.ConnectionString))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(delete, conn))
                            {
                                int result = cmd.ExecuteNonQuery();
                                RecargarDatos(AccesoriosSelect);
                                MessageBox.Show($"{result} registro/s eliminados correctamente",
                                "Eliminacion completada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para eliminar",
                    "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmAccesorios_Load(object sender, EventArgs e)
        {
            gv.AutoGenerateColumns = false;
            RecargarDatos(AccesoriosSelect);
        }

        private void picBusqueda_Click(object sender, EventArgs e)
        {
            string filtro = $"SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
                    $"FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id " +
                    $"WHERE a.Tipo LIKE '%{txFiltro.Text}%' or a.Nombre LIKE '%{txFiltro.Text}%' or a.Precio " +
                    $"LIKE '%{txFiltro.Text}%' or b.Modelo LIKE '%{txFiltro.Text}%'";
            RecargarDatos(filtro);
            txFiltro.Text = "";
        }

        private void picReload_Click(object sender, EventArgs e)
        {
            RecargarDatos(AccesoriosSelect);
            txFiltro.Text = "";
        }
    }
}



