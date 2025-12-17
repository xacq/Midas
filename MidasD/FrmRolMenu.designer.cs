namespace MidasD
{
    partial class FrmRolMenu
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
            this.chlMenu = new System.Windows.Forms.CheckedListBox();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.PictureBox();
            this.cbxRol = new System.Windows.Forms.ComboBox();
            this.grbRol = new System.Windows.Forms.GroupBox();
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
            this.lblTitulo.Location = new System.Drawing.Point(131, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(112, 25);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "Rol Menú";
            // 
            // gbxMenu
            // 
            this.gbxMenu.Controls.Add(this.chlMenu);
            this.gbxMenu.Controls.Add(this.btnCancelar);
            this.gbxMenu.Controls.Add(this.btnGuardar);
            this.gbxMenu.Enabled = false;
            this.gbxMenu.Location = new System.Drawing.Point(7, 6);
            this.gbxMenu.Name = "gbxMenu";
            this.gbxMenu.Size = new System.Drawing.Size(337, 264);
            this.gbxMenu.TabIndex = 14;
            this.gbxMenu.TabStop = false;
            this.gbxMenu.Text = "Menús";
            // 
            // chlMenu
            // 
            this.chlMenu.FormattingEnabled = true;
            this.chlMenu.Location = new System.Drawing.Point(5, 19);
            this.chlMenu.Name = "chlMenu";
            this.chlMenu.Size = new System.Drawing.Size(326, 199);
            this.chlMenu.TabIndex = 35;
            this.chlMenu.Tag = "Lista de Menús";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = global::MidasD.Properties.Resources.cancel_inactive;
            this.btnCancelar.Location = new System.Drawing.Point(178, 222);
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
            this.btnGuardar.Location = new System.Drawing.Point(65, 223);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 31);
            this.btnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGuardar.TabIndex = 33;
            this.btnGuardar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnGuardar, "Guardar registro");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbxRol
            // 
            this.cbxRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRol.FormattingEnabled = true;
            this.cbxRol.Location = new System.Drawing.Point(11, 19);
            this.cbxRol.Name = "cbxRol";
            this.cbxRol.Size = new System.Drawing.Size(322, 24);
            this.cbxRol.TabIndex = 4;
            this.totMensaje.SetToolTip(this.cbxRol, "Lista de Roles");
            this.cbxRol.SelectedIndexChanged += new System.EventHandler(this.cbxRol_SelectedIndexChanged);
            // 
            // grbRol
            // 
            this.grbRol.Controls.Add(this.btnAsignar);
            this.grbRol.Controls.Add(this.cbxRol);
            this.grbRol.Location = new System.Drawing.Point(12, 49);
            this.grbRol.Name = "grbRol";
            this.grbRol.Size = new System.Drawing.Size(339, 77);
            this.grbRol.TabIndex = 13;
            this.grbRol.TabStop = false;
            this.grbRol.Text = "Roles";
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exit_;
            this.btnSalir.Location = new System.Drawing.Point(274, 3);
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
            this.btnAsignar.Location = new System.Drawing.Point(134, 47);
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
            this.pnlCabecera.Location = new System.Drawing.Point(9, 38);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(349, 93);
            this.pnlCabecera.TabIndex = 16;
            this.pnlCabecera.TabStop = true;
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatos.Controls.Add(this.gbxMenu);
            this.pnlDatos.Location = new System.Drawing.Point(9, 137);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(349, 268);
            this.pnlDatos.TabIndex = 17;
            this.pnlDatos.TabStop = true;
            // 
            // FrmRolMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(367, 412);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grbRol);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.pnlDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmRolMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: MidasD - Rol Menú :::";
            this.gbxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            this.grbRol.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox cbxRol;
        private System.Windows.Forms.GroupBox grbRol;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.PictureBox btnAsignar;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.CheckedListBox chlMenu;
        private System.Windows.Forms.ToolTip totMensaje;
    }
}