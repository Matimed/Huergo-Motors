using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HuergoMotorsVentas
{
    public partial class frmVentas : Form
  
    {
        private new const string Select = "SELECT * FROM Ventas";
        public frmVentas()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSucursal_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ToDo: Probablemente sería bueno tener un "helper" para hacer querys...

            int id = (int)cbVendedor.SelectedValue;

            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter("SELECT Sucursal FROM Vendedores WHERE ID=" + id, Helper.ConnectionString))
            {
                da.Fill(dt);
            }

            string sucursal = (string)dt.Rows[0]["Sucursal"];

            txSucursal.Text = sucursal;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
               
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            frmClientes formulario = new frmClientes();
            formulario.ShowDialog(); 
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
      

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Precio", typeof(decimal));

            dt.Rows.Add("Accesorio 1", "Llantas", 3962.23m);
            dt.Rows.Add("Accesorio 2", "Llantas", 353.16m);

            gvAccesorios.DataSource = dt;
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                Helper.CargarCombo(cbVendedor, "SELECT Id, Nombre + ' ' + Apellido AS Vendedor FROM Vendedores", "Vendedor", "Id");
                Helper.CargarCombo(cbModelo, "SELECT Id, Modelo FROM Vehiculos", "Modelo", "Id");

            }
            catch (Exception)
            {
                //Aca es donde continua la ejecucion en caso de un error (Excepcion)
                throw;
            }
        }
    }
}