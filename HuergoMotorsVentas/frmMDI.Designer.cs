namespace HuergoMotorsVentas
{
    partial class frmMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accesoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btVehiculos = new System.Windows.Forms.ToolStripButton();
            this.btAccesorios = new System.Windows.Forms.ToolStripButton();
            this.btClientes = new System.Windows.Forms.ToolStripButton();
            this.btVendedores = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ventasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehiculosToolStripMenuItem,
            this.accesoriosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.vendedoresToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShowShortcutKeys = false;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 20);
            this.toolStripMenuItem1.Text = "Alta/Baja/Modificación";
            // 
            // vehiculosToolStripMenuItem
            // 
            this.vehiculosToolStripMenuItem.Name = "vehiculosToolStripMenuItem";
            this.vehiculosToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.vehiculosToolStripMenuItem.Text = "Vehículos";
            this.vehiculosToolStripMenuItem.Click += new System.EventHandler(this.vehiculosToolStripMenuItem_Click);
            // 
            // accesoriosToolStripMenuItem
            // 
            this.accesoriosToolStripMenuItem.Name = "accesoriosToolStripMenuItem";
            this.accesoriosToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.accesoriosToolStripMenuItem.Text = "Accesorios";
            this.accesoriosToolStripMenuItem.Click += new System.EventHandler(this.accesoriosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // vendedoresToolStripMenuItem
            // 
            this.vendedoresToolStripMenuItem.Name = "vendedoresToolStripMenuItem";
            this.vendedoresToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.vendedoresToolStripMenuItem.Text = "Vendedores";
            this.vendedoresToolStripMenuItem.Click += new System.EventHandler(this.vendedoresToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaDeVentasToolStripMenuItem,
            this.consultaDeVentasToolStripMenuItem,
            this.reporteDeVentasToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // altaDeVentasToolStripMenuItem
            // 
            this.altaDeVentasToolStripMenuItem.Name = "altaDeVentasToolStripMenuItem";
            this.altaDeVentasToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.altaDeVentasToolStripMenuItem.Text = "Alta de Ventas";
            // 
            // consultaDeVentasToolStripMenuItem
            // 
            this.consultaDeVentasToolStripMenuItem.Name = "consultaDeVentasToolStripMenuItem";
            this.consultaDeVentasToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.consultaDeVentasToolStripMenuItem.Text = "Consulta de Ventas";
            // 
            // reporteDeVentasToolStripMenuItem
            // 
            this.reporteDeVentasToolStripMenuItem.Name = "reporteDeVentasToolStripMenuItem";
            this.reporteDeVentasToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.reporteDeVentasToolStripMenuItem.Text = "Reporte de Ventas";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 549);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(734, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btVehiculos,
            this.btAccesorios,
            this.btClientes,
            this.btVendedores});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(105, 525);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btVehiculos
            // 
            this.btVehiculos.Image = global::HuergoMotorsVentas.Properties.Resources.car;
            this.btVehiculos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVehiculos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btVehiculos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btVehiculos.Name = "btVehiculos";
            this.btVehiculos.Size = new System.Drawing.Size(102, 36);
            this.btVehiculos.Text = "Vehículos";
            this.btVehiculos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVehiculos.Click += new System.EventHandler(this.btVehiculos_Click);
            // 
            // btAccesorios
            // 
            this.btAccesorios.Image = global::HuergoMotorsVentas.Properties.Resources.rueda1;
            this.btAccesorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAccesorios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btAccesorios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAccesorios.Name = "btAccesorios";
            this.btAccesorios.Size = new System.Drawing.Size(102, 36);
            this.btAccesorios.Text = "Accesorios";
            this.btAccesorios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAccesorios.Click += new System.EventHandler(this.btAccesorios_Click);
            // 
            // btClientes
            // 
            this.btClientes.Image = global::HuergoMotorsVentas.Properties.Resources.client;
            this.btClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btClientes.Name = "btClientes";
            this.btClientes.Size = new System.Drawing.Size(102, 36);
            this.btClientes.Text = "Clientes";
            this.btClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClientes.Click += new System.EventHandler(this.btClientes_Click);
            // 
            // btVendedores
            // 
            this.btVendedores.Image = global::HuergoMotorsVentas.Properties.Resources.vendedor;
            this.btVendedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVendedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btVendedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btVendedores.Name = "btVendedores";
            this.btVendedores.Size = new System.Drawing.Size(102, 36);
            this.btVendedores.Text = "Vendedores";
            this.btVendedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVendedores.Click += new System.EventHandler(this.btVendedores_Click);
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::HuergoMotorsVentas.Properties.Resources.fondo_rojo;
            this.ClientSize = new System.Drawing.Size(734, 571);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Huergo Motors - Ventas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vendedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accesoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeVentasToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btVehiculos;
        private System.Windows.Forms.ToolStripButton btAccesorios;
        private System.Windows.Forms.ToolStripButton btClientes;
        private System.Windows.Forms.ToolStripButton btVendedores;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
    }
}

