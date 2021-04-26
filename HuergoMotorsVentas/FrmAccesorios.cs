using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using HuergoMotors.Negocio;
using HuergoMotors.DTO;


namespace HuergoMotorsForms
{


    public partial class frmAccesorios : Form
    {
        AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();

        public frmAccesorios()
        {
            InitializeComponent();
        }
        
        private void btModificar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                CargarABM(HelperForms.Modo.Modificar);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para modificar",
                    "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarABM(HelperForms.Modo modo)
        {

            frmAccesoriosAlta accesoriosAlta = new frmAccesoriosAlta(modo);
            if (modo == HelperForms.Modo.Modificar)
            {
                accesoriosAlta.AccesorioSeleccionadoDTO = (AccesorioDTO)gv.SelectedRows[0].DataBoundItem;
                accesoriosAlta.CargarDatos();
            }
            accesoriosAlta.ShowDialog();

            if (accesoriosAlta.DialogResult == DialogResult.OK)
            {
                try
                {
                    CargarGridView(gv);
                }
                 
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btNuevo_Click(object sender, EventArgs e)
        {
            CargarABM(HelperForms.Modo.Agregar);
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                AccesorioDTO accesorioDTO = (AccesorioDTO)gv.SelectedRows[0].DataBoundItem;
                if (HelperForms.ConfirmacionEliminación
                    (accesorioDTO.Nombre, accesorioDTO.Tipo) == DialogResult.Yes)
                {
                    try
                    {
                        HelperForms.OperacionExitosa(this, HelperForms.Modo.Eliminar, accesoriosNegocio.
                            EliminarElemento(accesorioDTO.Id));
                        CargarGridView(gv);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para eliminar",
                    "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
           Close();
        }


        private void frmAccesorios_Load(object sender, EventArgs e)
        {
            try
            {
                gv.AutoGenerateColumns = false;
                CargarGridView(gv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picBusqueda_Click(object sender, EventArgs e)
        {
            try 
            {
                gv.DataSource = accesoriosNegocio.Buscar(txFiltro.Text);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picReload_Click(object sender, EventArgs e)
        {
            try
            {
                CargarGridView(gv);
                txFiltro.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public void CargarGridView(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = accesoriosNegocio.CargarTabla();
        }
    }
}



