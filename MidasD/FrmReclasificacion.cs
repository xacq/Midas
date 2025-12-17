
using MidasD.SrArgos;
using MidasD.SrMidasD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MidasD
{
    public partial class FrmReclasificacion : Form
    {
        SrMidasD.Usuario usuario;
        FrmCargando frmCargando;
        SrArgos.ArgosServiceClient servicioArgos;
        public Persona1 personaArgos;

        public int idFuncionario,idPersona,idFianza;
        SrMidasD.MidasDServiceClient servicio;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public bool mes,anio = false;

        public FrmReclasificacion(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();
            servicioArgos = new SrArgos.ArgosServiceClient();
            btnPnlLista = new List<Control>() { 
            btnBuscar,txtBuscar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() { btnEditar };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() { btnEditar,btnBuscar, 
            btnCancelar, btnGuardar, btnSalir });

           
        }

        private async Task listarPendientes()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);

            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvLista;
            paListarFianzasReclasificacionPendientes_Result[] asyncVariable1 = await this.servicio.paListarFianzasReclasificacionPendientesAsync(Util.header, txtBuscar.Text);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFianza" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() {"Nro_Fianza","apellidos_Y_Nombres", "sigma", "t727", "monto_Beneficiario"});
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);

            frmCargando.Close();

        }

        private async Task listarRealizadas()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvListaReclasificacionesRealizadas;
            paListarFianzasReclasificacion_Result[] asyncVariable1 = await this.servicio.paListarFianzasReclasificacionAsync(Util.header, txtBuscar.Text);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvListaReclasificacionesRealizadas, new List<string>() { "idFianza","idReclasificacion" });
            Utils.Wfa.positionHeadersDGV(dgvListaReclasificacionesRealizadas, new List<string>() { "Nro_Fianza", "apellidos_Y_Nombres", "sigma","mes","anio","monto_727", "monto_Beneficiario" });
            Utils.Wfa.setHeadersDGV(dgvListaReclasificacionesRealizadas);
            dgvListaReclasificacionesRealizadas.AutoResizeColumns();
            dgvListaReclasificacionesRealizadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);

            frmCargando.Close();

        }

        private void dgvFuncionarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvListaReclasificacionesRealizadas.Rows)
                {

                    //double montoBeneficiario = Convert.ToDouble(item.Cells["monto_Beneficiario"].Value);

                    int index = item.Index;

                    //if (montoBeneficiario < 0)
                    //{
                    //    Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "White");
                    //}
                    //else
                    //{
                        Util.pintarDatagridwiewIndex(dgvListaReclasificacionesRealizadas, index, "Black", "Green");
                    //}

                    //dgvLista.ClearSelection();

                }
            }
            catch { }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            await cargarCampos();
            verificarNuevo();
        }

        public void verificarNuevo()
        {
            if (cbxMes.SelectedIndex == -1)
            {
                mes = false;
            }
            else
            {
                mes = true;
            }

            if (string.IsNullOrEmpty(txtAnio.Text))
            {
                anio = false;
            }
            else
            {
                anio = true;
            }
        }

        private async Task cargarCampos()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            idFianza = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value);
                idFuncionario = (int)servicio.fianzaGet(Util.header,idFianza).idFuncionario;
                SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, idFuncionario);
                lblNombresList.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).nombres;
                lblPaternoList.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).paterno;
                lblMaternoList.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).materno;
                txtNumeroDoc.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento;
                lblTipoDocumentoList.Text =servicio.tipoDocumentoGet(Util.header,(int)servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).idTipoDocumento).descripcion;
                lblOficinaList.Text =servicio.oficinaGet(Util.header,(int)funcionarioDatos.idOficina).oficina1;//Cargamos los Cargos
                int idEscalaSalarial = (int)servicio.cargoGet(Util.header, (int)funcionarioDatos.idCargo).idEscalaSalarial;
                int idHaberBasico = (int)servicio.escalaSalarialGet(Util.header, idEscalaSalarial).idSueldoMensual;
                cbxCargo.DataSource = servicio.cargoListarOficina(Util.header, (int)funcionarioDatos.idOficina, (int)servicio.sueldoMensualGet(Util.header, idHaberBasico).gestion);
                cbxCargo.ValueMember = "idCargo";
                cbxCargo.DisplayMember = "cargo";
                cbxCargo.SelectedValue = funcionarioDatos.idCargo;
                try
                {
                cbxMes.SelectedValue = servicio.fechaServidor().Month;
                txtAnio.Text = servicio.fechaServidor().Year.ToString();
                mxbMontoBeneficiario.Text = Convert.ToDouble(servicio.reclasificacionGetidFianza(Util.header, idFianza).monto_727).ToString();
                }
                catch
                {
                    try
                    {
                        mxbMontoBeneficiario.Text =Convert.ToDouble(servicio.descuentoGetIdFianzaReclasificacion(Util.header, idFianza).t727).ToString();
                    
                }
                    catch
                    {
                    mxbMontoBeneficiario.Text = Convert.ToDouble(servicio.descuentoGetIdFianzaReclasificacion(Util.header, idFianza).monto_Beneficiario).ToString();
                    }
                    
                }

                lblCargoList.Text = cbxCargo.Text;
                lblNumeroMemorandoList.Text = funcionarioDatos.numero_Memorando;
            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)funcionarioDatos.idPersona).imagen1);
            }
            catch
            {

            }
               
                Util.pnlListaActivar(false, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlLista3);
                Util.pnlListaActivar(true, btnPnlDatos);
                Util.pnlListaActivar(false, btnPnlLista2);
                cbxMes.Focus();
                Util.pintarDatagridwiew(dgvLista,"Gray","Gray");

            frmCargando.Close();
         
        }
        private bool validarCampos()
        {
            limpiarErrores();
            verificarNuevo();

            if (!mes)
            {
                Util.errorMensaje(erpError,lblMes,"Debe Introducir un Mes");
            }

            if (!anio)
            {
                Util.errorMensaje(erpError, lblAnio, "Debe Introducir un Año");
            }

            if (mes == true && anio==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        { 
                if (!validarCampos())
                { }
                else
                {
                    editar();
                    Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                }
        }
     

      
        public void reiniciarVerificacion()
        {
            mes = false;
            anio = false;
        }

        public void limpiarErrores()
        {
            erpError.Clear();
          
        }

        private async void editar()
        {
            limpiarErrores();



            try
            {
                try
                {
                    SrMidasD.Persona persona = servicio.personaGet(Util.header, (int)servicio.funcionarioGet(Util.header, idFuncionario).idPersona);
                    SrArgos.Persona1 personaArgos = servicioArgos.segipConsulta(this.txtNumeroDoc.Text.Trim(), "7644473", this.lblNombresList.Text.Trim(), this.lblPaternoList.Text.Trim(), this.lblMaternoList.Text.Trim(), "Harper");
                    persona.idTipoDocumento = 1;
                    persona.numero_Documento = txtNumeroDoc.Text.Trim();
                    persona.paterno = lblPaternoList.Text.Trim();
                    persona.materno = lblMaternoList.Text.Trim();
                    persona.nombres = lblNombresList.Text.Trim();
                    persona.domicilio = personaArgos.domicilio;
                    persona.estado_Civil = personaArgos.estadoCivil;

                    switch (persona.estado_Civil)
                    {
                        case "CASADA":
                            persona.sexo = "F";
                            break;
                        case "CASADO":
                            persona.sexo = "M";
                            break;
                        case "SOLTERA":
                            persona.sexo = "F";
                            break;
                        case "SOLTERO":
                            persona.sexo = "M";
                            break;
                        case "VIUDA":
                            persona.sexo = "F";
                            break;
                        case "VIUDO":
                            persona.sexo = "M";
                            break;
                        case "DIVORCIADA":
                            persona.sexo = "F";
                            break;
                        case "DIVORCIADO":
                            persona.sexo = "M";
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    persona.departamento_Nacimiento = personaArgos.departamentoNacimiento;
                    persona.pais_Nacimiento = personaArgos.paisNacimiento;
                    persona.localidad_Nacimiento = personaArgos.localidadNacimiento;
                    persona.provincia_Nacimiento = personaArgos.provinciaNacimiento;
                    persona.profesion = personaArgos.profesion;
                    persona.fecha_Nacimiento = personaArgos.fechaNacimiento;
                    persona.registroActivo = true;
                    persona.usuarioRegistro = usuario.nombre_Usuario;
                    persona.fechaRegistro = DateTime.Now.Date;

                    servicio.personaEditar(Util.header, persona);

                    SrMidasD.Imagen imagen = servicio.imagenGetidPersona(Util.header, Convert.ToInt32(persona.idPersona));
                    imagen.idImagen = imagen.idImagen;
                    imagen.idPersona = imagen.idPersona;
                    imagen.imagen1 = Utils.Utils.imageToByteArray(pbImagen.Image);

                    servicio.imagenEditar(Util.header, imagen);
                }
                catch
                {
                    MessageBox.Show("Ha Sucedido un Error La Persona no existe.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                //Se edita la Fianza
                SrMidasD.Fianza fianza = servicio.fianzaIdFuncionario(Util.header, idFuncionario);
                fianza.idFianza = fianza.idFianza;
                fianza.idFuncionario = fianza.idFuncionario;
                fianza.registroActivo = true;
                //fianza.registroSigma=
                fianza.usuarioRegistro = usuario.nombre_Usuario;
                fianza.fechaRegistro = DateTime.Now.Date;
                int idFianza = servicio.fianzaEditar(Util.header, fianza);

                //Se Edita el Unico Descuento
                SrMidasD.Descuento descuento = servicio.descuentoGetIdFianzaReclasificacion(Util.header, fianza.idFianza);
                descuento.idDescuento = descuento.idDescuento;
                descuento.idFianza = fianza.idFianza;
                descuento.monto_Beneficiario = Convert.ToDouble(mxbMontoBeneficiario.Text.ToString());
                descuento.usuarioRegistro = usuario.nombre_Usuario;
                descuento.registroActivo = true;
                descuento.fechaRegistro = DateTime.Now.Date;
                int idDescuento = servicio.descuentoEditar(Util.header, descuento);

                //Se crea la Reclasificacion
                SrMidasD.Reclasificacion reclasificacion;
                reclasificacion = new SrMidasD.Reclasificacion();
                reclasificacion.idFianza = fianza.idFianza;
                reclasificacion.monto_727 = Convert.ToDouble(mxbMontoBeneficiario.Text.ToString());
                reclasificacion.mes = Convert.ToInt32(cbxMes.SelectedValue.ToString()); ;
                reclasificacion.anio = Convert.ToInt32(txtAnio.Text.ToString());
                reclasificacion.usuarioRegistro = usuario.nombre_Usuario;
                reclasificacion.registroActivo = true;
                reclasificacion.fechaRegistro = DateTime.Now.Date;
                servicio.reclasificacionInsertar(Util.header, reclasificacion);

                await listarPendientes();


                limpiarcampos();
                MessageBox.Show("Se ha registrado Correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
 

                catch
                {
                    MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
           
        }


      

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            await listarPendientes();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista,"Black","Gray");
            limpiarcampos();    
        }

       

        public void textleave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        }


        private async void FrmPersona_Load(object sender, EventArgs e)
        {
            List<Item> lista = new List<Item>();

            lista.Add(new Item("Enero", 1));
            lista.Add(new Item("Febrero", 2));
            lista.Add(new Item("Marzo", 3));
            lista.Add(new Item("Abril", 4));
            lista.Add(new Item("Mayo", 5));
            lista.Add(new Item("Junio", 6));
            lista.Add(new Item("Julio", 7));
            lista.Add(new Item("Agosto", 8));
            lista.Add(new Item("Septiembre", 9));
            lista.Add(new Item("Octubre", 10));
            lista.Add(new Item("Noviembre", 11));
            lista.Add(new Item("Diciembre", 12));

            cbxMes.DisplayMember = "Name";
            cbxMes.ValueMember = "Value";
            cbxMes.DataSource = lista;

            //
            // Se asigna el evento para control el cambio de seleccion
            //
            cbxMes.SelectedIndexChanged += new System.EventHandler(this.cbxMes_SelectedIndexChanged);
            cbxMes.SelectedValue = -1;

            txtBuscar.Enabled = false;
            await listarPendientes();
            txtBuscar.Enabled = true;
        }

        public class Item
        {
            public string Name { get; set; }
            public int Value { get; set; }

            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        void limpiarcampos()
        {
            mxbMontoBeneficiario.Clear();
            cbxMes.SelectedValue = -1;
            txtAnio.ResetText();
           
            txtNumeroDoc.ResetText();
            lblTipoDocumentoList.ResetText();
            lblNombresList.ResetText();
            lblPaternoList.ResetText();
            lblMaternoList.ResetText();
            lblOficinaList.ResetText();
            lblCargoList.ResetText();
            lblNumeroMemorandoList.ResetText();
          
            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1; 
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            reiniciarVerificacion();

            await listarPendientes();
        }

        private void txtc21_KeyPress(object sender, KeyPressEventArgs e)
        {
         
                Utils.Wfa.onlyNumbers(sender, e);
      
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item seleccion = cbxMes.SelectedItem as Item;

            if (seleccion == null)
                return;
        }

        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.notPaste = true;

            string nombre = ((TextBox)sender).Name.ToString();
            
            if (nombre == "txtAnio")
            {
                erpError.Clear();
                anio = true;
            }
 
        }

        private void txtAnio_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Clear();
        }

        private async void dgvLista_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            limpiarErrores();
            await cargarCampos();
            verificarNuevo();
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string namepage = tabControl1.SelectedTab.Name;

            if (namepage == "tabPage1".ToString())
            {
               
                await listarPendientes();

            }
            if (namepage == "tabPage2".ToString())
            {
                await listarRealizadas();
            }
        }

        private void txtAnio_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
        }

        private void FrmPersona_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender,e);
            }
        }

        public class WinAPI
        {
            // Constantes para SetWindowsPos
            //   Valores de wFlags
            const int SWP_NOSIZE = 0x1;
            const int SWP_NOMOVE = 0x2;
            const int SWP_NOACTIVATE = 0x10;
            const int wFlags = SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE;
            //   Valores de hwndInsertAfter
            const int HWND_TOPMOST = -1;
            const int HWND_NOTOPMOST = -2;
            //
            /// <summary>
            /// Para mantener la ventana siempre visible
            /// </summary>
            /// <remarks>No utilizamos el valor devuelto</remarks>
            [DllImport("user32.DLL")]
            private extern static void SetWindowPos(
                int hWnd, int hWndInsertAfter,
                int X, int Y,
                int cx, int cy,
                int wFlags);

            public static void SiempreEncima(int handle)
            {
                SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, wFlags);
            }

            public static void NoSiempreEncima(int handle)
            {
                SetWindowPos(handle, HWND_NOTOPMOST, 0, 0, 0, 0, wFlags);
            }
        }

        //Solo numeros y al mismo tiempo verificamos fianza pendiente
        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyNumbers(sender, e);

            string nombre = ((TextBox)sender).Name.ToString();
            

            if (e.KeyChar == Convert.ToChar(Keys.Enter) && nombre == "txtNumeroDoc")
            {
                try
                {
                    buscarCi();
                }
                catch
                { }
            }
        }

        //Funcion Buscar Ci Segip
        private void buscarCi()
        {
            SrMidasD.Persona personaBDL = servicio.personaGetPorNumeroDocumento(Util.header, txtNumeroDoc.Text);

            if (personaBDL.numero_Documento == "0" || personaBDL.idTipoDocumento!=5)
            {
                idPersona = personaBDL.idPersona;
                this.lblNombresList.Text = Utils.Utils.uppercaseFirstLetter(personaBDL.nombres);
                this.lblPaternoList.Text = Utils.Utils.uppercaseFirstLetter(personaBDL.paterno);
                this.lblMaternoList.Text = Utils.Utils.uppercaseFirstLetter(personaBDL.materno);
                try
                {
                    this.pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, personaBDL.idPersona).imagen1);
                }
                catch
                {

                }
            }

            else
            {
                try
                {
                    personaArgos = this.servicioArgos.segipConsulta(this.txtNumeroDoc.Text.Trim(), "7644473", this.lblNombresList.Text.Trim(), this.lblPaternoList.Text.Trim(), this.lblMaternoList.Text.Trim(), "Harper");
                    this.erpError.Clear();
                    if (personaArgos.estado == 2)//Cuando Existe Cedula Real
                    {
                        this.lblNombresList.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.nombres);
                        this.lblPaternoList.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.paterno);
                        this.lblMaternoList.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.materno);
                        this.pbImagen.Image = Utils.Utils.byteArrayToImage(personaArgos.fotografia);

                        this.btnGuardar.Enabled = true;
                    }
                    else if (personaArgos.estado == 1)//No Existe Cedula Real y se Procedera a su Creacion Manual
                    {

                        this.erpError.SetError(this.txtNumeroDoc, "La C\x00e9dula de Identidad es inv\x00e1lida.");
                        this.txtNumeroDoc.Focus();
                        this.btnGuardar.Enabled = false;

                    }
                    else
                    {
                        this.lblNombresList.Text = string.Empty;
                        this.lblPaternoList.Text = string.Empty;
                        this.lblMaternoList.Text = string.Empty;
                        this.txtUsuario.Text = string.Empty;
                        this.pbImagen.Image = null;
                        MessageBox.Show("Se encontr\x00f3 m\x00e1s de un registro con la c\x00e9dula de identidad\rIntroduzca el apellido paterno!", "::: Harper - Consulta :::", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtNumeroDoc.Focus();
                        this.btnGuardar.Enabled = false;
                    }
                }
                catch
                {
                    MessageBox.Show("No se pudo establecer conexi\x00f3n con el servicio Segip Consulta", "::: Harper - Error :::", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

           
        }
    }
}
