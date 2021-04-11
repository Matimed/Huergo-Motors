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
        private DataTable dtAccesorios;
        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                Helper.CargarCombo(cboVendedor, "SELECT Id, Nombre + ' ' + Apellido AS Vendedor FROM Vendedores", "Vendedor");
                Helper.CargarCombo(cboModelo, "SELECT  Id, Modelo FROM Vehiculos", "Modelo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void cboVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Helper.VerificarCombosCargados(cboVendedor))
                {
                    DataTable dtVendedor = Helper.LeerCombo(cboVendedor, "Sucursal", "Vendedores");
                    txtSucursal.Text = (string)dtVendedor.Rows[0]["Sucursal"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void cboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Helper.VerificarCombosCargados(cboModelo))
                {
                    if (dtAccesorios != null)
                    {
                        dtAccesorios.Clear();
                        gvAccesorios.DataSource= dtAccesorios;
                    }
                    DataTable dtModelo = Helper.LeerCombo(cboModelo, "*", "Vehiculos");
                    lblTipo.Text = (string)dtModelo.Rows[0]["Tipo"];
                    lblPrecio.Text = Convert.ToString((decimal)dtModelo.Rows[0]["PrecioVenta"]);
                    int idVehiculo = (int)dtModelo.Rows[0]["Id"];
                    Helper.CargarCombo(cboAccesorios, $"SELECT Nombre, Id FROM Accesorios WHERE idVehiculo = {idVehiculo}", "Nombre");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboAccesorios.Items.Count > 0)
                {
                    DataTable dtNuevosDatos = Helper.LeerCombo(cboAccesorios, "*", "Accesorios");
                    if (dtAccesorios != null && dtAccesorios.Rows.Count > 0)
                    {
                        dtAccesorios.Merge(dtNuevosDatos);
                    }
                    else
                    {
                        dtAccesorios = dtNuevosDatos;
                    }
                    gvAccesorios.DataSource = dtAccesorios;
                }
                else
                {
                    throw new Exception("No puede agregar un accesorio inexistente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        
        } 
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            frmClientes formulario = new frmClientes();
            formulario.ShowDialog(); 
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
      

        }

   

  


    }
}