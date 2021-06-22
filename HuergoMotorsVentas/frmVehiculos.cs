using System;
using System.Windows.Forms;
using HuergoMotors.DTO;

namespace HuergoMotorsForms
{

    public partial class frmVehiculos : Form
    {
        HuergoMotors.Negocio.VehiculosNegocio vehiculosNegocio = new HuergoMotors.Negocio.VehiculosNegocio();
   
        public frmVehiculos()
        {
            InitializeComponent();
        }

        private void frmVehiculos_Load(object sender, EventArgs e)
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

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                HelperForms.Modo modo = HelperForms.Modo.Modificar;
                CargarABM(modo);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para modificar",
                    "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarABM(HelperForms.Modo modo)
        {
            frmVehiculosAlta vehiculosAlta = new frmVehiculosAlta(modo);
            if (modo == HelperForms.Modo.Modificar)
            {
                vehiculosAlta.Id = HelperForms.LeerDTO(vehiculosAlta.Controls, (VehiculosDTO)gv.SelectedRows[0].DataBoundItem);
            }
            vehiculosAlta.ShowDialog();
            //Solo recargo datos si se cerró con un OK.
            if (vehiculosAlta.DialogResult == DialogResult.OK)
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
                    VehiculosDTO vehiculoDTO  = (VehiculosDTO)gv.SelectedRows[0].DataBoundItem;
                    if (HelperForms.ConfirmacionEliminación(vehiculoDTO.Tipo,vehiculoDTO.Modelo) == DialogResult.Yes)
                    {
                        HelperForms.OperacionExitosa(this, HelperForms.Modo.Eliminar, vehiculosNegocio.
                            EliminarElemento(vehiculoDTO.Id));
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
            Close();
        }

        //Filtro
        private void picBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                gv.DataSource = vehiculosNegocio.Buscar(txtFiltro.Text);
                txtFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picReload_Click(object sender, EventArgs e)
        {
            try
            {
                CargarGridView(gv);
                txtFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void CargarGridView(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = vehiculosNegocio.CargarTabla();
        }
    }
}
