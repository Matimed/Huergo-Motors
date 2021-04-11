using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuergoMotorsVentas
{
    public partial class frmMDI : Form
    {
        //Los atributos static (estáticos) se pueden acceder sin utilizar una instancia de la clase.

        public frmMDI()
        {
            InitializeComponent();  
        }

        private void AbrirForm(Form formulario)
        {
            formulario.MdiParent = this;
            formulario.Show();
        }
        //To do: CUando se abra un formulario el boton se ponga en otro color para marcar que esta seleccionado
        //y cuando se cierre el formulario se desmarque.
        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmVehiculos());
        }
        private void accesoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmAccesorios());
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes f = new frmClientes();
            f.Modificar();
            AbrirForm(f);
        }
        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmVendedores());
        }

        private void altaDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentas form = new frmVentas();
            form.ShowDialog();
        }
    }
}
