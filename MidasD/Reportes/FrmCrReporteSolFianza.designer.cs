namespace MidasD.Reportes
{
    partial class FrmCrSolicitudFianza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrSolicitudFianza));
            this.crReporteSolFianza = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crReporteSolFianza
            // 
            this.crReporteSolFianza.ActiveViewIndex = -1;
            this.crReporteSolFianza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crReporteSolFianza.Cursor = System.Windows.Forms.Cursors.Default;
            this.crReporteSolFianza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crReporteSolFianza.Location = new System.Drawing.Point(0, 0);
            this.crReporteSolFianza.Name = "crReporteSolFianza";
            this.crReporteSolFianza.ShowLogo = false;
            this.crReporteSolFianza.Size = new System.Drawing.Size(800, 450);
            this.crReporteSolFianza.TabIndex = 0;
            this.crReporteSolFianza.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmCrSolicitudFianza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crReporteSolFianza);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCrSolicitudFianza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crReporteSolFianza;
    }
}