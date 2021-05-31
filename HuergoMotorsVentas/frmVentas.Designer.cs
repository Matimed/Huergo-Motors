
namespace HuergoMotors.Forms
{
    partial class frmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.picReload = new System.Windows.Forms.PictureBox();
            this.picBusqueda = new System.Windows.Forms.PictureBox();
            this.btCerrar = new System.Windows.Forms.Button();
            this.gvVentas = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehiculoModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txFiltro = new System.Windows.Forms.TextBox();
            this.splitTablas = new System.Windows.Forms.SplitContainer();
            this.gvAccesorios = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreAccesorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoAccesorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picReload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitTablas)).BeginInit();
            this.splitTablas.Panel1.SuspendLayout();
            this.splitTablas.Panel2.SuspendLayout();
            this.splitTablas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccesorios)).BeginInit();
            this.SuspendLayout();
            // 
            // picReload
            // 
            this.picReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picReload.BackColor = System.Drawing.Color.Transparent;
            this.picReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picReload.Image = ((System.Drawing.Image)(resources.GetObject("picReload.Image")));
            this.picReload.Location = new System.Drawing.Point(663, 16);
            this.picReload.Name = "picReload";
            this.picReload.Size = new System.Drawing.Size(21, 21);
            this.picReload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picReload.TabIndex = 21;
            this.picReload.TabStop = false;
            this.picReload.Click += new System.EventHandler(this.picReload_Click);
            // 
            // picBusqueda
            // 
            this.picBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.picBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBusqueda.Image = ((System.Drawing.Image)(resources.GetObject("picBusqueda.Image")));
            this.picBusqueda.Location = new System.Drawing.Point(633, 16);
            this.picBusqueda.Name = "picBusqueda";
            this.picBusqueda.Size = new System.Drawing.Size(21, 21);
            this.picBusqueda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBusqueda.TabIndex = 20;
            this.picBusqueda.TabStop = false;
            this.picBusqueda.Click += new System.EventHandler(this.picBusqueda_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCerrar.Location = new System.Drawing.Point(12, 422);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(75, 23);
            this.btCerrar.TabIndex = 19;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // gvVentas
            // 
            this.gvVentas.AllowUserToAddRows = false;
            this.gvVentas.AllowUserToDeleteRows = false;
            this.gvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.VehiculoModelo,
            this.Cliente,
            this.Vendedor,
            this.Fecha,
            this.IdVehiculo,
            this.IdCliente,
            this.IdVendedor,
            this.Observaciones,
            this.Total});
            this.gvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvVentas.Location = new System.Drawing.Point(0, 0);
            this.gvVentas.Name = "gvVentas";
            this.gvVentas.ReadOnly = true;
            this.gvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvVentas.Size = new System.Drawing.Size(673, 267);
            this.gvVentas.TabIndex = 15;
            this.gvVentas.SelectionChanged += new System.EventHandler(this.gvVentas_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // VehiculoModelo
            // 
            this.VehiculoModelo.DataPropertyName = "Vehiculo";
            this.VehiculoModelo.HeaderText = "Vehiculo";
            this.VehiculoModelo.Name = "VehiculoModelo";
            this.VehiculoModelo.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Vendedor
            // 
            this.Vendedor.DataPropertyName = "Vendedor";
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // IdVehiculo
            // 
            this.IdVehiculo.DataPropertyName = "IdVehiculo";
            this.IdVehiculo.HeaderText = "idVehiculo";
            this.IdVehiculo.Name = "IdVehiculo";
            this.IdVehiculo.ReadOnly = true;
            this.IdVehiculo.Visible = false;
            // 
            // IdCliente
            // 
            this.IdCliente.DataPropertyName = "IdCliente";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = "0";
            this.IdCliente.DefaultCellStyle = dataGridViewCellStyle1;
            this.IdCliente.HeaderText = "IdCliente";
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            this.IdCliente.Visible = false;
            // 
            // IdVendedor
            // 
            this.IdVendedor.DataPropertyName = "IdVendedor";
            this.IdVendedor.HeaderText = "idVendedor";
            this.IdVendedor.Name = "IdVendedor";
            this.IdVendedor.ReadOnly = true;
            this.IdVendedor.Visible = false;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observacion";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filtro";
            // 
            // txFiltro
            // 
            this.txFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txFiltro.Location = new System.Drawing.Point(93, 15);
            this.txFiltro.Name = "txFiltro";
            this.txFiltro.Size = new System.Drawing.Size(463, 20);
            this.txFiltro.TabIndex = 13;
            // 
            // splitTablas
            // 
            this.splitTablas.Location = new System.Drawing.Point(12, 41);
            this.splitTablas.Name = "splitTablas";
            this.splitTablas.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitTablas.Panel1
            // 
            this.splitTablas.Panel1.Controls.Add(this.gvVentas);
            // 
            // splitTablas.Panel2
            // 
            this.splitTablas.Panel2.Controls.Add(this.gvAccesorios);
            this.splitTablas.Size = new System.Drawing.Size(673, 375);
            this.splitTablas.SplitterDistance = 267;
            this.splitTablas.TabIndex = 23;
            // 
            // gvAccesorios
            // 
            this.gvAccesorios.AllowUserToAddRows = false;
            this.gvAccesorios.AllowUserToDeleteRows = false;
            this.gvAccesorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAccesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccesorios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.NombreAccesorio,
            this.TipoAccesorio,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn10});
            this.gvAccesorios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAccesorios.Location = new System.Drawing.Point(0, 0);
            this.gvAccesorios.Name = "gvAccesorios";
            this.gvAccesorios.ReadOnly = true;
            this.gvAccesorios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAccesorios.Size = new System.Drawing.Size(673, 104);
            this.gvAccesorios.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // NombreAccesorio
            // 
            this.NombreAccesorio.DataPropertyName = "NombreAccesorio";
            this.NombreAccesorio.HeaderText = "Nombre";
            this.NombreAccesorio.Name = "NombreAccesorio";
            this.NombreAccesorio.ReadOnly = true;
            // 
            // TipoAccesorio
            // 
            this.TipoAccesorio.DataPropertyName = "TipoAccesorio";
            this.TipoAccesorio.HeaderText = "Tipo";
            this.TipoAccesorio.Name = "TipoAccesorio";
            this.TipoAccesorio.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "IdAccesorios";
            this.dataGridViewTextBoxColumn2.HeaderText = "IdAccesorios";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "IdVenta";
            this.dataGridViewTextBoxColumn6.HeaderText = "IdVenta";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Precio";
            this.dataGridViewTextBoxColumn10.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(697, 461);
            this.Controls.Add(this.splitTablas);
            this.Controls.Add(this.picReload);
            this.Controls.Add(this.picBusqueda);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(713, 500);
            this.Name = "frmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas - Busqueda";
            this.Load += new System.EventHandler(this.frmVentas_load);
            ((System.ComponentModel.ISupportInitialize)(this.picReload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVentas)).EndInit();
            this.splitTablas.Panel1.ResumeLayout(false);
            this.splitTablas.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTablas)).EndInit();
            this.splitTablas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvAccesorios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picReload;
        private System.Windows.Forms.PictureBox picBusqueda;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.DataGridView gvVentas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txFiltro;
        private System.Windows.Forms.SplitContainer splitTablas;
        private System.Windows.Forms.DataGridView gvAccesorios;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreAccesorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoAccesorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehiculoModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}