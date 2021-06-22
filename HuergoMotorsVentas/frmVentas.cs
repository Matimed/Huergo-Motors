using HuergoMotors.DTO;
using System;
using System.Windows.Forms;

namespace HuergoMotors.Forms
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }

       Negocio.VentasNegocio ventasNegocio = new Negocio.VentasNegocio();

        private void frmVentas_load(object sender, EventArgs e)
        {
            try
            {
                CargarGridViewVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Filtro
        private void picBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                gvVentas.DataSource = ventasNegocio.Buscar(txtFiltro.Text);
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
                CargarGridViewVentas();
                CargarGridViewVentasAccesorios();
                txtFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CargarGridViewVentas()
        {
            try
            {
                gvVentas.AutoGenerateColumns = false;
                gvVentas.DataSource = ventasNegocio.CargarTablaVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarGridViewVentasAccesorios()
        {
            try
            {
                if (gvVentas.SelectedRows.Count > 0)
                {
                    int id = ((VentasRDTO)gvVentas.SelectedRows[0].DataBoundItem).Id;
                    gvAccesorios.AutoGenerateColumns = false;
                    gvAccesorios.DataSource = ventasNegocio.CargarTablaVentasAccesorios(id);
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

   

        private void gvVentas_SelectionChanged(object sender, EventArgs e)
        {
                CargarGridViewVentasAccesorios();
        }
    }

}

