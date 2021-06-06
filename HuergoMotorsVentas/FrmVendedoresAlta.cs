using HuergoMotors.DTO;
using System;
using System.Windows.Forms;

namespace HuergoMotorsForms
{
    public partial class frmVendedoresAlta : Form
    {
        HuergoMotors.Negocio.VendedoresNegocio vendedoresNegocio = new HuergoMotors.Negocio.VendedoresNegocio();
        public VendedoresDTO VendedorSeleccionadoDTO { get; set; }
        public int Id { get; set; }
        public HelperForms.Modo Modo { get; private set; }
        public frmVendedoresAlta(HelperForms.Modo modo)
        {
            InitializeComponent();
            Modo = modo;
        }


        private void frmVendedoresAlta_Load(object sender, EventArgs e)
        {
            //Saca el focus del textbox y lo pone en el label por estetica
            ActiveControl = LabelApellido;

            if (Modo == HelperForms.Modo.Agregar)
            {
                ActiveControl = txtNombre;
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtSucursal.Text = string.Empty;
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
                                vendedoresNegocio.ModificarElemento(HelperForms.GenerarDTO<VendedoresDTO>(Controls,Id)));
                        }
                        break;
                    case HelperForms.Modo.Agregar:
                        HelperForms.OperacionExitosa(this, Modo, 
                            vendedoresNegocio.AgregarElemento(HelperForms.GenerarDTO<VendedoresDTO>(Controls)));
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
