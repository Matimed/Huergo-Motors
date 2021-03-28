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
        public static string ConnectionString = "Server=sql5078.site4now.net;Database=DB_9CF8B6_HuergoMotors2021;User Id=DB_9CF8B6_HuergoMotors2021_admin;Password=huergo2021;";

        public frmMDI()
        {
            InitializeComponent();
        }


       //To do: CUando se abra un formulario el boton se ponga en otro color para marcar que esta seleccionado
       //y cuando se cierre el formulario se desmarque.
        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehiculos();
        }
        private void accesoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accesorios();
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes();
        }
        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendedores();
        }


        private void btVehiculos_Click(object sender, EventArgs e)
        {
            Vehiculos();
        }
        private void btAccesorios_Click(object sender, EventArgs e)
        {
            Accesorios();
        }
        private void btClientes_Click(object sender, EventArgs e)
        {
            Clientes();
        }
        private void btVendedores_Click(object sender, EventArgs e)
        {
            Vendedores();
        }


        private void Vehiculos()
        {
            frmVehiculos f = new frmVehiculos();
            f.MdiParent = this;
            f.Show();
        }
        private void Accesorios()
        {
            frmAccesorios f = new frmAccesorios();
            f.MdiParent = this;
            f.Show();
        }
        private void Clientes()
        {
            frmClientes f = new frmClientes();
            f.MdiParent = this;
            f.Show();
        }
        private void Vendedores()
        {
            frmVendedores f = new frmVendedores();
            f.MdiParent = this;
            f.Show();
        }
    }
}
