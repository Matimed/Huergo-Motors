using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace HuergoMotorsVentas
{


    public partial class frmAccesorios : Form
    {
        private static string AccesoriosSelect = "SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
            "FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id;";

        public frmAccesorios()
        {
            InitializeComponent();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                CargarABM(Helper.Modo.Modificar);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para modificar",
                    "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarABM(Helper.Modo modo)
        {

            frmAccesoriosAlta f = new frmAccesoriosAlta(modo);
            if (modo == Helper.Modo.Modificar)
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];
                f.CargarDatos(id);
            }
            f.ShowDialog();

            if (f.DialogResult == DialogResult.OK)
            {
                gv.DataSource = Helper.CargarDataTable(AccesoriosSelect);
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
                string nombre = (string)((DataRowView)item)["Nombre"];
                if (Helper.ConfirmacionEliminación(nombre, tipo) == DialogResult.Yes)
                {
                    Helper.Conexion(this, Helper.Modo.Eliminar, $"DELETE FROM Accesorios Where Id={id} ");
                    gv.DataSource = Helper.CargarDataTable(AccesoriosSelect);
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


        private void frmAccesorios_Load(object sender, EventArgs e)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = Helper.CargarDataTable(AccesoriosSelect);
        }

        private void picBusqueda_Click(object sender, EventArgs e)
        {
            string filtro = $"SELECT a.Id, a.Nombre, a.Tipo, a.Precio, a.IdVehiculo, b.Modelo " +
                    $"FROM Accesorios a JOIN Vehiculos b ON a.IdVehiculo = b.Id " +
                    $"WHERE a.Tipo LIKE '%{txFiltro.Text}%' or a.Nombre LIKE '%{txFiltro.Text}%' or a.Precio " +
                    $"LIKE '%{txFiltro.Text}%' or b.Modelo LIKE '%{txFiltro.Text}%'";
            gv.DataSource = Helper.CargarDataTable(filtro);
            txFiltro.Text = "";
        }

        private void picReload_Click(object sender, EventArgs e)
        {
            gv.DataSource = Helper.CargarDataTable(AccesoriosSelect);
            txFiltro.Text = "";
        }
    }
}



