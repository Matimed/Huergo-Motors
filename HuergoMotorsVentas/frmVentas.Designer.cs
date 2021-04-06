
namespace HuergoMotorsVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.DtFecha = new System.Windows.Forms.DateTimePicker();
            this.CBvendedor = new System.Windows.Forms.ComboBox();
            this.TxtSucursal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LBPrecio = new System.Windows.Forms.Label();
            this.LBModelo = new System.Windows.Forms.Label();
            this.CBTipo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.LBEmail = new System.Windows.Forms.Label();
            this.LBTelefono = new System.Windows.Forms.Label();
            this.LBNombre = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.BtnConfirmarVenta = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gvAccesorios = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEliminarAccesorio = new System.Windows.Forms.DataGridViewButtonColumn();
            this.picLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccesorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Venta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Idventa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vendedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sucursal";
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(114, 50);
            this.TxtId.Name = "TxtId";
            this.TxtId.ReadOnly = true;
            this.TxtId.Size = new System.Drawing.Size(121, 20);
            this.TxtId.TabIndex = 5;
            // 
            // DtFecha
            // 
            this.DtFecha.CustomFormat = "dd/MM/yyyy";
            this.DtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecha.Location = new System.Drawing.Point(114, 77);
            this.DtFecha.Name = "DtFecha";
            this.DtFecha.Size = new System.Drawing.Size(121, 20);
            this.DtFecha.TabIndex = 6;
            this.DtFecha.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // CBvendedor
            // 
            this.CBvendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBvendedor.FormattingEnabled = true;
            this.CBvendedor.Location = new System.Drawing.Point(114, 101);
            this.CBvendedor.Name = "CBvendedor";
            this.CBvendedor.Size = new System.Drawing.Size(121, 21);
            this.CBvendedor.TabIndex = 7;
            // 
            // TxtSucursal
            // 
            this.TxtSucursal.Location = new System.Drawing.Point(114, 128);
            this.TxtSucursal.Name = "TxtSucursal";
            this.TxtSucursal.ReadOnly = true;
            this.TxtSucursal.Size = new System.Drawing.Size(121, 20);
            this.TxtSucursal.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Precio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Modelo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tipo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Vehiculos:";
            // 
            // LBPrecio
            // 
            this.LBPrecio.AutoSize = true;
            this.LBPrecio.Location = new System.Drawing.Point(133, 251);
            this.LBPrecio.Name = "LBPrecio";
            this.LBPrecio.Size = new System.Drawing.Size(16, 13);
            this.LBPrecio.TabIndex = 15;
            this.LBPrecio.Text = "...";
            // 
            // LBModelo
            // 
            this.LBModelo.AutoSize = true;
            this.LBModelo.Location = new System.Drawing.Point(133, 227);
            this.LBModelo.Name = "LBModelo";
            this.LBModelo.Size = new System.Drawing.Size(16, 13);
            this.LBModelo.TabIndex = 14;
            this.LBModelo.Text = "...";
            // 
            // CBTipo
            // 
            this.CBTipo.FormattingEnabled = true;
            this.CBTipo.Location = new System.Drawing.Point(114, 195);
            this.CBTipo.Name = "CBTipo";
            this.CBTipo.Size = new System.Drawing.Size(102, 21);
            this.CBTipo.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(286, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Clientes";
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Location = new System.Drawing.Point(358, 174);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(94, 24);
            this.BtnSeleccionar.TabIndex = 18;
            this.BtnSeleccionar.Text = "Seleccionar";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // LBEmail
            // 
            this.LBEmail.AutoSize = true;
            this.LBEmail.Location = new System.Drawing.Point(286, 251);
            this.LBEmail.Name = "LBEmail";
            this.LBEmail.Size = new System.Drawing.Size(32, 13);
            this.LBEmail.TabIndex = 21;
            this.LBEmail.Text = "Email";
            // 
            // LBTelefono
            // 
            this.LBTelefono.AutoSize = true;
            this.LBTelefono.Location = new System.Drawing.Point(281, 227);
            this.LBTelefono.Name = "LBTelefono";
            this.LBTelefono.Size = new System.Drawing.Size(49, 13);
            this.LBTelefono.TabIndex = 20;
            this.LBTelefono.Text = "Telefono";
            // 
            // LBNombre
            // 
            this.LBNombre.AutoSize = true;
            this.LBNombre.Location = new System.Drawing.Point(258, 203);
            this.LBNombre.Name = "LBNombre";
            this.LBNombre.Size = new System.Drawing.Size(94, 13);
            this.LBNombre.TabIndex = 19;
            this.LBNombre.Text = "Nombre Y Apellido";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(398, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(398, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "...";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(398, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "...";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(73, 293);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Accesorios:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(141, 293);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 21);
            this.comboBox1.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(358, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 24);
            this.button1.TabIndex = 27;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(45, 530);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(216, 16);
            this.label18.TabIndex = 28;
            this.label18.Text = "Total (Vehículo + Accesorios):";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(267, 530);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(48, 16);
            this.lbTotal.TabIndex = 29;
            this.lbTotal.Text = "$ 0,00";
            // 
            // BtnConfirmarVenta
            // 
            this.BtnConfirmarVenta.Location = new System.Drawing.Point(330, 526);
            this.BtnConfirmarVenta.Name = "BtnConfirmarVenta";
            this.BtnConfirmarVenta.Size = new System.Drawing.Size(164, 24);
            this.BtnConfirmarVenta.TabIndex = 30;
            this.BtnConfirmarVenta.Text = "Confirmar Venta";
            this.BtnConfirmarVenta.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 455);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(446, 65);
            this.textBox1.TabIndex = 31;
            // 
            // gvAccesorios
            // 
            this.gvAccesorios.AllowUserToAddRows = false;
            this.gvAccesorios.AllowUserToDeleteRows = false;
            this.gvAccesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccesorios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Tipo,
            this.Precio,
            this.bEliminarAccesorio});
            this.gvAccesorios.Location = new System.Drawing.Point(48, 329);
            this.gvAccesorios.Name = "gvAccesorios";
            this.gvAccesorios.Size = new System.Drawing.Size(446, 120);
            this.gvAccesorios.TabIndex = 32;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // bEliminarAccesorio
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Eliminar";
            this.bEliminarAccesorio.DefaultCellStyle = dataGridViewCellStyle2;
            this.bEliminarAccesorio.HeaderText = "Eliminar";
            this.bEliminarAccesorio.Name = "bEliminarAccesorio";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::HuergoMotorsVentas.Properties.Resources.CapturaHuergoMotors;
            this.picLogo.Location = new System.Drawing.Point(330, 25);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(127, 113);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 33;
            this.picLogo.TabStop = false;
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 552);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.gvAccesorios);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnConfirmarVenta);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LBEmail);
            this.Controls.Add(this.LBTelefono);
            this.Controls.Add(this.LBNombre);
            this.Controls.Add(this.BtnSeleccionar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CBTipo);
            this.Controls.Add(this.LBPrecio);
            this.Controls.Add(this.LBModelo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtSucursal);
            this.Controls.Add(this.CBvendedor);
            this.Controls.Add(this.DtFecha);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmVentas";
            this.Text = "frmVentas";
            ((System.ComponentModel.ISupportInitialize)(this.gvAccesorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.DateTimePicker DtFecha;
        private System.Windows.Forms.ComboBox CBvendedor;
        private System.Windows.Forms.TextBox TxtSucursal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LBPrecio;
        private System.Windows.Forms.Label LBModelo;
        private System.Windows.Forms.ComboBox CBTipo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnSeleccionar;
        private System.Windows.Forms.Label LBEmail;
        private System.Windows.Forms.Label LBTelefono;
        private System.Windows.Forms.Label LBNombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Button BtnConfirmarVenta;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView gvAccesorios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewButtonColumn bEliminarAccesorio;
        private System.Windows.Forms.PictureBox picLogo;
    }
}