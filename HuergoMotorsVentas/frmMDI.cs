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

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehiculos();
        }

        private void btVehiculos_Click(object sender, EventArgs e)
        {
            Vehiculos();
        }

        private void Vehiculos()
        {
            //Abro un formulario como 'hijo' del MDI.
            frmVehiculos f = new frmVehiculos();
            f.MdiParent = this;
            f.Show();
        }
    }
}
