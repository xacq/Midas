namespace MidasD
{
    partial class FrmContabilidadReportes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContabilidadReportes));
            this.totMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.erpError = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbxMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.PictureBox();
            this.rbt727 = new System.Windows.Forms.RadioButton();
            this.rbEcoGlobales = new System.Windows.Forms.RadioButton();
            this.rbBienesGravamenes = new System.Windows.Forms.RadioButton();
            this.btnCartilla = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btDevoluciones = new System.Windows.Forms.Button();
            this.btTransferencias = new System.Windows.Forms.Button();
            this.btReclasificaciones = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.mtfecha2 = new System.Windows.Forms.MaskedTextBox();
            this.mtfecha1 = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxAnio = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(342, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(246, 25);
            this.lblTitulo.TabIndex = 37;
            this.lblTitulo.Text = "Reportes Contabilidad";
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exit_;
            this.btnSalir.Location = new System.Drawing.Point(831, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 29);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 57;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // erpError
            // 
            this.erpError.ContainerControl = this;
            // 
            // cbxMes
            // 
            this.cbxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMes.FormattingEnabled = true;
            this.cbxMes.Location = new System.Drawing.Point(247, 22);
            this.cbxMes.Name = "cbxMes";
            this.cbxMes.Size = new System.Drawing.Size(106, 21);
            this.cbxMes.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(277, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Mes";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Image = global::MidasD.Properties.Resources.print;
            this.btnImprimir.Location = new System.Drawing.Point(183, 123);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(96, 29);
            this.btnImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnImprimir.TabIndex = 74;
            this.btnImprimir.TabStop = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click_1);
            // 
            // rbt727
            // 
            this.rbt727.AutoSize = true;
            this.rbt727.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbt727.Location = new System.Drawing.Point(33, 84);
            this.rbt727.Name = "rbt727";
            this.rbt727.Size = new System.Drawing.Size(53, 17);
            this.rbt727.TabIndex = 75;
            this.rbt727.TabStop = true;
            this.rbt727.Text = "T-727";
            this.rbt727.UseVisualStyleBackColor = true;
            // 
            // rbEcoGlobales
            // 
            this.rbEcoGlobales.AutoSize = true;
            this.rbEcoGlobales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbEcoGlobales.Location = new System.Drawing.Point(163, 84);
            this.rbEcoGlobales.Name = "rbEcoGlobales";
            this.rbEcoGlobales.Size = new System.Drawing.Size(127, 17);
            this.rbEcoGlobales.TabIndex = 76;
            this.rbEcoGlobales.TabStop = true;
            this.rbEcoGlobales.Text = "Economicas Globales";
            this.rbEcoGlobales.UseVisualStyleBackColor = true;
            // 
            // rbBienesGravamenes
            // 
            this.rbBienesGravamenes.AutoSize = true;
            this.rbBienesGravamenes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbBienesGravamenes.Location = new System.Drawing.Point(325, 84);
            this.rbBienesGravamenes.Name = "rbBienesGravamenes";
            this.rbBienesGravamenes.Size = new System.Drawing.Size(120, 17);
            this.rbBienesGravamenes.TabIndex = 77;
            this.rbBienesGravamenes.TabStop = true;
            this.rbBienesGravamenes.Text = "Bienes Gravamenes";
            this.rbBienesGravamenes.UseVisualStyleBackColor = true;
            // 
            // btnCartilla
            // 
            this.btnCartilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCartilla.Image = global::MidasD.Properties.Resources.empleados;
            this.btnCartilla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCartilla.Location = new System.Drawing.Point(155, 20);
            this.btnCartilla.Name = "btnCartilla";
            this.btnCartilla.Size = new System.Drawing.Size(124, 45);
            this.btnCartilla.TabIndex = 80;
            this.btnCartilla.Text = "Cartilla Fianza";
            this.btnCartilla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCartilla.UseVisualStyleBackColor = false;
            this.btnCartilla.Click += new System.EventHandler(this.btnCartilla_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(31, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 52);
            this.label1.TabIndex = 81;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "2.- Seleccione un Reporte";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "1.- Seleccione Reporte  a la fecha\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(382, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Año";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "3.- Impresion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(132, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Impresion de Cartilla de Fianza";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btDevoluciones);
            this.panel1.Controls.Add(this.btTransferencias);
            this.panel1.Controls.Add(this.btReclasificaciones);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.mtfecha2);
            this.panel1.Controls.Add(this.mtfecha1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(471, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 165);
            this.panel1.TabIndex = 87;
            // 
            // btDevoluciones
            // 
            this.btDevoluciones.BackColor = System.Drawing.Color.SteelBlue;
            this.btDevoluciones.ForeColor = System.Drawing.Color.White;
            this.btDevoluciones.Image = global::MidasD.Properties.Resources.fianzas_correccion;
            this.btDevoluciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDevoluciones.Location = new System.Drawing.Point(297, 73);
            this.btDevoluciones.Name = "btDevoluciones";
            this.btDevoluciones.Size = new System.Drawing.Size(120, 38);
            this.btDevoluciones.TabIndex = 95;
            this.btDevoluciones.Text = "Devoluciones";
            this.btDevoluciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDevoluciones.UseVisualStyleBackColor = false;
            this.btDevoluciones.Click += new System.EventHandler(this.btDevoluciones_Click);
            // 
            // btTransferencias
            // 
            this.btTransferencias.BackColor = System.Drawing.Color.SteelBlue;
            this.btTransferencias.ForeColor = System.Drawing.Color.White;
            this.btTransferencias.Image = global::MidasD.Properties.Resources.b_update;
            this.btTransferencias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTransferencias.Location = new System.Drawing.Point(165, 73);
            this.btTransferencias.Name = "btTransferencias";
            this.btTransferencias.Size = new System.Drawing.Size(119, 38);
            this.btTransferencias.TabIndex = 94;
            this.btTransferencias.Text = "Transferencias";
            this.btTransferencias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTransferencias.UseVisualStyleBackColor = false;
            this.btTransferencias.Click += new System.EventHandler(this.btTransferencias_Click);
            // 
            // btReclasificaciones
            // 
            this.btReclasificaciones.BackColor = System.Drawing.Color.SteelBlue;
            this.btReclasificaciones.ForeColor = System.Drawing.Color.White;
            this.btReclasificaciones.Image = global::MidasD.Properties.Resources.date_task;
            this.btReclasificaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReclasificaciones.Location = new System.Drawing.Point(19, 73);
            this.btReclasificaciones.Name = "btReclasificaciones";
            this.btReclasificaciones.Size = new System.Drawing.Size(133, 38);
            this.btReclasificaciones.TabIndex = 93;
            this.btReclasificaciones.Text = "Reclasificaciones";
            this.btReclasificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReclasificaciones.UseVisualStyleBackColor = false;
            this.btReclasificaciones.Click += new System.EventHandler(this.btReclasificaciones_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(294, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 92;
            this.label9.Text = "a";
            // 
            // mtfecha2
            // 
            this.mtfecha2.Location = new System.Drawing.Point(317, 32);
            this.mtfecha2.Mask = "00/00/0000";
            this.mtfecha2.Name = "mtfecha2";
            this.mtfecha2.Size = new System.Drawing.Size(100, 20);
            this.mtfecha2.TabIndex = 91;
            this.mtfecha2.ValidatingType = typeof(System.DateTime);
            // 
            // mtfecha1
            // 
            this.mtfecha1.Location = new System.Drawing.Point(186, 32);
            this.mtfecha1.Mask = "00/00/0000";
            this.mtfecha1.Name = "mtfecha1";
            this.mtfecha1.Size = new System.Drawing.Size(100, 20);
            this.mtfecha1.TabIndex = 90;
            this.mtfecha1.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 13);
            this.label8.TabIndex = 89;
            this.label8.Text = "4.- Reportes Entre Fechas";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnCartilla);
            this.panel2.Location = new System.Drawing.Point(259, 372);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(441, 74);
            this.panel2.TabIndex = 88;
            // 
            // cbxAnio
            // 
            this.cbxAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAnio.FormattingEnabled = true;
            this.cbxAnio.Location = new System.Drawing.Point(359, 22);
            this.cbxAnio.Name = "cbxAnio";
            this.cbxAnio.Size = new System.Drawing.Size(66, 21);
            this.cbxAnio.TabIndex = 96;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.cbxAnio);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.rbBienesGravamenes);
            this.panel3.Controls.Add(this.rbEcoGlobales);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.rbt727);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnImprimir);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.cbxMes);
            this.panel3.Location = new System.Drawing.Point(10, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 165);
            this.panel3.TabIndex = 89;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(511, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(342, 52);
            this.label10.TabIndex = 90;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(311, 332);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(341, 26);
            this.label11.TabIndex = 91;
            this.label11.Text = "Reportes en pdf de Cartillas\r\n-Cartilla Fianza (Impresion de las cartillas de fia" +
    "nza de cada funcionario)\r\n";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmContabilidadReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(924, 458);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContabilidadReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: MidasD - Reportes Contabilidad :::";
            this.Load += new System.EventHandler(this.frmEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip totMensaje;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.ErrorProvider erpError;
        private System.Windows.Forms.ComboBox cbxMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnImprimir;
        private System.Windows.Forms.RadioButton rbBienesGravamenes;
        private System.Windows.Forms.RadioButton rbEcoGlobales;
        private System.Windows.Forms.RadioButton rbt727;
        private System.Windows.Forms.Button btnCartilla;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mtfecha2;
        private System.Windows.Forms.MaskedTextBox mtfecha1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btDevoluciones;
        private System.Windows.Forms.Button btTransferencias;
        private System.Windows.Forms.Button btReclasificaciones;
        private System.Windows.Forms.ComboBox cbxAnio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
    }
}