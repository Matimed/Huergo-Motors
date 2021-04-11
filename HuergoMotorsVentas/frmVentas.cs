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
        public frmVentas()
        {
            InitializeComponent();
        }

        private void cbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = (int)cboVendedor.SelectedValue;

            DataTable dt = Helper.CargarDataTable("SELECT Sucursal FROM Vendedores WHERE ID=" + id);
            
            string sucursal = (string)dt.Rows[0]["Sucursal"];

            txtSucursal.Text = sucursal;
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
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Nombre");
            //dt.Columns.Add("Tipo");
            //dt.Columns.Add("Precio", typeof(decimal));

            //dt.Rows.Add("Accesorio 1", "Llantas", 3962.23m);
            //dt.Rows.Add("Accesorio 2", "Llantas", 353.16m);

            //gvAccesorios.DataSource = dt;
            string nombre = "Accesorio 1";
            string tipo = "Llantas";
            decimal precio = 56;

            gvAccesorios.Rows.Add(nombre, tipo, precio);
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                Helper.CargarCombo(cboVendedor, "SELECT Id, Nombre + ' ' + Apellido AS Vendedor FROM Vendedores", "Vendedor");
                Helper.CargarCombo(cboTipo, "SELECT DISTINCT Id, Tipo FROM Vehiculos", "Tipo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //if (cboTipo.SelectedIndex != 0)
            //{
            //    string dato = cboTipo.SelectedItem.ToString();
            //    try
            //    {
            //        Helper.CargarCombo(cboModelo, $"SELECT Modelo FROM Vehiculos WHERE Tipo = {dato}", "Modelo");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            //    }
            //}
        }
    }
}