using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                CargarGridView(gv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }


        //Filtro
        private void picBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                gv.DataSource = ventasNegocio.Buscar(txFiltro.Text);
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
        private void CargarGridView(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = ventasNegocio.CargarTabla();
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}

