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

            using (SqlDataAdapter da = new SqlDataAdapter("SELECT Sucursal FROM Vendedores WHERE ID=" + id, frmMDI.ConnectionString))
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
            using (frmClientes f = new frmClientes())
            {
                f.MostrarSeleccionar();

                if (f.ShowDialog() == DialogResult.OK)
                {
                    //ToDo: 
                    //Tirar un query a la tabla de Clientes usando el ID...
                    //f.IdSeleccionado 

                    //O aún mejor, devolver un objeto "Cliente" con todos los datos:
                    //Me estoy ahorrando ir nuevamente a la base de datos.
                    //Gano en performance y claridad del código.
                    LBNombre.Text = f.ClienteSeleccionado.Nombre;
                    LBEmail.Text = f.ClienteSeleccionado.Email;
                    LBTelefono.Text = f.ClienteSeleccionado.Telefono;
                }
                else
                {
                    LBNombre.Text = string.Empty;
                    LBEmail.Text = string.Empty;
                    LBTelefono.Text = string.Empty;
                }
            }
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            //ToDo: 
            //Validar que esten completos los campos de la pantalla.
            //Validar que haya Stock > 0.

            //Transacción:
            //Crear UN registro en la tabla "Venta".
            //Crear "N" registros en la tabla "VentasAccesorios".
            //Actualizar el Stock de la tabla "Vehiculo".

            try
            {
                using (SqlConnection conexion = new SqlConnection(frmMDI.ConnectionString))
                {
                    conexion.Open();

                    //INICIAR LA TRANSACCIÓN
                    //(hacer N operaciones)
                    using (SqlTransaction tran = conexion.BeginTransaction())
                    {
                        try
                        {
                            //Podemos tener un "cmd" para cada cosa o re-utilizar el mismo
                            //Lo importante es que queden "dentro" de la transacción.
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Transaction = tran;
                                cmd.Connection = conexion;

                                cmd.CommandText = "INSERT INTO ....";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = "UPDATE....";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = "DELETE....";
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Transaction = tran;
                                cmd.Connection = conexion;
                                cmd.CommandText = "INSERT INTO ....";
                                cmd.ExecuteNonQuery();
                            }

                            //-DARLA POR COMPLETADA (COMMIT)
                            tran.Commit();

                        }
                        catch (Exception)
                        {
                            //-CANCELARLA/DESHACERLA (ROLLBACK)
                            tran.Rollback();

                            //Podemos generar una nueva excepción "nuestra"...
                            //throw new Exception("Error en la transacción", ex);

                            //...o devolver la original.
                            throw;
                        }
                    }

                    //Mensaje de todo OK
                    MessageBox.Show("Su venta fué confirmada");
                }

            }
            catch (Exception ex)
            {
                //Mensaje de ERROR
                MessageBox.Show("Ocurrió un error." + ex.Message);
            }

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
                Helper.CargarCombos(cbVendedor, "SELECT Id, Nombre + ' ' + Apellido AS Vendedor FROM Vendedores", "Vendedor", "Id");
                Helper.CargarCombos(cbModelo, "SELECT Id, Modelo FROM Vehiculos", "Modelo", "Id");

            }
            catch (Exception)
            {
                //Aca es donde continua la ejecucion en caso de un error (Excepcion)
                throw;
            }
        }
    }
}