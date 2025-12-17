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

namespace MidasD
{
    public partial class FrmAsesoriaLegalCorreccionDatos: Form
    {
        SrMidasD.Usuario usuario;
  
        public int idFuncionario,idPersona;
        SrMidasD.MidasDServiceClient servicio;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;
        DateTime fechaActualServidor;
        FrmCargando frmCargando;
        public bool resolucionAdministrativa = false;

        public FrmAsesoriaLegalCorreccionDatos(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();

            btnPnlLista = new List<Control>() { 
            btnBuscar,txtBuscar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() {  btnEditar, btnQuitarSeleccion };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() { btnEditar,btnBuscar, 
            btnCancelar, btnGuardar, btnSalir ,btnQuitarSeleccion});

            fechaActualServidor= servicio.fechaServidor();
        }

        private async Task listarConResolucion()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvLista;
            paListarFuncionariosFianzaConResolucion_Result[] asyncVariable1 = await this.servicio.paListarFuncionariosFianzaConResolucionAsync(Util.header, txtBuscar.Text, "");
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFuncionario", "idFianza" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "numero_Fianza_Solicitud", "gestion", "tipo_Fianza", "fecha_limite_Fianza", "numero_Documento", "nombre_Completo", "cargo", "haber_Mensual", "oficina", "numero_Memorando", "fecha_Memorando", "tipo_contrato_item", "vigencia_Contrato", "Nro_Fianza", "usuario_RRHH", "usuario_Asesor", "resolucion_Administrativa", "fecha_Resolucion" });
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


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            await editarCampos();
        }

