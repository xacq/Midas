namespace MidasD
{
    partial class FrmOficinaCargo
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbxMenu = new System.Windows.Forms.GroupBox();
            this.chlCargos = new System.Windows.Forms.CheckedListBox();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.PictureBox();
            this.cbxOficina = new System.Windows.Forms.ComboBox();
            this.grbRol = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Gestion = new System.Windows.Forms.Label();
            this.txtGestion = new System.Windows.Forms.TextBox();
            this.btnBuscarOficina = new System.Windows.Forms.Button();
            this.txtOficinaLiteral = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxUnidadEjecutora = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.btnAsignar = new System.Windows.Forms.PictureBox();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.totMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.gbxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            this.grbRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAsignar)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(156, 5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(156, 25);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "Oficina Cargo";
            // 
            // gbxMenu
            // 
            this.gbxMenu.Controls.Add(this.chlCargos);
            this.gbxMenu.Controls.Add(this.btnCancelar);
            this.gbxMenu.Controls.Add(this.btnGuardar);
            this.gbxMenu.Enabled = false;
            this.gbxMenu.Location = new System.Drawing.Point(7, 6);
            this.gbxMenu.Name = "gbxMenu";
            this.gbxMenu.Size = new System.Drawing.Size(610, 302);
            this.gbxMenu.TabIndex = 14;
            this.gbxMenu.TabStop = false;
            this.gbxMenu.Text = "Cargos";
            // 
            // chlCargos
            // 
            this.chlCargos.FormattingEnabled = true;
            this.chlCargos.Location = new System.Drawing.Point(6, 19);
            this.chlCargos.Name = "chlCargos";
            this.chlCargos.Size = new System.Drawing.Size(598, 244);
            this.chlCargos.TabIndex = 35;
            this.chlCargos.Tag = "Lista de Menús";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = global::MidasD.Properties.Resources.cancel_inactive;
            this.btnCancelar.Location = new System.Drawing.Point(328, 269);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 31);
            this.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnCancelar, "Cancelar acción");
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Image = global::MidasD.Properties.Resources.save_inactive;
            this.btnGuardar.Location = new System.Drawing.Point(215, 269);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 31);
            this.btnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGuardar.TabIndex = 33;
            this.btnGuardar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnGuardar, "Guardar registro");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbxOficina
            // 
            this.cbxOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOficina.FormattingEnabled = true;
            this.cbxOficina.Location = new System.Drawing.Point(475, 14);
            this.cbxOficina.Name = "cbxOficina";
            this.cbxOficina.Size = new System.Drawing.Size(132, 24);
            this.cbxOficina.TabIndex = 4;
            this.totMensaje.SetToolTip(this.cbxOficina, "Lista de Roles");
            this.cbxOficina.Visible = false;
            this.cbxOficina.SelectedIndexChanged += new System.EventHandler(this.cbxRol_SelectedIndexChanged);
            this.cbxOficina.Leave += new System.EventHandler(this.cbxOficina_Leave);
            // 
            // grbRol
            // 
            this.grbRol.Controls.Add(this.label9);
            this.grbRol.Controls.Add(this.Gestion);
            this.grbRol.Controls.Add(this.txtGestion);
            this.grbRol.Controls.Add(this.btnBuscarOficina);
            this.grbRol.Controls.Add(this.txtOficinaLiteral);
            this.grbRol.Controls.Add(this.label2);
            this.grbRol.Controls.Add(this.cbxOficina);
            this.grbRol.Controls.Add(this.label1);
            this.grbRol.Controls.Add(this.cbxUnidadEjecutora);
            this.grbRol.Controls.Add(this.btnSalir);
            this.grbRol.Controls.Add(this.btnAsignar);
            this.grbRol.Location = new System.Drawing.Point(12, 37);
            this.grbRol.Name = "grbRol";
            this.grbRol.Size = new System.Drawing.Size(619, 196);
            this.grbRol.TabIndex = 13;
            this.grbRol.TabStop = false;
            this.grbRol.Text = "Datos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(368, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 24);
            this.label9.TabIndex = 82;
            this.label9.Text = "Sueldo Mensual\r\nSegun Año";
            // 
            // Gestion
            // 
            this.Gestion.AutoSize = true;
            this.Gestion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gestion.Location = new System.Drawing.Point(259, 20);
            this.Gestion.Name = "Gestion";
            this.Gestion.Size = new System.Drawing.Size(104, 15);
            this.Gestion.TabIndex = 81;
            this.Gestion.Text = "Año de los Cargos";
            // 
            // txtGestion
            // 
            this.txtGestion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGestion.Location = new System.Drawing.Point(183, 16);
            this.txtGestion.Name = "txtGestion";
            this.txtGestion.Size = new System.Drawing.Size(73, 22);
            this.txtGestion.TabIndex = 80;
            // 
            // btnBuscarOficina
            // 
            this.btnBuscarOficina.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBuscarOficina.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBuscarOficina.FlatAppearance.BorderSize = 0;
            this.btnBuscarOficina.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBuscarOficina.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBuscarOficina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarOficina.Image = global::MidasD.Properties.Resources.lupa;
            this.btnBuscarOficina.Location = new System.Drawing.Point(13, 89);
            this.btnBuscarOficina.Name = "btnBuscarOficina";
            this.btnBuscarOficina.Size = new System.Drawing.Size(45, 45);
            this.btnBuscarOficina.TabIndex = 79;
            this.btnBuscarOficina.UseVisualStyleBackColor = false;
            this.btnBuscarOficina.Click += new System.EventHandler(this.btnBuscarOficina_Click);
            this.btnBuscarOficina.MouseHover += new System.EventHandler(this.btnBuscarOficina_MouseHover);
            // 
            // txtOficinaLiteral
            // 
            this.txtOficinaLiteral.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtOficinaLiteral.Enabled = false;
            this.txtOficinaLiteral.Location = new System.Drawing.Point(64, 80);
            this.txtOficinaLiteral.Multiline = true;
            this.txtOficinaLiteral.Name = "txtOficinaLiteral";
            this.txtOficinaLiteral.Size = new System.Drawing.Size(549, 62);
            this.txtOficinaLiteral.TabIndex = 78;
            this.txtOficinaLiteral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOficinaLiteral.TextChanged += new System.EventHandler(this.txtOficinaLiteral_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Oficina";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Unidad Ejecutora";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbxUnidadEjecutora
            // 
            this.cbxUnidadEjecutora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidadEjecutora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxUnidadEjecutora.FormattingEnabled = true;
            this.cbxUnidadEjecutora.Location = new System.Drawing.Point(13, 50);
            this.cbxUnidadEjecutora.Name = "cbxUnidadEjecutora";
            this.cbxUnidadEjecutora.Size = new System.Drawing.Size(600, 24);
            this.cbxUnidadEjecutora.TabIndex = 36;
            this.totMensaje.SetToolTip(this.cbxUnidadEjecutora, "Lista de Roles");
            this.cbxUnidadEjecutora.SelectedIndexChanged += new System.EventHandler(this.cbxUnidadEjecutora_SelectedIndexChanged);
            this.cbxUnidadEjecutora.SelectionChangeCommitted += new System.EventHandler(this.cbxUnidadEjecutora_SelectionChangeCommitted);
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exitb_;
            this.btnSalir.Location = new System.Drawing.Point(322, 156);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 29);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 35;
            this.btnSalir.TabStop = false;
            this.totMensaje.SetToolTip(this.btnSalir, "Cerrar Ventana");
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignar.Image = global::MidasD.Properties.Resources.assign;
            this.btnAsignar.Location = new System.Drawing.Point(209, 156);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(88, 29);
            this.btnAsignar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAsignar.TabIndex = 34;
            this.btnAsignar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnAsignar, "Asignar Menús");
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCabecera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCabecera.Enabled = false;
            this.pnlCabecera.Location = new System.Drawing.Point(9, 33);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(627, 220);
            this.pnlCabecera.TabIndex = 16;
            this.pnlCabecera.TabStop = true;
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatos.Controls.Add(this.gbxMenu);
            this.pnlDatos.Location = new System.Drawing.Point(6, 259);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(627, 320);
            this.pnlDatos.TabIndex = 17;
            this.pnlDatos.TabStop = true;
            // 
            // FrmOficinaCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(645, 581);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grbRol);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.pnlDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmOficinaCargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: MidasD - Oficina Cargo :::";
            this.gbxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            this.grbRol.ResumeLayout(false);
            this.grbRol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAsignar)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbxMenu;
        private System.Windows.Forms.PictureBox btnCancelar;
        private System.Windows.Forms.PictureBox btnGuardar;
        private System.Windows.Forms.ComboBox cbxOficina;
        private System.Windows.Forms.GroupBox grbRol;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.PictureBox btnAsignar;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.CheckedListBox chlCargos;
        private System.Windows.Forms.ToolTip totMensaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxUnidadEjecutora;
        private System.Windows.Forms.TextBox txtOficinaLiteral;
        private System.Windows.Forms.Button btnBuscarOficina;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Gestion;
        private System.Windows.Forms.TextBox txtGestion;
    }
}