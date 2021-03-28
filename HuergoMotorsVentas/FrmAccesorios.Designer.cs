﻿
namespace HuergoMotorsVentas
{
    partial class frmAccesorios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccesorios));
            this.btCerrar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btNuevo = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.gv = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVehiculos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txFiltro = new System.Windows.Forms.TextBox();
            this.picboxB = new System.Windows.Forms.PictureBox();
            this.picboxR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxR)).BeginInit();
            this.SuspendLayout();
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCerrar.Location = new System.Drawing.Point(18, 652);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(112, 35);
            this.btCerrar.TabIndex = 16;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.ForeColor = System.Drawing.Color.White;
            this.btEliminar.Location = new System.Drawing.Point(747, 652);
            this.btEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(112, 35);
            this.btEliminar.TabIndex = 15;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btNuevo
            // 
            this.btNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNuevo.BackColor = System.Drawing.Color.OliveDrab;
            this.btNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btNuevo.Location = new System.Drawing.Point(504, 652);
            this.btNuevo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(112, 35);
            this.btNuevo.TabIndex = 14;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = false;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // btModificar
            // 
            this.btModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btModificar.BackColor = System.Drawing.Color.Goldenrod;
            this.btModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btModificar.Location = new System.Drawing.Point(626, 652);
            this.btModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(112, 35);
            this.btModificar.TabIndex = 12;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = false;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.AllowUserToDeleteRows = false;
            this.gv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Tipo,
            this.Precio,
            this.idVehiculos});
            this.gv.Location = new System.Drawing.Point(18, 66);
            this.gv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gv.Name = "gv";
            this.gv.ReadOnly = true;
            this.gv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv.Size = new System.Drawing.Size(840, 577);
            this.gv.TabIndex = 11;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = "0";
            this.Precio.DefaultCellStyle = dataGridViewCellStyle1;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // idVehiculos
            // 
            this.idVehiculos.DataPropertyName = "idVehiculos";
            this.idVehiculos.HeaderText = "idVehiculos";
            this.idVehiculos.Name = "idVehiculos";
            this.idVehiculos.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filtro";
            // 
            // txFiltro
            // 
            this.txFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txFiltro.Location = new System.Drawing.Point(70, 26);
            this.txFiltro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txFiltro.Name = "txFiltro";
            this.txFiltro.Size = new System.Drawing.Size(664, 26);
            this.txFiltro.TabIndex = 9;
            // 
            // picboxB
            // 
            this.picboxB.BackColor = System.Drawing.Color.Transparent;
            this.picboxB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picboxB.Image = global::HuergoMotorsVentas.Properties.Resources.lupa;
            this.picboxB.Location = new System.Drawing.Point(747, 24);
            this.picboxB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picboxB.Name = "picboxB";
            this.picboxB.Size = new System.Drawing.Size(32, 32);
            this.picboxB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxB.TabIndex = 17;
            this.picboxB.TabStop = false;
            this.picboxB.Click += new System.EventHandler(this.picBusqueda_Click);
            // 
            // picboxR
            // 
            this.picboxR.BackColor = System.Drawing.Color.Transparent;
            this.picboxR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picboxR.Image = global::HuergoMotorsVentas.Properties.Resources.reload;
            this.picboxR.Location = new System.Drawing.Point(797, 24);
            this.picboxR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picboxR.Name = "picboxR";
            this.picboxR.Size = new System.Drawing.Size(32, 32);
            this.picboxR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxR.TabIndex = 18;
            this.picboxR.TabStop = false;
            this.picboxR.Click += new System.EventHandler(this.picReload_Click);
            // 
            // frmAccesorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::HuergoMotorsVentas.Properties.Resources.fondo_rojo;
            this.ClientSize = new System.Drawing.Size(876, 709);
            this.Controls.Add(this.picboxR);
            this.Controls.Add(this.picboxB);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btNuevo);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.gv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAccesorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accesorios - Busqueda";
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVehiculos;
        private System.Windows.Forms.PictureBox picboxB;
        private System.Windows.Forms.PictureBox picboxR;
    }
}