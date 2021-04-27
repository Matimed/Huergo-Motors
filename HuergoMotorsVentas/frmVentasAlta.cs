using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using HuergoMotors.DTO;

namespace HuergoMotorsForms
{
    public partial class frmVentasAlta : Form

    {
        HuergoMotors.Negocio.VehiculosNegocio vehiculosNegocio = new HuergoMotors.Negocio.VehiculosNegocio();
        HuergoMotors.Negocio.AccesoriosNegocio accesoriosNegocio = new HuergoMotors.Negocio.AccesoriosNegocio();
        HuergoMotors.Negocio.VendedoresNegocio vendedoresNegocio = new HuergoMotors.Negocio.VendedoresNegocio();
        HuergoMotors.Negocio.VentasNegocio ventasNegocio = new HuergoMotors.Negocio.VentasNegocio();


        public ClienteDTO ClienteSelecionado { get; set; }
        public VehiculoDTO VehiculoSeleccionado { get; set; }
        public VendedorDTO VendedorSeleccionado { get; set; }


        public List<AccesorioDTO> listaAccesoriosDTOs = new List<AccesorioDTO>();

        private decimal PrecioTotalAccesorios;


        public frmVentasAlta()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                HelperForms.DisplayCombo(cboVendedor, "NombreCompleto");
                cboVendedor.DataSource = vendedoresNegocio.CargarTabla();
                HelperForms.DisplayCombo(cboModelo, "Modelo");
                cboModelo.DataSource = vehiculosNegocio.CargarTabla();
                gvAccesorios.AutoGenerateColumns = false;
                ActiveControl = label1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
                if (HelperForms.VerificarCombosCargados(cboVendedor))
                {
                    VendedorSeleccionado = (VendedorDTO)cboVendedor.SelectedItem;
                    txtSucursal.Text = VendedorSeleccionado.Sucursal;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (HelperForms.VerificarCombosCargados(cboModelo))
                {
                    if (listaAccesoriosDTOs != null)
                    {
                        PrecioTotalAccesorios = 0;
                        listaAccesoriosDTOs.Clear();
                        gvAccesorios.DataSource = listaAccesoriosDTOs;
                    }

                    VehiculoSeleccionado = vehiculosNegocio.CargarTabla((int)cboModelo.SelectedValue);

                    txtTipo.Text = VehiculoSeleccionado.Tipo;
                    txtPrecio.Text = VehiculoSeleccionado.PrecioVenta.ToString(HuergoMotors.Negocio.HelperNegocio.NFI());
                    lblTotal.Text = "$ " + VehiculoSeleccionado.PrecioVenta.ToString(HuergoMotors.Negocio.HelperNegocio.NFI());
                    HelperForms.DisplayCombo(cboAccesorios, "Nombre");
                    cboAccesorios.DataSource = accesoriosNegocio.CargarTablaIdVehiculo(VehiculoSeleccionado.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboAccesorios.Items.Count <= 0) throw new Exception("No puede agregar un accesorio inexistente");
                AccesorioDTO accesorioSeleccionado = new AccesorioDTO();
                accesorioSeleccionado = accesoriosNegocio.CargarTabla((int)cboAccesorios.SelectedValue)[0];
                listaAccesoriosDTOs.Add(accesorioSeleccionado);
                gvAccesorios.DataSource = new BindingList<AccesorioDTO> (listaAccesoriosDTOs);
                PrecioTotalAccesorios = PrecioTotalAccesorios + accesorioSeleccionado.Precio;
                lblTotal.Text = "$ " + Convert.ToString(PrecioTotalAccesorios + VehiculoSeleccionado.PrecioVenta);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gvAccesorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvAccesorios.Columns[e.ColumnIndex].Name == "Eliminar")
                {                    
                    AccesorioDTO accesorioSeleccionado = new AccesorioDTO();
                    PrecioTotalAccesorios = PrecioTotalAccesorios - listaAccesoriosDTOs[e.RowIndex].Precio;
                    listaAccesoriosDTOs.Remove(listaAccesoriosDTOs[e.RowIndex]);
                    gvAccesorios.DataSource = new BindingList<AccesorioDTO>(listaAccesoriosDTOs);
                    lblTotal.Text = "$ " + Convert.ToString(PrecioTotalAccesorios + VehiculoSeleccionado.PrecioVenta);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    (txtObservaciones.Text != "Observaciones:" & txtObservaciones.Text != "Observaciones"))
                {
                    observaciones = txtObservaciones.Text;
                }

                VentaDTO venta = ventasNegocio.CargarDTO(ClienteSelecionado, VehiculoSeleccionado,
                    VendedorSeleccionado, dateTime, observaciones);
                string precioVehiculo = VehiculoSeleccionado.PrecioVenta.ToString(HuergoMotors.Negocio.HelperNegocio.NFI());

                ventasNegocio.ConfirmarVenta(venta, listaAccesoriosDTOs);
                MessageBox.Show("Venta realizada exitosamente", "Operacion Completada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.Message + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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