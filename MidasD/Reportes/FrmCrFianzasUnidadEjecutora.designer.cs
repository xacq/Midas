namespace MidasD.Reportes
{
    partial class FrmCrFianzasUnidadEjecutora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrFianzasUnidadEjecutora));
            this.crReporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crReporte
            // 
            this.crReporte.ActiveViewIndex = -1;
            this.crReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crReporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.crReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crReporte.Location = new System.Drawing.Point(0, 0);
            this.crReporte.Name = "crReporte";
            this.crReporte.ShowLogo = false;
            this.crReporte.Size = new System.Drawing.Size(800, 450);
            this.crReporte.TabIndex = 0;
            this.crReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmCrFianzasUnidadEjecutora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crReporte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCrFianzasUnidadEjecutora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCrResumenGeneral_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crReporte;
    }
}