using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace HuergoMotorsVentas
{
    public partial class frmVendedores : Form
    {
        private new const string Select = "SELECT * FROM Vendedores";
        public frmVendedores()
        {
            InitializeComponent();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                CargarABM(Helper.Modo.Modificar);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para modificar",
                    "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarABM(Helper.Modo modo)
        {
            try
            {
                frmVendedoresAlta f = new frmVendedoresAlta(modo);
                if (modo == Helper.Modo.Modificar)
                {
                    object item = gv.SelectedRows[0].DataBoundItem;
                    int id = (int)((DataRowView)item)["Id"];
                    f.CargarDatos(id);
                }
                f.ShowDialog();
                //Solo recargo datos si se cerró con un OK.
                if (f.DialogResult == DialogResult.OK)
                {
                    gv.DataSource = Helper.CargarDataTable(Select);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            CargarABM(Helper.Modo.Agregar);
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gv.SelectedRows.Count == 1)
                {
                    object item = gv.SelectedRows[0].DataBoundItem;
                    int id = (int)((DataRowView)item)["Id"];
                    string nombre = (string)((DataRowView)item)["Nombre"];
                    string apellido = (string)((DataRowView)item)["Apellido"];
                    if (Helper.ConfirmacionEliminación(nombre, apellido) == DialogResult.Yes)
                    {
                        Helper.EditarDB(this, Helper.Modo.Eliminar, $"DELETE FROM Vendedores Where Id={id} ");
                        gv.DataSource = Helper.CargarDataTable(Select);
                    }
                }
                else
                {
                    throw new Exception("Debe seleccionar un elemento para eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picReload_Click(object sender, EventArgs e)
        {
            try
            {
                gv.DataSource = Helper.CargarDataTable(Select);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void frmVendedores_Load(object sender, EventArgs e)
        {
            try
            {
                gv.AutoGenerateColumns = false;
                gv.DataSource = Helper.CargarDataTable(Select);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void picBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = $"SELECT * FROM Vendedores WHERE Apellido LIKE '%{txFiltro.Text}%'" +
                    $" or Nombre LIKE '%{txFiltro.Text}%' or Sucursal LIKE '%{txFiltro.Text}%'";
                gv.DataSource = Helper.CargarDataTable(filtro);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void picReload_Click_1(object sender, EventArgs e)
        {
            try
            {
                gv.DataSource = Helper.CargarDataTable(Select);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        } 
    }
}
