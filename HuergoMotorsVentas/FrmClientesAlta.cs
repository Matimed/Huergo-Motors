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
    public partial class frmClientesAlta : Form
    {
        public int Id { get; set; } //Esto es una 'propiedad'.
        public Helper.Modo Modo { get; private set; }
        
        public frmClientesAlta(Helper.Modo modo)
        {
            InitializeComponent();
            Modo = modo;
        }

        private void FrmClientesAlta_Load(object sender, EventArgs e)
        {
            picLogo.Image = Image.FromFile("CapturaHuergoMotors.png");

            //Saca el focus del textbox y lo pone en el label por estetica
            this.ActiveControl = labelTelefono;

            if (Modo == Helper.Modo.agregar)
            {
                txtNombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtTelefono.Text = "0";
            }

        }
        internal void CargarDatos(int id)
        {
            try
            {
                Id = id;
                string query = $"SELECT * FROM Clientes WHERE Id={id}";

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(query, frmMDI.ConnectionString))
                {
                    da.Fill(dt);
                }

                string nombre = string.Empty;
                string direccion = string.Empty;
                string email = string.Empty;
                string telefono = string.Empty;

                if (!dt.Rows[0].IsNull("Nombre")) nombre = (string)dt.Rows[0]["Nombre"];
                if (!dt.Rows[0].IsNull("Direccion")) direccion = (string)dt.Rows[0]["Direccion"];
                if (!dt.Rows[0].IsNull("Email")) email = (string)dt.Rows[0]["Email"];
                if (!dt.Rows[0].IsNull("Telefono")) telefono = (string)dt.Rows[0]["Telefono"];

                //Escribe el número con puntos en lugar de comas para no dar error en la DB
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";

                txtEmail.Text = email;
                txtNombre.Text = nombre;
                txtDireccion.Text = direccion;
                txtTelefono.Text = telefono;
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
                    Helper.OperacionExitosa(Modo, result);
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
            if (Modo == Helper.Modo.modificar)
            {
                DialogResult resp = MessageBox.Show("Los datos guardados se sobrescribiran ¿Esta seguro de que quiere continuar?",
                                 "Sobresctibir los datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    Conexion($"UPDATE Clientes SET Nombre='{txtNombre.Text}', Direccion='{txtDireccion.Text}', Email='{txtEmail.Text}'," +
                            $" Telefono='{txtTelefono.Text}' WHERE Id={Id}");
                }

            }
            else if (Modo == Helper.Modo.agregar)
            {
                Conexion($"INSERT INTO Clientes (Nombre, Direccion, Email, Telefono) " +
                    $"VALUES ('{txtNombre.Text}', '{txtDireccion.Text}', '{txtEmail.Text}', '{txtTelefono.Text}')");
            }
        }
    }
}
