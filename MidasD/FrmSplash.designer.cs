namespace MidasD
{
    partial class FrmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplash));
            this.labelInicio = new System.Windows.Forms.Label();
            this.timerIniciar = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.lbVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.BackColor = System.Drawing.Color.Transparent;
            this.labelInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInicio.ForeColor = System.Drawing.Color.Black;
            this.labelInicio.Location = new System.Drawing.Point(14, 288);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(518, 17);
            this.labelInicio.TabIndex = 3;
            this.labelInicio.Text = "- Seccion de Administración de Sistemas Informaticos y Comunicaciones............" +
    "....";
            // 
            // timerIniciar
            // 
            this.timerIniciar.Enabled = true;
            this.timerIniciar.Interval = 3;
            this.timerIniciar.Tick += new System.EventHandler(this.timerIniciar_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MidasD.Properties.Resources.hecho_bolivia;
            this.pictureBox2.Location = new System.Drawing.Point(660, 266);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(61, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(11, 306);
            this.pb.Margin = new System.Windows.Forms.Padding(2);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(642, 12);
            this.pb.TabIndex = 6;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersion.ForeColor = System.Drawing.Color.Black;
            this.lbVersion.Location = new System.Drawing.Point(473, 157);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(68, 18);
            this.lbVersion.TabIndex = 27;
            this.lbVersion.Text = "versión ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MidasD.Properties.Resources.Moneda;
            this.pictureBox1.Location = new System.Drawing.Point(436, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // FrmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MidasD.Properties.Resources._12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(726, 321);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelInicio);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSplash";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSplash";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timerIniciar;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}