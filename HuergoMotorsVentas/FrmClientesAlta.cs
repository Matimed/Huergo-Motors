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
    public partial class frmClientesAlta : Form
    {
        HuergoMotors.Negocio.ClientesAltaNegocio clientesAltaNegocio = new HuergoMotors.Negocio.ClientesAltaNegocio();
        public int Id { get; set; } //Esto es una 'propiedad'.
        public HelperForms.Modo Modo { get; private set; }

        public frmClientesAlta(HelperForms.Modo modo)
        {
            InitializeComponent();
            Modo = modo;
        }

        private void FrmClientesAlta_Load(object sender, EventArgs e)
        {

            //Saca el focus del textbox y lo pone en el label por estetica
            this.ActiveControl = labelTelefono;

            if (Modo == HelperForms.Modo.Agregar)
            {
                txtNombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtTelefono.Text = "0";
            }

        }
        internal void CargarDatos()
        {
            try
            {

                DataTable dt = clientesAltaNegocio.CargarTabla(Id);
            
                //ToDo: hacer validaciones y pasarlo a negocio
                string nombre = string.Empty;
                string direccion = string.Empty;
                string email = string.Empty;
                string telefono = string.Empty;

                if (!dt.Rows[0].IsNull("Nombre")) nombre = (string)dt.Rows[0]["Nombre"];
                if (!dt.Rows[0].IsNull("Direccion")) direccion = (string)dt.Rows[0]["Direccion"];
                if (!dt.Rows[0].IsNull("Email")) email = (string)dt.Rows[0]["Email"];
                if (!dt.Rows[0].IsNull("Telefono")) telefono = (string)dt.Rows[0]["Telefono"];

                txtEmail.Text = email;
                txtNombre.Text = nombre;
                txtDireccion.Text = direccion;
                txtTelefono.Text = telefono;
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
                HelperForms.ValidarTextosVacios(txtDireccion, txtEmail, txtNombre, txtTelefono);
                switch (Modo)
                {
                    case HelperForms.Modo.Modificar:
                        if (HelperForms.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            HelperForms.MostrarOperacionExitosa(this, Modo,clientesAltaNegocio.ModificarElemento
                                (txtNombre.Text,txtDireccion.Text,txtEmail.Text,txtTelefono.Text,Id));
                        }
                        break;
                    case HelperForms.Modo.Agregar:
                        HelperForms.MostrarOperacionExitosa(this, Modo,clientesAltaNegocio.AgregarElemento
                            (txtNombre.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text));
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
