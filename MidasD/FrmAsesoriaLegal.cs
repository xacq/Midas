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
using System.Data.Entity.Validation;
using MidasD.SrMidasD;
using MidasD.Reportes;

namespace MidasD
{
    public partial class FrmAsesoriaLegal: Form
    {
        SrMidasD.Usuario usuario;
  
        public int idPersona;
        int dia1, dia2,idSolicitud;
        string usuarioParaLista;
        DateTime fechaActualServidor;
        FrmCargando frmCargando;

        SrMidasD.MidasDServiceClient servicio;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public bool resolucionAdministrativa = false;

        public FrmAsesoriaLegal(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();

            btnPnlLista = new List<Control>() { 
            btnBuscar,txtBuscar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() {  btnEditar,btnQuitarSeleccion,btnBaja,txtBajaObservado };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() { btnEditar,btnBuscar, btnImprimir3,btnImprimir2,btnImprimir1, 
            btnCancelar, btnGuardar, btnSalir ,btnQuitarSeleccion,btnBaja});

            fechaActualServidor = servicio.fechaServidor();
            txtBuscar.Focus();

        }

        private async Task listar()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvLista;
            paListarSolicitudesFianza_Result[] asyncVariable1 = await this.servicio.palistarSolicitudesFianzaBuscarAsync(Util.header, txtBuscar.Text, " ");
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idSolicitud", "usuario_Asesor_Acepta" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "numero_Fianza_Solicitud", "gestion", "tipo_Solicitud_Fianza", "fecha_limite_Presentacion", "numero_Documento", "nombre_Completo", "cargo", "haber_basico", "oficina", "numero_Memorando", "fecha_Memorando", "tipo_contrato_item", "vigencia_Contrato", "usuario_RRHH", "fecha_Registro_RRHH", "fecha_Aceptacion", "solicitud_Aceptada", "observacion" });
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);

            frmCargando.Close();
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

