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

        public AccesoriosRDTO AccesorioSeleccionadoDTO { get; set; }
        
        public HelperForms.Modo Modo { get; private set; }
        

        private void frmVehiculosAlta_Load(object sender, EventArgs e)
        {
            try
            {
                //Saca el focus del textbox y lo pone en el label por estetica
                ActiveControl = label1;

                if (Modo == HelperForms.Modo.Agregar)
                {
                    HelperForms.DisplayCombo(cboModelos, "Modelo");
                    cboModelos.DataSource = vehiculosNegocio.CargarTabla();
                    txtNombre.Text = string.Empty;
                    txtTipo.Text = string.Empty;
                    txtPrecio.Text = "0.00";
                    AccesorioSeleccionadoDTO = new HuergoMotors.DTO.AccesoriosRDTO();
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
                txtPrecio.Text = AccesorioSeleccionadoDTO.Precio.ToString();
                txtTipo.Text = AccesorioSeleccionadoDTO.Tipo;
                txtNombre.Text = AccesorioSeleccionadoDTO.Nombre;
                HelperForms.DisplayCombo(cboModelos, "Modelo");
                cboModelos.DataSource = vehiculosNegocio.CargarTabla();
                cboModelos.SelectedValue = AccesorioSeleccionadoDTO.IdVehiculo;
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
                HelperForms.ValidarTextosVacios(cboModelos.Text, txtPrecio.Text, txtNombre.Text, txtTipo.Text);
                HelperForms.ValidarID(AccesorioSeleccionadoDTO.Id);
                AccesoriosDTO nuevoAccesorio = accesoriosNegocio.CargarDTO(AccesorioSeleccionadoDTO.Id, (int)cboModelos.SelectedValue, 
                    HelperForms.ConvertirNumeroRacional(txtPrecio.Text), txtNombre.Text, txtTipo.Text);

                switch (Modo)
                {
                    case HelperForms.Modo.Modificar:
                        if (HelperForms.ConfirmacionModificacion() == DialogResult.Yes)
                        {
                            HelperForms.OperacionExitosa
                                (this, Modo, accesoriosNegocio.ModificarElemento (nuevoAccesorio));
                        }
                        break;
                    case HelperForms.Modo.Agregar:
                       
                        HelperForms.OperacionExitosa
                            (this, Modo, accesoriosNegocio.AgregarElemento(nuevoAccesorio));
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
