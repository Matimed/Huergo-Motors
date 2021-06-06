using HuergoMotors.DTO;
using System;
using System.Windows.Forms;

namespace HuergoMotorsForms
{
    public partial class frmVehiculosAlta : Form
    {
        HuergoMotors.Negocio.VehiculosNegocio vehiculosNegocio = new HuergoMotors.Negocio.VehiculosNegocio();
        public VehiculosDTO VehiculoSeleccionadoDTO {get; set;}
        public HelperForms.Modo Modo { get; private set; }

        public frmVehiculosAlta(HelperForms.Modo modo)
        {
            InitializeComponent();
            Modo = modo;
        }

        private void frmVehiculosAlta_Load(object sender, EventArgs e)
        {
            //Saca el focus del textbox y lo pone en el label por estetica
            ActiveControl = label1;

            if (Modo == HelperForms.Modo.Agregar)
            {
                ActiveControl = txtTipo;
                // Vaciar todos los txtbox
                txtModelo.Text = string.Empty;
                txtTipo.Text = string.Empty;
                txtPrecioVenta.Text = "0.00";
                txtStock.Text = "0";
            }
        }

        internal void CargarDatos()
        {
            try
            {
                txtPrecioVenta.Text = VehiculoSeleccionadoDTO.PrecioVenta.ToString();
                txtModelo.Text = VehiculoSeleccionadoDTO.Modelo;
                txtTipo.Text = VehiculoSeleccionadoDTO.Tipo;
                txtStock.Text = VehiculoSeleccionadoDTO.Stock.ToString();
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
                switch (Modo)
                {
                    case HelperForms.Modo.Modificar:
                        if (HelperForms.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            HelperForms.OperacionExitosa(this, Modo, 
                                vehiculosNegocio.ModificarElemento(HelperForms.GenerarDTO(Controls, VehiculoSeleccionadoDTO)));
                        }
                        break;
                    case HelperForms.Modo.Agregar:
                        HelperForms.OperacionExitosa(this, Modo,
                            vehiculosNegocio.AgregarElemento(HelperForms.GenerarDTO<VehiculosDTO>(Controls)));
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

