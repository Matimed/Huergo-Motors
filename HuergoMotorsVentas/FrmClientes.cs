using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace HuergoMotorsVentas
{
    public partial class frmClientes : Form
    {
        private static string ClientesSelect = "SELECT * FROM Clientes";
        public frmClientes()
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
                CargarABM("modificar");
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para modificar",
                    "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarABM(string modo)
        {

            frmClientesAlta f = new frmClientesAlta(modo);
            if (modo == "modificar")
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];
                f.CargarDatos(id);
            }
            f.ShowDialog();
            //Solo recargo datos si se cerró con un OK.
            if (f.DialogResult == DialogResult.OK)
            {
                RecargarDatos(ClientesSelect);
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            gv.AutoGenerateColumns = false;
            RecargarDatos(ClientesSelect);
            picBusqueda.Image = Image.FromFile("lupa.png");
            picReload.Image = Image.FromFile("reload.png");
        }
    }
}
