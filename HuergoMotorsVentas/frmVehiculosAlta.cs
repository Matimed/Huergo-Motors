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
        HuergoMotors.Negocio.VehiculosNegocio vehiculosNegocio = new HuergoMotors.Negocio.VehiculosNegocio();
        public HuergoMotors.DTO.VehiculoDTO VehiculoSeleccionadoDTO {get; set;}
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
                VehiculoSeleccionadoDTO = new HuergoMotors.DTO.VehiculoDTO();
            }
        }

        internal void CargarDatos()
        {
            try
            {
                VehiculoSeleccionadoDTO = vehiculosNegocio.CargarTabla(Id);

                txtPrecio.Text = VehiculoSeleccionadoDTO.PrecioVenta.ToString(HuergoMotors.Negocio.HelperNegocio.NFI());
                txtModelo.Text = VehiculoSeleccionadoDTO.Modelo;
                txtTipo.Text = VehiculoSeleccionadoDTO.Tipo;
                txtStock.Text = VehiculoSeleccionadoDTO.Stock.ToString();
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
                vehiculosNegocio.CargarDTO(VehiculoSeleccionadoDTO.Id,
                    txtModelo.Text, txtPrecio.Text, txtStock.Text, txtTipo.Text);
                switch (Modo)
                {
                    case HelperForms.Modo.Modificar:
                        if (HelperForms.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            HelperForms.OperacionExitosa(this, Modo, 
                                vehiculosNegocio.ModificarElemento(VehiculoSeleccionadoDTO));
                        }
                        break;
                    case HelperForms.Modo.Agregar:
                        HelperForms.OperacionExitosa(this, Modo,
                            vehiculosNegocio.AgregarElemento(VehiculoSeleccionadoDTO));
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

