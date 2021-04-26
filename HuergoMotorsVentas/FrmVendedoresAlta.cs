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
    public partial class frmVendedoresAlta : Form
    {
        HuergoMotors.Negocio.VendedoresNegocio vendedoresNegocio = new HuergoMotors.Negocio.VendedoresNegocio();
        public HuergoMotors.DTO.VendedorDTO VendedorSeleccionadoDTO { get; set; }
        public HelperForms.Modo Modo { get; private set; }
        public frmVendedoresAlta(HelperForms.Modo modo)
        {
            InitializeComponent();
            Modo = modo;
        }


        private void frmVendedoresAlta_Load(object sender, EventArgs e)
        {
            //Saca el focus del textbox y lo pone en el label por estetica
            this.ActiveControl = LabelApellido;

            if (Modo == HelperForms.Modo.Agregar)
            {
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtSucursal.Text = string.Empty;
                VendedorSeleccionadoDTO = new HuergoMotors.DTO.VendedorDTO();
            }
        }
        internal void CargarDatos()
        {
            try
            {
                txtSucursal.Text = VendedorSeleccionadoDTO.Sucursal;
                txtNombre.Text = VendedorSeleccionadoDTO.Nombre;
                txtApellido.Text = VendedorSeleccionadoDTO.Apellido;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                VendedorSeleccionadoDTO = vendedoresNegocio.CargarDTO(VendedorSeleccionadoDTO.Id,
                    txtNombre.Text, txtApellido.Text, txtSucursal.Text);
                switch (Modo)
                {
                    case HelperForms.Modo.Modificar:
                        if (HelperForms.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            HelperForms.OperacionExitosa(this, Modo,
                                vendedoresNegocio.ModificarElemento(VendedorSeleccionadoDTO));
                        }
                        break;
                    case HelperForms.Modo.Agregar:
                        HelperForms.OperacionExitosa(this, Modo, 
                            vendedoresNegocio.AgregarElemento(VendedorSeleccionadoDTO));
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
