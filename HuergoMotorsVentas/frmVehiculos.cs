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


        //se le aplica el filtro al gv, es decir agarra lo del filtro y se lo aplica al gv.
        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            gv.AutoGenerateColumns = false;
            RecargarDatos();
            this.leer_datos("SELECT * FROM Vehiculos ", ref resultados, "Vehiculos");
            this.mifiltro = ((DataTable)resultados.Tables["Vehiculos"]).DefaultView;
            this.gv.DataSource = mifiltro;

        }

        private void RecargarDatos()
        {
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
                CargarABM("Modificar");
            }
            else
            { 
                MessageBox.Show("Debe seleccionar un elemento para modificar",
                    "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarABM(string modo)
        {
            frmVehiculosAlta f = new frmVehiculosAlta();
            if (modo == "Modificar")
            {
                object item = gv.SelectedRows[0].DataBoundItem;
                int id = (int)((DataRowView)item)["Id"];
                f.CargarDatos(id);
            }
            f.ShowDialog();
            //Solo recargo datos si se cerró con un OK.
            if (f.DialogResult == DialogResult.OK)
            {
                RecargarDatos();
            }
        }
        private void btNuevo_Click(object sender, EventArgs e)
        {
            CargarABM("Agregar");
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            //ToDo: Implementar "Eliminar" (y MessageBox para pedir confirmación).
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataSet resultados = new DataSet();
        DataView mifiltro;
        
        
        //lee los datos de las tablas de sql,tipo se conecta entre el sql y la gv
        public void leer_datos (string query ,ref DataSet dstprincipal, string tabla)
        {
            try
            {
                string cadena = "Server=sql5078.site4now.net;Database=DB_9CF8B6_HuergoMotors2021;User Id=DB_9CF8B6_HuergoMotors2021_admin;Password=huergo2021";
                SqlConnection cn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataAdapter da  = new SqlDataAdapter(cmd);
                da.Fill(dstprincipal, tabla);
                da.Dispose();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        //Este seria el code del filtro y al terminar de escribir el filtro, se borra la palabra escrita
        private void btBuscar_Click(object sender, EventArgs e)
        {
            string salida_datos = "";
            string[] palabras_busqueda = this.txFiltro.Text.Split(' ');
            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(Tipo LIKE '%" + palabra + "%' OR Modelo LIKE '%" + palabra + "%' )";

                }
                else 
                {
                  salida_datos += "AND (Tipo LIKE '%" + palabra + "%' OR Modelo LIKE '%" + palabra + "%' )";
                }

            }
            txFiltro.Text = "";
            this.mifiltro.RowFilter = salida_datos;
        }
    }
}
