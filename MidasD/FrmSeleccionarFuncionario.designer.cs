namespace MidasD
{
    partial class FrmSeleccionarFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionarFuncionario));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.gbxMenu = new System.Windows.Forms.GroupBox();
            this.chkSeleccionarTodo = new System.Windows.Forms.CheckBox();
            this.chlFuncionario = new System.Windows.Forms.CheckedListBox();
            this.totMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbxUnidadEjecutora = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            this.gbxMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(206, 3);
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
            this.btnCancelar.Location = new System.Drawing.Point(332, 3);
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
            this.pnlDatos.Controls.Add(this.gbxMenu);
            this.pnlDatos.Location = new System.Drawing.Point(12, 79);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(630, 367);
            this.pnlDatos.TabIndex = 22;
            this.pnlDatos.TabStop = true;
            // 
            // gbxMenu
            // 
            this.gbxMenu.Controls.Add(this.chkSeleccionarTodo);
            this.gbxMenu.Controls.Add(this.chlFuncionario);
            this.gbxMenu.Location = new System.Drawing.Point(0, 0);
            this.gbxMenu.Name = "gbxMenu";
            this.gbxMenu.Size = new System.Drawing.Size(620, 353);
            this.gbxMenu.TabIndex = 14;
            this.gbxMenu.TabStop = false;
            this.gbxMenu.Text = "Lista de Personal";
            // 
            // chkSeleccionarTodo
            // 
            this.chkSeleccionarTodo.AutoSize = true;
            this.chkSeleccionarTodo.Location = new System.Drawing.Point(6, 327);
            this.chkSeleccionarTodo.Name = "chkSeleccionarTodo";
            this.chkSeleccionarTodo.Size = new System.Drawing.Size(110, 17);
            this.chkSeleccionarTodo.TabIndex = 36;
            this.chkSeleccionarTodo.Text = "Seleccionar Todo";
            this.chkSeleccionarTodo.UseVisualStyleBackColor = true;
            this.chkSeleccionarTodo.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodo_CheckedChanged);
            // 
            // chlFuncionario
            // 
            this.chlFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chlFuncionario.CheckOnClick = true;
            this.chlFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chlFuncionario.FormattingEnabled = true;
            this.chlFuncionario.HorizontalScrollbar = true;
            this.chlFuncionario.Location = new System.Drawing.Point(5, 19);
            this.chlFuncionario.Name = "chlFuncionario";
            this.chlFuncionario.Size = new System.Drawing.Size(609, 292);
            this.chlFuncionario.TabIndex = 35;
            this.chlFuncionario.Tag = "Lista de Menús";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Location = new System.Drawing.Point(12, 462);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 44);
            this.panel2.TabIndex = 23;
            this.panel2.TabStop = true;
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(313, 41);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(240, 20);
            this.txtParametro.TabIndex = 24;
            this.txtParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParametro_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Location = new System.Drawing.Point(559, 39);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 25;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbxUnidadEjecutora
            // 
            this.cbxUnidadEjecutora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidadEjecutora.FormattingEnabled = true;
            this.cbxUnidadEjecutora.Items.AddRange(new object[] {
            "Direccion Administrativa Financiera",
            "Derechos Reales",
            "Tribunal Supremo de Justicia",
            "Concejo de la Magistratura"});
            this.cbxUnidadEjecutora.Location = new System.Drawing.Point(12, 40);
            this.cbxUnidadEjecutora.Name = "cbxUnidadEjecutora";
            this.cbxUnidadEjecutora.Size = new System.Drawing.Size(277, 21);
            this.cbxUnidadEjecutora.TabIndex = 26;
            this.cbxUnidadEjecutora.SelectionChangeCommitted += new System.EventHandler(this.cbxUnidadEjecutora_SelectionChangeCommitted);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(200, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(239, 25);
            this.lblTitulo.TabIndex = 27;
            this.lblTitulo.Text = "Lista de Funcionarios";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Unidad Ejecutora";
            // 
            // FrmSeleccionarFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(654, 518);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.cbxUnidadEjecutora);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtParametro);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmSeleccionarFuncionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: MIdas - Lista de Personal:::";
            this.Load += new System.EventHandler(this.FrmSeleccionarFuncionario_Load);
            this.pnlDatos.ResumeLayout(false);
            this.gbxMenu.ResumeLayout(false);
            this.gbxMenu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.GroupBox gbxMenu;
        private System.Windows.Forms.CheckBox chkSeleccionarTodo;
        private System.Windows.Forms.CheckedListBox chlFuncionario;
        private System.Windows.Forms.ToolTip totMensaje;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbxUnidadEjecutora;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
    }
}