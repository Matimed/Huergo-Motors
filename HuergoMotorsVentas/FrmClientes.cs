using System;
using System.Windows.Forms;
using HuergoMotors.DTO;

namespace HuergoMotorsForms
{
    public partial class frmClientes : Form
    {
        HuergoMotors.Negocio.ClientesNegocio clientesNegocio = new HuergoMotors.Negocio.ClientesNegocio();
        public HuergoMotors.DTO.ClientesDTO ClienteSeleccionado { get; set; }
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gv.SelectedRows.Count != 1) throw new Exception("Debe seleccionar un elemento para modificar");
                CargarABM(HelperForms.Modo.Modificar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    frmClientesAlta.ClienteSeleccionadoDTO = (ClientesDTO)gv.SelectedRows[0].DataBoundItem;
                    frmClientesAlta.CargarDatos();
                }
                frmClientesAlta.ShowDialog();
                //Solo recargo datos si se cerró con un OK.
                if (frmClientesAlta.DialogResult == DialogResult.OK)
                {
                    CargarGridView(gv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                gv.DataSource = clientesNegocio.Buscar(txFiltro.Text);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    ClientesDTO clienteDTO = (ClientesDTO)gv.SelectedRows[0].DataBoundItem;
                    if (HelperForms.ConfirmacionEliminación(clienteDTO.Nombre) == DialogResult.Yes)
                    {
                        HelperForms.OperacionExitosa(this, HelperForms.Modo.Eliminar,clientesNegocio.
                            EliminarElemento(clienteDTO.Id));
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gv.SelectedRows.Count == 1)
                {
                    ClienteSeleccionado = (HuergoMotors.DTO.ClientesDTO)gv.SelectedRows[0].DataBoundItem;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        public void CargarGridView(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = clientesNegocio.CargarTabla();
        }
    }
}
