using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using HuergoMotors.Negocio;


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
                object item = gv.SelectedRows[0].DataBoundItem;
                accesoriosAlta.Id = (int)((DataRowView)item)["Id"];
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
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
                object item = gv.SelectedRows[0].DataBoundItem;
                if (HelperForms.ConfirmacionEliminación
                    ((string)((DataRowView)item)["Nombre"], (string)((DataRowView)item)["Tipo"]) == DialogResult.Yes)
                {
                    try
                    {
                        HelperForms.OperacionExitosa(this, HelperForms.Modo.Eliminar, accesoriosNegocio.
                            EliminarElemento((int)((DataRowView)item)["Id"]));
                        CargarGridView(gv);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            } 
        }

        public void CargarGridView(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = accesoriosNegocio.CargarTabla();
        }
    }
}



