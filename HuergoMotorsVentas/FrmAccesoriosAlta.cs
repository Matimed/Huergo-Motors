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
    public partial class frmAccesoriosAlta : Form
    {
        HuergoMotors.DTO.AccesorioDTO accesorioDTO = 
            new HuergoMotors.DTO.AccesorioDTO();

        HuergoMotors.Negocio.AccesoriosAltaNegocio accesoriosAltaNegocio = 
            new HuergoMotors.Negocio.AccesoriosAltaNegocio();

        public int Id { get; set; } //Esto es una 'propiedad'.
        public HelperForms.Modo Modo { get; private set; }
        

        private void frmVehiculosAlta_Load(object sender, EventArgs e)
        {
            //Saca el focus del textbox y lo pone en el label por estetica
            this.ActiveControl = label1;
            HelperForms.CargarCombo(cboModelos, "SELECT Id, Modelo FROM Vehiculos", "Modelo");
            if (Modo == HelperForms.Modo.Agregar)
            {
                txtNombre.Text = string.Empty;
                txtTipo.Text = string.Empty;
                txtPrecio.Text = "0.00";
            }
        }


        public frmAccesoriosAlta(HelperForms.Modo modo)
        {
            InitializeComponent();
            Modo = modo;
        }



        internal void CargarDatos()
        {
            try
            {
                accesorioDTO.Id = Id;
                DataTable dt = accesoriosAltaNegocio.CaragarTabla(Id);
                accesoriosAltaNegocio.CargarDTO(dt, accesorioDTO);
                
                txtPrecio.Text = accesorioDTO.Precio.ToString(HuergoMotors.Negocio.HelperNegocio.nfi());
                txtTipo.Text = accesorioDTO.Tipo;
                txtNombre.Text = accesorioDTO.Nombre;
                int index = cboModelos.FindString(accesorioDTO.ModeloVehiculo);
                cboModelos.SelectedIndex = index;
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
                HelperForms.ValidarTextBoxVacios(txtNombre,txtPrecio,txtTipo);
                HelperForms.ValidarNumerosRacionales(txtPrecio);


                switch (Modo)
                {
                    case HelperForms.Modo.Modificar:
                        if (HelperForms.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            HelperForms.MostrarOperacionExitosa(this, Modo, accesoriosAltaNegocio.ModificarElemento
                                (txtTipo.Text, txtNombre.Text, txtPrecio.Text, (int)cboModelos.SelectedValue, Id));
                        }
                        break;
                    case HelperForms.Modo.Agregar:
                       
                        HelperForms.MostrarOperacionExitosa(this, Modo, accesoriosAltaNegocio.AgregarElemento
                                (txtTipo.Text, txtNombre.Text, txtPrecio.Text, (int)cboModelos.SelectedValue));
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
