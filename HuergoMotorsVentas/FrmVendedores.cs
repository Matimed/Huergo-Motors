using System;
using System.Windows.Forms;
using HuergoMotors.DTO;


namespace HuergoMotorsForms
{
    public partial class frmVendedores : Form
    {
        HuergoMotors.Negocio.VendedoresNegocio vendedoresNegocio = new HuergoMotors.Negocio.VendedoresNegocio();
        public frmVendedores()
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
                frmVendedoresAlta frmVendedoresAlta = new frmVendedoresAlta(modo);
                if (modo == HelperForms.Modo.Modificar)
                {
                    frmVendedoresAlta.VendedorSeleccionadoDTO = (VendedorDTO)gv.SelectedRows[0].DataBoundItem;
                    frmVendedoresAlta.CargarDatos();
                }
                frmVendedoresAlta.ShowDialog();
                //Solo recargo datos si se cerró con un OK.
                if (frmVendedoresAlta.DialogResult == DialogResult.OK)
                {
                    CargarGridView(gv);
                }
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
                    VendedorDTO vendedorDTO = (VendedorDTO)gv.SelectedRows[0].DataBoundItem;

                    if (HelperForms.ConfirmacionEliminación(vendedorDTO.Nombre, 
                        vendedorDTO.Apellido) == DialogResult.Yes)
                    {
                        HelperForms.OperacionExitosa(this, HelperForms.Modo.Eliminar, vendedoresNegocio.
                             EliminarElemento(vendedorDTO.Id));
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

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picReload_Click(object sender, EventArgs e)
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

        private void frmVendedores_Load(object sender, EventArgs e)
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

        private void picBusqueda_Click(object sender, EventArgs e)
        {
            try
            {

                gv.DataSource = vendedoresNegocio.Buscar(txFiltro.Text);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picReload_Click_1(object sender, EventArgs e)
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
        public void CargarGridView(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = vendedoresNegocio.CargarTabla();
        }
    }
}
