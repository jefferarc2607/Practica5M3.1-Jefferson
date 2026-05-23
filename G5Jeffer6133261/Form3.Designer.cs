namespace G5Jeffer6133261
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.NumericUpDown nUDcant;
        private System.Windows.Forms.DateTimePicker dTime1;
        private System.Windows.Forms.Button btnIngresarP;
        private System.Windows.Forms.Button btnLimpiarP;
        private System.Windows.Forms.Button btnVolverP;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lbNombreC;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.nUDcant = new System.Windows.Forms.NumericUpDown();
            this.dTime1 = new System.Windows.Forms.DateTimePicker();
            this.btnIngresarP = new System.Windows.Forms.Button();
            this.btnLimpiarP = new System.Windows.Forms.Button();
            this.btnVolverP = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lbNombreC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDcant)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(30, 25);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(84, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Seleccione Cliente:";
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(33, 45);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(200, 21);
            this.cbCliente.TabIndex = 1;
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbCliente_SelectedIndexChanged);
            // 
            // lbNombreC
            // 
            this.lbNombreC.AutoSize = true;
            this.lbNombreC.Location = new System.Drawing.Point(250, 48);
            this.lbNombreC.Name = "lbNombreC";
            this.lbNombreC.Size = new System.Drawing.Size(0, 13);
            this.lbNombreC.TabIndex = 2;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(30, 85);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // nUDcant
            // 
            this.nUDcant.Location = new System.Drawing.Point(33, 105);
            this.nUDcant.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.nUDcant.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nUDcant.Name = "nUDcant";
            this.nUDcant.Size = new System.Drawing.Size(120, 20);
            this.nUDcant.TabIndex = 4;
            this.nUDcant.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(30, 145);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha:";
            // 
            // dTime1
            // 
            this.dTime1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTime1.Location = new System.Drawing.Point(33, 165);
            this.dTime1.Name = "dTime1";
            this.dTime1.Size = new System.Drawing.Size(120, 20);
            this.dTime1.TabIndex = 6;
            // 
            // btnIngresarP
            // 
            this.btnIngresarP.Location = new System.Drawing.Point(33, 210);
            this.btnIngresarP.Name = "btnIngresarP";
            this.btnIngresarP.Size = new System.Drawing.Size(75, 30);
            this.btnIngresarP.TabIndex = 7;
            this.btnIngresarP.Text = "Ingresar";
            this.btnIngresarP.UseVisualStyleBackColor = true;
            this.btnIngresarP.Click += new System.EventHandler(this.btnIngresarP_Click);
            // 
            // btnLimpiarP
            // 
            this.btnLimpiarP.Location = new System.Drawing.Point(120, 210);
            this.btnLimpiarP.Name = "btnLimpiarP";
            this.btnLimpiarP.Size = new System.Drawing.Size(75, 30);
            this.btnLimpiarP.TabIndex = 8;
            this.btnLimpiarP.Text = "Limpiar";
            this.btnLimpiarP.UseVisualStyleBackColor = true;
            this.btnLimpiarP.Click += new System.EventHandler(this.btnLimpiarP_Click);
            // 
            // btnVolverP
            // 
            this.btnVolverP.Location = new System.Drawing.Point(208, 210);
            this.btnVolverP.Name = "btnVolverP";
            this.btnVolverP.Size = new System.Drawing.Size(75, 30);
            this.btnVolverP.TabIndex = 9;
            this.btnVolverP.Text = "Volver";
            this.btnVolverP.UseVisualStyleBackColor = true;
            this.btnVolverP.Click += new System.EventHandler(this.btnVolverP_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.btnVolverP);
            this.Controls.Add(this.btnLimpiarP);
            this.Controls.Add(this.btnIngresarP);
            this.Controls.Add(this.dTime1);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.nUDcant);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lbNombreC);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.lblCliente);
            this.Name = "Form3";
            this.Text = "Gestión de Pedidos";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDcant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}