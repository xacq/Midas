namespace MidasD
{
    partial class FrmCargos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.chkDenominacion = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxTipoPersonal = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxSueldoMensual = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxEscalaSalarial = new System.Windows.Forms.ComboBox();
            this.txtCargoDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxOficina = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxUnidadEjecutora = new System.Windows.Forms.ComboBox();
            this.txtCargoDenominacion = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.erpMenu = new System.Windows.Forms.ErrorProvider(this.components);
            this.totMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.btnNuevo = new System.Windows.Forms.PictureBox();
            this.btnEditar = new System.Windows.Forms.PictureBox();
            this.btnBaja = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.cbxOficinaLista = new System.Windows.Forms.ComboBox();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.grbLista = new System.Windows.Forms.GroupBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxUnidadEjecutoraLista = new System.Windows.Forms.ComboBox();
            this.txtGestion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Gestion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBuscarOficina = new System.Windows.Forms.Button();
            this.txtOficinaLiteral = new System.Windows.Forms.TextBox();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.pnlDatos.SuspendLayout();
            this.grbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.grbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.pnlLista.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(527, 2);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(216, 25);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Cargos por Oficina ";
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatos.Controls.Add(this.grbDatos);
            this.pnlDatos.Controls.Add(this.btnGuardar);
            this.pnlDatos.Controls.Add(this.btnCancelar);
            this.pnlDatos.Enabled = false;
            this.pnlDatos.Location = new System.Drawing.Point(755, 33);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(442, 526);
            this.pnlDatos.TabIndex = 10;
            this.pnlDatos.TabStop = true;
            // 
            // grbDatos
            // 
            this.grbDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDatos.Controls.Add(this.chkDenominacion);
            this.grbDatos.Controls.Add(this.label8);
            this.grbDatos.Controls.Add(this.cbxTipoPersonal);
            this.grbDatos.Controls.Add(this.label7);
            this.grbDatos.Controls.Add(this.cbxSueldoMensual);
            this.grbDatos.Controls.Add(this.label6);
            this.grbDatos.Controls.Add(this.cbxEscalaSalarial);
            this.grbDatos.Controls.Add(this.txtCargoDescripcion);
            this.grbDatos.Controls.Add(this.label5);
            this.grbDatos.Controls.Add(this.label2);
            this.grbDatos.Controls.Add(this.cbxOficina);
            this.grbDatos.Controls.Add(this.label1);
            this.grbDatos.Controls.Add(this.cbxUnidadEjecutora);
            this.grbDatos.Controls.Add(this.txtCargoDenominacion);
            this.grbDatos.Controls.Add(this.lblCargo);
            this.grbDatos.Location = new System.Drawing.Point(10, 3);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(425, 397);
            this.grbDatos.TabIndex = 0;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos";
            // 
            // chkDenominacion
            // 
            this.chkDenominacion.AutoSize = true;
            this.chkDenominacion.Location = new System.Drawing.Point(115, 37);
            this.chkDenominacion.Name = "chkDenominacion";
            this.chkDenominacion.Size = new System.Drawing.Size(191, 17);
            this.chkDenominacion.TabIndex = 37;
            this.chkDenominacion.Text = "Usar Denominacion Escala Salarial";
            this.chkDenominacion.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(11, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Tipo de Personal";
            // 
            // cbxTipoPersonal
            // 
            this.cbxTipoPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoPersonal.FormattingEnabled = true;
            this.cbxTipoPersonal.Items.AddRange(new object[] {
            "ADMINISTRATIVO ",
            "SUSTANTIVO ",
            "ANTIGUO"});
            this.cbxTipoPersonal.Location = new System.Drawing.Point(11, 354);
            this.cbxTipoPersonal.Name = "cbxTipoPersonal";
            this.cbxTipoPersonal.Size = new System.Drawing.Size(407, 21);
            this.cbxTipoPersonal.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(11, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Sueldo Mensual";
            // 
            // cbxSueldoMensual
            // 
            this.cbxSueldoMensual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSueldoMensual.FormattingEnabled = true;
            this.cbxSueldoMensual.Location = new System.Drawing.Point(11, 57);
            this.cbxSueldoMensual.Name = "cbxSueldoMensual";
            this.cbxSueldoMensual.Size = new System.Drawing.Size(407, 21);
            this.cbxSueldoMensual.TabIndex = 0;
            this.cbxSueldoMensual.SelectedIndexChanged += new System.EventHandler(this.cbxSueldoMensual_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(11, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Escala Salarial";
            // 
            // cbxEscalaSalarial
            // 
            this.cbxEscalaSalarial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbxEscalaSalarial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbxEscalaSalarial.Enabled = false;
            this.cbxEscalaSalarial.FormattingEnabled = true;
            this.cbxEscalaSalarial.Location = new System.Drawing.Point(12, 103);
            this.cbxEscalaSalarial.Name = "cbxEscalaSalarial";
            this.cbxEscalaSalarial.Size = new System.Drawing.Size(407, 21);
            this.cbxEscalaSalarial.TabIndex = 1;
            // 
            // txtCargoDescripcion
            // 
            this.txtCargoDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargoDescripcion.Location = new System.Drawing.Point(11, 200);
            this.txtCargoDescripcion.Multiline = true;
            this.txtCargoDescripcion.Name = "txtCargoDescripcion";
            this.txtCargoDescripcion.Size = new System.Drawing.Size(404, 21);
            this.txtCargoDescripcion.TabIndex = 3;
            this.totMensaje.SetToolTip(this.txtCargoDescripcion, "Cargos");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(11, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Descripcion del Puesto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Oficina";
            // 
            // cbxOficina
            // 
            this.cbxOficina.FormattingEnabled = true;
            this.cbxOficina.Location = new System.Drawing.Point(11, 300);
            this.cbxOficina.Name = "cbxOficina";
            this.cbxOficina.Size = new System.Drawing.Size(407, 21);
            this.cbxOficina.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "UnidadEjecutora";
            // 
            // cbxUnidadEjecutora
            // 
            this.cbxUnidadEjecutora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidadEjecutora.FormattingEnabled = true;
            this.cbxUnidadEjecutora.Location = new System.Drawing.Point(11, 250);
            this.cbxUnidadEjecutora.Name = "cbxUnidadEjecutora";
            this.cbxUnidadEjecutora.Size = new System.Drawing.Size(407, 21);
            this.cbxUnidadEjecutora.TabIndex = 4;
            this.cbxUnidadEjecutora.SelectedIndexChanged += new System.EventHandler(this.cbxUnidadEjecutora_SelectedIndexChanged);
            // 
            // txtCargoDenominacion
            // 
            this.txtCargoDenominacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargoDenominacion.Location = new System.Drawing.Point(11, 150);
            this.txtCargoDenominacion.Multiline = true;
            this.txtCargoDenominacion.Name = "txtCargoDenominacion";
            this.txtCargoDenominacion.Size = new System.Drawing.Size(404, 21);
            this.txtCargoDenominacion.TabIndex = 2;
            this.totMensaje.SetToolTip(this.txtCargoDenominacion, "Cargos");
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCargo.Location = new System.Drawing.Point(11, 132);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(151, 13);
            this.lblCargo.TabIndex = 0;
            this.lblCargo.Text = "Denominacion del Puesto";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Image = global::MidasD.Properties.Resources.save_inactive;
            this.btnGuardar.Location = new System.Drawing.Point(125, 406);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 31);
            this.btnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnGuardar, "Guardar registro");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = global::MidasD.Properties.Resources.cancel_inactive;
            this.btnCancelar.Location = new System.Drawing.Point(228, 406);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 31);
            this.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnCancelar, "Cancelar acción");
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // erpMenu
            // 
            this.erpMenu.ContainerControl = this;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = global::MidasD.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(607, 55);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 29);
            this.btnBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Image = global::MidasD.Properties.Resources._new;
            this.btnNuevo.Location = new System.Drawing.Point(620, 88);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(81, 29);
            this.btnNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnNuevo.TabIndex = 30;
            this.btnNuevo.TabStop = false;
            this.totMensaje.SetToolTip(this.btnNuevo, "Nuevo Menú");
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Image = global::MidasD.Properties.Resources.edti;
            this.btnEditar.Location = new System.Drawing.Point(261, 361);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(81, 29);
            this.btnEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEditar.TabIndex = 31;
            this.btnEditar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnEditar, "Editar Menú");
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaja.Image = global::MidasD.Properties.Resources.delete;
            this.btnBaja.Location = new System.Drawing.Point(348, 361);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(81, 29);
            this.btnBaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBaja.TabIndex = 32;
            this.btnBaja.TabStop = false;
            this.totMensaje.SetToolTip(this.btnBaja, "Dar de Baja al Menú seleccionado");
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exit_;
            this.btnSalir.Location = new System.Drawing.Point(1115, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 29);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 33;
            this.btnSalir.TabStop = false;
            this.totMensaje.SetToolTip(this.btnSalir, "Cerrar Ventana");
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cbxOficinaLista
            // 
            this.cbxOficinaLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOficinaLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOficinaLista.FormattingEnabled = true;
            this.cbxOficinaLista.Location = new System.Drawing.Point(215, 223);
            this.cbxOficinaLista.Name = "cbxOficinaLista";
            this.cbxOficinaLista.Size = new System.Drawing.Size(132, 24);
            this.cbxOficinaLista.TabIndex = 34;
            this.totMensaje.SetToolTip(this.cbxOficinaLista, "Lista de Roles");
            this.cbxOficinaLista.Visible = false;
            // 
            // txtParametro
            // 
            this.txtParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParametro.Location = new System.Drawing.Point(490, 25);
            this.txtParametro.MaxLength = 20;
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(232, 21);
            this.txtParametro.TabIndex = 35;
            this.totMensaje.SetToolTip(this.txtParametro, "Introduzca Descripción o Nombre de Elemento del Menú");
            this.txtParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParametro_KeyPress);
            // 
            // grbLista
            // 
            this.grbLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLista.Controls.Add(this.cbxOficinaLista);
            this.grbLista.Controls.Add(this.btnBaja);
            this.grbLista.Controls.Add(this.dgvLista);
            this.grbLista.Controls.Add(this.btnEditar);
            this.grbLista.Location = new System.Drawing.Point(8, 123);
            this.grbLista.Name = "grbLista";
            this.grbLista.Size = new System.Drawing.Size(723, 396);
            this.grbLista.TabIndex = 0;
            this.grbLista.TabStop = false;
            this.grbLista.Text = "Lista de Cargos";
            // 
            // dgvLista
            // 
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLista.Location = new System.Drawing.Point(6, 19);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(705, 327);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.TabStop = false;
            this.dgvLista.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLista_CellMouseDoubleClick);
            this.dgvLista.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLista_RowPostPaint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(487, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Buscar por Descripción o Nombre ";
            // 
            // cbxUnidadEjecutoraLista
            // 
            this.cbxUnidadEjecutoraLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidadEjecutoraLista.FormattingEnabled = true;
            this.cbxUnidadEjecutoraLista.Location = new System.Drawing.Point(18, 24);
            this.cbxUnidadEjecutoraLista.Name = "cbxUnidadEjecutoraLista";
            this.cbxUnidadEjecutoraLista.Size = new System.Drawing.Size(466, 21);
            this.cbxUnidadEjecutoraLista.TabIndex = 37;
            this.cbxUnidadEjecutoraLista.SelectedIndexChanged += new System.EventHandler(this.cbxUnidadEjecutoraLista_SelectedIndexChanged);
            // 
            // txtGestion
            // 
            this.txtGestion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGestion.Location = new System.Drawing.Point(1014, 6);
            this.txtGestion.Name = "txtGestion";
            this.txtGestion.Size = new System.Drawing.Size(73, 22);
            this.txtGestion.TabIndex = 83;
            this.txtGestion.TextChanged += new System.EventHandler(this.txtGestion_TextChanged);
            this.txtGestion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGestion_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(17, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "UnidadEjecutora";
            // 
            // Gestion
            // 
            this.Gestion.AutoSize = true;
            this.Gestion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gestion.Location = new System.Drawing.Point(904, 10);
            this.Gestion.Name = "Gestion";
            this.Gestion.Size = new System.Drawing.Size(104, 15);
            this.Gestion.TabIndex = 84;
            this.Gestion.Text = "Año de los Cargos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(825, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 24);
            this.label9.TabIndex = 85;
            this.label9.Text = "Sueldo Mensual\r\nSegun Año";
            // 
            // btnBuscarOficina
            // 
            this.btnBuscarOficina.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBuscarOficina.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBuscarOficina.FlatAppearance.BorderSize = 0;
            this.btnBuscarOficina.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBuscarOficina.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBuscarOficina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarOficina.Image = global::MidasD.Properties.Resources.lupa;
            this.btnBuscarOficina.Location = new System.Drawing.Point(19, 64);
            this.btnBuscarOficina.Name = "btnBuscarOficina";
            this.btnBuscarOficina.Size = new System.Drawing.Size(45, 45);
            this.btnBuscarOficina.TabIndex = 86;
            this.btnBuscarOficina.UseVisualStyleBackColor = false;
            this.btnBuscarOficina.Click += new System.EventHandler(this.btnBuscarOficina_Click);
            // 
            // txtOficinaLiteral
            // 
            this.txtOficinaLiteral.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtOficinaLiteral.Enabled = false;
            this.txtOficinaLiteral.Location = new System.Drawing.Point(70, 55);
            this.txtOficinaLiteral.Multiline = true;
            this.txtOficinaLiteral.Name = "txtOficinaLiteral";
            this.txtOficinaLiteral.Size = new System.Drawing.Size(531, 62);
            this.txtOficinaLiteral.TabIndex = 87;
            this.txtOficinaLiteral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlLista
            // 
            this.pnlLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLista.Controls.Add(this.txtOficinaLiteral);
            this.pnlLista.Controls.Add(this.btnBuscarOficina);
            this.pnlLista.Controls.Add(this.label4);
            this.pnlLista.Controls.Add(this.cbxUnidadEjecutoraLista);
            this.pnlLista.Controls.Add(this.btnNuevo);
            this.pnlLista.Controls.Add(this.label3);
            this.pnlLista.Controls.Add(this.txtParametro);
            this.pnlLista.Controls.Add(this.grbLista);
            this.pnlLista.Controls.Add(this.btnBuscar);
            this.pnlLista.Location = new System.Drawing.Point(11, 33);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Size = new System.Drawing.Size(738, 526);
            this.pnlLista.TabIndex = 9;
            this.pnlLista.TabStop = true;
            // 
            // FrmCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1209, 571);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pnlLista);
            this.Controls.Add(this.Gestion);
            this.Controls.Add(this.txtGestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmCargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: MidasD - Cargos :::";
            this.pnlDatos.ResumeLayout(false);
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.grbLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.pnlLista.ResumeLayout(false);
            this.pnlLista.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.GroupBox grbDatos;
        private System.Windows.Forms.PictureBox btnCancelar;
        private System.Windows.Forms.PictureBox btnGuardar;
        private System.Windows.Forms.TextBox txtCargoDenominacion;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.ErrorProvider erpMenu;
        private System.Windows.Forms.ToolTip totMensaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxUnidadEjecutora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxOficina;
        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.TextBox txtOficinaLiteral;
        private System.Windows.Forms.Button btnBuscarOficina;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Gestion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGestion;
        private System.Windows.Forms.ComboBox cbxUnidadEjecutoraLista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.GroupBox grbLista;
        private System.Windows.Forms.ComboBox cbxOficinaLista;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.PictureBox btnBaja;
        private System.Windows.Forms.PictureBox btnEditar;
        private System.Windows.Forms.PictureBox btnNuevo;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.PictureBox btnBuscar;
        private System.Windows.Forms.TextBox txtCargoDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxSueldoMensual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxEscalaSalarial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxTipoPersonal;
        private System.Windows.Forms.CheckBox chkDenominacion;
    }
}