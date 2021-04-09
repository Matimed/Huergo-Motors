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
        public Helper.Modo Modo { get; private set; }

        private void frmVehiculosAlta_Load(object sender, EventArgs e)
        {
            //Saca el focus del textbox y lo pone en el label por estetica
            this.ActiveControl = label1;
            Helper.CargarCombo(cboModelos, "SELECT Id, Modelo FROM Vehiculos", "Modelo", "Id");
            if (Modo == Helper.Modo.Agregar)
            {
                txtNombre.Text = string.Empty;
                txtTipo.Text = string.Empty;
                txtPrecio.Text = "0.00";
            }
        }


        public frmAccesoriosAlta(Helper.Modo modo)
        {
            InitializeComponent();
            Modo = modo;
        }



        internal void CargarDatos(int id)
        {
            try
            {
                Id = id;
                string query = $"SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
                    $"FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id WHERE a.Id={id}";

                DataTable dt = Helper.CargarDataTable(query);

                string tipo = string.Empty;
                string nombre = string.Empty;
                decimal precio = 0;
                string modelo = string.Empty;


                if (!dt.Rows[0].IsNull("Tipo")) tipo = (string)dt.Rows[0]["Tipo"];
                if (!dt.Rows[0].IsNull("Nombre")) nombre = (string)dt.Rows[0]["Nombre"];
                if (!dt.Rows[0].IsNull("Precio")) precio = (decimal)dt.Rows[0]["Precio"];
                if (!dt.Rows[0].IsNull("Modelo")) modelo = (string)dt.Rows[0]["Modelo"];


                //Escribe el número con puntos en lugar de comas para no dar error en la DB
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";

                txtPrecio.Text = precio.ToString(nfi);
                txtTipo.Text = tipo;
                txtNombre.Text = nombre;
                int index = cboModelos.FindString(modelo);
                cboModelos.SelectedIndex = index;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        } 

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.ValidarTextosVacios(txtNombre,txtPrecio,txtTipo);
                Helper.ValidarNumerosRacionales(txtPrecio);
                int idVehiculo = (int)(cboModelos.SelectedValue);
                switch (Modo)
                {
                    case Helper.Modo.Modificar:
                        if (Helper.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            Helper.Conexion(this, Modo, $"UPDATE Accesorios SET Nombre='{txtNombre.Text}', Tipo='{txtTipo.Text}'," +
                                $" Precio='{txtPrecio.Text}', IdVehiculo= '{idVehiculo}' WHERE Id={Id}");
                        }
                        break;
                    case Helper.Modo.Agregar:
                        Helper.Conexion(this, Modo, $"INSERT INTO Accesorios (Nombre, Tipo, Precio, IdVehiculo)" +
                        $" VALUES ('{txtNombre.Text}', '{txtTipo.Text}', '{txtPrecio.Text}', '{idVehiculo}')");
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
