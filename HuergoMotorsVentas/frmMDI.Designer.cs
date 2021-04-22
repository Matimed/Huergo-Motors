namespace HuergoMotorsForms
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btVehiculos = new System.Windows.Forms.ToolStripButton();
            this.btAccesorios = new System.Windows.Forms.ToolStripButton();
            this.btClientes = new System.Windows.Forms.ToolStripButton();
            this.btVendedores = new System.Windows.Forms.ToolStripButton();
            this.btNuevaVenta = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btVehiculos,
            this.btAccesorios,
            this.btClientes,
            this.btVendedores,
            this.btNuevaVenta});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(110, 549);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btVehiculos
            // 
            this.btVehiculos.Image = ((System.Drawing.Image)(resources.GetObject("btVehiculos.Image")));
            this.btVehiculos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVehiculos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btVehiculos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btVehiculos.Name = "btVehiculos";
            this.btVehiculos.Size = new System.Drawing.Size(107, 36);
            this.btVehiculos.Text = "Vehículos";
            this.btVehiculos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVehiculos.Click += new System.EventHandler(this.btVehiculos_Click);
            // 
            // btAccesorios
            // 
            this.btAccesorios.Image = ((System.Drawing.Image)(resources.GetObject("btAccesorios.Image")));
            this.btAccesorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAccesorios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btAccesorios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAccesorios.Name = "btAccesorios";
            this.btAccesorios.Size = new System.Drawing.Size(107, 36);
            this.btAccesorios.Text = "Accesorios";
            this.btAccesorios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAccesorios.Click += new System.EventHandler(this.btAccesorios_Click);
            // 
            // btClientes
            // 
            this.btClientes.Image = ((System.Drawing.Image)(resources.GetObject("btClientes.Image")));
            this.btClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btClientes.Name = "btClientes";
            this.btClientes.Size = new System.Drawing.Size(107, 36);
            this.btClientes.Text = "Clientes";
            this.btClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClientes.Click += new System.EventHandler(this.btClientes_Click);
            // 
            // btVendedores
            // 
            this.btVendedores.Image = ((System.Drawing.Image)(resources.GetObject("btVendedores.Image")));
            this.btVendedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVendedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btVendedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btVendedores.Name = "btVendedores";
            this.btVendedores.Size = new System.Drawing.Size(107, 36);
            this.btVendedores.Text = "Vendedores";
            this.btVendedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVendedores.Click += new System.EventHandler(this.btVendedores_Click);
            // 
            // btNuevaVenta
            // 
            this.btNuevaVenta.Image = ((System.Drawing.Image)(resources.GetObject("btNuevaVenta.Image")));
            this.btNuevaVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNuevaVenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btNuevaVenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNuevaVenta.Name = "btNuevaVenta";
            this.btNuevaVenta.Size = new System.Drawing.Size(107, 36);
            this.btNuevaVenta.Text = "Nueva Venta";
            this.btNuevaVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNuevaVenta.Click += new System.EventHandler(this.btNuevaVenta_Click);
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(734, 571);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Huergo Motors - Ventas";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btVehiculos;
        private System.Windows.Forms.ToolStripButton btAccesorios;
        private System.Windows.Forms.ToolStripButton btClientes;
        private System.Windows.Forms.ToolStripButton btVendedores;
        private System.Windows.Forms.ToolStripButton btNuevaVenta;
    }
}

