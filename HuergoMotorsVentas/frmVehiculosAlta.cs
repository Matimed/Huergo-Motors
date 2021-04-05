﻿using System;
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
        public Helper.Modo Modo { get; private set; }

        public frmVehiculosAlta(Helper.Modo modo)
        {
            InitializeComponent();
            Modo = modo;

        }

        private void frmVehiculosAlta_Load(object sender, EventArgs e)
        {
            picLogo.Image = Image.FromFile("CapturaHuergoMotors.png");
            
            //Saca el focus del textbox y lo pone en el label por estetica
            this.ActiveControl = label1;

            if (Modo == Helper.Modo.agregar)
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
                if (!dt.Rows[0].IsNull("Stock")) stock = (int)dt.Rows[0]["Stock"];

                //Escribe el número con puntos en lugar de comas para no dar error en la DB en los decimal
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
                    Conexion($"UPDATE Vehiculos SET Tipo='{txtTipo.Text}', Modelo='{txtModelo.Text}', PrecioVenta='{txtPrecio.Text}'," +
                            $" Stock='{txtStock.Text}' WHERE Id={Id}");
                }

            }
            else if (Modo == Helper.Modo.agregar)
            {
                Conexion($"INSERT INTO Vehiculos (Tipo, Modelo, PrecioVenta, Stock) " +
                    $"VALUES ('{txtTipo.Text}', '{txtModelo.Text}', {txtPrecio.Text}, {txtStock.Text})");
            }
        }
    }
}

