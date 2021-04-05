using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace HuergoMotorsVentas
{
    public partial class frmClientes : Form
    {
        private static string ClientesSelect = "SELECT * FROM Clientes";
        public frmClientes()
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

            frmClientesAlta f = new frmClientesAlta(modo);
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
                gv.DataSource = Helper.CargarDataTable(ClientesSelect);
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            gv.AutoGenerateColumns = false;
            gv.DataSource = Helper.CargarDataTable(ClientesSelect);
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picBoxlupa_Click(object sender, EventArgs e)
        {
            string filtro = $"SELECT * FROM Clientes WHERE Nombre LIKE '%{txFiltro.Text}%'" +
                 $" or Direccion LIKE '%{txFiltro.Text}%' or Telefono LIKE '%{txFiltro.Text}%' or Email LIKE '%{txFiltro.Text}%'";
            gv.DataSource = Helper.CargarDataTable(filtro);
            txFiltro.Text = "";
        }

        private void picboxReload_Click(object sender, EventArgs e)
        {
            gv.DataSource = Helper.CargarDataTable(ClientesSelect);
            txFiltro.Text = "";
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
                string nombre = (string)((DataRowView)item)["Nombre"];
                DialogResult resp = MessageBox.Show("Seguro que desea borrar a " + nombre + "? Esta operacion no se puede revertir",
                    "Eliminar permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    try
                    {
                        string delete = $"DELETE FROM Clientes Where Id={id} ";

                        //Recordar: Utilizar bloques 'using'
                        using (SqlConnection conn = new SqlConnection(frmMDI.ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(delete, conn);
                            int result = cmd.ExecuteNonQuery();
                            gv.DataSource = Helper.CargarDataTable(ClientesSelect);
                            MessageBox.Show($"{result} registro/s eliminados correctamente",
                            "Eliminacion completada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };

                    }
                    catch (Exception ex)
                    {
                        //El bloque Try-Catch me permite capturar errores (excepciones) en el código, y en este caso mostrar un mensaje.
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para eliminar",
                    "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
    }
}
