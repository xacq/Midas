namespace MidasD
{
    partial class FrmPersonaConsulta
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
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.GroupBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbFechaNacimiento = new System.Windows.Forms.MaskedTextBox();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.cbxEstadoCivil = new System.Windows.Forms.ComboBox();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.cbxSexo = new System.Windows.Forms.ComboBox();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.cbxTipoDocumento = new System.Windows.Forms.ComboBox();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.txtMaterno = new System.Windows.Forms.TextBox();
            this.txtPaterno = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblMaterno = new System.Windows.Forms.Label();
            this.lblPaterno = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.erpFalloConectar = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEstadoHuella = new System.Windows.Forms.ToolStripStatusLabel();
            this.erpNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpApellido = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpDireccion = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpSexo = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpEstadoCivil = new System.Windows.Forms.ErrorProvider(this.components);
            this.erptipodocumento = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpnumDoc = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpPais = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpExpedido = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpFechaNac = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpOcupacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpLugarTrabajo = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpCelularTelefono = new System.Windows.Forms.ErrorProvider(this.components);
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.txtUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpFalloConectar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpApellido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpDireccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpSexo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpEstadoCivil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erptipodocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpnumDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpExpedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpFechaNac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpOcupacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpLugarTrabajo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCelularTelefono)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exit_;
            this.btnSalir.Location = new System.Drawing.Point(681, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 29);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 19;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatos.Controls.Add(this.txtUsuario);
            this.pnlDatos.Enabled = false;
            this.pnlDatos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDatos.Location = new System.Drawing.Point(8, 53);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(756, 182);
            this.pnlDatos.TabIndex = 1;
            this.pnlDatos.TabStop = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Controls.Add(this.txtDepartamento);
            this.txtUsuario.Controls.Add(this.label1);
            this.txtUsuario.Controls.Add(this.mtbFechaNacimiento);
            this.txtUsuario.Controls.Add(this.lblFechaNac);
            this.txtUsuario.Controls.Add(this.pbImagen);
            this.txtUsuario.Controls.Add(this.cbxEstadoCivil);
            this.txtUsuario.Controls.Add(this.lblEstadoCivil);
            this.txtUsuario.Controls.Add(this.lblDomicilio);
            this.txtUsuario.Controls.Add(this.txtDomicilio);
            this.txtUsuario.Controls.Add(this.lblSexo);
            this.txtUsuario.Controls.Add(this.cbxSexo);
            this.txtUsuario.Controls.Add(this.lblTipoDoc);
            this.txtUsuario.Controls.Add(this.cbxTipoDocumento);
            this.txtUsuario.Controls.Add(this.txtNumeroDocumento);
            this.txtUsuario.Controls.Add(this.txtMaterno);
            this.txtUsuario.Controls.Add(this.txtPaterno);
            this.txtUsuario.Controls.Add(this.txtNombre);
            this.txtUsuario.Controls.Add(this.lblDocumento);
            this.txtUsuario.Controls.Add(this.lblMaterno);
            this.txtUsuario.Controls.Add(this.lblPaterno);
            this.txtUsuario.Controls.Add(this.lblNombre);
            this.txtUsuario.Location = new System.Drawing.Point(-2, -2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(751, 175);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.TabStop = false;
            this.txtUsuario.Text = "Datos";
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDepartamento.Enabled = false;
            this.txtDepartamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartamento.Location = new System.Drawing.Point(300, 45);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(200, 23);
            this.txtDepartamento.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Departamento:";
            // 
            // mtbFechaNacimiento
            // 
            this.mtbFechaNacimiento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.mtbFechaNacimiento.Enabled = false;
            this.mtbFechaNacimiento.Location = new System.Drawing.Point(518, 137);
            this.mtbFechaNacimiento.Mask = "00/00/0000";
            this.mtbFechaNacimiento.Name = "mtbFechaNacimiento";
            this.mtbFechaNacimiento.Size = new System.Drawing.Size(100, 23);
            this.mtbFechaNacimiento.TabIndex = 50;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaNac.Location = new System.Drawing.Point(512, 121);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(103, 13);
            this.lblFechaNac.TabIndex = 41;
            this.lblFechaNac.Text = "Fecha Nacimiento:";
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;
            this.pbImagen.Location = new System.Drawing.Point(634, 29);
            this.pbImagen.Margin = new System.Windows.Forms.Padding(2);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(108, 125);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 37;
            this.pbImagen.TabStop = false;
            // 
            // cbxEstadoCivil
            // 
            this.cbxEstadoCivil.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbxEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstadoCivil.Enabled = false;
            this.cbxEstadoCivil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEstadoCivil.FormattingEnabled = true;
            this.cbxEstadoCivil.Items.AddRange(new object[] {
            "Casado",
            "Casada",
            "Soltero",
            "Soltera",
            "Divorciado",
            "Divorciada",
            "Viudo",
            "Viuda"});
            this.cbxEstadoCivil.Location = new System.Drawing.Point(402, 135);
            this.cbxEstadoCivil.Name = "cbxEstadoCivil";
            this.cbxEstadoCivil.Size = new System.Drawing.Size(108, 23);
            this.cbxEstadoCivil.TabIndex = 5;
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.AutoSize = true;
            this.lblEstadoCivil.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoCivil.Location = new System.Drawing.Point(399, 121);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(70, 13);
            this.lblEstadoCivil.TabIndex = 31;
            this.lblEstadoCivil.Text = "Estado Civil:";
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomicilio.Location = new System.Drawing.Point(5, 121);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(59, 13);
            this.lblDomicilio.TabIndex = 28;
            this.lblDomicilio.Text = "Domicilio:";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDomicilio.Enabled = false;
            this.txtDomicilio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomicilio.Location = new System.Drawing.Point(7, 136);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(328, 23);
            this.txtDomicilio.TabIndex = 3;
            this.txtDomicilio.Leave += new System.EventHandler(this.textleave);
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSexo.Location = new System.Drawing.Point(338, 121);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(35, 13);
            this.lblSexo.TabIndex = 26;
            this.lblSexo.Text = "Sexo:";
            // 
            // cbxSexo
            // 
            this.cbxSexo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSexo.Enabled = false;
            this.cbxSexo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSexo.FormattingEnabled = true;
            this.cbxSexo.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cbxSexo.Location = new System.Drawing.Point(341, 135);
            this.cbxSexo.Name = "cbxSexo";
            this.cbxSexo.Size = new System.Drawing.Size(54, 23);
            this.cbxSexo.TabIndex = 4;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDoc.Location = new System.Drawing.Point(137, 29);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(97, 13);
            this.lblTipoDoc.TabIndex = 24;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // cbxTipoDocumento
            // 
            this.cbxTipoDocumento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbxTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoDocumento.Enabled = false;
            this.cbxTipoDocumento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoDocumento.FormattingEnabled = true;
            this.cbxTipoDocumento.Location = new System.Drawing.Point(140, 45);
            this.cbxTipoDocumento.Name = "cbxTipoDocumento";
            this.cbxTipoDocumento.Size = new System.Drawing.Size(154, 23);
            this.cbxTipoDocumento.TabIndex = 6;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDocumento.Location = new System.Drawing.Point(10, 45);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(116, 23);
            this.txtNumeroDocumento.TabIndex = 7;
            this.txtNumeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDocumento_KeyPress);
            this.txtNumeroDocumento.Leave += new System.EventHandler(this.textleave);
            // 
            // txtMaterno
            // 
            this.txtMaterno.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMaterno.Enabled = false;
            this.txtMaterno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterno.Location = new System.Drawing.Point(424, 92);
            this.txtMaterno.Name = "txtMaterno";
            this.txtMaterno.Size = new System.Drawing.Size(193, 23);
            this.txtMaterno.TabIndex = 2;
            this.txtMaterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras_KeyPress);
            this.txtMaterno.Leave += new System.EventHandler(this.textleave);
            // 
            // txtPaterno
            // 
            this.txtPaterno.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPaterno.Enabled = false;
            this.txtPaterno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaterno.Location = new System.Drawing.Point(219, 92);
            this.txtPaterno.Name = "txtPaterno";
            this.txtPaterno.Size = new System.Drawing.Size(194, 23);
            this.txtPaterno.TabIndex = 1;
            this.txtPaterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras_KeyPress);
            this.txtPaterno.Leave += new System.EventHandler(this.textleave);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(7, 92);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 23);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras_KeyPress);
            this.txtNombre.Leave += new System.EventHandler(this.textleave);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.Location = new System.Drawing.Point(5, 29);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(117, 13);
            this.lblDocumento.TabIndex = 0;
            this.lblDocumento.Text = "Número Documento:";
            // 
            // lblMaterno
            // 
            this.lblMaterno.AutoSize = true;
            this.lblMaterno.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterno.Location = new System.Drawing.Point(422, 76);
            this.lblMaterno.Name = "lblMaterno";
            this.lblMaterno.Size = new System.Drawing.Size(102, 13);
            this.lblMaterno.TabIndex = 0;
            this.lblMaterno.Text = "Apellido Materno:";
            // 
            // lblPaterno
            // 
            this.lblPaterno.AutoSize = true;
            this.lblPaterno.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaterno.Location = new System.Drawing.Point(216, 76);
            this.lblPaterno.Name = "lblPaterno";
            this.lblPaterno.Size = new System.Drawing.Size(98, 13);
            this.lblPaterno.TabIndex = 0;
            this.lblPaterno.Text = "Apellido Paterno:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(5, 76);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombres:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(288, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(207, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Consultar Persona";
            // 
            // erpFalloConectar
            // 
            this.erpFalloConectar.ContainerControl = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado,
            this.lblEstadoHuella});
            this.statusStrip1.Location = new System.Drawing.Point(0, 243);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(776, 22);
            this.statusStrip1.TabIndex = 50;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(85, 17);
            this.lblEstado.Text = "Estado Actual: ";
            // 
            // lblEstadoHuella
            // 
            this.lblEstadoHuella.Name = "lblEstadoHuella";
            this.lblEstadoHuella.Size = new System.Drawing.Size(48, 17);
            this.lblEstadoHuella.Text = "Estado: ";
            // 
            // erpNombre
            // 
            this.erpNombre.ContainerControl = this;
            // 
            // erpApellido
            // 
            this.erpApellido.ContainerControl = this;
            // 
            // erpDireccion
            // 
            this.erpDireccion.ContainerControl = this;
            // 
            // erpSexo
            // 
            this.erpSexo.ContainerControl = this;
            // 
            // erpEstadoCivil
            // 
            this.erpEstadoCivil.ContainerControl = this;
            // 
            // erptipodocumento
            // 
            this.erptipodocumento.ContainerControl = this;
            // 
            // erpnumDoc
            // 
            this.erpnumDoc.ContainerControl = this;
            // 
            // erpPais
            // 
            this.erpPais.ContainerControl = this;
            // 
            // erpExpedido
            // 
            this.erpExpedido.ContainerControl = this;
            // 
            // erpFechaNac
            // 
            this.erpFechaNac.ContainerControl = this;
            // 
            // erpOcupacion
            // 
            this.erpOcupacion.ContainerControl = this;
            // 
            // erpLugarTrabajo
            // 
            this.erpLugarTrabajo.ContainerControl = this;
            // 
            // erpCelularTelefono
            // 
            this.erpCelularTelefono.ContainerControl = this;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Maroon;
            this.label16.Location = new System.Drawing.Point(6, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(181, 36);
            this.label16.TabIndex = 105;
            this.label16.Text = "Consultas de personas mediante\r\nel numero de carnet de identidad\r\npara ayuda y ve" +
    "rificacion de informacion.\r\n";
            // 
            // FrmPersonaConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(776, 265);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPersonaConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ::: MidasD Consultar Personas :::";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPersona_FormClosed);
            this.Load += new System.EventHandler(this.FrmPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.txtUsuario.ResumeLayout(false);
            this.txtUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpFalloConectar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpApellido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpDireccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpSexo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpEstadoCivil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erptipodocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpnumDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpExpedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpFechaNac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpOcupacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpLugarTrabajo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCelularTelefono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.GroupBox txtUsuario;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.TextBox txtMaterno;
        private System.Windows.Forms.TextBox txtPaterno;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblMaterno;
        private System.Windows.Forms.Label lblPaterno;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.ComboBox cbxTipoDocumento;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.ComboBox cbxSexo;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.ComboBox cbxEstadoCivil;
        private System.Windows.Forms.Label lblEstadoCivil;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.ErrorProvider erpFalloConectar;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblEstadoHuella;
        private System.Windows.Forms.ErrorProvider erpNombre;
        private System.Windows.Forms.ErrorProvider erpApellido;
        private System.Windows.Forms.ErrorProvider erpDireccion;
        private System.Windows.Forms.ErrorProvider erpSexo;
        private System.Windows.Forms.ErrorProvider erpEstadoCivil;
        private System.Windows.Forms.ErrorProvider erptipodocumento;
        private System.Windows.Forms.ErrorProvider erpnumDoc;
        private System.Windows.Forms.ErrorProvider erpPais;
        private System.Windows.Forms.ErrorProvider erpExpedido;
        private System.Windows.Forms.ErrorProvider erpFechaNac;
        private System.Windows.Forms.ErrorProvider erpOcupacion;
        private System.Windows.Forms.ErrorProvider erpLugarTrabajo;
        private System.Windows.Forms.ErrorProvider erpCelularTelefono;
        private System.Windows.Forms.MaskedTextBox mtbFechaNacimiento;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
    }
}