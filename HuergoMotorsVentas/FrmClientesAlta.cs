﻿using HuergoMotors.DTO;
using System;
using System.Windows.Forms;
namespace HuergoMotorsForms
{
    public partial class frmClientesAlta : Form
    {
        HuergoMotors.Negocio.ClientesNegocio clientesNegocio = new HuergoMotors.Negocio.ClientesNegocio();
        public ClientesDTO ClienteSeleccionadoDTO { get; set; }
        public HelperForms.Modo Modo { get; private set; }

        public frmClientesAlta(HelperForms.Modo modo)
        {
            InitializeComponent();
            Modo = modo;
        }

        private void FrmClientesAlta_Load(object sender, EventArgs e)
        {
            //Saca el focus del textbox y lo pone en el label por estetica
            ActiveControl = labelTelefono;

            if (Modo == HelperForms.Modo.Agregar)
            {
                ActiveControl = txtNombre;
                txtNombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                ClienteSeleccionadoDTO = new ClientesDTO();
            }

        }
        internal void CargarDatos()
        {
            try
            {
                txtEmail.Text = ClienteSeleccionadoDTO.Email;
                txtNombre.Text = ClienteSeleccionadoDTO.Nombre;
                txtDireccion.Text = ClienteSeleccionadoDTO.Direccion;
                txtTelefono.Text = ClienteSeleccionadoDTO.Telefono;
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
                HelperForms.ValidarTextosVacios(txtNombre.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text);
                HelperForms.ValidarEmail(txtEmail.Text);
                HelperForms.ValidarTelefono(txtTelefono.Text);
                HelperForms.ValidarID(ClienteSeleccionadoDTO.Id);
                ClientesDTO nuevoCliente = clientesNegocio.CargarDTO(ClienteSeleccionadoDTO.Id, 
                    txtNombre.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text);

                switch (Modo)
                {
                    case HelperForms.Modo.Modificar:
                        if (HelperForms.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            HelperForms.OperacionExitosa(this, Modo, clientesNegocio.
                                ModificarElemento(nuevoCliente));
                        }
                        break;
                    case HelperForms.Modo.Agregar:
                        HelperForms.OperacionExitosa(this, Modo, clientesNegocio.
                            AgregarElemento(nuevoCliente));
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
