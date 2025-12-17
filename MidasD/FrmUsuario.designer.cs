namespace MidasD
{
    partial class FrmUsuario
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
            this.pnlPersonas = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarPersonas = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvListaPersonas = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.lblMaterno = new System.Windows.Forms.Label();
            this.lblPaterno = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.grbLista = new System.Windows.Forms.GroupBox();
            this.btnEditar = new System.Windows.Forms.PictureBox();
            this.btnBaja = new System.Windows.Forms.PictureBox();
            this.btnRestablecerClave = new System.Windows.Forms.PictureBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.erpNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpCI = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.totMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.pnlDatos.SuspendLayout();
            this.pnlPersonas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            this.pnlLista.SuspendLayout();
            this.grbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestablecerClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(378, 4);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(105, 25);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Usuarios";
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatos.Controls.Add(this.pnlPersonas);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.lblUsuarios);
            this.pnlDatos.Controls.Add(this.lblUsuario);
            this.pnlDatos.Controls.Add(this.lblDocumento);
            this.pnlDatos.Controls.Add(this.txtUsuario);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.label7);
            this.pnlDatos.Controls.Add(this.label4);
            this.pnlDatos.Controls.Add(this.lblNombre);
            this.pnlDatos.Controls.Add(this.btnGuardar);
            this.pnlDatos.Controls.Add(this.btnCancelar);
            this.pnlDatos.Controls.Add(this.lblMaterno);
            this.pnlDatos.Controls.Add(this.lblPaterno);
            this.pnlDatos.Controls.Add(this.label11);
            this.pnlDatos.Enabled = false;
            this.pnlDatos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDatos.Location = new System.Drawing.Point(8, 281);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(876, 220);
            this.pnlDatos.TabIndex = 4;
            this.pnlDatos.TabStop = true;
            // 
            // pnlPersonas
            // 
            this.pnlPersonas.Controls.Add(this.label6);
            this.pnlPersonas.Controls.Add(this.label2);
            this.pnlPersonas.Controls.Add(this.btnBuscarPersonas);
            this.pnlPersonas.Controls.Add(this.txtBuscar);
            this.pnlPersonas.Controls.Add(this.dgvListaPersonas);
            this.pnlPersonas.Location = new System.Drawing.Point(1, 1);
            this.pnlPersonas.Name = "pnlPersonas";
            this.pnlPersonas.Size = new System.Drawing.Size(871, 214);
            this.pnlPersonas.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Persona Buscar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Lista de Personas";
            // 
            // btnBuscarPersonas
            // 
            this.btnBuscarPersonas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarPersonas.Image = global::MidasD.Properties.Resources.search;
            this.btnBuscarPersonas.Location = new System.Drawing.Point(549, 10);
            this.btnBuscarPersonas.Name = "btnBuscarPersonas";
            this.btnBuscarPersonas.Size = new System.Drawing.Size(81, 29);
            this.btnBuscarPersonas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBuscarPersonas.TabIndex = 57;
            this.btnBuscarPersonas.TabStop = false;
            this.btnBuscarPersonas.Click += new System.EventHandler(this.btnBuscarPersona_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(266, 14);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(268, 23);
            this.txtBuscar.TabIndex = 56;
            // 
            // dgvListaPersonas
            // 
            this.dgvListaPersonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListaPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPersonas.Location = new System.Drawing.Point(6, 42);
            this.dgvListaPersonas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaPersonas.Name = "dgvListaPersonas";
            this.dgvListaPersonas.RowTemplate.Height = 24;
            this.dgvListaPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPersonas.Size = new System.Drawing.Size(860, 170);
            this.dgvListaPersonas.TabIndex = 55;
            this.dgvListaPersonas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaPersonas_CellClick);
            this.dgvListaPersonas.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLista_RowPostPaint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(133, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "Paterno:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(133, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 39;
            this.label5.Text = "Nombres:";
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarios.Location = new System.Drawing.Point(658, 73);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(141, 15);
            this.lblUsuarios.TabIndex = 0;
            this.lblUsuarios.Text = "Usuario Recomendacion";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(213, 118);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(139, 15);
            this.lblUsuario.TabIndex = 54;
            this.lblUsuario.Text = "Aqui va el Usuario Actual";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(213, 103);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(125, 15);
            this.lblDocumento.TabIndex = 46;
            this.lblDocumento.Text = "Aqui va el Documento";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(661, 92);
            this.txtUsuario.MaxLength = 15;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(138, 23);
            this.txtUsuario.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(133, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 53;
            this.label9.Text = "Usuario:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(133, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 45;
            this.label7.Text = "Documento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(133, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Materno:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(213, 58);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(179, 15);
            this.lblNombre.TabIndex = 44;
            this.lblNombre.Text = "Aqui va el Nombre de la Persona";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Image = global::MidasD.Properties.Resources.save_inactive;
            this.btnGuardar.Location = new System.Drawing.Point(642, 147);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 31);
            this.btnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnGuardar, "Guardar registro");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = global::MidasD.Properties.Resources.cancel_inactive;
            this.btnCancelar.Location = new System.Drawing.Point(745, 147);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 31);
            this.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnCancelar, "Cancelar acción");
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblMaterno
            // 
            this.lblMaterno.AutoSize = true;
            this.lblMaterno.Location = new System.Drawing.Point(213, 88);
            this.lblMaterno.Name = "lblMaterno";
            this.lblMaterno.Size = new System.Drawing.Size(227, 15);
            this.lblMaterno.TabIndex = 43;
            this.lblMaterno.Text = "Aqui va el Apellido Materno de la Persona";
            // 
            // lblPaterno
            // 
            this.lblPaterno.AutoSize = true;
            this.lblPaterno.Location = new System.Drawing.Point(213, 73);
            this.lblPaterno.Name = "lblPaterno";
            this.lblPaterno.Size = new System.Drawing.Size(223, 15);
            this.lblPaterno.TabIndex = 42;
            this.lblPaterno.Text = "Aqui va el Apellido Paterno de la Persona";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 15);
            this.label11.TabIndex = 58;
            this.label11.Text = "Datos del Usuario";
            // 
            // pnlLista
            // 
            this.pnlLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLista.Controls.Add(this.grbLista);
            this.pnlLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLista.Location = new System.Drawing.Point(8, 69);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Size = new System.Drawing.Size(874, 206);
            this.pnlLista.TabIndex = 3;
            this.pnlLista.TabStop = true;
            // 
            // grbLista
            // 
            this.grbLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLista.Controls.Add(this.btnEditar);
            this.grbLista.Controls.Add(this.btnBaja);
            this.grbLista.Controls.Add(this.btnRestablecerClave);
            this.grbLista.Controls.Add(this.dgvLista);
            this.grbLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbLista.Location = new System.Drawing.Point(4, 7);
            this.grbLista.Name = "grbLista";
            this.grbLista.Size = new System.Drawing.Size(863, 190);
            this.grbLista.TabIndex = 0;
            this.grbLista.TabStop = false;
            this.grbLista.Text = "Lista de Usuarios";
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Image = global::MidasD.Properties.Resources.edit_inactive;
            this.btnEditar.Location = new System.Drawing.Point(258, 155);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(81, 29);
            this.btnEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEditar.TabIndex = 24;
            this.btnEditar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnEditar, "Editar Usuario");
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaja.Image = global::MidasD.Properties.Resources.delet_inactive;
            this.btnBaja.Location = new System.Drawing.Point(345, 155);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(81, 29);
            this.btnBaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBaja.TabIndex = 23;
            this.btnBaja.TabStop = false;
            this.totMensaje.SetToolTip(this.btnBaja, "Dar de Baja al Usuario");
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnRestablecerClave
            // 
            this.btnRestablecerClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestablecerClave.Image = global::MidasD.Properties.Resources.reset_password_inactive;
            this.btnRestablecerClave.Location = new System.Drawing.Point(432, 155);
            this.btnRestablecerClave.Name = "btnRestablecerClave";
            this.btnRestablecerClave.Size = new System.Drawing.Size(181, 29);
            this.btnRestablecerClave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRestablecerClave.TabIndex = 22;
            this.btnRestablecerClave.TabStop = false;
            this.totMensaje.SetToolTip(this.btnRestablecerClave, "Clave por defecto \"hola123\"");
            this.btnRestablecerClave.Click += new System.EventHandler(this.btnRestablecerClave_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AllowUserToOrderColumns = true;
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(6, 18);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(849, 131);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.TabStop = false;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            this.dgvLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellDoubleClick);
            this.dgvLista.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLista_RowPostPaint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(130, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 26);
            this.label3.TabIndex = 23;
            this.label3.Text = "Buscar por Usuario,  Apellidos,\r\nNombres o Cédula de Identidad";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = global::MidasD.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(604, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(93, 29);
            this.btnBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBuscar.TabIndex = 26;
            this.btnBuscar.TabStop = false;
            this.totMensaje.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtParametro
            // 
            this.txtParametro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParametro.Location = new System.Drawing.Point(303, 38);
            this.txtParametro.MaxLength = 20;
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(295, 22);
            this.txtParametro.TabIndex = 23;
            this.totMensaje.SetToolTip(this.txtParametro, "Introduzca Usuario,  Apellidos, Nombres o Cédula de Identidad");
            this.txtParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParametro_KeyPress);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Image = global::MidasD.Properties.Resources._new;
            this.btnNuevo.Location = new System.Drawing.Point(11, 35);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(81, 29);
            this.btnNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnNuevo.TabIndex = 25;
            this.btnNuevo.TabStop = false;
            this.totMensaje.SetToolTip(this.btnNuevo, "Nuevo Usuario");
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exit_;
            this.btnSalir.Location = new System.Drawing.Point(801, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 29);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 19;
            this.btnSalir.TabStop = false;
            this.totMensaje.SetToolTip(this.btnSalir, "Cerrar Ventana");
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // erpNombre
            // 
            this.erpNombre.ContainerControl = this;
            // 
            // erpCI
            // 
            this.erpCI.ContainerControl = this;
            // 
            // erpUsuario
            // 
            this.erpUsuario.ContainerControl = this;
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(896, 512);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.txtParametro);
            this.Controls.Add(this.pnlLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "FrmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: MidasD - Usuarios :::";
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlPersonas.ResumeLayout(false);
            this.pnlPersonas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            this.pnlLista.ResumeLayout(false);
            this.grbLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestablecerClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.PictureBox btnCancelar;
        private System.Windows.Forms.PictureBox btnGuardar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.GroupBox grbLista;
        private System.Windows.Forms.PictureBox btnNuevo;
        private System.Windows.Forms.PictureBox btnEditar;
        private System.Windows.Forms.PictureBox btnBaja;
        private System.Windows.Forms.PictureBox btnRestablecerClave;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.ErrorProvider erpNombre;
        private System.Windows.Forms.ErrorProvider erpCI;
        private System.Windows.Forms.ErrorProvider erpUsuario;
        private System.Windows.Forms.ToolTip totMensaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnBuscar;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblMaterno;
        private System.Windows.Forms.Label lblPaterno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvListaPersonas;
        private System.Windows.Forms.Panel pnlPersonas;
        private System.Windows.Forms.PictureBox btnBuscarPersonas;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
    }
}