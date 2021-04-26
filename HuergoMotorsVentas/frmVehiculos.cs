using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
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
            frmVehiculosAlta frmVehiculosAlta = new frmVehiculosAlta(modo);
            if (modo == HelperForms.Modo.Modificar)
            {
                VehiculoDTO vehiculoDTO = new VehiculoDTO();
                frmVehiculosAlta.VehiculoSeleccionadoDTO = (VehiculoDTO)gv.SelectedRows[0].DataBoundItem;
                frmVehiculosAlta.CargarDatos();
            }
            frmVehiculosAlta.ShowDialog();
            //Solo recargo datos si se cerró con un OK.
            if (frmVehiculosAlta.DialogResult == DialogResult.OK)
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
                    VehiculoDTO vehiculoDTO  = (VehiculoDTO)gv.SelectedRows[0].DataBoundItem;
                    object item = gv.SelectedRows[0].DataBoundItem;
                    if (HelperForms.ConfirmacionEliminación(vehiculoDTO.Tipo) == DialogResult.Yes)
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Filtro
        private void picBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                gv.DataSource = vehiculosNegocio.Buscar(txFiltro.Text);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void picReload_Click(object sender, EventArgs e)
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

        public void CargarGridView(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = vehiculosNegocio.CargarTabla();
        }
    }
}
