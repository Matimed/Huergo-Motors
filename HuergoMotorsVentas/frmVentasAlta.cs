using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace HuergoMotorsForms
{
    public partial class frmVentasAlta : Form

    {
        HuergoMotors.Negocio.VehiculosNegocio vehiculosNegocio = new HuergoMotors.Negocio.VehiculosNegocio();
        HuergoMotors.Negocio.VendedoresNegocio vendedoresNegocio = new HuergoMotors.Negocio.VendedoresNegocio();
        HuergoMotors.Negocio.VentasNegocio ventasNegocio = new HuergoMotors.Negocio.VentasNegocio();


        public HuergoMotors.DTO.ClienteDTO ClienteSelecionado { get; set; }
        public HuergoMotors.DTO.VehiculoDTO VehiculoSeleccionado { get; set; }
        public HuergoMotors.DTO.VendedorDTO VendedorSeleccionado { get; set; }


        private DataTable dataTableAccesorios;
        private decimal precioTotalAccesorios;


        public frmVentasAlta()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                HelperForms.DisplayCombo(cboVendedor, "Vendedor");
                cboVendedor.DataSource = ventasNegocio.CargarDTVendedor();
                HelperForms.DisplayCombo(cboModelo, "Modelo");
                cboModelo.DataSource = ventasNegocio.CargarDTModelo();
                gvAccesorios.AutoGenerateColumns = false;
                ActiveControl = label1;

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
                if (HelperForms.VerificarCombosCargados(cboVendedor))
                {
                    VendedorSeleccionado = vendedoresNegocio.BDCargarDTO((int)cboVendedor.SelectedValue);
                    txtSucursal.Text = VendedorSeleccionado.Sucursal;
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
                if (HelperForms.VerificarCombosCargados(cboModelo))
                {
                    if (dataTableAccesorios != null)
                    {
                        precioTotalAccesorios = 0;
                        dataTableAccesorios.Clear();
                        gvAccesorios.DataSource= dataTableAccesorios;
                    }

                    VehiculoSeleccionado = vehiculosNegocio.BDCargarDTO((int)cboModelo.SelectedValue);

                    txtTipo.Text = VehiculoSeleccionado.Tipo;
                    txtPrecio.Text = VehiculoSeleccionado.PrecioVenta.ToString(HuergoMotors.Negocio.HelperNegocio.NFI());
                    lblTotal.Text = "$ "+ VehiculoSeleccionado.PrecioVenta.ToString(HuergoMotors.Negocio.HelperNegocio.NFI());
                    HelperForms.DisplayCombo(cboAccesorios, "Nombre");
                    cboAccesorios.DataSource = ventasNegocio.CargarDTAccesorios(VehiculoSeleccionado.Id);
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
                
                if (cboAccesorios.Items.Count <= 0) throw new Exception("No puede agregar un accesorio inexistente");
                DataTable dtNuevosDatos = vehiculosNegocio.CargarTabla(((int)cboModelo.SelectedValue));
                if (dataTableAccesorios != null && dataTableAccesorios.Rows.Count > 0)
                {
                    dataTableAccesorios.Merge(dtNuevosDatos);
                }
                else
                {
                    precioTotalAccesorios = 0;
                    dataTableAccesorios = dtNuevosDatos;
                }
                gvAccesorios.DataSource = dataTableAccesorios;
                precioTotalAccesorios = precioTotalAccesorios + (decimal)dtNuevosDatos.Rows[0]["Precio"];
                lblTotal.Text = "$ " + Convert.ToString(precioTotalAccesorios + VehiculoSeleccionado.PrecioVenta);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        
        }

        private void gvAccesorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) //El index 5 es el del boton eliminar
            {
                precioTotalAccesorios = precioTotalAccesorios - (decimal)dataTableAccesorios.Rows[gvAccesorios.CurrentRow.Index]["Precio"];
                dataTableAccesorios.Rows.RemoveAt(gvAccesorios.CurrentRow.Index);
                gvAccesorios.DataSource = dataTableAccesorios;
                lblTotal.Text = "$ " + Convert.ToString(precioTotalAccesorios + VehiculoSeleccionado.PrecioVenta);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            using (frmClientes frmClientes = new frmClientes())
            {
                frmClientes.Seleccionar();

                if (frmClientes.ShowDialog() == DialogResult.OK)
                {
                    ClienteSelecionado = frmClientes.ClienteSeleccionado;
                    txtNombreCliente.Text = frmClientes.ClienteSeleccionado.Nombre;
                    txtEmail.Text = frmClientes.ClienteSeleccionado.Email;
                    txtTelefono.Text = frmClientes.ClienteSeleccionado.Telefono;
                }
                else
                {
                    txtNombreCliente.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                }
            }
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateTime = dtpFecha.Value;
                string observaciones = string.Empty;
                if (!string.IsNullOrEmpty(txtObservaciones.Text) &
                    (txtObservaciones.Text!= "Observaciones:" & txtObservaciones.Text != "Observaciones")) 
                {
                    observaciones = txtObservaciones.Text;
                }
                ventasNegocio.ConfirmarVenta(ClienteSelecionado, VehiculoSeleccionado,
                    VendedorSeleccionado, dateTime, observaciones, dataTableAccesorios);


                MessageBox.Show("Venta realizada exitosamente", "Operacion Completada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtObservaciones_Enter(object sender, EventArgs e)
        {
            txtObservaciones.Text = "";
        }
        private void txtObservaciones_Validated(object sender, EventArgs e)
        {
            if (txtObservaciones.Text == "") txtObservaciones.Text = "Observaciones:";
        }
    }
}