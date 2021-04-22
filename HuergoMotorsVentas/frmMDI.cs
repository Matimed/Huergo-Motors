using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuergoMotorsForms
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();  
        }

        private void AbrirForm(Form formulario)
        {
            formulario.MdiParent = this;
            formulario.Show();
        }
     
        private void btVehiculos_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmVehiculos());
        }
        private void btAccesorios_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmAccesorios());
        }
        private void btClientes_Click(object sender, EventArgs e)
        {
            frmClientes f = new frmClientes();
            f.Modificar();
            AbrirForm(f);
        }
        private void btVendedores_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmVendedores());
        }
        private void btNuevaVenta_Click(object sender, EventArgs e)
        {
            frmVentasAlta form = new frmVentasAlta();
            form.ShowDialog();
        }
    }
}
