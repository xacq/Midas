namespace MidasD.Reportes
{
    partial class FrmCrCertificado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrCertificado));
            this.crvCertificado = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCertificado
            // 
            this.crvCertificado.ActiveViewIndex = -1;
            this.crvCertificado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCertificado.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCertificado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCertificado.Location = new System.Drawing.Point(0, 0);
            this.crvCertificado.Name = "crvCertificado";
            this.crvCertificado.Size = new System.Drawing.Size(665, 566);
            this.crvCertificado.TabIndex = 0;
            this.crvCertificado.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmCrCertificado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(665, 566);
            this.Controls.Add(this.crvCertificado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCrCertificado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresion Certificado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReporteRestitucionEfectivo_FormClosing);
            this.Load += new System.EventHandler(this.FrmCrCertificado_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCertificado;
    }
}