        private void listarNoAsync()
        {
            dgvLista.DataSource = servicio.palistarSolicitudesFianzaBuscar(Util.header, txtBuscar.Text, " ");

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idSolicitud", "usuario_Asesor_Acepta" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "numero_Fianza_Solicitud", "gestion", "tipo_Solicitud_Fianza", "fecha_limite_Presentacion", "numero_Documento", "nombre_Completo", "cargo", "haber_basico", "oficina", "numero_Memorando", "fecha_Memorando", "tipo_contrato_item", "vigencia_Contrato", "usuario_RRHH", "fecha_Registro_RRHH", "fecha_Aceptacion", "solicitud_Aceptada", "observacion" });
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);

        }

        private async Task listarDiasRestantes()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            if (ch30Dias.Checked == true)
            {
                dia1 = 16;
                dia2 = 30;
            }
            if (ch15Dias.Checked == true)
            {
                dia1 = 1;
                dia2 = 15;
            }
            if (ch0Dias.Checked == true)
            {
                dia1 = -99999999;
                dia2 = -1;
            }

            DataGridView asyncVariable0 = this.dgvDiasRestantes;
            paListarSolicitudesFianzaDiasRestantes_Result[] asyncVariable1 = await this.servicio.paListarSolicitudesFianzaDiasRestantesAsync(Util.header, txtBuscar.Text, dia1, dia2, usuarioParaLista);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvDiasRestantes, new List<string>() { "idSolicitud", "usuario_Asesor_Acepta" });
            Utils.Wfa.positionHeadersDGV(dgvDiasRestantes, new List<string>() { "numero_Fianza_Solicitud", "gestion", "tipo_Solicitud_Fianza", "fecha_limite_Presentacion", "numero_Documento", "nombre_Completo", "cargo", "haber_basico", "oficina", "numero_Memorando", "fecha_Memorando", "tipo_contrato_item", "vigencia_Contrato", "usuario_RRHH", "fecha_Registro_RRHH", "fecha_Aceptacion", "solicitud_Aceptada", "observacion" });
            Utils.Wfa.setHeadersDGV(dgvDiasRestantes);
            dgvDiasRestantes.AutoResizeColumns();
            dgvDiasRestantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);

            frmCargando.Close();
        }

        private async Task listarConResolucion()
        {

            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvConResolucion;
            paListarFuncionariosFianzaConResolucion_Result[] asyncVariable1 = await this.servicio.paListarFuncionariosFianzaConResolucionAsync(Util.header, txtBuscar.Text, usuarioParaLista);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvConResolucion, new List<string>() { "idFuncionario", "idFianza" });
            Utils.Wfa.positionHeadersDGV(dgvConResolucion, new List<string>() { "numero_Fianza_Solicitud", "gestion", "tipo_Fianza", "fecha_limite_Fianza", "numero_Documento", "nombre_Completo", "cargo", "haber_Mensual", "oficina", "numero_Memorando", "fecha_Memorando", "tipo_contrato_item", "vigencia_Contrato", "Nro_Fianza", "usuario_RRHH", "usuario_Asesor", "resolucion_Administrativa","fecha_Resolucion" });
            Utils.Wfa.setHeadersDGV(dgvConResolucion);
            dgvConResolucion.AutoResizeColumns();
            dgvConResolucion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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
                foreach (DataGridViewRow item in dgvLista.Rows)
                {
                    int index = item.Index;
                    try
                    {
                        if ((item.Cells["solicitud_Aceptada"].Value) is null)
                        {
                            DateTime fechalimitePresentacion = Convert.ToDateTime(item.Cells["fecha_limite_Presentacion"].Value);

                            TimeSpan fechaRestante = fechalimitePresentacion - fechaActualServidor;
                            int diasRestantes = fechaRestante.Days;

                            if (fechaRestante.Days > 0)
                            {
                                if (fechaRestante.Days >= 15)
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


            private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private async void btnEditar_Click(object sender, EventArgs e)
        {
            pbFlecha.Visible = true;
            limpiarErrores();
            await cargarCampos();
            verificarNuevo();
        }

        public void verificarNuevo()
        {
            if (string.IsNullOrEmpty(txtResolucionAdministrativa.Text))
            {
                resolucionAdministrativa = false;
            }
            else
            {
                resolucionAdministrativa = true;
            }
        }

        private async Task cargarCampos()
        {

            if (!verificarFianzaCurso())
            {
                string tipoSolicitud=servicio.solicitudesGet(Util.header,idSolicitud).tipo_Solicitud_Fianza;
                /*Si es Devolucion solo cargamos los campos de la fianza anterior*/
                if(tipoSolicitud=="Devolucion")
                {
                    pnlCargoAnterior.Visible = true;
                    pnlCargoActual.Visible = false;
                    lblResoAnterior.Visible = true;
                    txtResoAnterior.Visible = true;
                    pnlCargoAnterior.Location = new Point(233, 64);

                    cargarCamposPersona();
                    await cargarCamposDevolucion();

                    pintarDatosFianzaAnterior(Color.Black);
                    lblTituloCargoAnterior.ForeColor = Color.Red;

                    reiniciarCamposFianzaNueva();
                }

                /*Si es Transferencia cargamos los campos de la anterior Fianza y la Nueva solicitud de fianza*/

                if (tipoSolicitud == "Transferencia")
                {
                    pnlCargoAnterior.Visible = true;
                    pnlCargoActual.Visible = true;
                    lblResoAnterior.Visible = true;
                    txtResoAnterior.Visible = true;
                    pnlCargoAnterior.Location = new Point(5, 64);
                    pnlCargoActual.Location = new Point(468, 64);

                    cargarCamposPersona();
                    await cargarCamposDevolucionTransferencia();
                    cargarCamposNuevaFianza();

                    pintarDatosFianzaAnterior(Color.Black);
                    lblTituloCargoAnterior.ForeColor = Color.Red;

                    pintarDatosFianzaActual(Color.Black);
                    lblTituloCargoActual.ForeColor = Color.Green;

                    //cbxTipoFianza.ForeColor = Color.Black;
                    //cbxTipoFianza.Enabled = true;
                    //cbxTipoFianza.BackColor = Color.White;
                }

                /*Si es Nueva Fianza solo cargamos los campos de la nueva Fianza*/

                if(tipoSolicitud=="Nueva Fianza")
                {
                    pnlCargoAnterior.Visible = false;
                    pnlCargoActual.Visible = true;
                    lblResoAnterior.Visible = false;
                    txtResoAnterior.Visible = false;
                    pnlCargoActual.Location = new Point(233, 64);


                    pintarDatosFianzaActual(Color.Black);
                    lblTituloCargoActual.ForeColor = Color.Green;

                    cargarCamposPersona();
                    cargarCamposNuevaFianza();

                    //cbxTipoFianza.ForeColor = Color.Black;
                    //cbxTipoFianza.Enabled = true;
                    //cbxTipoFianza.BackColor = Color.White;
                    reiniciarCamposFianzaAnterior();
                }
            }
            else
            {
                MessageBox.Show("Ya no se puede Editar Porque el funcionario ya tiene una Solicitud de Fianza Aceptada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarErrores();
                if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
                Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                await cancelar();
            }


        }


        private async Task cargarCamposDevolucion()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            List<SrMidasD.paReporteSolDevolucion_Result> lista = servicio.paReporteSolDevolucion(Util.header, idSolicitud).ToList();
            SrMidasD.paReporteSolDevolucion_Result pa = lista.FirstOrDefault();

            int idFianzaAnterior = (int)servicio.solicitudesGet(Util.header, idSolicitud).idFianza_Nueva;
            lblNumeroMemorandoListAnterior.Text = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianzaAnterior).idFuncionario).numero_Memorando;
            int idEscalaSalarialAnterior = (int)servicio.solicitudesGet(Util.header, idSolicitud).idEscalaSalarial;
            int idHaberBasicoAnterior = (int)servicio.solicitudesGet(Util.header, idSolicitud).idSueldoMensual;
            cbxTipoFianzaAnterior.DataSource = servicio.tipoFianzaListar(Util.header);//Cargamos el tipo de Fianza
            cbxTipoFianzaAnterior.DisplayMember = "descripcion_Fianza";
            cbxTipoFianzaAnterior.ValueMember = "idTipoFianza";
            cbxTipoFianzaAnterior.SelectedValue = (int)servicio.solicitudesGet(Util.header, idSolicitud).idTipoFianza;
            lblOficinaListAnterior.Text = servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idOficina).oficina1;
            cbxCargoAnterior.DataSource = servicio.cargoListarOficina(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idOficina, (int)servicio.sueldoMensualGet(Util.header, idHaberBasicoAnterior).gestion);
            cbxCargoAnterior.ValueMember = "idCargo";
            cbxCargoAnterior.DisplayMember = "cargo";
            cbxCargoAnterior.SelectedValue = (int)servicio.solicitudesGet(Util.header, idSolicitud).idCargo;
            lblCargoListAnterior.Text = cbxCargoAnterior.Text;
            lblCertificadoFianzaList.Text = servicio.fianzaGet(Util.header, (int)servicio.solicitudesGet(Util.header, (int)idSolicitud).idFianza_Nueva).Nro_Fianza + " / " + pa.año_Impresa_RRHH;
            lblMontoFianzaList.Text = pa.total_descontado_en_planilla;
            lblTipoSolicitud.Text = "Solicitud de\n" + "'" + servicio.solicitudesGet(Util.header, idSolicitud).tipo_Solicitud_Fianza + "'";
            txtResoAnterior.Text = servicio.fianzaGet(Util.header, (int)servicio.solicitudesGet(Util.header, (int)idSolicitud).idFianza_Nueva).resolucion_Administrativa;
            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idPersona).imagen1);
            }
            catch
            {}

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            txtResolucionAdministrativa.Focus();
            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");

            frmCargando.Close();
        }


        private async Task cargarCamposDevolucionTransferencia()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            List<SrMidasD.paReporteSolDevolucion_Result> lista = servicio.paReporteSolDevolucion(Util.header, idSolicitud).ToList();
            SrMidasD.paReporteSolDevolucion_Result pa = lista.FirstOrDefault();

            int idFianzaAnterior = (int)servicio.solicitudesGet(Util.header, idSolicitud).idFianza_Nueva;
            int idFuncionarioActualizar = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianzaAnterior).idFuncionario).idFuncionario;
            lblNumeroMemorandoListAnterior.Text =servicio.funcionarioGet(Util.header, idFuncionarioActualizar).numero_Memorando;
            int idCargoAnterior = (int)servicio.funcionarioGet(Util.header, idFuncionarioActualizar).idCargo;
            int idEscalaSalarialAnterior = (int)servicio.escalaSalarialGet(Util.header,(int)servicio.cargoGet(Util.header,idCargoAnterior).idEscalaSalarial).idEscalaSalarial;
            int idHaberBasicoAnterior = (int)servicio.sueldoMensualGet(Util.header, (int)servicio.escalaSalarialGet(Util.header,idEscalaSalarialAnterior).idSueldoMensual).idSueldoMensual;
            cbxTipoFianzaAnterior.DataSource = servicio.tipoFianzaListar(Util.header);//Cargamos el tipo de Fianza
            cbxTipoFianzaAnterior.DisplayMember = "descripcion_Fianza";
            cbxTipoFianzaAnterior.ValueMember = "idTipoFianza";
            cbxTipoFianzaAnterior.SelectedValue = servicio.fianzaGet(Util.header,idFianzaAnterior).idTipoFianza;
            lblOficinaListAnterior.Text = servicio.oficinaGet(Util.header, (int)servicio.funcionarioGet(Util.header, idFuncionarioActualizar).idOficina).oficina1;
            cbxCargoAnterior.DataSource = servicio.cargoListarOficina(Util.header, (int)servicio.funcionarioGet(Util.header, idFuncionarioActualizar).idOficina, (int)servicio.sueldoMensualGet(Util.header, idHaberBasicoAnterior).gestion);
            cbxCargoAnterior.ValueMember = "idCargo";
            cbxCargoAnterior.DisplayMember = "cargo";
            cbxCargoAnterior.SelectedValue = idCargoAnterior;
            lblCargoListAnterior.Text = cbxCargoAnterior.Text;
            lblCertificadoFianzaList.Text = servicio.fianzaGet(Util.header, (int)servicio.solicitudesGet(Util.header, (int)idSolicitud).idFianza_Nueva).Nro_Fianza + " / " + pa.año_Impresa_RRHH;
            lblMontoFianzaList.Text = pa.total_descontado_en_planilla;
            lblTipoSolicitud.Text = "Solicitud de\n" + "'" + servicio.solicitudesGet(Util.header, idSolicitud).tipo_Solicitud_Fianza + "'";
            txtResoAnterior.Text = servicio.fianzaGet(Util.header, (int)servicio.solicitudesGet(Util.header, (int)idSolicitud).idFianza_Nueva).resolucion_Administrativa;
            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idPersona).imagen1);
            }
            catch {}

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            txtResolucionAdministrativa.Focus();
            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");

            frmCargando.Close();
        }


        public void cargarCamposPersona()
        {
            idPersona = (int)servicio.solicitudesGet(Util.header, idSolicitud).idPersona;
            lblNombresList.Text = servicio.personaGet(Util.header, idPersona).nombres;
            lblPaternoList.Text = servicio.personaGet(Util.header, idPersona).paterno;
            lblMaternoList.Text = servicio.personaGet(Util.header, idPersona).materno;
            lblNumeroDocumentoList.Text = servicio.personaGet(Util.header, idPersona).numero_Documento;
            lblTipoDocumentoList.Text = servicio.tipoDocumentoGet(Util.header, (int)servicio.personaGet(Util.header, (int)idPersona).idTipoDocumento).descripcion;
        }


        public void cargarCamposNuevaFianza()
        {
            lblOficinaList.Text = servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idOficina).oficina1;
            int idEscalaSalarial = (int)servicio.solicitudesGet(Util.header, idSolicitud).idEscalaSalarial;
            int idHaberBasico = (int)servicio.solicitudesGet(Util.header, idSolicitud).idSueldoMensual;
            cbxCargo.DataSource = servicio.cargoListarOficina(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idOficina, (int)servicio.sueldoMensualGet(Util.header, idHaberBasico).gestion);
            cbxCargo.ValueMember = "idCargo";
            cbxCargo.DisplayMember = "cargo";
            cbxCargo.SelectedValue = (int)servicio.solicitudesGet(Util.header, idSolicitud).idCargo;
            cbxTipoFianza.DataSource = servicio.tipoFianzaListar(Util.header);//Cargamos el tipo de Fianza
            cbxTipoFianza.DisplayMember = "descripcion_Fianza";
            cbxTipoFianza.ValueMember = "idTipoFianza";
            cbxTipoFianza.SelectedValue = (int)servicio.solicitudesGet(Util.header, idSolicitud).idTipoFianza;
            lblCargoList.Text = cbxCargo.Text;
            lblNumeroMemorandoList.Text = servicio.solicitudesGet(Util.header, idSolicitud).numero_memorando;
            lblTipoSolicitud.Text = "Solicitud de\n" + "'" + servicio.solicitudesGet(Util.header, idSolicitud).tipo_Solicitud_Fianza + "'";
            //txtResolucionAdministrativa.Text = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario).resolucion_Administrativa;
            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idPersona).imagen1);
            }
            catch
            {

            }

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            txtResolucionAdministrativa.Focus();
            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
        }


        public void pintarDatosFianzaAnterior(Color color)
        {
            lblNumeroMemorandoAnterior.ForeColor = color;
            lblTipoFianzaAnterior.ForeColor = color;
            lblOficinaAnterior.ForeColor = color;
            lblCargoAnterior.ForeColor = color;
            lblCertificadoFianza.ForeColor = color;
            lblMontoFianza.ForeColor = color;

            lblNumeroMemorandoListAnterior.ForeColor = color;
            lblTipoFianzaAnterior.ForeColor = color;
            lblOficinaListAnterior.ForeColor = color;
            lblCargoListAnterior.ForeColor = color;
            lblCertificadoFianzaList.ForeColor = color;
            lblMontoFianzaList.ForeColor = color;
            lblTituloCargoAnterior.ForeColor = color;
            lblResoAnterior.ForeColor = color;

        }

        public void pintarDatosFianzaActual(Color color)
        {
            lblNumeroMemorando.ForeColor = color;
            lblTituloCargoActual.ForeColor = color;
            lblNumeroMemorandoList.ForeColor = color;
            lblTipoFianza.ForeColor = color;
            lblOficina.ForeColor = color;
            lblCargo.ForeColor = color;
        }

        public void reiniciarCamposFianzaAnterior()
        {
            lblCertificadoFianzaList.Text = "XXXXXXXXXXX";
            lblMontoFianzaList.Text = "XXXXXXXXXXX";
            lblNumeroMemorandoListAnterior.Text = "XXXXXXXXXXX";
            cbxTipoFianzaAnterior.SelectedValue = -1;
            cbxCargoAnterior.SelectedValue = -1;
            lblOficinaListAnterior.Clear();
            lblCargoListAnterior.Clear();
            txtResoAnterior.Clear();
        }

        public void reiniciarCamposPersona()
        {
            lblNombresList.Text = "XXXXXXXXXXX";
            lblPaternoList.Text = "XXXXXXXXXXX";
            lblMaternoList.Text = "XXXXXXXXXXX";
            lblNumeroDocumentoList.Text = "XXXXXXXXXXX";
            lblTipoDocumentoList.Text = "XXXXXXXXXXX";
        }

        public void reiniciarCamposFianzaNueva()
        {
            lblNumeroMemorandoList.Text = "XXXXXXXXXXX";
            cbxTipoFianza.SelectedValue = -1;
            cbxCargo.SelectedValue = -1;

            lblOficinaList.Clear();
            lblCargoList.Clear();
        }

   
        private bool validarCampos()
        {
            limpiarErrores();
            verificarNuevo();

            if (!resolucionAdministrativa)
            {
                Util.errorMensaje(erpError,txtResolucionAdministrativa,"Debe Introducir la Resolucion Administrativa");
            }
           
            if (resolucionAdministrativa == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
                if (validarCampos())
                {
                    await editar();
                    Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                } 
        }
     
        public void reiniciarVerificacion()
        {
            resolucionAdministrativa = false;       
        }

        public void limpiarErrores()
        {
            erpError.Clear();
          
        }

        private async Task editar()
        {
            //frmCargando = new FrmCargando();
            //frmCargando.Show();
            //await Task.Delay(250);

            limpiarErrores();


            if (!verificarFianzaCurso())
            {
                try
                {
                    SrMidasD.Solicitudes solicitudesDatos= servicio.solicitudesGet(Util.header, idSolicitud);
                    /*Si es Devolucion solo cargamos los campos de la fianza anterior*/
                    if (solicitudesDatos.tipo_Solicitud_Fianza == "Devolucion")
                    {

                        SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioValidarNuevo(Util.header, lblNumeroDocumentoList.Text.Trim());
                        SrMidasD.Fianza fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);


                        //Registramos la Devolucion
                        SrMidasD.Devolucion devolucion = new SrMidasD.Devolucion();
                        devolucion.idFianza = fianzaDatos.idFianza;
                        devolucion.idFuncionario = fianzaDatos.idFuncionario;
                        devolucion.resolucion_Administrativa = txtResolucionAdministrativa.Text;
                        devolucion.monto_Devolucion =Convert.ToDouble(lblMontoFianzaList.Text);
                        //devolucion.mes = fechaActualServidor.Month;
                        //devolucion.anio = fechaActualServidor.Year;
                        devolucion.usuarioRegistro = usuario.nombre_Usuario;
                        devolucion.fechaRegistro = fechaActualServidor; ;
                        if (!string.IsNullOrEmpty(txtObservacion.Text))
                        {
                            devolucion.observacion = txtObservacion.Text;
                        }
                        devolucion.registroActivo = true;
                        int idDevolucion=servicio.devolucionInsertar(Util.header, devolucion);

                        //Editar la Solicitud
                        SrMidasD.Solicitudes solicitud = servicio.solicitudesGet(Util.header, idSolicitud);
                        solicitud.solicitud_Aceptada = true;
                        solicitud.fecha_Aceptacion = fechaActualServidor;
                        solicitud.usuario_Asesor_Acepta = usuario.nombre_Usuario;
                        solicitud.idDevolucion_Registro = idDevolucion;
                        if (!string.IsNullOrEmpty(txtObservacion.Text))
                        {
                            solicitud.observacion = txtObservacion.Text;
                        }
                        idSolicitud = servicio.solicitudesEditar(Util.header, solicitud);
                    }

                    /*Si es Transferencia cargamos los campos de la anterior Fianza y la Nueva solicitud de fianza*/

                    if (solicitudesDatos.tipo_Solicitud_Fianza == "Transferencia")
                    {
                        SrMidasD.Funcionario funcionarioDatosAnterior = servicio.funcionarioValidarNuevo(Util.header, lblNumeroDocumentoList.Text.Trim());
                        SrMidasD.Fianza fianzaDatosAnterior = servicio.fianzaIdFuncionario(Util.header, funcionarioDatosAnterior.idFuncionario);
                       
                        //Sacamos los Datos de la Fianza Anterior y la Guardamos en  Transferencia para Almacenar como Historico
                        SrMidasD.Transferencia transferencia = new SrMidasD.Transferencia();
                        transferencia.idFianza = solicitudesDatos.idFianza_Nueva;
                        transferencia.idFuncionario = fianzaDatosAnterior.idFuncionario;
                        transferencia.idCargoAnterior = funcionarioDatosAnterior.idCargo;
                        transferencia.numero_Memorando_Anterior =funcionarioDatosAnterior.numero_Memorando;
                        transferencia.fecha_Memorando_Anterior = funcionarioDatosAnterior.fecha_Memorando;
                        transferencia.tipo_Contrato_item_Anterior = funcionarioDatosAnterior.tipo_Contrato_Item.ToString();
                        transferencia.vigencia_Contrato_Anterior = funcionarioDatosAnterior.vigencia_Contrato.ToString();
                        transferencia.idTipoFianzaAnterior = fianzaDatosAnterior.idTipoFianza;
                        transferencia.idOficinaAnterior = (int)funcionarioDatosAnterior.idOficina;
                        int idEscalaSalarialAnterior = (int)servicio.cargoGet(Util.header,(int)funcionarioDatosAnterior.idCargo).idEscalaSalarial;
                        transferencia.idSueldoSueldoMensual = servicio.escalaSalarialGet(Util.header, idEscalaSalarialAnterior).idSueldoMensual;
                        transferencia.fecha_LimiteFianza_Anterior = fianzaDatosAnterior.fecha_Limite_Fianza.ToString();
                        transferencia.resolucion_Administrativa_Anterior = fianzaDatosAnterior.resolucion_Administrativa;
                        transferencia.usuario_RRHH_Anterior = fianzaDatosAnterior.usuario_RRHH;
                        transferencia.fecha_RRHH_Anterior = fianzaDatosAnterior.fecha_RRHH.ToString();
                        transferencia.usuario_Resolucion_Anterior = fianzaDatosAnterior.usuario_Resolucion;
                        transferencia.fecha_Resolucion_Anterior = fianzaDatosAnterior.fecha_Resolucion;
                        transferencia.usuario_Impresa_Anterior = fianzaDatosAnterior.usuario_Impresa_RRHH;
                        transferencia.fecha_Impresa_Anterior = fianzaDatosAnterior.fecha_Impresa_RRHH;
                        transferencia.observacion_Anterior = fianzaDatosAnterior.observacion; ;
                        transferencia.monto_Fianza_Transferir =Convert.ToDouble(lblMontoFianzaList.Text.ToString());
                        transferencia.resolucion_Administrativa_Transferencia = txtResolucionAdministrativa.Text;

                        transferencia.registroActivo = true;
                        transferencia.usuarioRegistro = usuario.nombre_Usuario;
                        transferencia.fechaRegistro = fechaActualServidor;


                        int idTransferencia = servicio.transferenciaInsertar(Util.header,transferencia);

                        //Actualizamos Datos del Funcionario al Nuevo Cargo
                        SrMidasD.Funcionario funcionarioDatosActual = servicio.funcionarioGet(Util.header, funcionarioDatosAnterior.idFuncionario);
                        funcionarioDatosActual.idFuncionario = funcionarioDatosAnterior.idFuncionario;
                        funcionarioDatosActual.idPersona = solicitudesDatos.idPersona;
                        funcionarioDatosActual.numero_Memorando = solicitudesDatos.numero_memorando;
                        funcionarioDatosActual.tipo_Contrato_Item =Convert.ToInt32(solicitudesDatos.tipo_Contrato_Item);
                        funcionarioDatosActual.vigencia_Contrato = solicitudesDatos.vigencia_Contrato;
                        funcionarioDatosActual.idCargo = solicitudesDatos.idCargo;
                        funcionarioDatosActual.idOficina = solicitudesDatos.idOficina;
                        funcionarioDatosActual.fecha_Memorando = solicitudesDatos.fecha_Memorando;
                        funcionarioDatosActual.usuarioRegistro = usuario.nombre_Usuario;
                        funcionarioDatosActual.fechaRegistro = fechaActualServidor;
                        funcionarioDatosActual.registroActivo = true;

                        servicio.funcionarioEditar(Util.header, funcionarioDatosActual);

                        //Actualizamos la Fianza al Cargo Actual
                        SrMidasD.Fianza fianzaDatosActual = servicio.fianzaGet(Util.header, fianzaDatosAnterior.idFianza);
                        fianzaDatosActual.idFianza = fianzaDatosAnterior.idFianza;
                        fianzaDatosActual.Nro_Fianza = fianzaDatosAnterior.Nro_Fianza;
                        fianzaDatosActual.idTipoFianza = solicitudesDatos.idTipoFianza;
                        fianzaDatosActual.idFuncionario = funcionarioDatosAnterior.idFuncionario;
                        fianzaDatosActual.registro_Sigma = fianzaDatosAnterior.registro_Sigma;
                        fianzaDatosActual.fecha_Limite_Fianza = solicitudesDatos.fecha_limite_presentacion;
                        fianzaDatosActual.resolucion_Administrativa = servicio.transferenciaGet(Util.header, idTransferencia).resolucion_Administrativa_Transferencia;
                        fianzaDatosActual.observacion = txtObservacion.Text;
                        /*Preguntamos si el monto de la Fianza requiere Descuento dentro de los 3 casos*/
                        double montoRequerido;
                        double montoFianza;
                        montoRequerido =(double) (servicio.oficinaGet(Util.header,(int)solicitudesDatos.idOficina).cuantia * servicio.sueldoMensualGet(Util.header,(int)solicitudesDatos.idSueldoMensual).monto);
                        montoFianza = Convert.ToDouble(lblMontoFianzaList.Text);

                        /*Como no se puede mandar fechas nulas colocamos una fecha a 1900*/
                        DateTime fechaNull;
                        fechaNull = new DateTime(1900,01, 01);


                        if (montoRequerido >= montoFianza)
                        {
                            fianzaDatosActual.fianza_Completa_Habilitado = false;
                            fianzaDatosActual.usuario_Completa_Habilitado = "";
                            fianzaDatosActual.fecha_Completa_Habilitado = fechaNull;
                            fianzaDatosActual.fianza_Validada_Contabilidad = false;
                            fianzaDatosActual.usuario_Validada_Contabilidad = "";
                            fianzaDatosActual.fecha_Validada_Contabilidad = fechaNull;
                            fianzaDatosActual.fianza_Devuelta_Contabilidad = false;
                            fianzaDatosActual.usuario_Devuelta_Contabilidad = "";
                            fianzaDatosActual.fecha_Devuelta_Contabilidad = fechaNull;
                            fianzaDatosActual.fianza_Impresa_RRHH = false;
                            fianzaDatosActual.usuario_Impresa_RRHH = "";
                            fianzaDatosActual.fecha_Impresa_RRHH = fechaNull;
                            fianzaDatosActual.observacion = "";
                            fianzaDatosActual.usuario_RRHH = solicitudesDatos.usuario_RRHH;
                            fianzaDatosActual.fecha_RRHH = solicitudesDatos.fecha_Registro_RRHH;
                            fianzaDatosActual.usuario_Resolucion = usuario.nombre_Usuario;
                            fianzaDatosActual.fecha_Resolucion = fechaActualServidor; 
                        }
                        if (montoRequerido < montoFianza)
                        {
                            fianzaDatosActual.fianza_Completa_Habilitado = true; /*Colocamos en estado true para que Habilitado no proceda al descuento*/
                            fianzaDatosActual.usuario_Completa_Habilitado = usuario.nombre_Usuario;
                            fianzaDatosActual.fecha_Completa_Habilitado = fechaActualServidor;
                            fianzaDatosActual.fianza_Validada_Contabilidad = false;
                            fianzaDatosActual.usuario_Validada_Contabilidad = "";
                            fianzaDatosActual.fecha_Validada_Contabilidad = fechaNull;
                            fianzaDatosActual.fianza_Devuelta_Contabilidad = false;
                            fianzaDatosActual.usuario_Devuelta_Contabilidad = "";
                            fianzaDatosActual.fecha_Devuelta_Contabilidad = fechaNull;
                            fianzaDatosActual.fianza_Impresa_RRHH = false;
                            fianzaDatosActual.usuario_Impresa_RRHH = "";
                            fianzaDatosActual.fecha_Impresa_RRHH = fechaNull;
                            fianzaDatosActual.observacion = "La fianza no requiere Descuento porque el monto requerido es menor al monto de la tranferencia de la fianza anterior";
                            fianzaDatosActual.usuario_RRHH = solicitudesDatos.usuario_RRHH;
                            fianzaDatosActual.fecha_RRHH = solicitudesDatos.fecha_Registro_RRHH;
                            fianzaDatosActual.usuario_Resolucion = usuario.nombre_Usuario;
                            fianzaDatosActual.fecha_Resolucion = fechaActualServidor;
                        }

                        fianzaDatosActual.registroActivo = true;
                        fianzaDatosActual.fechaRegistro = fechaActualServidor;
                        fianzaDatosActual.usuarioRegistro = usuario.nombre_Usuario;

                        servicio.fianzaEditar(Util.header, fianzaDatosActual);

                        //Editar la Solicitud
                        SrMidasD.Solicitudes solicitud = servicio.solicitudesGet(Util.header, idSolicitud);
                        solicitud.solicitud_Aceptada = true;
                        solicitud.fecha_Aceptacion = fechaActualServidor;
                        solicitud.usuario_Asesor_Acepta = usuario.nombre_Usuario;
                        solicitud.idTransferencia_Nueva = idTransferencia;
                        if (!string.IsNullOrEmpty(txtObservacion.Text))
                        {
                            solicitud.observacion = txtObservacion.Text;
                        }
                        idSolicitud = servicio.solicitudesEditar(Util.header, solicitud);
                    }

                    /*Si es Nueva Fianza solo cargamos los campos de la nueva Fianza*/

                    if (solicitudesDatos.tipo_Solicitud_Fianza == "Nueva Fianza")
                    {
                        //Registro del Funcionario
                        SrMidasD.Funcionario funcionario = new SrMidasD.Funcionario();
                        funcionario.idPersona = solicitudesDatos.idPersona;
                        funcionario.numero_Memorando = lblNumeroMemorandoList.Text.Trim();
                        funcionario.tipo_Contrato_Item = Convert.ToInt32(solicitudesDatos.tipo_Contrato_Item);
                        funcionario.vigencia_Contrato = solicitudesDatos.vigencia_Contrato;
                        funcionario.idCargo = Convert.ToInt32(solicitudesDatos.idCargo);
                        funcionario.idOficina = Convert.ToInt32(solicitudesDatos.idOficina);
                        funcionario.codigo_Distrito = "06";
                        funcionario.fecha_Memorando = solicitudesDatos.fecha_Memorando;
                        funcionario.registroActivo = true;
                        funcionario.usuarioRegistro = usuario.nombre_Usuario;
                        funcionario.fechaRegistro = fechaActualServidor;

                        int idFuncionario = servicio.funcionarioInsertar(Util.header, funcionario);

                        //Registro de la Fianza
                        SrMidasD.Fianza fianza = new SrMidasD.Fianza();
                        fianza.idFuncionario = idFuncionario;

                        //fianza.Nro_Fianza = servicio.ultimoNumeroFianza(Util.header) + 1;
                        fianza.Nro_Fianza = 0;


                        fianza.idTipoFianza = Convert.ToInt32(cbxTipoFianza.SelectedValue.ToString());
                        fianza.registro_Sigma = lblNumeroDocumentoList.Text.ToString();
                        fianza.fecha_Limite_Fianza = solicitudesDatos.fecha_limite_presentacion;
                        fianza.registroActivo = true;
                        if(Convert.ToInt32(cbxTipoFianza.SelectedValue.ToString())==3)
                        {
                            fianza.fianza_Completa_Habilitado = false;
                            fianza.fecha_Completa_Habilitado = fechaActualServidor;
                            fianza.usuario_Completa_Habilitado = usuario.nombre_Usuario;
                            fianza.fianza_Validada_Contabilidad = false;
                            fianza.fecha_Validada_Contabilidad = fechaActualServidor;
                            fianza.usuario_Validada_Contabilidad = usuario.nombre_Usuario;
                        }
                        else
                        {
                            fianza.fianza_Completa_Habilitado = false;
                            fianza.fianza_Validada_Contabilidad = false;
                        }
                        fianza.fianza_Devuelta_Contabilidad = false;
                        fianza.fianza_Impresa_RRHH = false;
                        fianza.usuarioRegistro = usuario.nombre_Usuario;
                        fianza.fechaRegistro = fechaActualServidor;
                        fianza.usuario_RRHH = solicitudesDatos.usuario_RRHH;
                        fianza.fecha_RRHH = solicitudesDatos.fecha_Registro_RRHH;
                        fianza.usuario_Resolucion = usuario.nombre_Usuario;
                        fianza.fecha_Resolucion = fechaActualServidor;
                        fianza.resolucion_Administrativa = txtResolucionAdministrativa.Text.Trim();
                        fianza.observacion = txtObservacion.Text;
                        fianza.registroActivo = true;
                        fianza.fechaRegistro = fechaActualServidor;
                        fianza.usuarioRegistro = usuario.nombre_Usuario;

                        int idFianza = servicio.fianzaInsertar(Util.header, fianza);

                        //Editar la Solicitud
                        SrMidasD.Solicitudes solicitud = servicio.solicitudesGet(Util.header, idSolicitud);
                        solicitud.solicitud_Aceptada = true;
                        solicitud.fecha_Aceptacion = fechaActualServidor;
                        solicitud.usuario_Asesor_Acepta = usuario.nombre_Usuario;
                        solicitud.observacion = txtObservacion.Text;
                        solicitud.idFianza_Nueva = idFianza;
                        idSolicitud = servicio.solicitudesEditar(Util.header, solicitud);
                    }

                    await cancelar();
                    MessageBox.Show("Se ha registrado la Resolucion Correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ya no se puede Editar Porque el funcionario ya tiene una Solicitud de Fianza Aceptada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarErrores();
             
                if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
                Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                await cancelar();
            }

            //frmCargando.Close();
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

            if (idSolicitud == -1)
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

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        private async Task cancelar()
        {
            txtResolucionAdministrativa.Clear();
            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;
            pbFlecha.Visible = false;
            txtBuscar.Clear();
            lblTipoSolicitud.ResetText();

            limpiarErrores();
            await listar();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            pbFlecha.Visible = false;

            reiniciarCamposFianzaAnterior();
            reiniciarCamposFianzaNueva();
            reiniciarCamposPersona();

            pnlCargoAnterior.Visible = true;
            pnlCargoActual.Visible = true;
            pnlCargoAnterior.Location = new Point(5, 64);
            pnlCargoActual.Location = new Point(468, 64);
        }

        private void cancelarNoAsync()
        {
            txtResolucionAdministrativa.Clear();
            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;
            pbFlecha.Visible = false;
            txtBuscar.Clear();
            lblTipoSolicitud.ResetText();

            limpiarErrores();
            listarNoAsync();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            pbFlecha.Visible = false;

            reiniciarCamposFianzaAnterior();
            reiniciarCamposFianzaNueva();
            reiniciarCamposPersona();

            pnlCargoAnterior.Visible = true;
            pnlCargoActual.Visible = true;
            pnlCargoAnterior.Location = new Point(5, 64);
            pnlCargoActual.Location = new Point(468, 64);
        }

        private  void btnBaja_Click(object sender, EventArgs e)
        {

        }

        public void textleave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        }


        private async void FrmPersona_Load(object sender, EventArgs e)
        {
            txtBuscar.Enabled = false;
            await listar();
            txtBuscar.Enabled = true;
        }



        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            reiniciarVerificacion();

            await listar();
        }


        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.notPaste = true;

            string nombre = ((TextBox)sender).Name.ToString();
            
            if (nombre == "txtResolucionAdministrativa")
            {
                erpError.Clear();
                resolucionAdministrativa = true;
            }
 
        }

        private void btnLeyenda_Click(object sender, EventArgs e)
        {
            new FrmLeyenda().ShowDialog();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            pbFlecha.Visible = true;
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

       
        private async void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        private async void ch0Dias_Click(object sender, EventArgs e)
        {
            string nombre = ((CheckBox)sender).Name.ToString();
            if (nombre== "ch0Dias")
            {
                ch0Dias.Checked = true;
                ch15Dias.Checked = false;
                ch30Dias.Checked = false;
            }
            if (nombre == "ch15Dias")
            {
                ch0Dias.Checked = false;
                ch15Dias.Checked = true;
                ch30Dias.Checked = false;
            }
            if (nombre == "ch30Dias")
            {
                ch15Dias.Checked = false;
                ch0Dias.Checked = false;
                ch30Dias.Checked = true;
            }
            usuarioParaLista = " ";
            await listarDiasRestantes();
        }

        private async void btnBaja_Click_1(object sender, EventArgs e)
        {
            limpiarErrores();
            bool solicitudAceptada = false;

            try
            {
                idSolicitud = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idSolicitud"].Value);
                solicitudAceptada = (bool)servicio.solicitudesGet(Util.header, idSolicitud).solicitud_Aceptada;
            }
            catch { }

            if(solicitudAceptada)
            {
                MessageBox.Show("La solicitud ha sido aceptada no puede dar de baja ni rechazar la misma.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                DialogResult ResultadoDialogo = MessageBox.Show("La solicitud será dado de baja por Observacion.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ResultadoDialogo == DialogResult.Yes)
                {
                    idSolicitud = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idSolicitud"].Value);
                    Solicitudes solicitud = servicio.solicitudesGet(Util.header, idSolicitud);
                    solicitud.observacion = "Observado: Nro-Sol:" + solicitud.numero_Fianza_Solicitud + " /" + txtBajaObservado.Text.TrimEnd();
                    servicio.solicitudesEditar(Util.header, solicitud);
                    servicio.solicitudesEliminar(Util.header, idSolicitud);
                    MessageBox.Show("La solicitud ha sido dado de baja.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await listar();
                }

            }
           
        }

        private async Task listarRechazados()
        {
            DataGridView asyncVariable0 = this.dgvConRechazo;
            paListarSolicitudesFianzaDiasRestantes_Result[] asyncVariable1 = await this.servicio.paListarSolicitudesFianzaDiasRestantesAsync(Util.header, txtBuscar.Text, 100, 1, " ");
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvConRechazo, new List<string>() { "idSolicitud", "usuario_Asesor_Acepta" });
            Utils.Wfa.positionHeadersDGV(dgvConRechazo, new List<string>() { "numero_Fianza_Solicitud", "gestion", "tipo_Solicitud_Fianza", "fecha_limite_Presentacion", "numero_Documento", "nombre_Completo", "cargo", "haber_basico", "oficina", "numero_Memorando", "fecha_Memorando", "tipo_contrato_item", "vigencia_Contrato", "usuario_RRHH", "fecha_Registro_RRHH", "fecha_Aceptacion", "solicitud_Aceptada", "observacion" });
            Utils.Wfa.setHeadersDGV(dgvConRechazo);
            dgvConRechazo.AutoResizeColumns();
            dgvConRechazo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);

            frmCargando.Close();
        }

        private async void btnImprimir3_Click(object sender, EventArgs e)
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            try
            {
                frmCargando.Close();
                new FrmCrEstadoSolicitudes(100, 1, usuarioParaLista).ShowDialog();
            }
            catch
            { }
        }

        private async void btnImprimir2_Click(object sender, EventArgs e)
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            if (ch30Dias.Checked == true)
            {
                dia1 = 16;
                dia2 = 30;
            }
            if (ch15Dias.Checked == true)
            {
                dia1 = 1;
                dia2 = 15;
            }
            if (ch0Dias.Checked == true)
            {
                dia1 = -99999999;
                dia2 = -1;
            }


            try
            {
                frmCargando.Close();
                new FrmCrEstadoSolicitudes(dia1, dia2, usuarioParaLista).ShowDialog();
            }
            catch
            { }
        }

        private async void btnImprimir1_Click(object sender, EventArgs e)
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            try
            {
                frmCargando.Close();
                new FrmCrEstadoSolicitudes(0, 0, usuarioParaLista).ShowDialog();
            }
            catch
            { }
        }

        private async void dgvLista_DoubleClick(object sender, EventArgs e)
        {
            pbFlecha.Visible = true;
            limpiarErrores();
            await cargarCampos();
            verificarNuevo();
        }

        private async void chkUsuarioRHASE_CheckedChanged(object sender, EventArgs e)
        {

            if (chkUsuarioRHASE.Checked == true)
            {
                usuarioParaLista = usuario.nombre_Usuario;
            }
            else
            {
                usuarioParaLista = " ";
            }
            await listarConResolucion();
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

        private void dgvDiasRestantes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (ch30Dias.Checked == true)
            {
                foreach (DataGridViewRow item in dgvDiasRestantes.Rows)
                {
                    int index = item.Index;
                    Util.pintarDatagridwiewIndex(dgvDiasRestantes, index, "Black", "LimeGreen");
                }
            }
            if (ch15Dias.Checked == true)
            {
                foreach (DataGridViewRow item in dgvDiasRestantes.Rows)
                {
                    int index = item.Index;

                    Util.pintarDatagridwiewIndex(dgvDiasRestantes, index, "Black", "Gold");
                }
            }
            if (ch0Dias.Checked == true)
            {
                foreach (DataGridViewRow item in dgvDiasRestantes.Rows)
                {
                    int index = item.Index;

                    Util.pintarDatagridwiewIndex(dgvDiasRestantes, index, "Black", "OrangeRed");
                }
            }

            dgvDiasRestantes.ClearSelection();

        }

        private async void tbcFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string namepage = tbcFuncionarios.SelectedTab.Name;
           
            if (namepage == "tabPage3".ToString())
            {
                usuarioParaLista = " ";
                ch30Dias.Checked = true;
                txtBuscar.Clear();
                await listarDiasRestantes();

            }
            if (namepage == "tabPage2".ToString())
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
                txtBuscar.Clear();
                await listarConResolucion();
            }

            if (namepage == "tabPage4".ToString())
            {
                txtBuscar.Clear();
                await listarRechazados();
            }
        }
    }
}
