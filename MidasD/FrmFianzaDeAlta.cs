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
    public partial class FrmFianzaDeAlta : Form
    {
        SrMidasD.Usuario usuario;
        FrmCargando frmCargando;
        public int idFuncionario,idPersona,idFianza;
        SrMidasD.MidasDServiceClient servicio;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public bool resolucionAdministrativa = false;

        public FrmFianzaDeAlta(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();

            btnPnlLista = new List<Control>() { 
            btnBuscar,txtBuscar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() {  btnEditar };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() { btnEditar,btnBuscar, 
            btnCancelar, btnGuardar, btnSalir });

            cargarUnidadEjecutora();
        }

        //Listar las Unidades Encargadas
        private void cargarUnidadEjecutora()
        {
            cbxUnidadEjecutora.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutora.DisplayMember = "descripcion";
            cbxUnidadEjecutora.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutora.SelectedIndex = 0;
        }

        private async Task listar()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvLista;
            paFuncionarioFianzaActualBuscarBaja_Result[] asyncVariable1 = await this.servicio.pafuncionarioFianzaActualBuscarBajaAsync(Util.header, txtBuscar.Text.Trim().ToLower(), Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()), 2);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() {"idFianza","item","vigencia_Contrato","fecha_Memorando","a_Descontar"});
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() {"Nro_Fianza", "ci","cargo","nombre_Completo", "haber_Mensual", "total_Descuento","total_Descontar","falta_Descontar"});
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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

                    //DateTime fechalimitefianza = Convert.ToDateTime(item.Cells["fecha_limite_fianza"].Value);
                    //DateTime diaActual = DateTime.Now;
                    //TimeSpan fechaRestante = fechalimitefianza - diaActual;
                    //int diasRestantes = fechaRestante.Days;
                    
                    //int index = item.Index;

                    //if (diasRestantes<30)
                    //{
                    //    Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Green");
                    //}
                    //if (diasRestantes < 15)
                    //{
                    //    Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Yellow");
                    //}
                    //if (diasRestantes < 0)
                    //{
                    //    Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Red");
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
            if (string.IsNullOrEmpty(txtObservacion.Text))
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

            idFianza = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value);
            idFuncionario = (int)servicio.fianzaGet(Util.header, idFianza).idFuncionario;
            SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, idFuncionario);
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
            txtObservacion.Text = servicio.fianzaGet(Util.header, idFianza).observacion;

            lblCargoList.Text = cbxCargo.Text;
            lblNumeroMemorandoList.Text = funcionarioDatos.numero_Memorando;
            lblResolucion.Text = servicio.fianzaGet(Util.header, idFianza).resolucion_Administrativa;
            pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)funcionarioDatos.idPersona).imagen1);
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            txtObservacion.Focus();
            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");

            frmCargando.Close();
        }
        private bool validarCampos()
        {
            limpiarErrores();
            verificarNuevo();

            if (!resolucionAdministrativa)
            {
                Util.errorMensaje(erpError,txtObservacion,"Debe Introducir el Motivo de la Alta ");
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
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            limpiarErrores();

            DialogResult ResultadoDialogo = MessageBox.Show("La Fianza del Funcionario será dado de Alta.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                try
                {
                    //Se edita la Fianza
                    SrMidasD.Fianza fianza = servicio.fianzaIdFuncionario(Util.header, idFuncionario);
                    fianza.idFianza = fianza.idFianza;
                    fianza.idFuncionario = fianza.idFuncionario;
                    fianza.fianza_Completa_Habilitado = false;
                    fianza.fecha_Completa_Habilitado = null;
                    fianza.usuario_Completa_Habilitado = null;
                    fianza.observacion = txtObservacion.Text.TrimEnd() + "\"Usuario: " + usuario.nombre_Usuario;
                    fianza.registroActivo = true;
                    int idFianza = servicio.fianzaEditar(Util.header, fianza);

                    await listar();

                    limpiarcampos();
                    MessageBox.Show("Se ha dado de Alta Correctamente Correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            frmCargando.Close();
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            await listar();
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
            await listar();
        }

        void limpiarcampos()
        {
            txtObservacion.Clear();
           
            lblNumeroDocumentoList.ResetText();
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

            await listar();
        }

        private async void cbxUnidadEjecutora_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await listar();
        }

        private async void dgvLista_DoubleClick(object sender, EventArgs e)
        {
            limpiarErrores();
            await cargarCampos();
            verificarNuevo();
        }



        private async void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarErrores();
            await cargarCampos();
            verificarNuevo();
        }

        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.notPaste = true;

            string nombre = ((TextBox)sender).Name.ToString();
            
            if (nombre == "txtObservacion")
            {
                erpError.Clear();
                resolucionAdministrativa = true;
            }
 
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
    }
}
