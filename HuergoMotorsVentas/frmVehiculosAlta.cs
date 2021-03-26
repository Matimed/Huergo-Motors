using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuergoMotorsVentas
{
    public partial class frmVehiculosAlta : Form
    {
        public int Id { get; set; } //Esto es una 'propiedad'.
        public string Modo { get; private set; }

        public frmVehiculosAlta(string modo)
        {
            InitializeComponent();
            Modo = modo;
        }

        private void frmVehiculosAlta_Load(object sender, EventArgs e)
        {
            
            //Saca el focus del textbox y lo pone en el label por estetica
            this.ActiveControl = label1;
        }
     
        internal void CargarDatos(int id)
        {
            try
            {
                Id = id;
                string query = $"SELECT * FROM Vehiculos WHERE Id={id}";

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(query, frmMDI.ConnectionString))
                {
                    da.Fill(dt);
                }

                string tipo = string.Empty;
                string modelo = string.Empty;
                decimal precioVenta = 0;
                int stock = 0;

                if (!dt.Rows[0].IsNull("Tipo")) tipo = (string)dt.Rows[0]["Tipo"];
                if (!dt.Rows[0].IsNull("Modelo")) modelo = (string)dt.Rows[0]["Modelo"];
                if (!dt.Rows[0].IsNull("PrecioVenta")) precioVenta = (decimal)dt.Rows[0]["PrecioVenta"];
                if (!dt.Rows[0].IsNull("PrecioVenta")) stock = (int)dt.Rows[0]["Stock"];

                //Escribe el número con puntos en lugar de comas para no dar error en la DB
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";

                txtPrecio.Text = precioVenta.ToString(nfi);
                txtModelo.Text = modelo;
                txtTipo.Text = tipo;
                txtStock.Text = stock.ToString();
            }
            catch (Exception ex)
            {
                //El bloque Try-Catch me permite capturar errores (excepciones) en el código, y en este caso mostrar un mensaje.
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == "modificar")
            {
                var resp = MessageBox.Show("Los datos guardados se sobrescribiran ¿Esta seguro de que quiere continuar?",
                                 "Sobresctibir los datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    try
                    {
                        string update = $"UPDATE Vehiculos SET Tipo='{txtTipo.Text}', Modelo='{txtModelo.Text}', PrecioVenta='{txtPrecio.Text}'," +
                            $" Stock='{txtStock.Text}' WHERE Id={Id}";

                        //ToDo: Utilizar bloques 'using' =)
                        using (SqlConnection conn = new SqlConnection(frmMDI.ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(update, conn);
                            int result = cmd.ExecuteNonQuery();
                            MessageBox.Show($"{result} registro/s actualizados correctamente",
                            "Actualización correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };
                        //Al setear el DialogResult se cierra el formulario.
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        //El bloque Try-Catch me permite capturar errores (excepciones) en el código, y en este caso mostrar un mensaje.
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (Modo == "agregar")
            {
                //ToDo: Agregar el insert
            }


        }
    }
}
