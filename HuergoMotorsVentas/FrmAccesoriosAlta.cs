using HuergoMotors.DTO;
using System;
using System.Windows.Forms;

namespace HuergoMotorsForms
{
    public partial class frmAccesoriosAlta : Form
    {
        
        HuergoMotors.Negocio.AccesoriosNegocio accesoriosNegocio = 
            new HuergoMotors.Negocio.AccesoriosNegocio();

        HuergoMotors.Negocio.VehiculosNegocio vehiculosNegocio =
            new HuergoMotors.Negocio.VehiculosNegocio();

        public int Id { get; set; }
        public AccesoriosDTO AccesorioSeleccionadoDTO { get; set; }
        
        public HelperForms.Modo Modo { get; private set; }
        

        private void frmVehiculosAlta_Load(object sender, EventArgs e)
        {
            try
            {
                //Saca el focus del textbox y lo pone en el label por estetica
                ActiveControl = label1;

                if (Modo == HelperForms.Modo.Agregar)
                {
                    ActiveControl = txtNombre;
                    HelperForms.DisplayCombo(cboVehiculos, "Modelo");
                    cboVehiculos.DataSource = vehiculosNegocio.CargarTabla();
                    txtNombre.Text = string.Empty;
                    txtTipo.Text = string.Empty;
                    txtPrecio.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                HelperForms.DisplayCombo(cboVehiculos, "Modelo");
                cboVehiculos.DataSource = vehiculosNegocio.CargarTabla();
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
                HelperForms.VerificarCombosCargados(cboVehiculos);
                switch (Modo)
                {
                    case HelperForms.Modo.Modificar:
                        if (HelperForms.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            HelperForms.OperacionExitosa
                                (this, Modo, accesoriosNegocio.ModificarElemento (HelperForms.GenerarDTO<AccesoriosDTO>(Controls,Id)));
                        }
                        break;
                    case HelperForms.Modo.Agregar:
                       
                        HelperForms.OperacionExitosa
                            (this, Modo, accesoriosNegocio.AgregarElemento(HelperForms.GenerarDTO<AccesoriosDTO>(Controls)));
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
