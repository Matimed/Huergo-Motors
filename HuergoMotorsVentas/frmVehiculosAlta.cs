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

namespace HuergoMotorsForms
{
    public partial class frmVehiculosAlta : Form
    {
        public int Id { get; set; } //Esto es una 'propiedad'.
        public HelperForms.Modo Modo { get; private set; }

        public frmVehiculosAlta(HelperForms.Modo modo)
        {
            InitializeComponent();
            Modo = modo;
        }

        private void frmVehiculosAlta_Load(object sender, EventArgs e)
        {
            //Saca el focus del textbox y lo pone en el label por estetica
            this.ActiveControl = label1;

            if (Modo == HelperForms.Modo.Agregar)
            {
                // Vaciar todos los txtbox
                txtModelo.Text = string.Empty;
                txtTipo.Text = string.Empty;
                txtPrecio.Text = "0.00";
                txtStock.Text = "0";
            }
        }

        internal void CargarDatos(int id)
        {
            Id = id;
            string query = $"SELECT * FROM Vehiculos WHERE Id={id}";
            try
            {
                DataTable dt = HelperForms.CargarDataTable(query);
                string tipo = string.Empty;
                string modelo = string.Empty;
                decimal precioVenta = 0;
                int stock = 0;
                if (!dt.Rows[0].IsNull("Tipo")) tipo = (string)dt.Rows[0]["Tipo"];
                if (!dt.Rows[0].IsNull("Modelo")) modelo = (string)dt.Rows[0]["Modelo"];
                if (!dt.Rows[0].IsNull("PrecioVenta")) precioVenta = (decimal)dt.Rows[0]["PrecioVenta"];
                if (!dt.Rows[0].IsNull("Stock")) stock = (int)dt.Rows[0]["Stock"];

                txtPrecio.Text = precioVenta.ToString(HelperForms.nfi());
                txtModelo.Text = modelo;
                txtTipo.Text = tipo;
                txtStock.Text = stock.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

       
        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                HelperForms.ValidarTextosVacios(txtModelo, txtPrecio, txtStock, txtTipo);
                HelperForms.ValidarNumerosNaturales(txtStock);
                HelperForms.ValidarNumerosRacionales(txtPrecio);
                switch (Modo)
                {
                    case HelperForms.Modo.Modificar:
                        if (HelperForms.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            HelperForms.EditarDB(this, Modo, $"UPDATE Vehiculos SET Tipo='{txtTipo.Text}', Modelo='{txtModelo.Text}', PrecioVenta='{txtPrecio.Text}'," +
                                    $" Stock='{txtStock.Text}' WHERE Id={Id}");
                        }
                        break;
                    case HelperForms.Modo.Agregar:
                        HelperForms.EditarDB(this, Modo, $"INSERT INTO Vehiculos (Tipo, Modelo, PrecioVenta, Stock) " +
                        $"VALUES ('{txtTipo.Text}', '{txtModelo.Text}', {txtPrecio.Text}, {txtStock.Text})");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}