        public async Task editarCampos()
        {
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
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            bool validadoHabilitado, validadoContabilidad, fianzaImpresa;

            idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFuncionario"].Value);
            SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, idFuncionario);
            SrMidasD.Fianza fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);
            lblNombresList.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).nombres;
            lblPaternoList.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).paterno;
            lblMaternoList.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).materno;
            lblNumeroDocumentoList.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento;
            lblTipoDocumentoList.Text = servicio.tipoDocumentoGet(Util.header, (int)servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).idTipoDocumento).descripcion;
            lblOficinaList.Text = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina).oficina1;//Cargamos los Cargos
            int idEscalaSalarial = (int)servicio.cargoGet(Util.header, (int)funcionarioDatos.idCargo).idEscalaSalarial;
            int idHaberBasico = (int)servicio.escalaSalarialGet(Util.header, idEscalaSalarial).idSueldoMensual;
            cbxCargo.DataSource = servicio.cargoListarOficina(Util.header, (int)funcionarioDatos.idOficina, (int)servicio.sueldoMensualGet(Util.header, idHaberBasico).gestion);
            cbxCargo.ValueMember = "idCargo";
            cbxCargo.DisplayMember = "cargo";
            cbxCargo.SelectedValue = funcionarioDatos.idCargo;
            cbxTipoFianza.DataSource = servicio.tipoFianzaListar(Util.header);//Cargamos el tipo de Fianza
            cbxTipoFianza.DisplayMember = "descripcion_Fianza";
            cbxTipoFianza.ValueMember = "idTipoFianza";
            cbxTipoFianza.SelectedValue = servicio.fianzaIdFuncionario(Util.header, (int)funcionarioDatos.idFuncionario).idTipoFianza;
            lblCargoList.Text = cbxCargo.Text;
            lblNumeroMemorandoList.Text = funcionarioDatos.numero_Memorando;
            txtResolucionAdministrativa.Text = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario).resolucion_Administrativa;
            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)funcionarioDatos.idPersona).imagen1);
            }
            catch
            {

            }


            try
            {
                validadoHabilitado = (bool)fianzaDatos.fianza_Completa_Habilitado;
            }
            catch
            {
                validadoHabilitado = false;
            }
            try
            {
                validadoContabilidad = (bool)fianzaDatos.fianza_Validada_Contabilidad;
            }
            catch
            {
                validadoContabilidad = false;
            }
            try
            {
                fianzaImpresa = (bool)fianzaDatos.fianza_Impresa_RRHH;
            }
            catch
            {
                fianzaImpresa = false;
            }


            //if (validadoHabilitado == true && validadoContabilidad == true)
            //{
            //    Util.pnlListaActivar(true, btnPnlLista);
            //    Util.pnlListaActivar(true, btnPnlLista3);
            //    Util.pnlListaActivar(false, btnPnlDatos);
            //    Util.pnlListaActivar(true, btnPnlLista2);
            //    MessageBox.Show(" La Fianza se encuentra Validada por\r***Habilitado y Contabilidad***\rYa no se puede Modificar", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            //}
            //else
            //{
                Util.pnlListaActivar(false, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlLista3);
                Util.pnlListaActivar(true, btnPnlDatos);
                Util.pnlListaActivar(false, btnPnlLista2);
                txtResolucionAdministrativa.Focus();
                Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");

            //}
            frmCargando.Close();

        }

        private bool validarCampos()
        {
            limpiarErrores();
            verificarNuevo();

            if (!resolucionAdministrativa)
            {
                Util.errorMensaje(erpError,lblNombre,"Debe Introducir la Resolucion Administrativa");
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
          
                if (!validarCampos())
                { }
                else
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
            limpiarErrores();

                try
                {
                    
                    SrMidasD.Fianza fianza = servicio.fianzaIdFuncionario(Util.header, idFuncionario);
                    fianza.resolucion_Administrativa = txtResolucionAdministrativa.Text;
                    fianza.registroActivo = true;
                    fianza.usuario_Resolucion = usuario.nombre_Usuario;
                    fianza.fecha_Resolucion =fechaActualServidor;
                    servicio.fianzaEditar(Util.header, fianza);
                    await listarConResolucion();

                    limpiarcampos();
                    MessageBox.Show("Se ha registrado la Resolucion Correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
          
        }


       

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        public async Task cancelar()
        {
            limpiarErrores();
            await listarConResolucion();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            limpiarcampos();
        }

        public void textleave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        }


        private async void FrmPersona_Load(object sender, EventArgs e)
        {
            txtBuscar.Enabled = false;
            await listarConResolucion();
            txtBuscar.Enabled = true;
        }

        void limpiarcampos()
        {
            txtResolucionAdministrativa.Clear();
            cbxTipoFianza.SelectedValue=-1;
            lblNumeroDocumentoList.ResetText();
            lblTipoDocumentoList.ResetText();
            lblNombresList.ResetText();
            lblPaternoList.ResetText();
            lblMaternoList.ResetText();
            lblOficinaList.ResetText();
            lblCargoList.ResetText();
            lblNumeroMemorandoList.ResetText();
            cbxTipoFianza.SelectedValue=-1;
            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1; 
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            reiniciarVerificacion();

            await listarConResolucion();
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

        private async void dgvLista_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           await editarCampos();
        }

        private async void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            await cancelar();
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

        //private void dgvFuncionarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow item in dgvLista.Rows)
        //        {
        //            int index = item.Index;
        //            try
        //            {
        //                if ((item.Cells["solicitud_Aceptada"].Value) is null)
        //                {
        //                    DateTime fechalimitePresentacion = Convert.ToDateTime(item.Cells["fecha_limite_Presentacion"].Value);

        //                    TimeSpan fechaRestante = fechalimitePresentacion - fechaActualServidor;
        //                    int diasRestantes = fechaRestante.Days;

        //                    if (fechaRestante.Days > 0)
        //                    {
        //                        if (fechaRestante.Days > 15)
        //                        {

        //                            Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "LimeGreen");
        //                        }
        //                        else
        //                        {
        //                            Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Gold");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "OrangeRed");
        //                    }


        //                }
        //                else
        //                {
        //                    Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Sienna");
        //                }

        //            }
        //            catch
        //            {
        //                Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Sienna");
        //            }


        //            dgvLista.ClearSelection();

        //        }
        //    }
        //    catch { }
        //}
    }
}
