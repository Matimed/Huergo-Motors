using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace HuergoMotorsVentas
{

    public partial class frmVehiculos : Form
    {
        const string Select = "SELECT * FROM Vehiculos";
        public frmVehiculos()
        {
            InitializeComponent();
        }


        
        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            gv.AutoGenerateColumns = false;
            RecargarDatos(Select);

        }
        //este es la parte que se recarga la tabla
        private void RecargarDatos(string query)
        {
            
            
           
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
                CargarABM("modificar");
            }
            else
            { 
                MessageBox.Show("Debe seleccionar un elemento para modificar",
                    "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarABM(string modo)
        {

            frmVehiculosAlta f = new frmVehiculosAlta(modo);
            if (modo == "modificar")
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];
                f.CargarDatos(id);
            }
            f.ShowDialog();
            //Solo recargo datos si se cerró con un OK.
            if (f.DialogResult == DialogResult.OK)
            {
                RecargarDatos(Select);
            }
        }
        private void btNuevo_Click(object sender, EventArgs e)
        {
            CargarABM("agregar");
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count == 1)
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];
                string tipo = (string)((DataRowView)item)["Tipo"];
                DialogResult resp = MessageBox.Show("Seguro que desea borrar el " + tipo + "? Esta operacion no se puede revertir",
                    "Eliminar permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    try
                    {
                        string delete = $"DELETE FROM Vehiculos Where Id={id} ";

                        //ToDo: Utilizar bloques 'using' =)
                        using (SqlConnection conn = new SqlConnection(frmMDI.ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(delete, conn);
                            int result = cmd.ExecuteNonQuery();
                            RecargarDatos("SELECT * FROM Vehiculos");
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

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //DataSet resultados = new DataSet(); q hace??
       

      
        //aca esta el filtro del GV
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string filtro = $"SELECT * FROM Vehiculos WHERE Tipo LIKE '%{txFiltro.Text}%' or Modelo LIKE '%{txFiltro.Text}%' or PrecioVenta LIKE '%{txFiltro.Text}%'";
            
            RecargarDatos(filtro);
            txFiltro.Text = "";
        }
        //este es para el reload de las tablas de la base de datos
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RecargarDatos(Select);
            txFiltro.Text = "";
        }
    }
}
