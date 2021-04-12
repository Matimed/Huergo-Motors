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
    public partial class frmVentasAlta : Form

    {
        private DataTable dtAccesorios;
        private int idCliente;
        private decimal precioVehiculo;
        private decimal precioAccesorios;
        private int idVenta;
        public frmVentasAlta()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                Helper.CargarCombo(cboVendedor, "SELECT Id, Nombre + ' ' + Apellido AS Vendedor FROM Vendedores", "Vendedor");
                Helper.CargarCombo(cboModelo, "SELECT  Id, Modelo FROM Vehiculos", "Modelo");
                gvAccesorios.AutoGenerateColumns = false;

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
                    txtSucursal.Text = Helper.LeerDatoCombo(cboVendedor, "Sucursal", "Vendedores");
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
                        precioAccesorios = 0;
                        dtAccesorios.Clear();
                        gvAccesorios.DataSource= dtAccesorios;
                    }
                    DataTable dtModelo = Helper.LeerCombo(cboModelo, "*", "Vehiculos");
                    txtTipo.Text = (string)dtModelo.Rows[0]["Tipo"];
                    precioVehiculo = (decimal)dtModelo.Rows[0]["PrecioVenta"];
                    txtPrecio.Text = precioVehiculo.ToString(Helper.nfi());
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
                        precioAccesorios = 0;
                        dtAccesorios = dtNuevosDatos;
                    }
                    gvAccesorios.DataSource = dtAccesorios;
                    precioAccesorios = precioAccesorios + (decimal)dtNuevosDatos.Rows[0]["Precio"];
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
            using (frmClientes f = new frmClientes())
            {
                f.Seleccionar();

                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtNombreCliente.Text = f.ClienteSeleccionado.Nombre;
                    txtEmail.Text = f.ClienteSeleccionado.Email;
                    txtTelefono.Text = f.ClienteSeleccionado.Telefono;
                    idCliente = f.ClienteSeleccionado.Id;
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
                Helper.ValidarTextosVacios(txtEmail, txtNombreCliente, txtTelefono, txtSucursal, txtTipo, txtPrecio);
                if (!Helper.VerificarCombosCargados(cboModelo, cboVendedor))
                {
                    throw new Exception("Es necesario que todos los ComboBox esten cargados");
                }
                int stock = Helper.LeerNumeroCombo(cboModelo, "Stock", "Vehiculos");
                if (stock < 1)
                {
                    throw new Exception("No hay stock del vehiculo seleccionado");
                }
                DateTime dateTime = dtpFecha.Value;
                if (dateTime.Date > DateTime.Now.Date)
                {
                    throw new Exception("La fecha no puede ser posterior a la actual del sistema");
                }
                string fecha = dateTime.ToString("dd/MM/yyyy");
                int idVehiculo = (int)cboModelo.SelectedValue;
                int idVendedor = (int)cboVendedor.SelectedValue;
                string observaciones = string.Empty;
                if (!string.IsNullOrEmpty(txtObservaciones.Text) &
                    (txtObservaciones.Text!= "Observaciones:" & txtObservaciones.Text != "Observaciones"))
                {
                    observaciones = txtObservaciones.Text;
                }

                using (SqlConnection conexion = new SqlConnection(Helper.ConnectionString))
                {
                    conexion.Open();
                    using (SqlTransaction transaction = conexion.BeginTransaction())
                    {
                        try
                        {
                            //Helper.EditarDB($"INSERT INTO Ventas(Fecha, IdVehiculo, IdCliente, IdVendedor, Observaciones, Total) " +
                            //$"VALUES ('11/04/2021', '1', '2021', '3', '', '300.00')",conexion, transaction);
                            Helper.EditarDB($"INSERT INTO Ventas(Fecha, IdVehiculo, IdCliente, IdVendedor, Observaciones, Total) " +
                            $"VALUES ('{fecha}', '{idVehiculo}', '{idCliente}', '{idVendedor}', '{observaciones}', '{precioVehiculo.ToString(Helper.nfi())}')", conexion, transaction);

                            //Actualizar Stock
                            stock = stock - 1;
                            Helper.EditarDB($"UPDATE Vehiculos SET Stock='{stock}' WHERE Id={idVehiculo}",conexion , transaction);

                            //Si hay accesorios los agrega y si no termina la transaction
                            if (dtAccesorios != null && dtAccesorios.Rows.Count > 0)
                            {
                                //Detectar idVenta
                                DataTable dt = Helper.CargarDataTable("SELECT MAX (Id) AS IdVenta FROM Ventas");
                                idVenta = (int)dt.Rows[0][0];

                                //Por cada accesorio en la lista se agrega una venta en VentasAccesorios
                                foreach (DataRow dataRow in dtAccesorios.Rows)
                                {
                                    int idAccesorio = (int)dataRow["id"];
                                    decimal precioAccesorio = (decimal)dataRow["Precio"];
                                    Helper.EditarDB($"INSERT INTO VentasAccesorios (IdVenta, IdAccesorio, Precio) VALUES" +
                                        $"('{idVenta}', '{idAccesorio}', '{precioAccesorio.ToString(Helper.nfi())}')",conexion, transaction);
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
                
                MessageBox.Show("Venta realizada exitosamente");
                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        private void gvAccesorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) //El index 5 es el del boton eliminar
            {
                dtAccesorios.Rows.RemoveAt(gvAccesorios.CurrentRow.Index);
                gvAccesorios.DataSource = dtAccesorios;
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