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
                CargarGridViewVentas(gvVentas);
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
                gvVentas.DataSource = ventasNegocio.Buscar(txFiltro.Text);
                txFiltro.Text = "";
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
                CargarGridViewVentas(gvVentas);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CargarGridViewVentas(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = ventasNegocio.CargarTablaVentas();

        }

        private void CargarGridViewVentasAccesorios(DataGridView gv, int id)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = ventasNegocio.CargarTablaVentasAccesorios(id);
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

   

        private void gvVentas_SelectionChanged(object sender, EventArgs e)
        {
            //Validar que ya se haya cargado el gv
            if (gvVentas.SelectedRows.Count > 0)
            {
                int id = ((VentasRDTO)gvVentas.SelectedRows[0].DataBoundItem).Id;
                CargarGridViewVentasAccesorios(gvAccesorios, id);
            }
        }
    }

}

