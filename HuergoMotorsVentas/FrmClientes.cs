using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace HuergoMotorsForms
{
    public partial class frmClientes : Form
    {
        HuergoMotors.Negocio.ClienteNegocio clienteNegocio = new HuergoMotors.Negocio.ClienteNegocio();
        //public ClienteForms ClienteSeleccionado { get; set; }
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
                frmClientesAlta frmClientesAlta = new frmClientesAlta(modo);
                if (modo == HelperForms.Modo.Modificar)
                {
                    object item = gv.SelectedRows[0].DataBoundItem;
                    frmClientesAlta.Id = (int)((DataRowView)item)["Id"];
                    frmClientesAlta.CargarDatos();
                }
                frmClientesAlta.ShowDialog();
                //Solo recargo datos si se cerró con un OK.
                if (frmClientesAlta.DialogResult == DialogResult.OK)
                {
                    CargarGridView(gv);
                    //enviar señar a negocios que haga un return del cargardatatable
                    
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
                CargarGridView(gv);
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
                gv.DataSource = clienteNegocio.Buscar(txFiltro.Text);
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
                CargarGridView(gv);
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
                        HelperForms.MostrarOperacionExitosa(this, HelperForms.Modo.Eliminar,
                            clienteNegocio.EliminarElemento(id));
                        CargarGridView(gv);

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
                //ToDo:Hacer validacion de btnSeleccionar
                HuergoMotors.DTO.ClienteDTO clienteDTO = new HuergoMotors.DTO.ClienteDTO();

                clienteDTO.Id = (int)gv.SelectedRows[0].Cells["Id"].Value;
                clienteDTO.Nombre = (string)gv.SelectedRows[0].Cells["Nombre"].Value;
                clienteDTO.Direccion = (string)gv.SelectedRows[0].Cells["Direccion"].Value;
                clienteDTO.Telefono = (string)gv.SelectedRows[0].Cells["Telefono"].Value;
                clienteDTO.Email = (string)gv.SelectedRows[0].Cells["Email"].Value;
                
                 //return clienteDTO;

                DialogResult = DialogResult.OK;
            }
        }

        public void CargarGridView(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = clienteNegocio.CargarTabla();
        }
    }
}
