namespace MidasD
{
    partial class FrmFianzaDeBaja
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
            this.pnlLista = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.grbLista = new System.Windows.Forms.GroupBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.cbxUnidadEjecutora = new System.Windows.Forms.ComboBox();
            this.btnEditar = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.lblResolucion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblNumeroDocumentoList = new System.Windows.Forms.Label();
            this.lblTipoDocumentoList = new System.Windows.Forms.Label();
            this.lblNombresList = new System.Windows.Forms.Label();
            this.lblPaternoList = new System.Windows.Forms.Label();
            this.lblMaternoList = new System.Windows.Forms.Label();
            this.lblOficinaList = new System.Windows.Forms.Label();
            this.lblCargoList = new System.Windows.Forms.Label();
            this.lblNumeroMemorandoList = new System.Windows.Forms.Label();
            this.lblNumeroMemorando = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblOficina = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.PictureBox();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblNumeroDocumento = new System.Windows.Forms.Label();
            this.lblMaterno = new System.Windows.Forms.Label();
            this.lblPaterno = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cbxCargo = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.erpFalloConectar = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEstadoHuella = new System.Windows.Forms.ToolStripStatusLabel();
            this.erpError = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pnlLista.SuspendLayout();
            this.grbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.txtUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpFalloConectar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLista
            // 
            this.pnlLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLista.Controls.Add(this.label1);
            this.pnlLista.Controls.Add(this.grbLista);
            this.pnlLista.Controls.Add(this.cbxUnidadEjecutora);
            this.pnlLista.Controls.Add(this.btnEditar);
            this.pnlLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLista.Location = new System.Drawing.Point(10, 78);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Size = new System.Drawing.Size(1152, 348);
            this.pnlLista.TabIndex = 0;
            this.pnlLista.TabStop = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(373, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Unidad Ejecutora";
            // 
            // grbLista
            // 
            this.grbLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLista.Controls.Add(this.dgvLista);
            this.grbLista.Location = new System.Drawing.Point(8, 32);
            this.grbLista.Name = "grbLista";
            this.grbLista.Size = new System.Drawing.Size(1131, 273);
            this.grbLista.TabIndex = 0;
            this.grbLista.TabStop = false;
            this.grbLista.Text = "Lista del Personal";
            // 
            // dgvLista
            // 
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(5, 16);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(1120, 251);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.TabStop = false;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            this.dgvLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellDoubleClick);
            this.dgvLista.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvFuncionarios_DataBindingComplete);
            this.dgvLista.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvGrilla_RowPostPaint);
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
            this.cbxUnidadEjecutora.Location = new System.Drawing.Point(484, 7);
            this.cbxUnidadEjecutora.Name = "cbxUnidadEjecutora";
            this.cbxUnidadEjecutora.Size = new System.Drawing.Size(277, 23);
            this.cbxUnidadEjecutora.TabIndex = 52;
            this.cbxUnidadEjecutora.SelectionChangeCommitted += new System.EventHandler(this.cbxUnidadEjecutora_SelectionChangeCommitted);
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Image = global::MidasD.Properties.Resources.edit_inactive;
            this.btnEditar.Location = new System.Drawing.Point(534, 312);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(81, 29);
            this.btnEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEditar.TabIndex = 24;
            this.btnEditar.TabStop = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = global::MidasD.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(780, 43);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(81, 29);
            this.btnBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBuscar.TabIndex = 50;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(496, 46);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(277, 23);
            this.txtBuscar.TabIndex = 49;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exit_;
            this.btnSalir.Location = new System.Drawing.Point(1081, 9);
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
            this.pnlDatos.Location = new System.Drawing.Point(10, 432);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(1154, 223);
            this.pnlDatos.TabIndex = 1;
            this.pnlDatos.TabStop = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Controls.Add(this.label4);
            this.txtUsuario.Controls.Add(this.txtObservacion);
            this.txtUsuario.Controls.Add(this.lblResolucion);
            this.txtUsuario.Controls.Add(this.label2);
            this.txtUsuario.Controls.Add(this.label9);
            this.txtUsuario.Controls.Add(this.lblNumeroDocumentoList);
            this.txtUsuario.Controls.Add(this.lblTipoDocumentoList);
            this.txtUsuario.Controls.Add(this.lblNombresList);
            this.txtUsuario.Controls.Add(this.lblPaternoList);
            this.txtUsuario.Controls.Add(this.lblMaternoList);
            this.txtUsuario.Controls.Add(this.lblOficinaList);
            this.txtUsuario.Controls.Add(this.lblCargoList);
            this.txtUsuario.Controls.Add(this.lblNumeroMemorandoList);
            this.txtUsuario.Controls.Add(this.lblNumeroMemorando);
            this.txtUsuario.Controls.Add(this.lblCargo);
            this.txtUsuario.Controls.Add(this.lblOficina);
            this.txtUsuario.Controls.Add(this.btnCancelar);
            this.txtUsuario.Controls.Add(this.btnGuardar);
            this.txtUsuario.Controls.Add(this.pbImagen);
            this.txtUsuario.Controls.Add(this.lblTipoDoc);
            this.txtUsuario.Controls.Add(this.lblNumeroDocumento);
            this.txtUsuario.Controls.Add(this.lblMaterno);
            this.txtUsuario.Controls.Add(this.lblPaterno);
            this.txtUsuario.Controls.Add(this.lblNombre);
            this.txtUsuario.Controls.Add(this.cbxCargo);
            this.txtUsuario.Location = new System.Drawing.Point(-2, -2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(1154, 215);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.TabStop = false;
            this.txtUsuario.Text = "Datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(183, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(640, 45);
            this.label4.TabIndex = 93;
            this.label4.Text = "Nota: \r\nAl estar dando de Baja la fianza,automaticamente el estado de esta fianza" +
    " pasa a ser una \"Fianza Completa\" para no\r\nrealizar ningun descuento mas y por e" +
    "nde queda validado por Habilitado.\r\n";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(857, 92);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(272, 54);
            this.txtObservacion.TabIndex = 92;
            // 
            // lblResolucion
            // 
            this.lblResolucion.AutoSize = true;
            this.lblResolucion.Location = new System.Drawing.Point(533, 96);
            this.lblResolucion.Name = "lblResolucion";
            this.lblResolucion.Size = new System.Drawing.Size(84, 15);
            this.lblResolucion.TabIndex = 91;
            this.lblResolucion.Text = "XXXXXXXXXXX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(457, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 90;
            this.label2.Text = "Resolucion:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1053, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 88;
            this.label9.Text = "Observacion";
            // 
            // lblNumeroDocumentoList
            // 
            this.lblNumeroDocumentoList.AutoSize = true;
            this.lblNumeroDocumentoList.Location = new System.Drawing.Point(320, 24);
            this.lblNumeroDocumentoList.Name = "lblNumeroDocumentoList";
            this.lblNumeroDocumentoList.Size = new System.Drawing.Size(84, 15);
            this.lblNumeroDocumentoList.TabIndex = 72;
            this.lblNumeroDocumentoList.Text = "XXXXXXXXXXX";
            // 
            // lblTipoDocumentoList
            // 
            this.lblTipoDocumentoList.AutoSize = true;
            this.lblTipoDocumentoList.Location = new System.Drawing.Point(320, 49);
            this.lblTipoDocumentoList.Name = "lblTipoDocumentoList";
            this.lblTipoDocumentoList.Size = new System.Drawing.Size(84, 15);
            this.lblTipoDocumentoList.TabIndex = 71;
            this.lblTipoDocumentoList.Text = "XXXXXXXXXXX";
            // 
            // lblNombresList
            // 
            this.lblNombresList.AutoSize = true;
            this.lblNombresList.Location = new System.Drawing.Point(320, 74);
            this.lblNombresList.Name = "lblNombresList";
            this.lblNombresList.Size = new System.Drawing.Size(84, 15);
            this.lblNombresList.TabIndex = 70;
            this.lblNombresList.Text = "XXXXXXXXXXX";
            // 
            // lblPaternoList
            // 
            this.lblPaternoList.AutoSize = true;
            this.lblPaternoList.Location = new System.Drawing.Point(320, 99);
            this.lblPaternoList.Name = "lblPaternoList";
            this.lblPaternoList.Size = new System.Drawing.Size(84, 15);
            this.lblPaternoList.TabIndex = 69;
            this.lblPaternoList.Text = "XXXXXXXXXXX";
            // 
            // lblMaternoList
            // 
            this.lblMaternoList.AutoSize = true;
            this.lblMaternoList.Location = new System.Drawing.Point(320, 124);
            this.lblMaternoList.Name = "lblMaternoList";
            this.lblMaternoList.Size = new System.Drawing.Size(84, 15);
            this.lblMaternoList.TabIndex = 68;
            this.lblMaternoList.Text = "XXXXXXXXXXX";
            // 
            // lblOficinaList
            // 
            this.lblOficinaList.AutoSize = true;
            this.lblOficinaList.Location = new System.Drawing.Point(515, 24);
            this.lblOficinaList.Name = "lblOficinaList";
            this.lblOficinaList.Size = new System.Drawing.Size(84, 15);
            this.lblOficinaList.TabIndex = 67;
            this.lblOficinaList.Text = "XXXXXXXXXXX";
            // 
            // lblCargoList
            // 
            this.lblCargoList.AutoSize = true;
            this.lblCargoList.Location = new System.Drawing.Point(515, 48);
            this.lblCargoList.Name = "lblCargoList";
            this.lblCargoList.Size = new System.Drawing.Size(84, 15);
            this.lblCargoList.TabIndex = 66;
            this.lblCargoList.Text = "XXXXXXXXXXX";
            // 
            // lblNumeroMemorandoList
            // 
            this.lblNumeroMemorandoList.AutoSize = true;
            this.lblNumeroMemorandoList.Location = new System.Drawing.Point(610, 72);
            this.lblNumeroMemorandoList.Name = "lblNumeroMemorandoList";
            this.lblNumeroMemorandoList.Size = new System.Drawing.Size(84, 15);
            this.lblNumeroMemorandoList.TabIndex = 65;
            this.lblNumeroMemorandoList.Text = "XXXXXXXXXXX";
            // 
            // lblNumeroMemorando
            // 
            this.lblNumeroMemorando.AutoSize = true;
            this.lblNumeroMemorando.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroMemorando.Location = new System.Drawing.Point(460, 72);
            this.lblNumeroMemorando.Name = "lblNumeroMemorando";
            this.lblNumeroMemorando.Size = new System.Drawing.Size(144, 15);
            this.lblNumeroMemorando.TabIndex = 64;
            this.lblNumeroMemorando.Text = "Numero de Memorando:";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.Location = new System.Drawing.Point(460, 48);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(42, 15);
            this.lblCargo.TabIndex = 61;
            this.lblCargo.Text = "Cargo:";
            // 
            // lblOficina
            // 
            this.lblOficina.AutoSize = true;
            this.lblOficina.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOficina.Location = new System.Drawing.Point(460, 24);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(49, 15);
            this.lblOficina.TabIndex = 53;
            this.lblOficina.Text = "Oficina:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = global::MidasD.Properties.Resources.cancel_inactive;
            this.btnCancelar.Location = new System.Drawing.Point(1005, 152);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 31);
            this.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Image = global::MidasD.Properties.Resources.save_inactive;
            this.btnGuardar.Location = new System.Drawing.Point(902, 153);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 31);
            this.btnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;
            this.pbImagen.Location = new System.Drawing.Point(25, 21);
            this.pbImagen.Margin = new System.Windows.Forms.Padding(2);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(131, 167);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 37;
            this.pbImagen.TabStop = false;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDoc.Location = new System.Drawing.Point(205, 49);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(103, 15);
            this.lblTipoDoc.TabIndex = 24;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // lblNumeroDocumento
            // 
            this.lblNumeroDocumento.AutoSize = true;
            this.lblNumeroDocumento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroDocumento.Location = new System.Drawing.Point(183, 24);
            this.lblNumeroDocumento.Name = "lblNumeroDocumento";
            this.lblNumeroDocumento.Size = new System.Drawing.Size(125, 15);
            this.lblNumeroDocumento.TabIndex = 0;
            this.lblNumeroDocumento.Text = "Número Documento:";
            // 
            // lblMaterno
            // 
            this.lblMaterno.AutoSize = true;
            this.lblMaterno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterno.Location = new System.Drawing.Point(202, 124);
            this.lblMaterno.Name = "lblMaterno";
            this.lblMaterno.Size = new System.Drawing.Size(106, 15);
            this.lblMaterno.TabIndex = 0;
            this.lblMaterno.Text = "Apellido Materno:";
            // 
            // lblPaterno
            // 
            this.lblPaterno.AutoSize = true;
            this.lblPaterno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaterno.Location = new System.Drawing.Point(206, 99);
            this.lblPaterno.Name = "lblPaterno";
            this.lblPaterno.Size = new System.Drawing.Size(102, 15);
            this.lblPaterno.TabIndex = 0;
            this.lblPaterno.Text = "Apellido Paterno:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(247, 74);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(61, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombres:";
            // 
            // cbxCargo
            // 
            this.cbxCargo.FormattingEnabled = true;
            this.cbxCargo.Location = new System.Drawing.Point(50, 92);
            this.cbxCargo.Name = "cbxCargo";
            this.cbxCargo.Size = new System.Drawing.Size(90, 23);
            this.cbxCargo.TabIndex = 74;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(414, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(336, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Dar de Baja Fianza Económica\r\n";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1174, 22);
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
            // erpError
            // 
            this.erpError.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(319, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 26);
            this.label3.TabIndex = 51;
            this.label3.Text = "Buscar por Apellidos,\r\nNombres o Cédula de Identidad";
            // 
            // FrmFianzaDeBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1174, 680);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmFianzaDeBaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ::: MidasD Dar de Baja Fianzas:::";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPersona_FormClosed);
            this.Load += new System.EventHandler(this.FrmPersona_Load);
            this.pnlLista.ResumeLayout(false);
            this.pnlLista.PerformLayout();
            this.grbLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.txtUsuario.ResumeLayout(false);
            this.txtUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpFalloConectar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.GroupBox grbLista;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.GroupBox txtUsuario;
        private System.Windows.Forms.Label lblNumeroDocumento;
        private System.Windows.Forms.Label lblMaterno;
        private System.Windows.Forms.Label lblPaterno;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.PictureBox btnEditar;
        private System.Windows.Forms.PictureBox btnCancelar;
        private System.Windows.Forms.PictureBox btnGuardar;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.ErrorProvider erpFalloConectar;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblEstadoHuella;
        private System.Windows.Forms.PictureBox btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ErrorProvider erpError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOficina;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblMaternoList;
        private System.Windows.Forms.Label lblOficinaList;
        private System.Windows.Forms.Label lblCargoList;
        private System.Windows.Forms.Label lblNumeroMemorandoList;
        private System.Windows.Forms.Label lblNumeroMemorando;
        private System.Windows.Forms.Label lblNumeroDocumentoList;
        private System.Windows.Forms.Label lblTipoDocumentoList;
        private System.Windows.Forms.Label lblNombresList;
        private System.Windows.Forms.Label lblPaternoList;
        private System.Windows.Forms.ComboBox cbxCargo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblResolucion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxUnidadEjecutora;
        private System.Windows.Forms.Label label4;
    }
}