namespace MidasD
{
    partial class FrmCambiarClave
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.PictureBox();
            this.txtConfirmaClave = new System.Windows.Forms.TextBox();
            this.txtClaveNueva = new System.Windows.Forms.TextBox();
            this.txtClaveActual = new System.Windows.Forms.TextBox();
            this.lblConfirmaClave = new System.Windows.Forms.Label();
            this.lblClaveNueva = new System.Windows.Forms.Label();
            this.lblClaveactual = new System.Windows.Forms.Label();
            this.erpClaveActual = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpNuevaClave = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpConfirmarClave = new System.Windows.Forms.ErrorProvider(this.components);
            this.totMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpClaveActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpNuevaClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpConfirmarClave)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatos.Controls.Add(this.btnSalir);
            this.pnlDatos.Controls.Add(this.btnGuardar);
            this.pnlDatos.Controls.Add(this.txtConfirmaClave);
            this.pnlDatos.Controls.Add(this.txtClaveNueva);
            this.pnlDatos.Controls.Add(this.txtClaveActual);
            this.pnlDatos.Controls.Add(this.lblConfirmaClave);
            this.pnlDatos.Controls.Add(this.lblClaveNueva);
            this.pnlDatos.Controls.Add(this.lblClaveactual);
            this.pnlDatos.Location = new System.Drawing.Point(11, 11);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(231, 204);
            this.pnlDatos.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exit_;
            this.btnSalir.Location = new System.Drawing.Point(120, 154);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(87, 29);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 23;
            this.btnSalir.TabStop = false;
            this.totMensaje.SetToolTip(this.btnSalir, "Cerrar Ventana");
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Image = global::MidasD.Properties.Resources.save;
            this.btnGuardar.Location = new System.Drawing.Point(17, 154);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(87, 31);
            this.btnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnGuardar, "Cambiar clave");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtConfirmaClave
            // 
            this.txtConfirmaClave.Location = new System.Drawing.Point(17, 128);
            this.txtConfirmaClave.Name = "txtConfirmaClave";
            this.txtConfirmaClave.PasswordChar = '*';
            this.txtConfirmaClave.Size = new System.Drawing.Size(190, 20);
            this.txtConfirmaClave.TabIndex = 2;
            this.txtConfirmaClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmaClave_KeyPress);
            // 
            // txtClaveNueva
            // 
            this.txtClaveNueva.Location = new System.Drawing.Point(17, 83);
            this.txtClaveNueva.Name = "txtClaveNueva";
            this.txtClaveNueva.PasswordChar = '*';
            this.txtClaveNueva.Size = new System.Drawing.Size(190, 20);
            this.txtClaveNueva.TabIndex = 1;
            this.txtClaveNueva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClaveNueva_KeyPress);
            // 
            // txtClaveActual
            // 
            this.txtClaveActual.Location = new System.Drawing.Point(17, 38);
            this.txtClaveActual.Name = "txtClaveActual";
            this.txtClaveActual.PasswordChar = '*';
            this.txtClaveActual.Size = new System.Drawing.Size(190, 20);
            this.txtClaveActual.TabIndex = 0;
            this.txtClaveActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClaveActual_KeyPress);
            // 
            // lblConfirmaClave
            // 
            this.lblConfirmaClave.AutoSize = true;
            this.lblConfirmaClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmaClave.Location = new System.Drawing.Point(14, 112);
            this.lblConfirmaClave.Name = "lblConfirmaClave";
            this.lblConfirmaClave.Size = new System.Drawing.Size(96, 13);
            this.lblConfirmaClave.TabIndex = 0;
            this.lblConfirmaClave.Text = "Confirmar Clave";
            // 
            // lblClaveNueva
            // 
            this.lblClaveNueva.AutoSize = true;
            this.lblClaveNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaveNueva.Location = new System.Drawing.Point(14, 67);
            this.lblClaveNueva.Name = "lblClaveNueva";
            this.lblClaveNueva.Size = new System.Drawing.Size(80, 13);
            this.lblClaveNueva.TabIndex = 0;
            this.lblClaveNueva.Text = "Clave Nueva";
            // 
            // lblClaveactual
            // 
            this.lblClaveactual.AutoSize = true;
            this.lblClaveactual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaveactual.Location = new System.Drawing.Point(14, 22);
            this.lblClaveactual.Name = "lblClaveactual";
            this.lblClaveactual.Size = new System.Drawing.Size(79, 13);
            this.lblClaveactual.TabIndex = 0;
            this.lblClaveactual.Text = "Clave Actual";
            // 
            // erpClaveActual
            // 
            this.erpClaveActual.ContainerControl = this;
            // 
            // erpNuevaClave
            // 
            this.erpNuevaClave.ContainerControl = this;
            // 
            // erpConfirmarClave
            // 
            this.erpConfirmarClave.ContainerControl = this;
            // 
            // FrmCambiarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(253, 226);
            this.Controls.Add(this.pnlDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmCambiarClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: TodoAgro - Cambiar Clave :::";
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpClaveActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpNuevaClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpConfirmarClave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.PictureBox btnGuardar;
        private System.Windows.Forms.TextBox txtConfirmaClave;
        private System.Windows.Forms.TextBox txtClaveNueva;
        private System.Windows.Forms.TextBox txtClaveActual;
        private System.Windows.Forms.Label lblConfirmaClave;
        private System.Windows.Forms.Label lblClaveNueva;
        private System.Windows.Forms.Label lblClaveactual;
        private System.Windows.Forms.ErrorProvider erpClaveActual;
        private System.Windows.Forms.ErrorProvider erpNuevaClave;
        private System.Windows.Forms.ErrorProvider erpConfirmarClave;
        private System.Windows.Forms.ToolTip totMensaje;
    }
}