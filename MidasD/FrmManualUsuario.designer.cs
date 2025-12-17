namespace MidasD
{
    partial class FrmManualUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManualUsuario));
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.webBrowserPDF = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserPDF
            // 
            this.webBrowserPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserPDF.Location = new System.Drawing.Point(0, 0);
            this.webBrowserPDF.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPDF.Name = "webBrowserPDF";
            this.webBrowserPDF.Size = new System.Drawing.Size(722, 600);
            this.webBrowserPDF.TabIndex = 1;
            // 
            // FrmManualUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 600);
            this.Controls.Add(this.webBrowserPDF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmManualUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual de Usuarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmManualUsuario_FormClosing);
            this.Load += new System.EventHandler(this.FrmManualUsuario_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.WebBrowser webBrowserPDF;
    }
}