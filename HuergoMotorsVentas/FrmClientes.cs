using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace HuergoMotorsForms
{
    public partial class frmClientes : Form
    {
        public ClienteForms ClienteSeleccionado { get; set; }
        private new const string Select = "SELECT * FROM Clientes";
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                CargarABM(HelperForms.Modo.Modificar);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para modificar",
                    "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarABM(HelperForms.Modo modo)
        {
            try
            {
                frmClientesAlta f = new frmClientesAlta(modo);
                if (modo == HelperForms.Modo.Modificar)
                {
                    object item = gv.SelectedRows[0].DataBoundItem;
                    int id = (int)((DataRowView)item)["Id"];
                    f.CargarDatos(id);
                }
                f.ShowDialog();
                //Solo recargo datos si se cerró con un OK.
                if (f.DialogResult == DialogResult.OK)
                {
                    gv.DataSource = HelperForms.CargarDataTable(Select);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        public void Seleccionar()
        {
            btnSeleccionar.Visible = true;
            btEliminar.Visible = false;
        }
        public void Modificar()
        {
            btnSeleccionar.Visible = false;
            btEliminar.Visible = true;
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {            
                gv.AutoGenerateColumns = false;
                gv.DataSource = HelperForms.CargarDataTable(Select);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void picBoxlupa_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = $"SELECT * FROM Clientes WHERE Nombre LIKE '%{txFiltro.Text}%'" +
                     $" or Direccion LIKE '%{txFiltro.Text}%' or Telefono LIKE '%{txFiltro.Text}%' or Email LIKE '%{txFiltro.Text}%'";
                gv.DataSource = HelperForms.CargarDataTable(filtro);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void picboxReload_Click(object sender, EventArgs e)
        {
            try
            {
                gv.DataSource = HelperForms.CargarDataTable(Select);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            CargarABM(HelperForms.Modo.Agregar);
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
                    if (HelperForms.ConfirmacionEliminación(nombre) == DialogResult.Yes)
                    {
                        HelperForms.EditarDB(this, HelperForms.Modo.Eliminar, $"DELETE FROM Clientes Where Id={id} ");
                        gv.DataSource = HelperForms.CargarDataTable(Select);
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

        private void gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                ClienteForms cliente = new ClienteForms();
                cliente.Id = (int)gv.SelectedRows[0].Cells["Id"].Value;
                cliente.Nombre = (string)gv.SelectedRows[0].Cells["Nombre"].Value;
                cliente.Direccion = (string)gv.SelectedRows[0].Cells["Direccion"].Value;
                cliente.Telefono = (string)gv.SelectedRows[0].Cells["Telefono"].Value;
                cliente.Email = (string)gv.SelectedRows[0].Cells["Email"].Value;

                ClienteSeleccionado = cliente;

                DialogResult = DialogResult.OK;
            }
        }
    }
}
