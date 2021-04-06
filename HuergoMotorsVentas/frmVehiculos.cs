using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace HuergoMotorsVentas
{
    
    public partial class frmVehiculos : Form
    {
        private new const string Select = "SELECT * FROM Vehiculos";
        public frmVehiculos()
        {
            InitializeComponent();
        }

        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource =  Helper.CargarDataTable(Select);
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                 Helper.Modo modo = Helper.Modo.Modificar; 
                CargarABM(modo);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para modificar",
                    "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarABM(Helper.Modo modo)
        {

            frmVehiculosAlta f = new frmVehiculosAlta(modo);
            if (modo == Helper.Modo.Modificar)
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];
                f.CargarDatos(id);
            }
            f.ShowDialog();
            //Solo recargo datos si se cerró con un OK.
            if (f.DialogResult == DialogResult.OK)
            {
                gv.DataSource = Helper.CargarDataTable(Select);
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            CargarABM(Helper.Modo.Agregar);
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];
                string tipo = (string)((DataRowView)item)["Tipo"];
                if (Helper.ConfirmacionEliminación(tipo) == DialogResult.Yes)
                {
                    Helper.Conexion(this, Helper.Modo.Eliminar, $"DELETE FROM Vehiculos Where Id={id} ");
                    gv.DataSource = Helper.CargarDataTable(Select);
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
            this.Close();
        }

        //Filtro
        private void picBusqueda_Click(object sender, EventArgs e)
        {
            string filtro = $"SELECT * FROM Vehiculos WHERE Tipo LIKE '%{txFiltro.Text}%'" +
                 $" or Modelo LIKE '%{txFiltro.Text}%' or PrecioVenta LIKE '%{txFiltro.Text}%' ";
            gv.DataSource = Helper.CargarDataTable(filtro);
            txFiltro.Text = "";
        }

        private void picReload_Click(object sender, EventArgs e)
        {
            gv.DataSource = Helper.CargarDataTable(Select);
            txFiltro.Text = "";
        }
    }
}
