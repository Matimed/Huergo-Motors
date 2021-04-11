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
    public partial class frmVendedoresAlta : Form
    {
        public int Id { get; set; } //Esto es una 'propiedad'.
        public Helper.Modo Modo { get; private set; }
        public frmVendedoresAlta(Helper.Modo modo)
        {
            InitializeComponent();
            Modo = modo;
        }


        private void frmVendedoresAlta_Load(object sender, EventArgs e)
        {
            //Saca el focus del textbox y lo pone en el label por estetica
            this.ActiveControl = LabelApellido;

            if (Modo == Helper.Modo.Agregar)
            {
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtSucursal.Text = string.Empty;

            }
        }
        internal void CargarDatos(int id)
        {
            try
            {
                Id = id;
                string query = $"SELECT * FROM Vendedores WHERE Id={id}";

                DataTable dt = Helper.CargarDataTable(query);

                string nombre = string.Empty;
                string apellido = string.Empty;
                string sucursal = string.Empty;

                if (!dt.Rows[0].IsNull("Nombre")) nombre = (string)dt.Rows[0]["Nombre"];
                if (!dt.Rows[0].IsNull("Apellido")) apellido = (string)dt.Rows[0]["Apellido"];
                if (!dt.Rows[0].IsNull("Sucursal")) sucursal = (string)dt.Rows[0]["Sucursal"];

                //Escribe el número con puntos en lugar de comas para no dar error en la DB
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";

                txtSucursal.Text = sucursal;
                txtNombre.Text = nombre;
                txtApellido.Text = apellido;
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
                Helper.ValidarTextosVacios(txtApellido,txtNombre,txtSucursal);
                switch (Modo)
                {
                    case Helper.Modo.Modificar:
                        if (Helper.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            Helper.EditarDB(this, Modo, $"UPDATE Vendedores SET Nombre='{txtNombre.Text}', " +
                                $"Apellido='{txtApellido.Text}', Sucursal='{txtSucursal.Text}' WHERE Id={Id}");
                        }
                        break;
                    case Helper.Modo.Agregar:
                        Helper.EditarDB(this, Modo, $"INSERT INTO Vendedores (Nombre, Apellido, Sucursal) VALUES" +
                            $" ('{txtNombre.Text}', '{txtApellido.Text}', '{txtSucursal.Text}')");
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
