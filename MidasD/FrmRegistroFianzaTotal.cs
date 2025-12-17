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
    public partial class FrmRegistroFianzaTotal : Form
    {
        SrMidasD.Usuario usuario;
        DateTime fechaActualServidor;
         public int idFuncionario,idPersona,idFianza;
        SrMidasD.MidasDServiceClient servicio;
        FrmCargando frmCargando;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public bool resolucionAdministrativa = false;

        public FrmRegistroFianzaTotal(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();

            btnPnlLista = new List<Control>() { 
            btnBuscar,txtBuscar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() { btnEditar,btnQuitarSeleccion };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() { btnEditar,btnBuscar, 
            btnCancelar, btnGuardar, btnSalir,btnQuitarSeleccion });

            fechaActualServidor = servicio.fechaServidor();
        }

        private async Task listarFianzasParaValidacion()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());


            DataGridView asyncVariable0 = this.dgvLista;
            paFuncionarioFianzaActualBuscarTipoFianzaTotalEstadoValidado_Result[] asyncVariable1 = await this.servicio.pafianzaListarFuncionariosBuscarTipoFianzaTotalEstadoValidadoAsync(Util.header, txtBuscar.Text, 3, 0);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFuncionario","idFianza","ubicacion","tipo_Bien","folio","concepto","a_Favor","cpbte","tipo", "mes", "anio", "c21" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "Nro_Fianza","cargo","nombre_Completo", "registro_Sigma", "monto_Beneficiario"  });
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

        private async Task listarFianzasValidadas()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvListaFianzasValidadas;
            paFuncionarioFianzaActualBuscarTipoFianzaTotalEstadoValidado_Result[] asyncVariable1 = await this.servicio.pafianzaListarFuncionariosBuscarTipoFianzaTotalEstadoValidadoAsync(Util.header, txtBuscar.Text, 3, 1);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvListaFianzasValidadas, new List<string>() { "idFuncionario", "idFianza", "ubicacion", "tipo_Bien", "folio", "concepto", "a_Favor", "cpbte", "tipo" });
            Utils.Wfa.positionHeadersDGV(dgvListaFianzasValidadas, new List<string>() { "Nro_Fianza", "cargo", "nombre_Completo", "registro_Sigma", "monto_Beneficiario","mes","anio","c21" });
            Utils.Wfa.setHeadersDGV(dgvListaFianzasValidadas);
            dgvListaFianzasValidadas.AutoResizeColumns();
            dgvListaFianzasValidadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            frmCargando.Close();

        }

        //private void dgvFuncionarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow item in dgvLista.Rows)
        //        {

        //            DateTime fechalimitefianza = Convert.ToDateTime(item.Cells["fecha_limite_fianza"].Value);
        //            DateTime diaActual = DateTime.Now;
        //            TimeSpan fechaRestante = fechalimitefianza - diaActual;
        //            int diasRestantes = fechaRestante.Days;

        //            int index = item.Index;

        //            if (diasRestantes<30)
        //            {
        //                Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Green");
        //            }
        //            if (diasRestantes < 15)
        //            {
        //                Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Yellow");
        //            }
        //            if (diasRestantes < 0)
        //            {
        //                Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Red");
        //            }

        //            dgvLista.ClearSelection();

        //        }
        //    }
        //    catch { }

        //}

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
            if (string.IsNullOrEmpty(txtMonto.Text))
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
            lblResolucion.Text = servicio.fianzaGet(Util.header, idFianza).resolucion_Administrativa.ToString();


            int cuantia = (int)servicio.oficinaGet(Util.header, (int)servicio.funcionarioGet(Util.header, idFuncionario).idOficina).cuantia;
            int idCargo = (int)servicio.funcionarioGet(Util.header, idFuncionario).idCargo;
            int idEscalaSalarial = (int)servicio.cargoGet(Util.header, idCargo).idEscalaSalarial;
            int idSueldoMensual = (int)servicio.escalaSalarialGet(Util.header, idEscalaSalarial).idSueldoMensual;
            txtMonto.Text = String.Format("{0:n}", (cuantia * servicio.sueldoMensualGet(Util.header, idSueldoMensual).monto)); ;

            lblOficinaList.Text = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina).oficina1;//Cargamos los Cargos
            idEscalaSalarial = (int)servicio.cargoGet(Util.header, (int)funcionarioDatos.idCargo).idEscalaSalarial;
            int idHaberBasico = (int)servicio.escalaSalarialGet(Util.header, idEscalaSalarial).idSueldoMensual;
            cbxCargo.DataSource = servicio.cargoListarOficina(Util.header, (int)funcionarioDatos.idOficina, (int)servicio.sueldoMensualGet(Util.header, idHaberBasico).gestion);
            cbxCargo.ValueMember = "idCargo";
            cbxCargo.DisplayMember = "cargo";
            cbxCargo.SelectedValue = funcionarioDatos.idCargo;


            lblCargoList.Text = cbxCargo.Text;
            lblNumeroMemorandoList.Text = funcionarioDatos.numero_Memorando;
            //txtTipoFianzaReal.Text = servicio.fianzaVerificarPendiente(Util.header, funcionarioDatos.idFuncionario).resolucionAdministrativa;
            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)funcionarioDatos.idPersona).imagen1);
            }
            catch { }
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            txtMonto.Focus();
            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");

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
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            try
                {
                    //Se edita la Fianza
                    SrMidasD.Fianza fianza = servicio.fianzaIdFuncionario(Util.header, idFuncionario);
                    fianza.idFianza = fianza.idFianza;
                    fianza.idFuncionario = fianza.idFuncionario;
                    fianza.fianza_Completa_Habilitado = true;
                    fianza.usuario_Completa_Habilitado = usuario.nombre_Usuario;
                    fianza.fecha_Completa_Habilitado = fechaActualServidor;
                    fianza.fianza_Validada_Contabilidad = true;
                    fianza.usuario_Validada_Contabilidad = usuario.nombre_Usuario;
                    fianza.fecha_Validada_Contabilidad = fechaActualServidor;
                    servicio.fianzaEditar(Util.header, fianza);

                    //Se crea el descuento una sola vez
                    SrMidasD.Descuento descuento;
                    descuento = new SrMidasD.Descuento();
                    descuento.idFianza = idFianza;
                    descuento.monto_Beneficiario = Convert.ToDouble(txtMonto.Text.ToString());
                    descuento.usuarioRegistro = usuario.nombre_Usuario;
                    descuento.mes = fechaActualServidor.Month;
                    descuento.anio =fechaActualServidor.Year;
                    descuento.c21 =Convert.ToInt32(txtc21.Text);
                    descuento.observacion = "Deposito en Dinero en Efectivo";
                    descuento.registroActivo = true;
                    descuento.fechaRegistro = fechaActualServidor;
                    int idDescuento = servicio.descuentoInsertar(Util.header, descuento);

                    limpiarcampos();
                    MessageBox.Show("Se ha registrado la Resolucion Correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            frmCargando.Close();

            await listarFianzasParaValidacion();
        }


      

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

       private async Task cancelar()
        {
            limpiarErrores();

            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            limpiarcampos();

            string namepage = tabControl1.SelectedTab.Name;

            if (namepage == "tabPage1".ToString())
            {

                await listarFianzasParaValidacion();
            }
            if (namepage == "tabPage2".ToString())
            {

                await listarFianzasValidadas();
            }
        }

        public void textleave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        }


        private async void FrmPersona_Load(object sender, EventArgs e)
        {
            txtBuscar.Enabled = false;
            await listarFianzasParaValidacion();
            txtBuscar.Enabled = true;
        }

        void limpiarcampos()
        {
            txtMonto.Clear();
           
            lblNumeroDocumentoList.ResetText();
            lblTipoDocumentoList.ResetText();
            lblNombresList.ResetText();
            lblPaternoList.ResetText();
            lblMaternoList.ResetText();
            lblOficinaList.ResetText();
            lblCargoList.ResetText();
            lblNumeroMemorandoList.ResetText();
            lblResolucion.ResetText();
          
            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1; 
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            reiniciarVerificacion();
            string namepage = tabControl1.SelectedTab.Name;

            if (namepage == "tabPage1".ToString())
            {

                await listarFianzasParaValidacion();
            }
            if (namepage == "tabPage2".ToString())
            {

                await listarFianzasValidadas();
            }
        }

        private void txtc21_KeyPress(object sender, KeyPressEventArgs e)
        {
         
                Utils.Wfa.onlyNumbers(sender, e);
      
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string namepage = tabControl1.SelectedTab.Name;

            if (namepage == "tabPage1".ToString())
            {
               
                await listarFianzasParaValidacion();
            }
            if (namepage == "tabPage2".ToString())
            {

                 await listarFianzasValidadas();
            }
        }

        private async void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarErrores();
            await cargarCampos();
            verificarNuevo();
        }

        private async void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            await cancelar();        }

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
    }
}
