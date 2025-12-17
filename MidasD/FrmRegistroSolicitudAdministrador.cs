using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using MidasD.SrArgos;
using MidasD.SrMidasD;
using MidasD.Reportes;

namespace MidasD
{
    public partial class FrmRegistroSolicitudAdministrador  : Form
    {
        SrMidasD.Usuario usuario;

        bool bandera;
        int dia1, dia2,idSolicitud, idFianzaGlobalSeleccionada;
        string usuarioParaLista,usuarioParaRRHH,c31;

        public int  idPersona,idFianza;
        SrMidasD.MidasDServiceClient servicio;

        SrArgos.ArgosServiceClient servicioArgos;
        public Persona1 personaArgos;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public bool nombres, apellido,
        tipodocumento, numerodoc, unidadEjecutora,
        oficina, cargo, numeroMemorando, tipodeFianza,solicitaTransDevo = false;

        DateTime fechaActualDiauno, fechaActualServidor;

        public FrmRegistroSolicitudAdministrador(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();
            servicioArgos = new SrArgos.ArgosServiceClient();

            btnPnlLista = new List<Control>() {
            btnNuevo,btnBuscar,txtBuscar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() { btnBaja, btnEditar,btnImprimir,btnQuitarSeleccion };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar, pnlDatos };
            Util.btn_Mouse(new List<PictureBox>() { btnNuevo, btnEditar, btnBaja,btnBuscar,btnImprimir,btnQuitarSeleccion,
            btnCancelar, btnGuardar, btnSalir });

            chkUsuarioListaFuncionarios.Text = usuario.nombre_Usuario;

            usuarioParaRRHH = usuario.nombre_Usuario;

            listarSolicitudes();
            cargarTipoDocumento();
            cargarUnidadEjecutora();
            cargarTipoFianza();

            cbxOficina.Enabled = false;
            cbxCargo.Enabled = false;

            fechaActualServidor = servicio.fechaServidor();
            txtGestion.Text = fechaActualServidor.Year.ToString();
            //if(fechaActualServidor.Month>6)
            //{
            //    txtGestion.Text = fechaActualServidor.Year.ToString();
            //}
            //else
            //{
            //    txtGestion.Text = (fechaActualServidor.Year-1).ToString();
            //}

            txtAñoSolicitud.Text = (fechaActualServidor.Year-1).ToString();
            fechaActualDiauno = new DateTime(fechaActualServidor.Year, fechaActualServidor.Month, 01);
            mtxtFechaMemorando.Text =fechaActualDiauno.ToString("dd-MM-yyyy");
            txtBuscar.Focus();
            lbTipoSolicitud.Visible = false;
            rbTransferencia.Visible = false;
            rbDevolucion.Visible = false;

            rbFianza20.Visible = false;
            rbFianzaTotal.Visible = false;
            rbFianzaSuperior.Visible = false;
        }

