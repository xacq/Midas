namespace MidasD
{
    partial class FrmMenu
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreElemento = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.PictureBox();
            this.txtMenu = new System.Windows.Forms.TextBox();
            this.lblMenu = new System.Windows.Forms.Label();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.grbLista = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.btnBaja = new System.Windows.Forms.PictureBox();
            this.btnEditar = new System.Windows.Forms.PictureBox();
            this.btnNuevo = new System.Windows.Forms.PictureBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.erpMenu = new System.Windows.Forms.ErrorProvider(this.components);
            this.totMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.pnlDatos.SuspendLayout();
            this.grbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            this.pnlLista.SuspendLayout();
            this.grbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(171, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(82, 25);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Menús";
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatos.Controls.Add(this.grbDatos);
            this.pnlDatos.Enabled = false;
            this.pnlDatos.Location = new System.Drawing.Point(9, 304);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(436, 134);
            this.pnlDatos.TabIndex = 10;
            this.pnlDatos.TabStop = true;
            // 
            // grbDatos
            // 
            this.grbDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDatos.Controls.Add(this.label1);
            this.grbDatos.Controls.Add(this.txtNombreElemento);
            this.grbDatos.Controls.Add(this.btnCancelar);
            this.grbDatos.Controls.Add(this.btnGuardar);
            this.grbDatos.Controls.Add(this.txtMenu);
            this.grbDatos.Controls.Add(this.lblMenu);
            this.grbDatos.Location = new System.Drawing.Point(10, 3);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(415, 124);
            this.grbDatos.TabIndex = 0;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nombre Elemento";
            // 
            // txtNombreElemento
            // 
            this.txtNombreElemento.Location = new System.Drawing.Point(9, 67);
            this.txtNombreElemento.Name = "txtNombreElemento";
            this.txtNombreElemento.Size = new System.Drawing.Size(385, 20);
            this.txtNombreElemento.TabIndex = 27;
            this.totMensaje.SetToolTip(this.txtNombreElemento, "Menú");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = global::MidasD.Properties.Resources.cancel_inactive;
            this.btnCancelar.Location = new System.Drawing.Point(215, 91);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 31);
            this.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnCancelar, "Cancelar acción");
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Image = global::MidasD.Properties.Resources.save_inactive;
            this.btnGuardar.Location = new System.Drawing.Point(109, 91);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 31);
            this.btnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnGuardar, "Guardar registro");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtMenu
            // 
            this.txtMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMenu.Location = new System.Drawing.Point(9, 30);
            this.txtMenu.Name = "txtMenu";
            this.txtMenu.Size = new System.Drawing.Size(385, 22);
            this.txtMenu.TabIndex = 0;
            this.totMensaje.SetToolTip(this.txtMenu, "Menú");
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMenu.Location = new System.Drawing.Point(6, 12);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(38, 13);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Menú";
            // 
            // pnlLista
            // 
            this.pnlLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLista.Controls.Add(this.label3);
            this.pnlLista.Controls.Add(this.txtParametro);
            this.pnlLista.Controls.Add(this.grbLista);
            this.pnlLista.Controls.Add(this.btnBuscar);
            this.pnlLista.Location = new System.Drawing.Point(11, 40);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Size = new System.Drawing.Size(434, 249);
            this.pnlLista.TabIndex = 9;
            this.pnlLista.TabStop = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Buscar por Descripción o Nombre de Elemento";
            // 
            // txtParametro
            // 
            this.txtParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParametro.Location = new System.Drawing.Point(14, 34);
            this.txtParametro.MaxLength = 20;
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(286, 22);
            this.txtParametro.TabIndex = 35;
            this.totMensaje.SetToolTip(this.txtParametro, "Introduzca Descripción o Nombre de Elemento del Menú");
            this.txtParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParametro_KeyPress);
            // 
            // grbLista
            // 
            this.grbLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLista.Controls.Add(this.btnBaja);
            this.grbLista.Controls.Add(this.btnEditar);
            this.grbLista.Controls.Add(this.dgvLista);
            this.grbLista.Location = new System.Drawing.Point(8, 60);
            this.grbLista.Name = "grbLista";
            this.grbLista.Size = new System.Drawing.Size(413, 182);
            this.grbLista.TabIndex = 0;
            this.grbLista.TabStop = false;
            this.grbLista.Text = "Lista de Menús";
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exit_;
            this.btnSalir.Location = new System.Drawing.Point(364, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 29);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 33;
            this.btnSalir.TabStop = false;
            this.totMensaje.SetToolTip(this.btnSalir, "Cerrar Ventana");
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaja.Image = global::MidasD.Properties.Resources.delete;
            this.btnBaja.Location = new System.Drawing.Point(212, 146);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(81, 29);
            this.btnBaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBaja.TabIndex = 32;
            this.btnBaja.TabStop = false;
            this.totMensaje.SetToolTip(this.btnBaja, "Dar de Baja al Menú seleccionado");
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Image = global::MidasD.Properties.Resources.edti;
            this.btnEditar.Location = new System.Drawing.Point(125, 146);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(81, 29);
            this.btnEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEditar.TabIndex = 31;
            this.btnEditar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnEditar, "Editar Menú");
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Image = global::MidasD.Properties.Resources._new;
            this.btnNuevo.Location = new System.Drawing.Point(12, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(81, 29);
            this.btnNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnNuevo.TabIndex = 30;
            this.btnNuevo.TabStop = false;
            this.totMensaje.SetToolTip(this.btnNuevo, "Nuevo Menú");
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(6, 19);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(401, 121);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.TabStop = false;
            this.dgvLista.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLista_RowPostPaint);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = global::MidasD.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(306, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 29);
            this.btnBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // erpMenu
            // 
            this.erpMenu.ContainerControl = this;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(458, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: MidasD - Menús :::";
            this.pnlDatos.ResumeLayout(false);
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            this.pnlLista.ResumeLayout(false);
            this.pnlLista.PerformLayout();
            this.grbLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.GroupBox grbDatos;
        private System.Windows.Forms.PictureBox btnCancelar;
        private System.Windows.Forms.PictureBox btnGuardar;
        private System.Windows.Forms.TextBox txtMenu;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.GroupBox grbLista;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.PictureBox btnBaja;
        private System.Windows.Forms.PictureBox btnEditar;
        private System.Windows.Forms.PictureBox btnNuevo;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.ErrorProvider erpMenu;
        private System.Windows.Forms.ToolTip totMensaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.PictureBox btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreElemento;
    }
}