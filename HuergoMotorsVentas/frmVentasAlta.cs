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
        HuergoMotors.Negocio.VentasNegocio ventasNegocio = new HuergoMotors.Negocio.VentasNegocio();


        public HuergoMotors.DTO.VehiculoDTO VehiculoSeleccionado { get; set; }

        private DataTable dataTableAccesorios;
        private int idCliente;
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
                    txtSucursal.Text = (string)HelperForms.LeerCombo(cboVendedor, "Sucursal", "Vendedores").Rows[0]["Sucursal"];
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            using (frmClientes frmClientes = new frmClientes())
            {
                frmClientes.Seleccionar();

                if (frmClientes.ShowDialog() == DialogResult.OK)
                {
                    txtNombreCliente.Text = frmClientes.ClienteSeleccionado.Nombre;
                    txtEmail.Text = frmClientes.ClienteSeleccionado.Email;
                    txtTelefono.Text = frmClientes.ClienteSeleccionado.Telefono;
                    idCliente = frmClientes.ClienteSeleccionado.Id;
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
                HelperForms.ValidarTextosVacios(txtEmail, txtNombreCliente, txtTelefono, txtSucursal, txtTipo, txtPrecio);
                if (!HelperForms.VerificarCombosCargados(cboModelo, cboVendedor)) throw new Exception
                        ("Es necesario que todos los ComboBox esten cargados");
                
                int stock = HelperForms.LeerNumeroCombo(cboModelo, "Stock", "Vehiculos");

                if (stock < 1) throw new Exception("No hay stock del vehiculo seleccionado");
                
                DateTime dateTime = dtpFecha.Value;

                if (dateTime.Date > DateTime.Now.Date) throw new Exception
                        ("La fecha no puede ser posterior a la actual del sistema");
                
                string fecha = dateTime.ToString("dd/MM/yyyy");
                int idVehiculo = (int)cboModelo.SelectedValue;
                int idVendedor = (int)cboVendedor.SelectedValue;
                string observaciones = string.Empty;

                if (!string.IsNullOrEmpty(txtObservaciones.Text) &
                    (txtObservaciones.Text!= "Observaciones:" & txtObservaciones.Text != "Observaciones")) 
                {
                    observaciones = txtObservaciones.Text;
                }

                using (SqlConnection conexion = new SqlConnection(HelperForms.ConnectionString))
                {
                    conexion.Open();
                    using (SqlTransaction transaction = conexion.BeginTransaction())
                    {
                        try
                        {
                            HelperForms.EditarDB($"INSERT INTO Ventas(Fecha, IdVehiculo, IdCliente, IdVendedor, Observaciones, Total) " +
                            $"VALUES ('{fecha}', '{idVehiculo}', '{idCliente}', '{idVendedor}', '{observaciones}', '{precioVehiculo.ToString(HelperForms.nfi())}')", conexion, transaction);

                            //Actualizar Stock
                            stock = stock - 1;
                            HelperForms.EditarDB($"UPDATE Vehiculos SET Stock='{stock}' WHERE Id={idVehiculo}",conexion , transaction);

                            //Si hay accesorios los agrega y si no termina la transaction
                            if (dtAccesorios != null && dtAccesorios.Rows.Count > 0)
                            {
                                //Por cada accesorio en la lista se agrega una venta en VentasAccesorios
                                foreach (DataRow dataRow in dtAccesorios.Rows)
                                {
                                    int idAccesorio = (int)dataRow["id"];
                                    decimal precioAccesorio = (decimal)dataRow["Precio"];
                                    HelperForms.EditarDB($"INSERT INTO VentasAccesorios (IdVenta, IdAccesorio, Precio) VALUES" +
                                        $"((SELECT MAX(Id) AS IdVenta FROM Ventas), '{idAccesorio}', '{precioAccesorio.ToString(HelperForms.nfi())}')", conexion, transaction);
                                }
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error al confirmar la venta", ex);
                        }
                    } 
                }

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
        private void gvAccesorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) //El index 5 es el del boton eliminar
            {
                precioTotalAccesorios = precioTotalAccesorios - (decimal)dtAccesorios.Rows[gvAccesorios.CurrentRow.Index]["Precio"];
                dtAccesorios.Rows.RemoveAt(gvAccesorios.CurrentRow.Index);
                gvAccesorios.DataSource = dtAccesorios;
                lblTotal.Text = "$ " + Convert.ToString(precioTotalAccesorios + precioVehiculo);
            }
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