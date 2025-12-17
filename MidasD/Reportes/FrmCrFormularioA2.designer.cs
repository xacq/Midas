namespace MidasD.Reportes
{
    partial class FrmCrFormularioA2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrFormularioA2));
            this.crvFormularioA2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvFormularioA2
            // 
            this.crvFormularioA2.ActiveViewIndex = -1;
            this.crvFormularioA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvFormularioA2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvFormularioA2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvFormularioA2.Location = new System.Drawing.Point(0, 0);
            this.crvFormularioA2.Name = "crvFormularioA2";
            this.crvFormularioA2.Size = new System.Drawing.Size(665, 566);
            this.crvFormularioA2.TabIndex = 0;
            this.crvFormularioA2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmCrFormularioA2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(665, 566);
            this.Controls.Add(this.crvFormularioA2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCrFormularioA2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresion ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReporteRestitucionEfectivo_FormClosing);
            this.Load += new System.EventHandler(this.FrmCrFormularioA2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvFormularioA2;
    }
}