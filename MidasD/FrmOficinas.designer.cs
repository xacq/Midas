namespace MidasD
{
    partial class FrmOficinas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.txtCuantia = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxUnidadEjecutora = new System.Windows.Forms.ComboBox();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.txtOficina = new System.Windows.Forms.TextBox();
            this.lblOficina = new System.Windows.Forms.Label();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.PictureBox();
            this.grbLista = new System.Windows.Forms.GroupBox();
            this.btnBaja = new System.Windows.Forms.PictureBox();
            this.btnEditar = new System.Windows.Forms.PictureBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.erpMenu = new System.Windows.Forms.ErrorProvider(this.components);
            this.totMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.pnlDatos.SuspendLayout();
            this.grbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).BeginInit();
            this.grbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(382, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(98, 25);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Oficinas";
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatos.Controls.Add(this.grbDatos);
            this.pnlDatos.Enabled = false;
            this.pnlDatos.Location = new System.Drawing.Point(9, 414);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(853, 151);
            this.pnlDatos.TabIndex = 10;
            this.pnlDatos.TabStop = true;
            // 
            // grbDatos
            // 
            this.grbDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDatos.Controls.Add(this.txtCuantia);
            this.grbDatos.Controls.Add(this.btnCancelar);
            this.grbDatos.Controls.Add(this.btnGuardar);
            this.grbDatos.Controls.Add(this.label1);
            this.grbDatos.Controls.Add(this.label4);
            this.grbDatos.Controls.Add(this.label2);
            this.grbDatos.Controls.Add(this.cbxUnidadEjecutora);
            this.grbDatos.Controls.Add(this.txtPorcentaje);
            this.grbDatos.Controls.Add(this.txtOficina);
            this.grbDatos.Controls.Add(this.lblOficina);
            this.grbDatos.Location = new System.Drawing.Point(10, 3);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(836, 130);
            this.grbDatos.TabIndex = 0;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos";
            // 
            // txtCuantia
            // 
            this.txtCuantia.Location = new System.Drawing.Point(531, 79);
            this.txtCuantia.Name = "txtCuantia";
            this.txtCuantia.Size = new System.Drawing.Size(47, 20);
            this.txtCuantia.TabIndex = 30;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = global::MidasD.Properties.Resources.cancel_inactive;
            this.btnCancelar.Location = new System.Drawing.Point(727, 101);
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
            this.btnGuardar.Location = new System.Drawing.Point(727, 64);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 31);
            this.btnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnGuardar, "Guardar registro");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(427, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "UnidadEjecutora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(430, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Porcentaje";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(528, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cuantia";
            // 
            // cbxUnidadEjecutora
            // 
            this.cbxUnidadEjecutora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidadEjecutora.FormattingEnabled = true;
            this.cbxUnidadEjecutora.Location = new System.Drawing.Point(427, 32);
            this.cbxUnidadEjecutora.Name = "cbxUnidadEjecutora";
            this.cbxUnidadEjecutora.Size = new System.Drawing.Size(407, 21);
            this.cbxUnidadEjecutora.TabIndex = 1;
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(440, 80);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(47, 20);
            this.txtPorcentaje.TabIndex = 28;
            // 
            // txtOficina
            // 
            this.txtOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOficina.Location = new System.Drawing.Point(9, 34);
            this.txtOficina.Multiline = true;
            this.txtOficina.Name = "txtOficina";
            this.txtOficina.Size = new System.Drawing.Size(404, 83);
            this.txtOficina.TabIndex = 0;
            this.totMensaje.SetToolTip(this.txtOficina, "Menú");
            // 
            // lblOficina
            // 
            this.lblOficina.AutoSize = true;
            this.lblOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblOficina.Location = new System.Drawing.Point(6, 14);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(47, 13);
            this.lblOficina.TabIndex = 0;
            this.lblOficina.Text = "Oficina";
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
            this.pnlLista.Size = new System.Drawing.Size(851, 368);
            this.pnlLista.TabIndex = 9;
            this.pnlLista.TabStop = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Buscar por Descripción o Nombre ";
            // 
            // txtParametro
            // 
            this.txtParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParametro.Location = new System.Drawing.Point(287, 19);
            this.txtParametro.MaxLength = 20;
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(286, 21);
            this.txtParametro.TabIndex = 35;
            this.totMensaje.SetToolTip(this.txtParametro, "Introduzca Descripción o Nombre de Elemento del Menú");
            this.txtParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParametro_KeyPress);
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
            // grbLista
            // 
            this.grbLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLista.Controls.Add(this.btnBaja);
            this.grbLista.Controls.Add(this.btnEditar);
            this.grbLista.Controls.Add(this.dgvLista);
            this.grbLista.Location = new System.Drawing.Point(8, 50);
            this.grbLista.Name = "grbLista";
            this.grbLista.Size = new System.Drawing.Size(830, 311);
            this.grbLista.TabIndex = 0;
            this.grbLista.TabStop = false;
            this.grbLista.Text = "Lista de Oficinas";
            // 
            // btnBaja
            // 
            this.btnBaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaja.Image = global::MidasD.Properties.Resources.delete;
            this.btnBaja.Location = new System.Drawing.Point(430, 276);
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
            this.btnEditar.Location = new System.Drawing.Point(343, 276);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(81, 29);
            this.btnEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEditar.TabIndex = 31;
            this.btnEditar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnEditar, "Editar Menú");
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLista.Location = new System.Drawing.Point(6, 19);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(818, 251);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.TabStop = false;
            this.dgvLista.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLista_RowPostPaint);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = global::MidasD.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(579, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 29);
            this.btnBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exit_;
            this.btnSalir.Location = new System.Drawing.Point(776, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 29);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 33;
            this.btnSalir.TabStop = false;
            this.totMensaje.SetToolTip(this.btnSalir, "Cerrar Ventana");
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // erpMenu
            // 
            this.erpMenu.ContainerControl = this;
            // 
            // FrmOficinas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(875, 577);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmOficinas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: MidasD - Oficinas :::";
            this.pnlDatos.ResumeLayout(false);
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            this.pnlLista.ResumeLayout(false);
            this.pnlLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).EndInit();
            this.grbLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
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
        private System.Windows.Forms.TextBox txtOficina;
        private System.Windows.Forms.Label lblOficina;
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
        private System.Windows.Forms.ComboBox cbxUnidadEjecutora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.TextBox txtCuantia;
    }
}