using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuergoMotorsVentas
{
    public partial class frmVehiculosAlta : Form
    {
        public int Id { get; set; } //Esto es una 'propiedad'.

        public frmVehiculosAlta()
        {
            InitializeComponent();
        }

        private void frmVehiculosAlta_Load(object sender, EventArgs e)
        {

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

                if (!dt.Rows[0].IsNull("Tipo")) tipo = (string)dt.Rows[0]["Tipo"];
                if (!dt.Rows[0].IsNull("Modelo")) modelo = (string)dt.Rows[0]["Modelo"];
                if (!dt.Rows[0].IsNull("PrecioVenta")) precioVenta = (decimal)dt.Rows[0]["PrecioVenta"];

                txId.Text = Convert.ToString(id);
                txModelo.Text = modelo;
                txTipo.Text = tipo;
            
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
            var resp = MessageBox.Show("Los datos guardados se sobrescribiran ¿Esta seguro de que quiere continuar?",
                 "Sobresctibir los datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                try
                {
                    string update = $"UPDATE Vehiculos SET Tipo='{txTipo.Text}' WHERE Id={Id}";

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
    }
}
