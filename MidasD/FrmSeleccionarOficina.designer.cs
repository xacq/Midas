namespace MidasD
{
    partial class FrmSeleccionarOficina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionarOficina));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.gbxMenu = new System.Windows.Forms.GroupBox();
            this.dgvListaOficinas = new System.Windows.Forms.DataGridView();
            this.totMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.gbxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOficinas)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(356, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(101, 36);
            this.btnAceptar.TabIndex = 39;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.totMensaje.SetToolTip(this.btnAceptar, "Imprimir Seleccionados");
            this.btnAceptar.UseCompatibleTextRendering = true;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(463, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 36);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.totMensaje.SetToolTip(this.btnCancelar, "Cancelar acción");
            this.btnCancelar.UseCompatibleTextRendering = true;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatos.Location = new System.Drawing.Point(12, 79);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(934, 328);
            this.pnlDatos.TabIndex = 22;
            this.pnlDatos.TabStop = true;
            // 
            // gbxMenu
            // 
            this.gbxMenu.Controls.Add(this.dgvListaOficinas);
            this.gbxMenu.Location = new System.Drawing.Point(14, 42);
            this.gbxMenu.Name = "gbxMenu";
            this.gbxMenu.Size = new System.Drawing.Size(927, 353);
            this.gbxMenu.TabIndex = 14;
            this.gbxMenu.TabStop = false;
            this.gbxMenu.Text = "Lista de Oficinas";
            // 
            // dgvListaOficinas
            // 
            this.dgvListaOficinas.AllowUserToAddRows = false;
            this.dgvListaOficinas.AllowUserToDeleteRows = false;
            this.dgvListaOficinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaOficinas.Location = new System.Drawing.Point(6, 19);
            this.dgvListaOficinas.Name = "dgvListaOficinas";
            this.dgvListaOficinas.ReadOnly = true;
            this.dgvListaOficinas.Size = new System.Drawing.Size(921, 328);
            this.dgvListaOficinas.TabIndex = 0;
            this.dgvListaOficinas.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvGrilla_RowPostPaint);
            this.dgvListaOficinas.DoubleClick += new System.EventHandler(this.dgvListaOficinas_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Location = new System.Drawing.Point(12, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(934, 44);
            this.panel2.TabIndex = 23;
            this.panel2.TabStop = true;
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(242, 15);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(349, 20);
            this.txtParametro.TabIndex = 24;
            this.txtParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParametro_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Location = new System.Drawing.Point(597, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 25;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(7, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(189, 25);
            this.lblTitulo.TabIndex = 27;
            this.lblTitulo.Text = "Lista de Oficinas";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Maroon;
            this.label16.Location = new System.Drawing.Point(716, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(225, 24);
            this.label16.TabIndex = 105;
            this.label16.Text = "Listado de Oficinas segun la Unidad Ejecutora\r\n(Puede hacer doble click para sele" +
    "ccionar la oficina)\r\n";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmSeleccionarOficina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(958, 462);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.gbxMenu);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtParametro);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmSeleccionarOficina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: MidasD - Lista de Oficinas::";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSeleccionarOficina_FormClosing);
            this.gbxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOficinas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.GroupBox gbxMenu;
        private System.Windows.Forms.ToolTip totMensaje;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvListaOficinas;
        private System.Windows.Forms.Label label16;
    }
}