        //Listar Funcionarios para Recursos Humanos
        private void listarSolicitudes()
        {
            dgvLista.DataSource = servicio.palistarSolicitudesFianzaBuscar(Util.header, txtBuscar.Text,usuarioParaRRHH);
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idSolicitud","usuario_Asesor_Acepta"});
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "numero_Fianza_Solicitud", "gestion", "tipo_Solicitud_Fianza", "fecha_limite_Presentacion", "numero_Documento", "nombre_Completo", "cargo", "haber_basico", "oficina", "numero_Memorando", "fecha_Memorando", "tipo_contrato_item", "vigencia_Contrato", "usuario_RRHH", "fecha_Registro_RRHH", "fecha_Aceptacion", "solicitud_Aceptada","observacion" });
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);
        }

        private void listarDiasRestantes()
        {
            
            if (rb30Dias.Checked==true)
            {
                dia1 = 16;
                dia2 = 30;
            }
            if(rb15Dias.Checked==true)
            {
                dia1 = 1;
                dia2 = 15;
            }
            if (rb0Dias.Checked == true)
            {
                dia1 = -99999999;
                dia2 = -1;
            }
            dgvDiasRestantes.DataSource = servicio.paListarSolicitudesFianzaDiasRestantes(Util.header, txtBuscar.Text,dia1,dia2, usuarioParaLista);
            Utils.Wfa.hideHeadersDGV(dgvDiasRestantes, new List<string>() { "idSolicitud", "usuario_Asesor_Acepta" });
            Utils.Wfa.positionHeadersDGV(dgvDiasRestantes, new List<string>() { "numero_Fianza_Solicitud", "gestion", "tipo_Solicitud_Fianza", "fecha_limite_Presentacion", "numero_Documento", "nombre_Completo", "cargo", "haber_basico", "oficina", "numero_Memorando", "fecha_Memorando", "tipo_contrato_item", "vigencia_Contrato", "usuario_RRHH", "fecha_Registro_RRHH", "fecha_Aceptacion", "solicitud_Aceptada", "observacion" });
            Utils.Wfa.setHeadersDGV(dgvDiasRestantes);
            dgvDiasRestantes.AutoResizeColumns();
            dgvDiasRestantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);
        }

        private void listarConResolucion()
        {

            dgvConResolucion.DataSource = servicio.paListarFuncionariosFianzaConResolucion(Util.header, txtBuscar.Text, usuarioParaLista);
            Utils.Wfa.hideHeadersDGV(dgvConResolucion, new List<string>() { "idFuncionario", "idFianza" });
            Utils.Wfa.positionHeadersDGV(dgvConResolucion, new List<string>() { "numero_Fianza_Solicitud", "gestion", "tipo_Fianza","fecha_limite_Fianza", "numero_Documento", "nombre_Completo", "cargo", "haber_Mensual", "oficina", "numero_Memorando", "fecha_Memorando", "tipo_contrato_item", "vigencia_Contrato","Nro_Fianza", "usuario_RRHH", "usuario_Asesor", "resolucion_Administrativa","fecha_Resolucion" });
            Utils.Wfa.setHeadersDGV(dgvConResolucion);
            dgvConResolucion.AutoResizeColumns();
            dgvConResolucion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);
        }


        private void dgvFuncionarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           
            try
            {
                foreach (DataGridViewRow item in dgvLista.Rows)
                {
                    int index = item.Index;
                    try
                    {
                        if((item.Cells["solicitud_Aceptada"].Value)is null)
                        {
                            DateTime fechalimitePresentacion = Convert.ToDateTime(item.Cells["fecha_limite_Presentacion"].Value);
                          
                            TimeSpan fechaRestante = fechalimitePresentacion - fechaActualServidor;
                            int diasRestantes = fechaRestante.Days;

                            if (fechaRestante.Days > 0)
                            {
                                if (fechaRestante.Days > 15)
                                {

                                    Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "LimeGreen");
                                }
                                else
                                {
                                    Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Gold");
                                }
                            }
                            else
                            {
                                Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "OrangeRed");
                            }

                           
                        }
                        else
                        {
                            Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Sienna");
                        }
      
                    }
                    catch
                    {
                        Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Sienna");
                    }

                    
                    dgvLista.ClearSelection();

                }
            }
            catch { }

        }

        //Listar Tipo de Documento
        private void cargarTipoDocumento()
        {
            cbxTipoDocumento.DataSource = servicio.tipoDocumentoListar(Util.header);
            cbxTipoDocumento.ValueMember = "idTipoDocumento";
            cbxTipoDocumento.DisplayMember = "descripcion";
            cbxTipoDocumento.SelectedIndex = -1;
        }

        //Listar las Unidades Encargadas
        private void cargarUnidadEjecutora()
        {
            cbxUnidadEjecutora.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutora.DisplayMember = "descripcion";
            cbxUnidadEjecutora.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutora.SelectedIndex = -1;
        }

       

        //Redimencionar Combo Box Cargos
        public static int widthComboBoxCargos(ComboBox cbx)
        {
            int num = 0;
            int preferredWidth = 0;
            Label label = new Label
            {
                Font = new Font(cbx.Font.FontFamily, cbx.Font.Size, cbx.Font.Style, GraphicsUnit.Point, 0)
            };
            foreach (object obj2 in cbx.Items)
            {
                label.Text = ((paListaCargoOficina_Result)obj2).Cargo.Trim();
                preferredWidth = label.PreferredWidth;
                if (preferredWidth > num)
                {
                    num = preferredWidth;
                }
            }
            return (num + 20);
        }

        //Listar las Oficinas de Acuerdo a la Unidad Encargada
        private void cargarOficinas()
        {
            try
            {
                cbxOficina.ValueMember = "idOficina";
                cbxOficina.DisplayMember = "oficina";
                cbxOficina.DataSource = servicio.oficinaListarUnidadEjecutora(Util.header, Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
                cbxOficina.SelectedIndex = -1;
            }
            catch
            {}
        }

        //Listar Cargos de Acuerdo a la Oficina
        private void cargarCargo()
        {
            try
            {
                cbxCargo.DataSource = servicio.cargoListarOficina(Util.header, Convert.ToInt32(cbxOficina.SelectedValue.ToString()), Convert.ToInt32(txtGestion.Text));
                cbxCargo.ValueMember = "idCargo";
                cbxCargo.DisplayMember = "cargo";
                cbxCargo.DropDownWidth = widthComboBoxCargos(cbxCargo);
                cbxCargo.SelectedIndex = -1;
                cbxCargo.Enabled = true;
            }
            catch
            { }
        }

        //Listar los tipos de Fianza
        private void cargarTipoFianza()
        {
            cbxTipoFianza.DataSource = servicio.tipoFianzaListar(Util.header);
            cbxTipoFianza.DisplayMember = "descripcion_Fianza";
            cbxTipoFianza.ValueMember = "idTipoFianza";
            cbxTipoFianza.SelectedIndex = -1;
        }

        //Salir dek Firmulario
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Habilitacion para insertar un nuevo Funcionario
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            verificarNuevo();

            bandera = true;

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlDatos);

            cbxUnidadEjecutora.SelectedIndex = -1;
            cbxOficina.SelectedIndex = -1;
            cbxCargo.SelectedIndex = -1;
            cbxTipoDocumento.SelectedIndex = -1;
            cbxTipoFianza.SelectedIndex = -1;
            txtNumeroDocumento.Focus();
            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
            limpiarcampos();
            mtxtFechaMemorando.Text = fechaActualDiauno.ToString("dd-MM-yyyy");
            txtNumeroSolicitud.Text= (servicio.ultimoNumeroSolicitud(Util.header,Convert.ToInt32(txtAñoSolicitud.Text))+1).ToString();
            txtNumeroDocumento.Enabled = true;
            cbxUnidadEjecutora.Enabled = true;
            cbxTipoContrato.Enabled = true;
            cbxTipoFianza.Enabled = true;
            mtxtFechaMemorando.Enabled = true;
            txtItem.Enabled = true;
            btnBuscarOficina.Enabled = false;
            txtNumeroDocumento.Focus();
        }

        //Editar un Funcionario Registrado desde RRHH
        private void btnEditar_Click(object sender, EventArgs e)
        {
            bandera = false;
            limpiarErrores();
            cargarCampos();
            verificarNuevo(); 
        }


        //Validacion de si todo esta lleno
        public void verificarNuevo()
        {
            //Numero de Documento
            if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                numerodoc = false;
            }
            else
            {
                numerodoc = true;
            }

            //Nombres
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                nombres = false;
            }
            else
            {
                nombres = true;
            }

            //Apellidos
            if (string.IsNullOrEmpty(txtPaterno.Text) && string.IsNullOrEmpty(txtMaterno.Text))
            {

                apellido = false;
            }
            else
            {
                apellido = true;
            }

            //Tipo de Documento
            if (cbxTipoDocumento.SelectedIndex == -1)
            {
                tipodocumento = false;
            }
            else
            {
                tipodocumento = true;
            }

            //Unidad Ejecutora
            if (cbxUnidadEjecutora.SelectedIndex == -1)
            {
                unidadEjecutora = false;
            }
            else
            {
                unidadEjecutora = true;
            }

            //Oficina
            if (cbxOficina.SelectedIndex == -1)
            {
                oficina = false;
            }
            else
            {
                oficina = true;
            }

            //Cargo
            if (cbxCargo.SelectedIndex == -1)
            {
                cargo = false;
            }
            else
            {
                cargo = true;
            }


            //Numero de Memorando
            if (string.IsNullOrEmpty(txtNumeroMemorando.Text))
            {
                numeroMemorando = false;
            }
            else
            {
                numeroMemorando = true;
            }

            //Tipo de Fianza
            if (cbxTipoFianza.SelectedIndex == -1)
            {
                //Tipo de Fianza
                if (rbFianza20.Checked || rbFianzaSuperior.Checked || rbFianzaTotal.Checked)
                {
                    tipodeFianza = true;
                }
                else
                {
                    tipodeFianza = true;
                }
            }
            else
            {
                tipodeFianza = true;
            }

           

        }

        //Cargar Campos del Funcionario Registrado
        private void cargarCampos()
        {



            if (verificarFianzaCurso()==true)//Verificamos si no tiene fianza pendiente y cargamos
            {
                DialogResult ResultadoDialogo = MessageBox.Show("El funcionario ya tiene una fianza corriendo. Quiere Editar", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ResultadoDialogo == DialogResult.Yes)
                {
                    cargarTodosCampos();
                }
                else
                {
                    cancelar();
                }
            }
            else
            {
                cargarTodosCampos();
            }
 
        }

        public void cargarTodosCampos()
        {
            idSolicitud = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idSolicitud"].Value);
            SrMidasD.Solicitudes solicitudesDatos = servicio.solicitudesGet(Util.header, idSolicitud);

            txtNumeroDocumento.Text = servicio.personaGet(Util.header, (int)solicitudesDatos.idPersona).numero_Documento;
            cbxTipoDocumento.SelectedValue = servicio.personaGet(Util.header, (int)(int)solicitudesDatos.idPersona).idTipoDocumento;
            txtNombre.Text = servicio.personaGet(Util.header, (int)solicitudesDatos.idPersona).nombres;
            txtPaterno.Text = servicio.personaGet(Util.header, (int)solicitudesDatos.idPersona).paterno;
            txtMaterno.Text = servicio.personaGet(Util.header, (int)solicitudesDatos.idPersona).materno;
            cbxUnidadEjecutora.SelectedValue = servicio.oficinaGet(Util.header, (int)solicitudesDatos.idOficina).idUnidadEjecutora;
            cbxOficina.SelectedValue = solicitudesDatos.idOficina;
            txtOficinaLiteral.Text = servicio.oficinaGet(Util.header, (int)solicitudesDatos.idOficina).oficina1;
            txtItem.Text = solicitudesDatos.tipo_Contrato_Item;
            cbxTipoContrato.SelectedItem = solicitudesDatos.vigencia_Contrato;
            cargarCargo();
            mtxtFechaMemorando.Text = Convert.ToDateTime(solicitudesDatos.fecha_Memorando).ToString("dd-MM-yyyy");
            cbxCargo.SelectedValue = solicitudesDatos.idCargo;
            txtNumeroMemorando.Text = solicitudesDatos.numero_memorando;
            cbxTipoFianza.SelectedValue = solicitudesDatos.idTipoFianza;
            txtNumeroSolicitud.Text = solicitudesDatos.numero_Fianza_Solicitud.ToString();

            if (solicitudesDatos.tipo_Solicitud_Fianza != "Nueva Fianza")
            {
                lbTipoSolicitud.Visible = true;
                rbTransferencia.Visible = true;
                rbDevolucion.Visible = true;
                if (solicitudesDatos.tipo_Solicitud_Fianza == "Devolucion")
                {
                    rbDevolucion.Checked = true;
                }
                if (solicitudesDatos.tipo_Solicitud_Fianza == "Transferencia")
                {
                    rbTransferencia.Checked = true;

                    cbxTipoFianza.Visible = false;

                    if (solicitudesDatos.idTipoFianza == 2)
                    {
                        rbFianza20.Checked = true;
                        rbFianza20.Visible = true;
                        rbFianzaTotal.Visible = true;
                        rbFianzaTotal.Checked = false;
                        rbFianzaSuperior.Visible = false;
                        rbFianzaSuperior.Checked = false;
                    }
                    if (solicitudesDatos.idTipoFianza == 3)
                    {
                        rbFianzaTotal.Checked = true;
                        rbFianzaTotal.Visible = true;
                        rbFianza20.Visible = true;
                        rbFianza20.Checked = false;
                        rbFianzaSuperior.Visible = false;
                        rbFianzaSuperior.Checked = false;
                    }
                    if (solicitudesDatos.idTipoFianza == 0)
                    {
                        rbFianzaSuperior.Visible = true;
                        rbFianzaSuperior.Checked = true;
                        rbFianzaTotal.Visible = false;
                        rbFianzaTotal.Checked = false;
                        rbFianza20.Checked = false;
                        rbFianza20.Visible = false;
                    }
                }
            }
            else
            {
                lbTipoSolicitud.Visible = false;
                rbTransferencia.Visible = false;
                rbDevolucion.Visible = false;
                txtNumeroDocumento.Enabled = true;
                cbxUnidadEjecutora.Enabled = true;
                cbxTipoContrato.Enabled = true;
                cbxTipoFianza.Enabled = true;
                mtxtFechaMemorando.Enabled = true;
                txtItem.Enabled = true;
            }

            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)solicitudesDatos.idPersona).imagen1);
            }
            catch
            {

            }
            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            txtNumeroDocumento.Focus();
            btnBuscarOficina.Enabled = false;
        }

        //Verificamos si el Funcionario Tiene Fianzas en Curso 
        public bool verificarFianzaCurso()/*Para no poder editar si el funcionario ya tiene una fianza corriendo*/
        {
            try
            {
                idSolicitud = Convert.ToInt32((dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idSolicitud"].Value).ToString());
            }
            catch
            {
                idSolicitud = -1;/*No tiene solicitudes*/
            }

            if(idSolicitud==-1)
            {
                return false;
            }
            else
            {
                if (servicio.solicitudesGet(Util.header, idSolicitud).solicitud_Aceptada == true && servicio.solicitudesGet(Util.header, idSolicitud).idFianza_Nueva != null)/*si tiene solicitud aceptada y ya registrada una fianza tiene pendiente*/
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        //Revisamos que Este todo lleno sino damos Advertencia
        private bool validarCampos()
        {
            limpiarErrores();
            verificarNuevo();

            if (!numerodoc)
            {
                Util.errorMensaje(erpError, lblDocumento, "Debe Introducir el Número de Documento");
            }

            if (!tipodocumento)
            {
                Util.errorMensaje(erpError, lblTipoDoc, "Debe Introducir el Tipo de Documento");
            }

            if (!nombres)
            {
                Util.errorMensaje(erpError, lblNombre, "Debe Introducir Nombre");
            }

            if (!apellido)
            {
                Util.errorMensaje(erpError, lblPaterno, "Debe Introducir Por Lo Menos un Apellido");
                Util.errorMensaje(erpError, lblMaterno, "Debe Introducir Por Lo Menos un Apellido");
            }

            if (!unidadEjecutora)
            {
                Util.errorMensaje(erpError, lblUnidadEjecutora, "Debe Introducir la Unidad Ejecutora");

            }

            if (!oficina)
            {
                Util.errorMensaje(erpError, lblOficina, "Debe Introducir Una Oficina");

            }

            if (!cargo)
            {
                Util.errorMensaje(erpError, lblCargo, "Debe Introducir Un Cargo");

            }

            if (!numeroMemorando)
            {
                Util.errorMensaje(erpError, lblNumeroMemorando, "Debe Introducir el Número de Memorando");

            }

            if (!tipodeFianza)
            {
                Util.errorMensaje(erpError, lblTipoFianza, "Debe Introducir el Tipo de Fianza");

            }
            if (numerodoc == true && tipodocumento == true && nombres == true && apellido == true && unidadEjecutora == true && oficina == true && cargo == true && numeroMemorando == true && tipodeFianza == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Registrar un Funcionario por medio de RRHH
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bandera)
            {
                if (validarCampos())
                {
                        guardar();

                        MessageBox.Show("El Funcionario se ha registrado correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult ResultadoDialogo = MessageBox.Show("Desea Imprimir Solicitud Fianza.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ResultadoDialogo == DialogResult.Yes)
                        {
                            imprimir();
                        }
                        limpiarErrores();
                        reiniciarVerificacion();
                        listarSolicitudes();
                        if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
                        Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                        limpiarcampos();
                }
               
            }
            else
            {
                if (validarCampos())
                {
                    editar();
                    MessageBox.Show("El Funcionario se ha editado correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarErrores();
                    reiniciarVerificacion();
                    listarSolicitudes();
                    if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
                    Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                    limpiarcampos();
                }
            }

            txtBuscar.Focus();
        }

        //Verificamos si el Funcionario Tiene ya una Fianza
        private bool verificarSiFuncionarioFianza()
        {
            if(!solicitaTransDevo)//Aqui damos paso a la solicitud de transferencia o fianza nueva
            {
                //Verificar si existe Funcionario con Fianza y habilitamos para el registro de transferencia o devolucion
                try
                {
                    SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioValidarNuevo(Util.header, txtNumeroDocumento.Text.Trim());
                    SrMidasD.Fianza fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);
                    int idFianzaDevolucion;
                    try
                    {
                        SrMidasD.Devolucion devolucionDatos = servicio.devolucionGetidFianza(Util.header, fianzaDatos.idFianza);
                        idFianzaDevolucion = (int)devolucionDatos.idFianza;
                        c31 = devolucionDatos.c31;
                    }
                    catch
                    {
                        idFianzaDevolucion = 0;
                        c31 = "0";
                    }

                    if(fianzaDatos.idFianza >0)
                    {
                        if (idFianzaDevolucion == 0)/*Sino Tiene registrado una devolucion le decimos que tiene una fianza pendiente*/
                        {
                            string nombre = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).nombres;
                            string paterno = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).paterno;
                            string materno = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).materno;
                            string documento = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento;

                            DialogResult ResultadoDialogo = MessageBox.Show("El Funcionario ya está registrado.\rNombre: " + nombre + ".\rApellido Paterno: " + paterno + ".\rApelllido Materno: " + materno + ".\rDoc. Identidad: " + documento + "\nTeniendo una Fianza Pendiente.\n\n Quiere Ver la Fianza?", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ResultadoDialogo == DialogResult.Yes)
                            {
                                new FrmSeleccionarFianzaPorPersona(documento, usuario).ShowDialog();
                                insertarDatosFianzaDeboOTransf(FrmSeleccionarFianzaPorPersona.fianza);
                                lbTipoSolicitud.Visible = true;
                                rbDevolucion.Visible = true;
                                rbTransferencia.Visible = true;
                                solicitaTransDevo = true;
                                if(bandera)
                                {
                                    cargarCamposTransferencia();
                                }
                                cbxTipoFianza.Visible = false;
                            }
                            else
                            {
                                cancelar();
                            }

                            return true;
                        }
                        else
                        {
                            string nombre = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).nombres;
                            string paterno = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).paterno;
                            string materno = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).materno;
                            string documento = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento;


                            if (c31 == null)//Puede Existir Devolucion pero no una finalizada por eso verificamos su c31
                            {

                                DialogResult ResultadoDialogo = MessageBox.Show("El Funcionario ya está registrado.\rNombre: " + nombre + ".\rApellido Paterno: " + paterno + ".\rApelllido Materno: " + materno + ".\rDoc. Identidad: " + documento + "\nTeniendo una Fianza Pendiente.\n\n Quiere Ver la Fianza?", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (ResultadoDialogo == DialogResult.Yes)
                                {
                                    new FrmSeleccionarFianzaPorPersona(documento, usuario).ShowDialog();
                                    insertarDatosFianzaDeboOTransf(FrmSeleccionarFianzaPorPersona.fianza);

                                    lbTipoSolicitud.Visible = true;
                                    rbDevolucion.Visible = true;
                                    rbTransferencia.Visible = true;
                                    solicitaTransDevo = true;
                                    if (bandera)
                                    {
                                        cargarCamposTransferencia();
                                    }
                                    cbxTipoFianza.Visible = false;
                                }
                                else
                                {
                                    cancelar();
                                }

                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
           else
            {
                return false;
            }
        }

        private void insertarDatosFianzaDeboOTransf(SrMidasD.Fianza fianza)
        {
            try
            {
                idFianzaGlobalSeleccionada = fianza.idFianza;
            }
            catch { }
        }

        //Registramos a la Persona
        private void guardar()
        {
            limpiarErrores();

            //Verificamos si tenemos a la Persona Registrada en nuestra BD
            try
            {
                idPersona = servicio.personaGetPorNumeroDocumento(Util.header, txtNumeroDocumento.Text).idPersona;
            }
            catch
            { idPersona = 0;
            }

            //Sino esta registrado lo registramos
            if (idPersona == 0)
            {
                SrMidasD.Persona persona = new SrMidasD.Persona();
                persona.idTipoDocumento = 1;
                persona.numero_Documento = txtNumeroDocumento.Text.Trim();
                persona.paterno = txtPaterno.Text.Trim();
                persona.materno = txtMaterno.Text.Trim();
                persona.nombres = txtNombre.Text.Trim();
                persona.domicilio = personaArgos.domicilio;
                persona.estado_Civil = personaArgos.estadoCivil;
                switch (persona.estado_Civil)
                {
                    case "CASADO":
                        persona.sexo = "F";
                        break;
                    case "CASADA":
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
                persona.fechaRegistro = fechaActualServidor;

                idPersona = servicio.personaInsertar(Util.header, persona);

                //Insertar Imagen
                SrMidasD.Imagen imagen = new SrMidasD.Imagen();
                imagen.idPersona = imagen.idPersona;
                imagen.idPersona = idPersona;
                imagen.registroActivo = true;
                imagen.usuarioRegistro = usuario.nombre_Usuario;
                imagen.fechaRegistro = fechaActualServidor;
                imagen.imagen1 = Utils.Utils.imageToByteArray(pbImagen.Image);

                servicio.imagenInsertar(Util.header, imagen);
            }

            if (solicitaTransDevo)/*En el caso que tiene Fianza en Curso*/
            {
                try
                {
                    //Registro la Solicitud
                    SrMidasD.Solicitudes solicitud = new SrMidasD.Solicitudes();
                    if (rbDevolucion.Checked)
                    {
                        solicitud.tipo_Solicitud_Fianza = "Devolucion";
                        SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada).idFuncionario);
                        SrMidasD.Fianza fianzaDatos = servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada);
                        solicitud.idFianza_Nueva = fianzaDatos.idFianza;
                        solicitud.idTipoFianza = Convert.ToInt32(cbxTipoFianza.SelectedValue.ToString());
                    }
                    if (rbTransferencia.Checked)
                    {
                        solicitud.tipo_Solicitud_Fianza = "Transferencia";
                        SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada).idFuncionario);
                        SrMidasD.Fianza fianzaDatos = servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada);
                        solicitud.idFianza_Nueva = fianzaDatos.idFianza;

                        if (rbFianza20.Checked)
                        {
                            cbxTipoFianza.SelectedValue = 2;
                            solicitud.idTipoFianza = Convert.ToInt32(cbxTipoFianza.SelectedValue.ToString());
                        }
                        if (rbFianzaTotal.Checked)
                        {
                            cbxTipoFianza.SelectedValue = 3;
                            solicitud.idTipoFianza = Convert.ToInt32(cbxTipoFianza.SelectedValue.ToString());
                        }
                        if (rbFianzaSuperior.Checked)
                        {
                            solicitud.idTipoFianza = 0;
                        }
                    }

                    solicitud.numero_memorando = txtNumeroMemorando.Text.Trim();
                    solicitud.fecha_Memorando = Convert.ToDateTime(mtxtFechaMemorando.Text.ToString());
                    solicitud.numero_Fianza_Solicitud = Convert.ToInt32(txtNumeroSolicitud.Text);
                    solicitud.gestion =Convert.ToInt32(txtAñoSolicitud.Text);
                    solicitud.fecha_limite_presentacion = fechaActualServidor.AddDays(30);
                    solicitud.fecha_Aceptacion = servicio.fechaServidor();
                    solicitud.usuario_RRHH = usuario.nombre_Usuario;
                    solicitud.fecha_Registro_RRHH = fechaActualServidor;
                    solicitud.idPersona = idPersona;
                    solicitud.idCargo = Convert.ToInt32(cbxCargo.SelectedValue.ToString());
                    solicitud.idOficina = Convert.ToInt32(cbxOficina.SelectedValue.ToString());
                    solicitud.idEscalaSalarial = servicio.cargoGet(Util.header, (int)solicitud.idCargo).idEscalaSalarial;
                    solicitud.idSueldoMensual = servicio.escalaSalarialGet(Util.header, (int)solicitud.idEscalaSalarial).idSueldoMensual;
                    solicitud.tipo_Contrato_Item = txtItem.Text.ToString();
                    solicitud.vigencia_Contrato = cbxTipoContrato.SelectedItem.ToString();
                    solicitud.registroActivo = true;
                    solicitud.usuarioRegistro = usuario.nombre_Usuario;
                    solicitud.fechaRegistro = fechaActualServidor;

                    idSolicitud = servicio.solicitudesInsertar(Util.header, solicitud);
                }
                catch
                {
                    MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


            if (solicitaTransDevo==false)/*Sino tiene Fianza en Curso en Nueva Fianza*/
            {
                try
                {
                    //Registro la Solicitud
                    SrMidasD.Solicitudes solicitud = new SrMidasD.Solicitudes();
                    solicitud.tipo_Solicitud_Fianza = "Nueva Fianza";
                    solicitud.numero_memorando = txtNumeroMemorando.Text.Trim();
                    solicitud.fecha_Memorando = Convert.ToDateTime(mtxtFechaMemorando.Text.ToString());
                    solicitud.numero_Fianza_Solicitud = Convert.ToInt32(txtNumeroSolicitud.Text);
                    solicitud.gestion =Convert.ToInt32(txtAñoSolicitud.Text);
                    solicitud.fecha_limite_presentacion = fechaActualServidor.AddDays(30);
                    solicitud.fecha_Aceptacion = servicio.fechaServidor();
                    solicitud.usuario_RRHH = usuario.nombre_Usuario;
                    solicitud.fecha_Registro_RRHH = fechaActualServidor;
                    solicitud.idPersona = idPersona;
                    solicitud.idCargo = Convert.ToInt32(cbxCargo.SelectedValue.ToString());
                    solicitud.idOficina = Convert.ToInt32(cbxOficina.SelectedValue.ToString());
                    solicitud.idEscalaSalarial = servicio.cargoGet(Util.header, (int)solicitud.idCargo).idEscalaSalarial;
                    solicitud.idSueldoMensual = servicio.escalaSalarialGet(Util.header, (int)solicitud.idEscalaSalarial).idSueldoMensual;
                    solicitud.tipo_Contrato_Item = txtItem.Text.ToString();
                    solicitud.vigencia_Contrato = cbxTipoContrato.SelectedItem.ToString();
                    solicitud.idTipoFianza = Convert.ToInt32(cbxTipoFianza.SelectedValue.ToString());
                    solicitud.registroActivo = true;
                    solicitud.usuarioRegistro = usuario.nombre_Usuario;
                    solicitud.fechaRegistro = fechaActualServidor;

                    idSolicitud = servicio.solicitudesInsertar(Util.header, solicitud);
                }
                catch
                {
                    MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            

           
        }

        //Reiniciar Verificacion
        public void reiniciarVerificacion()
        {
            nombres = false;
            apellido = false;
            unidadEjecutora = false;
            oficina = false;
            cargo = false;
            numeroMemorando = false;
            tipodocumento = false;
            tipodeFianza = false;
            numerodoc = false; 
        }

        //Limpiar errores
        public void limpiarErrores()
        {
            erpError.Clear();
        }

        //Opcion Editar
        private void editar()
        {
            limpiarErrores();

            try
            {
                //Verificamos si tenemos a la Persona Registrada en nuestra BD
                try
                {
                    idPersona = servicio.personaGetPorNumeroDocumento(Util.header, txtNumeroDocumento.Text).idPersona;
                }
                catch
                {
                    idPersona = 0;
                }

                //Sino esta registrado lo registramos
                if (idPersona == 0)
                {
                    SrMidasD.Persona persona = new SrMidasD.Persona();
                    persona.idTipoDocumento = 1;
                    persona.numero_Documento = txtNumeroDocumento.Text.Trim();
                    persona.paterno = txtPaterno.Text.Trim();
                    persona.materno = txtMaterno.Text.Trim();
                    persona.nombres = txtNombre.Text.Trim();
                    persona.domicilio = personaArgos.domicilio;
                    persona.estado_Civil = personaArgos.estadoCivil;
                    switch (persona.estado_Civil)
                    {
                        case "CASADO":
                            persona.sexo = "F";
                            break;
                        case "CASADA":
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
                    persona.fechaRegistro = fechaActualServidor;

                    idPersona = servicio.personaInsertar(Util.header, persona);

                    //Insertar Imagen
                    SrMidasD.Imagen imagen = new SrMidasD.Imagen();
                    imagen.idPersona = imagen.idPersona;
                    imagen.idPersona = idPersona;
                    imagen.registroActivo = true;
                    imagen.usuarioRegistro = usuario.nombre_Usuario;
                    imagen.fechaRegistro = fechaActualServidor;
                    imagen.imagen1 = Utils.Utils.imageToByteArray(pbImagen.Image);

                    servicio.imagenInsertar(Util.header, imagen);
                }

                //Editar la Solicitud
                SrMidasD.Solicitudes solicitud = servicio.solicitudesGet(Util.header, idSolicitud);
                if (rbDevolucion.Checked)
                {
                    solicitud.tipo_Solicitud_Fianza = "Devolucion";
                    SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada).idFuncionario);
                    SrMidasD.Fianza fianzaDatos = servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada);
                    solicitud.idFianza_Nueva = fianzaDatos.idFianza;
                    solicitud.idTipoFianza = Convert.ToInt32(cbxTipoFianza.SelectedValue.ToString());
                }
                if (rbTransferencia.Checked)
                {
                    solicitud.tipo_Solicitud_Fianza = "Transferencia";
                    SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada).idFuncionario);
                    SrMidasD.Fianza fianzaDatos = servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada);
                    solicitud.idFianza_Nueva = fianzaDatos.idFianza;

                    if (rbFianza20.Checked)
                    {
                        cbxTipoFianza.SelectedValue = 2;
                        solicitud.idTipoFianza = Convert.ToInt32(cbxTipoFianza.SelectedValue.ToString());
                    }
                    if (rbFianzaTotal.Checked)
                    {
                        cbxTipoFianza.SelectedValue = 3;
                        solicitud.idTipoFianza = Convert.ToInt32(cbxTipoFianza.SelectedValue.ToString());
                    }
                    if (rbFianzaSuperior.Checked)
                    {
                        solicitud.idTipoFianza = 0;
                    }
                }
                if (solicitud.tipo_Solicitud_Fianza== "Nueva Fianza")
                {
                    solicitud.tipo_Solicitud_Fianza = "Nueva Fianza";
                }
                solicitud.numero_memorando = txtNumeroMemorando.Text.Trim();
                solicitud.fecha_Memorando = Convert.ToDateTime(mtxtFechaMemorando.Text.ToString());
                solicitud.numero_Fianza_Solicitud = Convert.ToInt32(txtNumeroSolicitud.Text);
                solicitud.gestion = fechaActualServidor.Year;
                solicitud.idPersona = solicitud.idPersona;
                solicitud.idCargo = Convert.ToInt32(cbxCargo.SelectedValue.ToString());
                solicitud.idOficina = Convert.ToInt32(cbxOficina.SelectedValue.ToString());
                solicitud.idEscalaSalarial = servicio.cargoGet(Util.header, (int)solicitud.idCargo).idEscalaSalarial;
                solicitud.idSueldoMensual = servicio.escalaSalarialGet(Util.header, (int)solicitud.idEscalaSalarial).idSueldoMensual;
                solicitud.tipo_Contrato_Item = txtItem.Text.ToString();
                solicitud.vigencia_Contrato = cbxTipoContrato.SelectedItem.ToString();
                solicitud.registroActivo = true;
                solicitud.usuarioRegistro = usuario.nombre_Usuario;
                solicitud.fechaRegistro = fechaActualServidor;

                idSolicitud = servicio.solicitudesEditar(Util.header, solicitud);
            }
             
            catch
            {
                  MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }

        //Opcion Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
            txtBuscar.Focus();
        }

        private void cancelar()
        {
            limpiarErrores();
            listarSolicitudes();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            limpiarcampos();
            bandera = true;
        }

        //Quitar Funcionario
        private void btnBaja_Click(object sender, EventArgs e)
        {
            limpiarErrores();

            DialogResult ResultadoDialogo = MessageBox.Show("La solicitud será dado de baja.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                idSolicitud = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idSolicitud"].Value);
                servicio.solicitudesEliminar(Util.header, idSolicitud);
                MessageBox.Show("La solicitud ha sido dado de baja.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarSolicitudes();
                limpiarcampos();
            }
        }

        //Buscar Imagen
        private void pbImagen_Click(object sender, EventArgs e)
        {
            pbImagen.Refresh();
            pbImagen.Show();
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        //Primeras Letras Mayusculas
        public void textleave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        }

        //Solo letras
        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyLetters(sender, e);

            string nombre = ((TextBox)sender).Name.ToString();
            if (nombre == "txtNombre")
            {
                erpError.Clear();
                nombres = true;
            }
            if (nombre == "txtPaterno" || nombre == "txtMaterno")
            {
                erpError.Clear();
                apellido = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && nombre == "txtNombre")
            {
                txtPaterno.Focus();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && nombre == "txtPaterno")
            {
                txtMaterno.Focus();
            }
                  
        }

        //Solo numeros y al mismo tiempo verificamos fianza pendiente
        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyNumbers(sender, e);
           
            string nombre = ((TextBox)sender).Name.ToString();
            if (nombre == "txtNumeroDocumento")
            {
                erpError.Clear();
                numerodoc = true;          
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter) && nombre == "txtNumeroDocumento")
            {
                txtNombre.Clear();
                txtPaterno.Clear();
                txtMaterno.Clear();
                txtNumeroMemorando.Clear();
                txtItem.Clear();

                cbxTipoDocumento.SelectedIndex = -1;
                cbxTipoDocumento.ResetText();

                cbxUnidadEjecutora.SelectedIndex = -1;
                cbxUnidadEjecutora.ResetText();

                cbxOficina.SelectedIndex = -1;
                cbxOficina.ResetText();

                cbxCargo.SelectedIndex = -1;
                cbxCargo.ResetText();

                cbxTipoFianza.SelectedIndex = -1;
                cbxTipoFianza.ResetText();

                cbxTipoContrato.SelectedIndex = -1;
                cbxTipoContrato.ResetText();

                mtxtFechaMemorando.Text = fechaActualDiauno.ToString("dd-MM-yyyy");

                pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;

                lbTipoSolicitud.Visible = false;
                rbTransferencia.Visible = false;
                rbTransferencia.Checked = false;
                rbDevolucion.Visible = false;
                rbDevolucion.Checked = false;
                solicitaTransDevo = false;

                try
                {
                    if (!verificarSiFuncionarioFianza())
                    {
                        buscarCi();
                    }
                    if(solicitaTransDevo)
                    {
                        buscarCi();
                    }
 
                }
                catch
                { }
            } 
        }

        //Funcion Buscar Ci Segip
        private void buscarCi()
        {
            SrMidasD.Persona personaBDL =servicio.personaGetPorNumeroDocumento(Util.header, txtNumeroDocumento.Text);

            if(personaBDL!=null)
            {
                idPersona = personaBDL.idPersona;
                this.txtNombre.Text = Utils.Utils.uppercaseFirstLetter(personaBDL.nombres);
                this.txtPaterno.Text = Utils.Utils.uppercaseFirstLetter(personaBDL.paterno);
                this.txtMaterno.Text = Utils.Utils.uppercaseFirstLetter(personaBDL.materno);
                this.pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header,personaBDL.idPersona).imagen1);
            }

            else
            {
                try
                {
                    personaArgos = this.servicioArgos.segipConsulta(this.txtNumeroDocumento.Text.Trim(), "7644473", this.txtNombre.Text.Trim(), this.txtPaterno.Text.Trim(), this.txtMaterno.Text.Trim(), "Harper");
                    this.erpError.Clear();
                    if (personaArgos.estado == 2)//Cuando Existe Cedula Real
                    {
                        this.txtNombre.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.nombres);
                        this.txtPaterno.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.paterno);
                        this.txtMaterno.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.materno);
                        this.pbImagen.Image = Utils.Utils.byteArrayToImage(personaArgos.fotografia);

                        this.btnGuardar.Enabled = true;
                    }
                    else if (personaArgos.estado == 1)//No Existe Cedula Real y se Procedera a su Creacion Manual
                    {
                        this.txtNombre.Text = string.Empty;
                        this.txtPaterno.Text = string.Empty;
                        this.txtMaterno.Text = string.Empty;
                        this.txtUsuario.Text = string.Empty;
                        this.pbImagen.Image = null;

                        MessageBox.Show("No se pudo encontrar el Carnet de Identidad verifique el numero de documento", "::: MidasD - Error :::", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        this.txtNombre.Text = string.Empty;
                        this.txtPaterno.Text = string.Empty;
                        this.txtMaterno.Text = string.Empty;
                        this.txtUsuario.Text = string.Empty;
                        this.pbImagen.Image = null;
                        MessageBox.Show("Se encontr\x00f3 m\x00e1s de un registro con la c\x00e9dula de identidad\rConsulte con la Unidad de Sistemas DAF!", "::: MidasD - Consulta :::", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtPaterno.Focus();
                        this.btnGuardar.Enabled = false;
                    }
                }
                catch
                {
                    MessageBox.Show("No se pudo establecer conexi\x00f3n con el servicio Segip Consulta", "::: MidasD - Error :::", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }    
            }

            cbxTipoDocumento.SelectedValue = 1;
        }


        //Cargar Inicio
        private void FrmPersona_Load(object sender, EventArgs e)
        {
            txtBuscar.Enabled = false;
            listarSolicitudes();
            txtBuscar.Enabled = true;
        }

      
        //Limpiamos todos los campos
        void limpiarcampos()
        {
            txtNombre.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            txtNumeroDocumento.Clear();
            txtNumeroMemorando.Clear();
            txtItem.Clear();

            cbxTipoDocumento.SelectedIndex = -1;
            cbxTipoDocumento.ResetText();

            cbxUnidadEjecutora.SelectedIndex = -1;
            cbxUnidadEjecutora.ResetText();

            cbxOficina.SelectedIndex = -1;
            cbxOficina.ResetText();

            cbxCargo.SelectedIndex = -1;
            cbxCargo.ResetText();

            cbxTipoFianza.SelectedIndex = -1;
            cbxTipoFianza.ResetText();

            cbxTipoContrato.SelectedIndex = -1;
            cbxTipoContrato.ResetText();

            mtxtFechaMemorando.Text= fechaActualDiauno.ToString("dd-MM-yyyy");
            txtNumeroSolicitud.Text = "XXXX";

            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;

            lbTipoSolicitud.Visible = false;
            rbTransferencia.Visible = false;
            rbTransferencia.Checked = false;
            rbDevolucion.Visible = false;
            rbDevolucion.Checked = false;
            solicitaTransDevo = false;

            txtOficinaLiteral.Clear();

            btnBuscarOficina.BackColor = Color.Transparent;

            rbFianzaTotal.Visible = false;
            rbFianzaTotal.Checked = false;
            rbFianzaSuperior.Visible = false;
            rbFianzaSuperior.Checked = false;
            rbFianza20.Visible = false;
            rbFianza20.Checked = false;
            cbxTipoFianza.Visible = true;
        }

       
        //Al seleccionar Oficina se Cargan los Cargos de la Oficina
        private void cbxOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxOficina.SelectedIndex.ToString()!="-1" && cbxOficina.SelectedIndex.ToString() != "0")
            {
                cargarCargo();  
            }
            else
            {
                cbxCargo.SelectedIndex = -1;
                cbxCargo.Enabled = false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            idSolicitud = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idSolicitud"].Value);

            if(servicio.solicitudesGet(Util.header,idSolicitud).tipo_Solicitud_Fianza== "Devolucion")
            {
                try
                {
                    new FrmCrSolicitudFianza(idSolicitud,-1, usuario.nombre_Usuario).ShowDialog();
                }
                catch
                {}
            }

            if (servicio.solicitudesGet(Util.header, idSolicitud).tipo_Solicitud_Fianza == "Transferencia")
            {
                try
                {
                    new FrmCrSolicitudFianza(idSolicitud,0, usuario.nombre_Usuario).ShowDialog();
                }
                catch
                {}
            }

            if (servicio.solicitudesGet(Util.header, idSolicitud).tipo_Solicitud_Fianza == "Nueva Fianza")
            {
                try
                {
                    new FrmCrSolicitudFianza(idSolicitud, (int)servicio.solicitudesGet(Util.header, idSolicitud).idTipoFianza, usuario.nombre_Usuario).ShowDialog();
                }
                catch
                {}
            }
        }

        private void txtGestion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cargarCargo();
            }
        }

        private void btnLeyenda_Click(object sender, EventArgs e)
        {
            new FrmLeyenda().ShowDialog();
        }

        private void rb30Dias_CheckedChanged(object sender, EventArgs e)
        {
   
                if (chkUsuarioRRHH.Checked == true)
                {
                    usuarioParaLista = usuario.nombre_Usuario;
                }
                else
                {
                    usuarioParaLista = " ";
                }
            listarDiasRestantes();
        }

        private void rb15Dias_CheckedChanged(object sender, EventArgs e)
        {

            if (chkUsuarioRRHH.Checked == true)
            {
                usuarioParaLista = usuario.nombre_Usuario;
            }
            else
            {
                usuarioParaLista = " ";
            }
            listarDiasRestantes();
        }

        private void chkUsuarioRRHH_CheckedChanged(object sender, EventArgs e)
        {

            if (chkUsuarioRRHH.Checked == true)
            {
                usuarioParaLista = usuario.nombre_Usuario;
            }
            else
            {
                usuarioParaLista = " ";
            }
           
            listarDiasRestantes();
        }

        private void rb0Dias_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsuarioRRHH.Checked == true)
            {
                usuarioParaLista = usuario.nombre_Usuario;
            }
            else
            {
                usuarioParaLista = " ";
            }
            listarDiasRestantes();
        }

        private void chkUsuarioListaFuncionarios_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsuarioListaFuncionarios.Checked == true)
            {
                usuarioParaRRHH = usuario.nombre_Usuario;
            }
            else
            {
                usuarioParaRRHH = " ";
            }
            listarSolicitudes();
        }

        public void bloqueoCamposDevolucion(bool estado)/*Bloqueamos todos los campos datos*/
        {
            txtNumeroDocumento.Enabled = estado;
            cbxTipoDocumento.Enabled = estado;
            cbxUnidadEjecutora.Enabled = estado;
            cbxOficina.Enabled = estado;
            cbxCargo.Enabled = estado;
            txtNumeroMemorando.Enabled = estado;
            cbxTipoFianza.Enabled = estado;
            cbxTipoContrato.Enabled = estado;
            txtItem.Enabled = estado;
            mtxtFechaMemorando.Enabled = estado;
        }

        private void rbDevolucion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDevolucion.Checked)
            {
                bloqueoCamposDevolucion(false);
                cbxTipoFianza.Visible = true;
                cargarCamposDevolucion();
            }
        }
        private void rbTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTransferencia.Checked)
            {
                cbxTipoFianza.Visible = false;
                bloqueoCamposDevolucion(true);
                if (bandera)
                {
                    cargarCamposTransferencia();
                }
            }
        }

        public void cargarCamposTransferencia() /*Habilitamos los campos para llenar*/
        {
            cbxUnidadEjecutora.SelectedIndex = -1;
            cbxOficina.SelectedIndex = -1;
            cbxCargo.SelectedIndex = -1;
            cbxTipoFianza.SelectedIndex = -1;
            cbxTipoContrato.SelectedIndex = -1;
            cbxOficina.Enabled = false;
            btnBuscarOficina.Enabled = false;
            cbxCargo.Enabled = false;

            if (fechaActualServidor.Month > 6)
            {
                txtGestion.Text = fechaActualServidor.Year.ToString();
            }
            else
            {
                txtGestion.Text = (fechaActualServidor.Year - 1).ToString();
            }

            fechaActualDiauno = new DateTime(fechaActualServidor.Year, fechaActualServidor.Month, 01);
            mtxtFechaMemorando.Text = fechaActualDiauno.ToString("dd-MM-yyyy");
            
            txtItem.Clear();
            txtNumeroMemorando.Clear();          
        }

        public void cargarCamposDevolucion()/*Cuando se Habilita la devolucion se bloquea todo y se carga los datos de fianza a devolver*/
        {
            if (idFianzaGlobalSeleccionada != 0)
            {
                SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada).idFuncionario);
                SrMidasD.Fianza fianzaDatos = servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada);
                SrMidasD.Cargo cargoDatos = servicio.cargoGet(Util.header, (int)funcionarioDatos.idCargo);

                txtNumeroDocumento.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento;
                cbxTipoDocumento.SelectedValue = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).idTipoDocumento;
                txtNombre.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).nombres;
                txtPaterno.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).paterno;
                txtMaterno.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).materno;
                cbxUnidadEjecutora.SelectedValue = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina).idUnidadEjecutora;
                cbxOficina.SelectedValue = funcionarioDatos.idOficina;
                txtOficinaLiteral.Text = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina).oficina1;
                cbxOficina.Enabled = false;
                btnBuscarOficina.Enabled = false;
                txtItem.Text = servicio.funcionarioGet(Util.header, funcionarioDatos.idFuncionario).tipo_Contrato_Item.ToString();
                cbxTipoContrato.SelectedItem = servicio.funcionarioGet(Util.header, funcionarioDatos.idFuncionario).vigencia_Contrato;
                mtxtFechaMemorando.Text = Convert.ToDateTime(funcionarioDatos.fecha_Memorando).ToString("dd-MM-yyyy");
                if (cargoDatos.fechaRegistro.Value.Month > 6)
                {
                    txtGestion.Text = cargoDatos.fechaRegistro.Value.Year.ToString();
                }
                else
                {
                    txtGestion.Text = (cargoDatos.fechaRegistro.Value.Year - 1).ToString();
                }
                cargarCargo();
                cbxCargo.SelectedValue = funcionarioDatos.idCargo;
                cbxCargo.Enabled = false;
                txtNumeroMemorando.Text = funcionarioDatos.numero_Memorando;
                cbxTipoFianza.SelectedValue = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario).idTipoFianza;
                try
                {
                    pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)funcionarioDatos.idPersona).imagen1);
                }
                catch
                {

                }

            }

            else
            {
                MessageBox.Show("Ha seleccionado anteriormente una fianza ya devuelta, Seleccione una fianza activa e intente Nuevamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cancelar();
            }
            }

        private void btnBuscarOficina_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmSeleccionarOficina(Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString())).ShowDialog();
                insertarOficinaCbx(FrmSeleccionarOficina.oficina);
            }
            catch { }
        }

        private void btnBuscarOficina_MouseHover(object sender, EventArgs e)
        {
            btnBuscarOficina.BackColor = Color.LimeGreen;
        }

        private void rbFianza20_CheckedChanged(object sender, EventArgs e)
        {
            if(rbFianza20.Checked)
            {
                rbFianzaTotal.Checked = false;
                rbFianzaSuperior.Checked = false;
            }
        }

        private void rbFianzaTotal_CheckedChanged(object sender, EventArgs e)
        {
            if(rbFianzaTotal.Checked)
            {
                rbFianza20.Checked = false;
                rbFianzaSuperior.Checked = false;
            }
            
        }

        private void rbFianzaSuperior_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFianzaSuperior.Checked)
            {
                rbFianza20.Checked = false;
                rbFianzaTotal.Checked = false;
            }
        }


        private void insertarOficinaCbx(SrMidasD.Oficina oficina)
        {
            try
            {
                cbxOficina.SelectedValue = oficina.idOficina;
                txtOficinaLiteral.Text = oficina.oficina1;
                erpError.Clear();
                cargarCargo();
                cbxCargo.Focus();
                cbxCargo.DroppedDown = true;
            }
            catch { }
        }

        private void chkUsuarioRHASE_CheckedChanged(object sender, EventArgs e)
        {

            if (chkUsuarioRHASE.Checked == true)
            {
                usuarioParaLista = usuario.nombre_Usuario;
            }
            else
            {
                usuarioParaLista = " ";
            }
            listarConResolucion();
        }

        private void dgvConResolucion_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           
                foreach (DataGridViewRow item in dgvConResolucion.Rows)
                {
                    int index = item.Index;
                Util.pintarDatagridwiewIndex(dgvConResolucion, index, "Black", "Sienna");
                }

            dgvConResolucion.ClearSelection();
        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarErrores();
            cargarCampos();
            verificarNuevo();

            bandera = false;
        }

        private void dgvDiasRestantes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (rb30Dias.Checked == true)
            {
                foreach (DataGridViewRow item in dgvDiasRestantes.Rows)
                {
                    int index = item.Index;
                    Util.pintarDatagridwiewIndex(dgvDiasRestantes, index, "Black", "LimeGreen");
                }
            }
            if (rb15Dias.Checked == true)
            {
                foreach (DataGridViewRow item in dgvDiasRestantes.Rows)
                {
                    int index = item.Index;

                    Util.pintarDatagridwiewIndex(dgvDiasRestantes, index, "Black", "Gold");
                }
            }
            if (rb0Dias.Checked == true)
            {
                foreach (DataGridViewRow item in dgvDiasRestantes.Rows)
                {
                    int index = item.Index;

                    Util.pintarDatagridwiewIndex(dgvDiasRestantes, index, "Black", "OrangeRed");
                }
            }

            dgvDiasRestantes.ClearSelection();

        }

        private void tbcFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string namepage = tbcFuncionarios.SelectedTab.Name;
           
            if (namepage == "tabPage2".ToString())
            {
                if (chkUsuarioRRHH.Checked == true)
                {
                    chkUsuarioRRHH.Text = usuario.nombre_Usuario;
                    usuarioParaLista = usuario.nombre_Usuario;
                }
                else
                {
                    usuarioParaLista = " ";
                }
                
                rb30Dias.Checked = true;
                listarDiasRestantes();
            }
            if (namepage == "tabPage3".ToString())
            {
                if (chkUsuarioRHASE.Checked == true)
                {
                    chkUsuarioRHASE.Text = usuario.nombre_Usuario;
                    usuarioParaLista = usuario.nombre_Usuario;
                }
                else
                {
                    usuarioParaLista = " ";
                }

                listarConResolucion();
            }
        }

        public void imprimir()
        {

            if (servicio.solicitudesGet(Util.header, idSolicitud).tipo_Solicitud_Fianza == "Devolucion")
            {
                try
                {
                    new FrmCrSolicitudFianza(idSolicitud, -1, usuario.nombre_Usuario).ShowDialog();
                }
                catch
                { }
            }

            if (servicio.solicitudesGet(Util.header, idSolicitud).tipo_Solicitud_Fianza == "Transferencia")
            {
                try
                {
                    new FrmCrSolicitudFianza(idSolicitud, 0, usuario.nombre_Usuario).ShowDialog();
                }
                catch
                { }
            }

            if (servicio.solicitudesGet(Util.header, idSolicitud).tipo_Solicitud_Fianza == "Nueva Fianza")
            {
                try
                {
                    new FrmCrSolicitudFianza(idSolicitud, (int)servicio.solicitudesGet(Util.header, idSolicitud).idTipoFianza, usuario.nombre_Usuario).ShowDialog();
                }
                catch
                { }
            }

        }

        //Al seleccionar la Unidad Ejecutora se Cargan las Oficinas
        private void cbxUnidadEjecutora_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarOficinas();
        }

        //Buscar Funcionarios
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            reiniciarVerificacion();
            listarSolicitudes();
        }

        //Al escribir se limpia los errores
        private void cbxCargo_Leave(object sender, EventArgs e)
        {
            erpError.Clear();
        }

        //Al escribir se limpia los errores
        private void cbxTipoDocumento_Leave(object sender, EventArgs e)
        {
            erpError.Clear();
        }

        //Al escribir se limpia los errores
        private void cbxOficina_Leave(object sender, EventArgs e)
        {
            erpError.Clear();
        }

        //Al escribir se limpia los errores y pasamos a tipo de fianza
        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.notPaste = true;

            string nombre = ((TextBox)sender).Name.ToString();
            
            if (nombre == "txtNumeroMemorando")
            {
                erpError.Clear();
                numeroMemorando = true;

                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    cbxTipoFianza.Focus();
                    cbxTipoFianza.DroppedDown = true;
                }
            }
        }

        //Dependiendo al combo box navegamos de manera facil
        private void combo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string nombre = ((ComboBox)sender).Name.ToString();

            if (nombre == "cbxUnidadEjecutora")
            {
                erpError.Clear();
                btnBuscarOficina.Enabled = true;
                btnBuscarOficina.Focus();
                btnBuscarOficina.BackColor = Color.LimeGreen;
                txtOficinaLiteral.Clear();
                ((ComboBox)sender).MouseLeave += new System.EventHandler(cbxOficina_Leave);
            }
            if (nombre == "cbxOficina")
            {
                erpError.Clear();
                cbxCargo.Focus();
                cbxCargo.DroppedDown = true;
                ((ComboBox)sender).MouseLeave += new System.EventHandler(cbxCargo_Leave);
            }

            if (nombre == "cbxCargo")
            {
                erpError.Clear();
                txtNumeroMemorando.Focus();
                txtNumeroMemorando.Enabled = true;

                if (rbTransferencia.Checked)
                {
                    SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada).idFuncionario);
                    SrMidasD.Fianza fianzaDatos = servicio.fianzaGet(Util.header, idFianzaGlobalSeleccionada);
                    List<SrMidasD.paFuncionarioFianzaActualBuscaridFianza_Result> lista = servicio.pafuncionarioFianzaActualBuscaridFianza(Util.header,(int)servicio.oficinaGet(Util.header,(int)funcionarioDatos.idOficina).idUnidadEjecutora, fianzaDatos.idFianza).ToList();
                    SrMidasD.paFuncionarioFianzaActualBuscaridFianza_Result pa = lista.FirstOrDefault();

                    int fianzaRequerida =(int) ((servicio.oficinaGet(Util.header, Convert.ToInt32(cbxOficina.SelectedValue.ToString())).cuantia) *(servicio.sueldoMensualGet(Util.header,(int)servicio.escalaSalarialGet(Util.header,(int)(servicio.cargoGet(Util.header, Convert.ToInt32(cbxCargo.SelectedValue.ToString())).idEscalaSalarial)).idSueldoMensual).monto));

                    if (pa.total_Descuento < fianzaRequerida)
                    {
                        rbFianza20.Visible = true;
                        rbFianzaTotal.Visible = true;
                        cbxTipoFianza.Visible = false;
                        rbFianzaSuperior.Visible = false;
                    }
                    if (pa.total_Descuento >= fianzaRequerida)
                    {
                        rbFianzaSuperior.Visible = true;
                        rbFianza20.Visible = false;
                        rbFianzaTotal.Visible = false;
                        cbxTipoFianza.Visible = false;
                    }

                }
            }

        }

        //Seleccion para evitar errores
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
        }

        //Limpiamos la memoria
        private void FrmFuncionario_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        //Insertamos numeracion
        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        //Opcion buscar presionando enter
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender,e);
            }
        } 
    }
}
