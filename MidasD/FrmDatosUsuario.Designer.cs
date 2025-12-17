namespace MidasD
{
    partial class FrmDatosUsuario
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
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.lblNombres = new System.Windows.Forms.TextBox();
            this.lblCi = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;
            this.pbImagen.Location = new System.Drawing.Point(38, 12);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(110, 124);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 0;
            this.pbImagen.TabStop = false;
            // 
            // lblNombres
            // 
            this.lblNombres.Enabled = false;
            this.lblNombres.Location = new System.Drawing.Point(11, 151);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(172, 20);
            this.lblNombres.TabIndex = 1;
            this.lblNombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCi
            // 
            this.lblCi.Enabled = false;
            this.lblCi.Location = new System.Drawing.Point(11, 178);
            this.lblCi.Name = "lblCi";
            this.lblCi.Size = new System.Drawing.Size(172, 20);
            this.lblCi.TabIndex = 2;
            this.lblCi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRol
            // 
            this.lblRol.Enabled = false;
            this.lblRol.Location = new System.Drawing.Point(11, 205);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(172, 20);
            this.lblRol.TabIndex = 3;
            this.lblRol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pbImagen);
            this.panel1.Controls.Add(this.lblRol);
            this.panel1.Controls.Add(this.lblNombres);
            this.panel1.Controls.Add(this.lblCi);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 236);
            this.panel1.TabIndex = 4;
            // 
            // FrmDatosUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(221, 260);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDatosUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información de Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.TextBox lblNombres;
        private System.Windows.Forms.TextBox lblCi;
        private System.Windows.Forms.TextBox lblRol;
        private System.Windows.Forms.Panel panel1;
    }
}