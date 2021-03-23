using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace HuergoMotorsVentas
{

    public partial class frmVehiculos : Form
    {
        public frmVehiculos()
        {
            InitializeComponent();
        }

        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            gv.AutoGenerateColumns = false;

            RecargarDatos();
        }

        private void RecargarDatos()
        {
            //Implementar filtros...
            string query = "SELECT * FROM Vehiculos";
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(query, frmMDI.ConnectionString))
            {
                da.Fill(dt);
            }

            gv.DataSource = dt;
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];

                frmVehiculosAlta f = new frmVehiculosAlta();
                f.CargarDatos(id);
                f.ShowDialog();

                //Solo recargo datos si se cerró con un OK.
                if (f.DialogResult == DialogResult.OK)
                {
                    RecargarDatos();
                }
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            //ToDo: Implementar "Nuevo"
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            //ToDo: Implementar "Eliminar" (y MessageBox para pedir confirmación).
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
