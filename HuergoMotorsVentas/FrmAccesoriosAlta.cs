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
    public partial class frmAccesoriosAlta : Form
    {
        public int Id { get; set; } //Esto es una 'propiedad'.
        public string Modo { get; private set; }
        private void frmVehiculosAlta_Load(object sender, EventArgs e)
        {
            picLogo.Image = Image.FromFile("CapturaHuergoMotors.png");

            //Saca el focus del textbox y lo pone en el label por estetica
            this.ActiveControl = label1;

            if (Modo == "agregar")
            {
                txtNombre.Text = string.Empty;
                txtTipo.Text = string.Empty;
                txtPrecio.Text = "0.00";
                
            }
        }

        public frmAccesoriosAlta(string modo)
        {
            InitializeComponent(); 
            Modo = modo;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
      
        internal void CargarDatos(int id)
        {
            try
            {
                Id = id;
                string query = $"SELECT * FROM Accesorios WHERE Id={id}";

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(query, frmMDI.ConnectionString))
                {
                    da.Fill(dt);
                }

                string tipo = string.Empty;
                string nombre = string.Empty;
                decimal precio = 0;


                if (!dt.Rows[0].IsNull("Tipo")) tipo = (string)dt.Rows[0]["Tipo"];
                if (!dt.Rows[0].IsNull("Nombre")) nombre = (string)dt.Rows[0]["Nombre"];
                if (!dt.Rows[0].IsNull("Precio")) precio = (decimal)dt.Rows[0]["Precio"];


                //Escribe el número con puntos en lugar de comas para no dar error en la DB
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";

                txtPrecio.Text = precio.ToString(nfi);
                txtTipo.Text = tipo;
                txtNombre.Text = nombre;
                
            }
            catch (Exception ex)
            {
                //El bloque Try-Catch me permite capturar errores (excepciones) en el código, y en este caso mostrar un mensaje.
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Conexion(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(frmMDI.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int result = cmd.ExecuteNonQuery();
                    if (Modo == "agregar")
                    {
                        MessageBox.Show($"{result} registro/s agregados correctamente",
                        "Los registros fueron agregados exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (Modo == "modificar")
                    {
                        MessageBox.Show($"{result} registro/s actualizados correctamente",
                        "Actualización completada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
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
                DialogResult resp = MessageBox.Show("Los datos guardados se sobrescribiran ¿Esta seguro de que quiere continuar?",
                                 "Sobrescribir los datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    Conexion($"UPDATE Accesorios SET Nombre='{txtNombre.Text}', Tipo='{txtTipo.Text}', Precio='{txtPrecio.Text}' WHERE Id={Id}");
                }

            }
            else if (Modo == "agregar")
            {
                Conexion($"INSERT INTO Accesorios (Nombre, Tipo, Precio, IdVehiculo)" +
                    $" VALUES ('{txtNombre.Text}', '{txtTipo.Text}', '{txtPrecio.Text}', '{txtIdVehiculo.Text}')");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
