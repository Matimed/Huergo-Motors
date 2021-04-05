using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace HuergoMotorsVentas
{
    public partial class frmVendedores : Form
    {
        private static string VendedoresSelect = "SELECT * FROM Vendedores";
        public frmVendedores()
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

            frmVendedoresAlta f = new frmVendedoresAlta(modo);
            if (modo == Helper.Modo.modificar)
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];
                f.CargarDatos(id);
            }
            f.ShowDialog();
            //Solo recargo datos si se cerró con un OK.
            if (f.DialogResult == DialogResult.OK)
            {
                RecargarDatos(VendedoresSelect);
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
                string nombre = (string)((DataRowView)item)["Nombre"];
                string apellido = (string)((DataRowView)item)["Apellido"];
                DialogResult resp = MessageBox.Show("Seguro que desea borrar a " + nombre + " "+ apellido + "? Esta operacion no se puede revertir",
                    "Eliminar permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    try
                    {
                        string delete = $"DELETE FROM Vendedores Where Id={id} ";

                        //Recordar: Utilizar bloques 'using'
                        using (SqlConnection conn = new SqlConnection(frmMDI.ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(delete, conn);
                            int result = cmd.ExecuteNonQuery();
                            RecargarDatos(VendedoresSelect);
                            MessageBox.Show($"{result} registro/s eliminados correctamente",
                            "Eliminacion completada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };

                    }
                    catch (Exception ex)
                    {
                        //El bloque Try-Catch me permite capturar errores (excepciones) en el código, y en este caso mostrar un mensaje.
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

        private void picReload_Click(object sender, EventArgs e)
        {
            RecargarDatos(VendedoresSelect);
            txFiltro.Text = "";
        }

        private void frmVendedores_Load(object sender, EventArgs e)
        {
            gv.AutoGenerateColumns = false;
            RecargarDatos(VendedoresSelect);
            picBusqueda.Image = Image.FromFile("lupa.png");
            picReload.Image = Image.FromFile("reload.png");
        }

        private void picBusqueda_Click(object sender, EventArgs e)
        {
            string filtro = $"SELECT * FROM Vendedores WHERE Apellido LIKE '%{txFiltro.Text}%'" +
                $" or Nombre LIKE '%{txFiltro.Text}%' or Sucursal LIKE '%{txFiltro.Text}%'";
            RecargarDatos(filtro);
            txFiltro.Text = "";
        }

        private void picReload_Click_1(object sender, EventArgs e)
        {
            RecargarDatos(VendedoresSelect);
            txFiltro.Text = "";
        }
    }
}
