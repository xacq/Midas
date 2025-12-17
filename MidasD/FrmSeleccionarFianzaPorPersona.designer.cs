namespace MidasD
{
    partial class FrmSeleccionarFianzaPorPersona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionarFianzaPorPersona));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.gbxMenu = new System.Windows.Forms.GroupBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.totMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTotalDescontadoPlanilla = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTipoFianza = new System.Windows.Forms.Label();
            this.lbl13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.lblCantidadMesesDescontar = new System.Windows.Forms.Label();
            this.lblidFianza = new System.Windows.Forms.Label();
            this.lblTotalDescuentoMes = new System.Windows.Forms.Label();
            this.lblHaberMensual = new System.Windows.Forms.Label();
            this.lblCalculoSueldos = new System.Windows.Forms.Label();
            this.lblTotalDescontar = new System.Windows.Forms.Label();
            this.lblDescuentoSalario = new System.Windows.Forms.Label();
            this.lblNombresApellidos = new System.Windows.Forms.Label();
            this.lblCi = new System.Windows.Forms.Label();
            this.lblTipoContrato = new System.Windows.Forms.Label();
            this.lblVigenciaItem = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblNumMemorando = new System.Windows.Forms.Label();
            this.lbl12 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.grProductos = new System.Windows.Forms.GroupBox();
            this.dgvListaCartilla = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.pnlDatos.SuspendLayout();
            this.gbxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.grProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCartilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(536, 3);
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
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatos.Controls.Add(this.gbxMenu);
            this.pnlDatos.Location = new System.Drawing.Point(13, 64);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(1180, 413);
            this.pnlDatos.TabIndex = 22;
            this.pnlDatos.TabStop = true;
            // 
            // gbxMenu
            // 
            this.gbxMenu.Controls.Add(this.dgvLista);
            this.gbxMenu.Location = new System.Drawing.Point(3, 3);
            this.gbxMenu.Name = "gbxMenu";
            this.gbxMenu.Size = new System.Drawing.Size(1173, 402);
            this.gbxMenu.TabIndex = 14;
            this.gbxMenu.TabStop = false;
            this.gbxMenu.Text = "Lista de Fianzas";
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(6, 19);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(1161, 375);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvLista_DataBindingComplete);
            this.dgvLista.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvGrilla_RowPostPaint);
            this.dgvLista.DoubleClick += new System.EventHandler(this.dgvListaOficinas_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Location = new System.Drawing.Point(15, 496);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1178, 44);
            this.panel2.TabIndex = 23;
            this.panel2.TabStop = true;
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(540, 15);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(129, 20);
            this.txtParametro.TabIndex = 24;
            this.txtParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParametro_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Location = new System.Drawing.Point(678, 12);
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
            this.lblTitulo.Location = new System.Drawing.Point(446, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(323, 25);
            this.lblTitulo.TabIndex = 27;
            this.lblTitulo.Text = "Lista de Fianzas Por Persona";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Maroon;
            this.label16.Location = new System.Drawing.Point(965, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(223, 24);
            this.label16.TabIndex = 105;
            this.label16.Text = "Listado de Fianzas por Persona\r\n(Puede hacer doble click para seleccionar la Fian" +
    "za)\r\n";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Nro.de Documento:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1207, 580);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pnlDatos);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.txtParametro);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1199, 554);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Buscar Por Numero Documento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LimeGreen;
            this.label5.Location = new System.Drawing.Point(139, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 102;
            this.label5.Text = "Fianza en Pendiente o Curso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 103;
            this.label6.Text = "Estado de la Fianza";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(139, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 101;
            this.label4.Text = "Fianza Devuelta y Finalizada";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1199, 554);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cartilla de Fianza";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 36);
            this.label2.TabIndex = 101;
            this.label2.Text = "Cartilla de descuentos a detalle de Fianzas Judiciales de los funcionarios con fi" +
    "anzas\r\npara cualquier informacion requerida.\r\n\r\n";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lblTotalDescontadoPlanilla);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.grProductos);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Location = new System.Drawing.Point(6, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 490);
            this.panel1.TabIndex = 98;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(794, 458);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(223, 20);
            this.label15.TabIndex = 105;
            this.label15.Text = "Total Descontado Planilla: ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalDescontadoPlanilla
            // 
            this.lblTotalDescontadoPlanilla.AutoSize = true;
            this.lblTotalDescontadoPlanilla.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalDescontadoPlanilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDescontadoPlanilla.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDescontadoPlanilla.Location = new System.Drawing.Point(1023, 458);
            this.lblTotalDescontadoPlanilla.Name = "lblTotalDescontadoPlanilla";
            this.lblTotalDescontadoPlanilla.Size = new System.Drawing.Size(117, 20);
            this.lblTotalDescontadoPlanilla.TabIndex = 104;
            this.lblTotalDescontadoPlanilla.Text = "XXXXXXXXX";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Ivory;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Controls.Add(this.lblTipoFianza);
            this.panel3.Controls.Add(this.lbl13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.pbImagen);
            this.panel3.Controls.Add(this.lblCantidadMesesDescontar);
            this.panel3.Controls.Add(this.lblidFianza);
            this.panel3.Controls.Add(this.lblTotalDescuentoMes);
            this.panel3.Controls.Add(this.lblHaberMensual);
            this.panel3.Controls.Add(this.lblCalculoSueldos);
            this.panel3.Controls.Add(this.lblTotalDescontar);
            this.panel3.Controls.Add(this.lblDescuentoSalario);
            this.panel3.Controls.Add(this.lblNombresApellidos);
            this.panel3.Controls.Add(this.lblCi);
            this.panel3.Controls.Add(this.lblTipoContrato);
            this.panel3.Controls.Add(this.lblVigenciaItem);
            this.panel3.Controls.Add(this.lblCargo);
            this.panel3.Controls.Add(this.lblNumMemorando);
            this.panel3.Controls.Add(this.lbl12);
            this.panel3.Controls.Add(this.lbl11);
            this.panel3.Controls.Add(this.lbl7);
            this.panel3.Controls.Add(this.lbl9);
            this.panel3.Controls.Add(this.lbl8);
            this.panel3.Controls.Add(this.lbl10);
            this.panel3.Controls.Add(this.lbl2);
            this.panel3.Controls.Add(this.lbl3);
            this.panel3.Controls.Add(this.lbl4);
            this.panel3.Controls.Add(this.lbl5);
            this.panel3.Controls.Add(this.lbl6);
            this.panel3.Controls.Add(this.lbl1);
            this.panel3.Location = new System.Drawing.Point(7, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(751, 421);
            this.panel3.TabIndex = 66;
            // 
            // lblTipoFianza
            // 
            this.lblTipoFianza.AutoSize = true;
            this.lblTipoFianza.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoFianza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFianza.ForeColor = System.Drawing.Color.White;
            this.lblTipoFianza.Location = new System.Drawing.Point(282, 377);
            this.lblTipoFianza.Name = "lblTipoFianza";
            this.lblTipoFianza.Size = new System.Drawing.Size(126, 13);
            this.lblTipoFianza.TabIndex = 67;
            this.lblTipoFianza.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lbl13
            // 
            this.lbl13.AutoSize = true;
            this.lbl13.BackColor = System.Drawing.Color.Transparent;
            this.lbl13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl13.ForeColor = System.Drawing.Color.White;
            this.lbl13.Location = new System.Drawing.Point(23, 377);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(84, 13);
            this.lbl13.TabIndex = 66;
            this.lbl13.Text = "TIPO FIANZA";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(577, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 20);
            this.label14.TabIndex = 65;
            this.label14.Text = "N° FIANZA ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;
            this.pbImagen.Location = new System.Drawing.Point(545, 211);
            this.pbImagen.Margin = new System.Windows.Forms.Padding(2);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(158, 179);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 63;
            this.pbImagen.TabStop = false;
            // 
            // lblCantidadMesesDescontar
            // 
            this.lblCantidadMesesDescontar.AutoSize = true;
            this.lblCantidadMesesDescontar.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidadMesesDescontar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadMesesDescontar.ForeColor = System.Drawing.Color.White;
            this.lblCantidadMesesDescontar.Location = new System.Drawing.Point(282, 347);
            this.lblCantidadMesesDescontar.Name = "lblCantidadMesesDescontar";
            this.lblCantidadMesesDescontar.Size = new System.Drawing.Size(126, 13);
            this.lblCantidadMesesDescontar.TabIndex = 62;
            this.lblCantidadMesesDescontar.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lblidFianza
            // 
            this.lblidFianza.AutoSize = true;
            this.lblidFianza.BackColor = System.Drawing.Color.Transparent;
            this.lblidFianza.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidFianza.ForeColor = System.Drawing.Color.White;
            this.lblidFianza.Location = new System.Drawing.Point(578, 101);
            this.lblidFianza.Name = "lblidFianza";
            this.lblidFianza.Size = new System.Drawing.Size(98, 18);
            this.lblidFianza.TabIndex = 64;
            this.lblidFianza.Text = "XXXXXXXXX";
            // 
            // lblTotalDescuentoMes
            // 
            this.lblTotalDescuentoMes.AutoSize = true;
            this.lblTotalDescuentoMes.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalDescuentoMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDescuentoMes.ForeColor = System.Drawing.Color.White;
            this.lblTotalDescuentoMes.Location = new System.Drawing.Point(282, 317);
            this.lblTotalDescuentoMes.Name = "lblTotalDescuentoMes";
            this.lblTotalDescuentoMes.Size = new System.Drawing.Size(126, 13);
            this.lblTotalDescuentoMes.TabIndex = 61;
            this.lblTotalDescuentoMes.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lblHaberMensual
            // 
            this.lblHaberMensual.AutoSize = true;
            this.lblHaberMensual.BackColor = System.Drawing.Color.Transparent;
            this.lblHaberMensual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaberMensual.ForeColor = System.Drawing.Color.White;
            this.lblHaberMensual.Location = new System.Drawing.Point(282, 197);
            this.lblHaberMensual.Name = "lblHaberMensual";
            this.lblHaberMensual.Size = new System.Drawing.Size(126, 13);
            this.lblHaberMensual.TabIndex = 60;
            this.lblHaberMensual.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lblCalculoSueldos
            // 
            this.lblCalculoSueldos.AutoSize = true;
            this.lblCalculoSueldos.BackColor = System.Drawing.Color.Transparent;
            this.lblCalculoSueldos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalculoSueldos.ForeColor = System.Drawing.Color.White;
            this.lblCalculoSueldos.Location = new System.Drawing.Point(285, 257);
            this.lblCalculoSueldos.Name = "lblCalculoSueldos";
            this.lblCalculoSueldos.Size = new System.Drawing.Size(126, 13);
            this.lblCalculoSueldos.TabIndex = 59;
            this.lblCalculoSueldos.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lblTotalDescontar
            // 
            this.lblTotalDescontar.AutoSize = true;
            this.lblTotalDescontar.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalDescontar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDescontar.ForeColor = System.Drawing.Color.White;
            this.lblTotalDescontar.Location = new System.Drawing.Point(282, 227);
            this.lblTotalDescontar.Name = "lblTotalDescontar";
            this.lblTotalDescontar.Size = new System.Drawing.Size(126, 13);
            this.lblTotalDescontar.TabIndex = 58;
            this.lblTotalDescontar.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lblDescuentoSalario
            // 
            this.lblDescuentoSalario.AutoSize = true;
            this.lblDescuentoSalario.BackColor = System.Drawing.Color.Transparent;
            this.lblDescuentoSalario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoSalario.ForeColor = System.Drawing.Color.White;
            this.lblDescuentoSalario.Location = new System.Drawing.Point(282, 287);
            this.lblDescuentoSalario.Name = "lblDescuentoSalario";
            this.lblDescuentoSalario.Size = new System.Drawing.Size(126, 13);
            this.lblDescuentoSalario.TabIndex = 57;
            this.lblDescuentoSalario.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lblNombresApellidos
            // 
            this.lblNombresApellidos.AutoSize = true;
            this.lblNombresApellidos.BackColor = System.Drawing.Color.Transparent;
            this.lblNombresApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombresApellidos.ForeColor = System.Drawing.Color.White;
            this.lblNombresApellidos.Location = new System.Drawing.Point(282, 47);
            this.lblNombresApellidos.Name = "lblNombresApellidos";
            this.lblNombresApellidos.Size = new System.Drawing.Size(126, 13);
            this.lblNombresApellidos.TabIndex = 56;
            this.lblNombresApellidos.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lblCi
            // 
            this.lblCi.AutoSize = true;
            this.lblCi.BackColor = System.Drawing.Color.Transparent;
            this.lblCi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCi.ForeColor = System.Drawing.Color.White;
            this.lblCi.Location = new System.Drawing.Point(282, 77);
            this.lblCi.Name = "lblCi";
            this.lblCi.Size = new System.Drawing.Size(126, 13);
            this.lblCi.TabIndex = 55;
            this.lblCi.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lblTipoContrato
            // 
            this.lblTipoContrato.AutoSize = true;
            this.lblTipoContrato.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoContrato.ForeColor = System.Drawing.Color.White;
            this.lblTipoContrato.Location = new System.Drawing.Point(285, 107);
            this.lblTipoContrato.Name = "lblTipoContrato";
            this.lblTipoContrato.Size = new System.Drawing.Size(126, 13);
            this.lblTipoContrato.TabIndex = 54;
            this.lblTipoContrato.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lblVigenciaItem
            // 
            this.lblVigenciaItem.AutoSize = true;
            this.lblVigenciaItem.BackColor = System.Drawing.Color.Transparent;
            this.lblVigenciaItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVigenciaItem.ForeColor = System.Drawing.Color.White;
            this.lblVigenciaItem.Location = new System.Drawing.Point(285, 137);
            this.lblVigenciaItem.Name = "lblVigenciaItem";
            this.lblVigenciaItem.Size = new System.Drawing.Size(126, 13);
            this.lblVigenciaItem.TabIndex = 53;
            this.lblVigenciaItem.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.BackColor = System.Drawing.Color.Transparent;
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.ForeColor = System.Drawing.Color.White;
            this.lblCargo.Location = new System.Drawing.Point(79, 166);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(359, 15);
            this.lblCargo.TabIndex = 52;
            this.lblCargo.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            // 
            // lblNumMemorando
            // 
            this.lblNumMemorando.AutoSize = true;
            this.lblNumMemorando.BackColor = System.Drawing.Color.Transparent;
            this.lblNumMemorando.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumMemorando.ForeColor = System.Drawing.Color.White;
            this.lblNumMemorando.Location = new System.Drawing.Point(282, 17);
            this.lblNumMemorando.Name = "lblNumMemorando";
            this.lblNumMemorando.Size = new System.Drawing.Size(126, 13);
            this.lblNumMemorando.TabIndex = 51;
            this.lblNumMemorando.Text = "XXXXXXXXXXXXXXXXX";
            // 
            // lbl12
            // 
            this.lbl12.AutoSize = true;
            this.lbl12.BackColor = System.Drawing.Color.Transparent;
            this.lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl12.ForeColor = System.Drawing.Color.White;
            this.lbl12.Location = new System.Drawing.Point(23, 347);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(229, 13);
            this.lbl12.TabIndex = 50;
            this.lbl12.Text = "CANTIDAD DE MESES A DESCONTAR";
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.BackColor = System.Drawing.Color.Transparent;
            this.lbl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl11.ForeColor = System.Drawing.Color.White;
            this.lbl11.Location = new System.Drawing.Point(23, 317);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(199, 13);
            this.lbl11.TabIndex = 49;
            this.lbl11.Text = "TOTAL A DESCONTAR POR MES";
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.BackColor = System.Drawing.Color.Transparent;
            this.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.ForeColor = System.Drawing.Color.White;
            this.lbl7.Location = new System.Drawing.Point(23, 197);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(112, 13);
            this.lbl7.TabIndex = 48;
            this.lbl7.Text = "HABER MENSUAL";
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.BackColor = System.Drawing.Color.Transparent;
            this.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9.ForeColor = System.Drawing.Color.White;
            this.lbl9.Location = new System.Drawing.Point(23, 257);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(249, 13);
            this.lbl9.TabIndex = 47;
            this.lbl9.Text = "N° SUELDOS PARA CALCULO DE FIANZA";
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.BackColor = System.Drawing.Color.Transparent;
            this.lbl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl8.ForeColor = System.Drawing.Color.White;
            this.lbl8.Location = new System.Drawing.Point(23, 227);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(139, 13);
            this.lbl8.TabIndex = 46;
            this.lbl8.Text = "TOTAL A DESCONTAR";
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.BackColor = System.Drawing.Color.Transparent;
            this.lbl10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10.ForeColor = System.Drawing.Color.White;
            this.lbl10.Location = new System.Drawing.Point(23, 287);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(167, 13);
            this.lbl10.TabIndex = 45;
            this.lbl10.Text = "% DESCUENTO S/SALARIO";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.White;
            this.lbl2.Location = new System.Drawing.Point(23, 47);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(152, 13);
            this.lbl2.TabIndex = 44;
            this.lbl2.Text = "NOMBRES Y APELLIDOS";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.BackColor = System.Drawing.Color.Transparent;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.ForeColor = System.Drawing.Color.White;
            this.lbl3.Location = new System.Drawing.Point(23, 77);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(150, 13);
            this.lbl3.TabIndex = 43;
            this.lbl3.Text = "CARNET DE IDENTIDAD";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.BackColor = System.Drawing.Color.Transparent;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.ForeColor = System.Drawing.Color.White;
            this.lbl4.Location = new System.Drawing.Point(23, 107);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(129, 13);
            this.lbl4.TabIndex = 42;
            this.lbl4.Text = "TIPO DE CONTRATO";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.BackColor = System.Drawing.Color.Transparent;
            this.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.ForeColor = System.Drawing.Color.White;
            this.lbl5.Location = new System.Drawing.Point(23, 137);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(219, 13);
            this.lbl5.TabIndex = 41;
            this.lbl5.Text = "VIGENCIA DE CONTRATO Y/O ITEM";
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.BackColor = System.Drawing.Color.Transparent;
            this.lbl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl6.ForeColor = System.Drawing.Color.White;
            this.lbl6.Location = new System.Drawing.Point(23, 167);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(50, 13);
            this.lbl6.TabIndex = 40;
            this.lbl6.Text = "CARGO";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(23, 17);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(106, 13);
            this.lbl1.TabIndex = 39;
            this.lbl1.Text = "N° MEMORANDO";
            // 
            // grProductos
            // 
            this.grProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grProductos.Controls.Add(this.dgvListaCartilla);
            this.grProductos.Location = new System.Drawing.Point(764, 3);
            this.grProductos.Name = "grProductos";
            this.grProductos.Size = new System.Drawing.Size(408, 454);
            this.grProductos.TabIndex = 38;
            this.grProductos.TabStop = false;
            this.grProductos.Text = "Lista";
            // 
            // dgvListaCartilla
            // 
            this.dgvListaCartilla.AllowUserToAddRows = false;
            this.dgvListaCartilla.AllowUserToDeleteRows = false;
            this.dgvListaCartilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCartilla.Location = new System.Drawing.Point(6, 16);
            this.dgvListaCartilla.MultiSelect = false;
            this.dgvListaCartilla.Name = "dgvListaCartilla";
            this.dgvListaCartilla.ReadOnly = true;
            this.dgvListaCartilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaCartilla.Size = new System.Drawing.Size(396, 432);
            this.dgvListaCartilla.TabIndex = 0;
            this.dgvListaCartilla.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvGrilla_RowPostPaint);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Image = global::MidasD.Properties.Resources.print;
            this.btnImprimir.Location = new System.Drawing.Point(312, 451);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(96, 29);
            this.btnImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnImprimir.TabIndex = 66;
            this.btnImprimir.TabStop = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(602, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 99;
            this.label3.Text = "Cartilla";
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = global::MidasD.Properties.Resources.exit_;
            this.btnSalir.Location = new System.Drawing.Point(1148, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 29);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSalir.TabIndex = 100;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmSeleccionarFianzaPorPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1241, 624);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmSeleccionarFianzaPorPersona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: MidasD - Lista de Fianzas Por Persona::";
            this.pnlDatos.ResumeLayout(false);
            this.gbxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.grProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCartilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.GroupBox gbxMenu;
        private System.Windows.Forms.ToolTip totMensaje;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTotalDescontadoPlanilla;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTipoFianza;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Label lblCantidadMesesDescontar;
        private System.Windows.Forms.Label lblidFianza;
        private System.Windows.Forms.Label lblTotalDescuentoMes;
        private System.Windows.Forms.Label lblHaberMensual;
        private System.Windows.Forms.Label lblCalculoSueldos;
        private System.Windows.Forms.Label lblTotalDescontar;
        private System.Windows.Forms.Label lblDescuentoSalario;
        private System.Windows.Forms.Label lblNombresApellidos;
        private System.Windows.Forms.Label lblCi;
        private System.Windows.Forms.Label lblTipoContrato;
        private System.Windows.Forms.Label lblVigenciaItem;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblNumMemorando;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.GroupBox grProductos;
        private System.Windows.Forms.DataGridView dgvListaCartilla;
        private System.Windows.Forms.PictureBox btnImprimir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}