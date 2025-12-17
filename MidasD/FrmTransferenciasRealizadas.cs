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

namespace MidasD
{
    public partial class FrmTransferenciasRealizadas : Form
    {
        SrMidasD.Usuario usuario;
  
        public int idPersona;
        int idFianza,idTransferencia;
        DateTime fechaActualServidor;
        FrmCargando frmCargando;

        SrMidasD.MidasDServiceClient servicio;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista3, btnPnlLista2;

        public bool resolucionAdministrativa = false;

        public FrmTransferenciasRealizadas(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();


            btnPnlLista = new List<Control>() {  btnBuscar,txtBuscar };
            btnPnlLista2 = new List<Control>() { btnEditar, btnQuitarSeleccion };
            btnPnlLista3 = new List<Control>() {  pnlLista };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar, pnlDatos };

            Util.btn_Mouse(new List<PictureBox>() {btnBuscar, btnSalir,btnQuitarSeleccion,btnEditar,btnGuardar,btnCancelar });

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
            paListarFuncionariosFianzaTranferencias_Result[] asyncVariable1 = await this.servicio.paListarFuncionariosFianzaTranferenciasAsync(Util.header, txtBuscar.Text, " ");
            asyncVariable0.DataSource = asyncVariable1;
       
            asyncVariable0 = null;
            asyncVariable1 = null;
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFianza", "idFuncionario","idTransferencia" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "Nro_Fianza", "numero_Documento", "nombre_Completo", "Fianza_Anterior", "Fianza_Actual", "resolucion_Administrativa_Transferencia", "usuario_Contabilidad_Transferencia", "fecha_Contabilidad_Transferencia", "mes_Transferencia", "anio_Tranferencia", "observacion_Transferencia"});
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
            dgvLista.DataSource = servicio.paListarFuncionariosFianzaTranferencias(Util.header, txtBuscar.Text, " ");

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFianza", "idFuncionario" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "Nro_Fianza", "numero_Documento", "nombre_Completo", "Fianza_Anterior", "Fianza_Actual", "resolucion_Administrativa_Transferencia", "usuario_Contabilidad_Transferencia", "fecha_Contabilidad_Transferencia", "mes_Transferencia", "anio_Tranferencia", "observacion_Transferencia" });
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);
        }

        


            private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

            pnlCargoAnterior.Visible = true;
            pnlCargoActual.Visible = true;
            lblResoAnterior.Visible = true;
            txtResoAnterior.Visible = true;
            pnlCargoAnterior.Location = new Point(5, 64);
            pnlCargoActual.Location = new Point(468, 64);

            cargarCamposPersona();
            cargarCamposDevolucionTransferencia();
            cargarCamposNuevaFianza();

            pintarDatosFianzaAnterior(Color.Black);
            lblTituloCargoAnterior.ForeColor = Color.Red;

            pintarDatosFianzaActual(Color.Black);
            lblTituloCargoActual.ForeColor = Color.Green;

            //cbxTipoFianza.ForeColor = Color.Black;
            //cbxTipoFianza.Enabled = true;
            //cbxTipoFianza.BackColor = Color.White;
          

            frmCargando.Close();

        }


        private void cargarCamposDevolucionTransferencia()
        {

            idTransferencia = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idTransferencia"].Value);
            SrMidasD.Transferencia transferencia = servicio.transferenciaGet(Util.header, idTransferencia);

            lblNumeroMemorandoListAnterior.Text = transferencia.numero_Memorando_Anterior;
            SrMidasD.Cargo cargo = servicio.cargoGet(Util.header, (int)transferencia.idCargoAnterior);
            SrMidasD.EscalaSalarial escalaSalarial = servicio.escalaSalarialGet(Util.header, (int)cargo.idEscalaSalarial);
            SrMidasD.SueldoMensual haberBasico = servicio.sueldoMensualGet(Util.header, (int)escalaSalarial.idSueldoMensual);
            cbxTipoFianzaAnterior.DataSource = servicio.tipoFianzaListar(Util.header);//Cargamos el tipo de Fianza
            cbxTipoFianzaAnterior.DisplayMember = "descripcion_Fianza";
            cbxTipoFianzaAnterior.ValueMember = "idTipoFianza";
            cbxTipoFianzaAnterior.SelectedValue = (int)transferencia.idTipoFianzaAnterior;
            lblOficinaListAnterior.Text = servicio.oficinaGet(Util.header, (int)transferencia.idOficinaAnterior).oficina1;
            cbxCargoAnterior.DataSource = servicio.cargoListarOficina(Util.header, (int)transferencia.idOficinaAnterior, (int)haberBasico.gestion);
            cbxCargoAnterior.ValueMember = "idCargo";
            cbxCargoAnterior.DisplayMember = "cargo";
            cbxCargoAnterior.SelectedValue = (int)cargo.idCargo;
            lblCargoListAnterior.Text = cbxCargoAnterior.Text;

            lblMontoFianzaList.Text = Convert.ToString(transferencia.monto_Fianza_Transferir);
            txtObservacion.Text = transferencia.observacion_Transferencia;
            txtResoAnterior.Text = transferencia.resolucion_Administrativa_Anterior;
            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)servicio.funcionarioGet(Util.header, (int)transferencia.idFuncionario).idPersona).imagen1);
            }
            catch
            { }

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);

            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
        }


        public void cargarCamposPersona()
        {
            idFianza = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value);
            idPersona = (int)servicio.funcionarioGet(Util.header,(int)servicio.fianzaGet(Util.header, idFianza).idFuncionario).idPersona;
            lblNombresList.Text = servicio.personaGet(Util.header, idPersona).nombres;
            lblPaternoList.Text = servicio.personaGet(Util.header, idPersona).paterno;
            lblMaternoList.Text = servicio.personaGet(Util.header, idPersona).materno;
            lblNumeroDocumentoList.Text = servicio.personaGet(Util.header, idPersona).numero_Documento;
            lblTipoDocumentoList.Text = servicio.tipoDocumentoGet(Util.header, (int)servicio.personaGet(Util.header, (int)idPersona).idTipoDocumento).descripcion;
        }


        public void cargarCamposNuevaFianza()
        {
            lblOficinaList.Text = servicio.oficinaGet(Util.header, (int)servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianza).idFuncionario).idOficina).oficina1;
            SrMidasD.Cargo cargo = servicio.cargoGet(Util.header, (int)servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianza).idFuncionario).idCargo);
            SrMidasD.EscalaSalarial escalaSalarial = servicio.escalaSalarialGet(Util.header, (int)cargo.idEscalaSalarial);
            SrMidasD.SueldoMensual haberBasico = servicio.sueldoMensualGet(Util.header, (int)escalaSalarial.idSueldoMensual);

            cbxCargo.DataSource = servicio.cargoListarOficina(Util.header, (int)servicio.oficinaGet(Util.header, (int)servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianza).idFuncionario).idOficina).idOficina, (int)haberBasico.gestion);
            cbxCargo.ValueMember = "idCargo";
            cbxCargo.DisplayMember = "cargo";
            cbxCargo.SelectedValue = (int)cargo.idCargo;
            cbxTipoFianza.DataSource = servicio.tipoFianzaListar(Util.header);//Cargamos el tipo de Fianza
            cbxTipoFianza.DisplayMember = "descripcion_Fianza";
            cbxTipoFianza.ValueMember = "idTipoFianza";
            cbxTipoFianza.SelectedValue = (int)servicio.fianzaGet(Util.header,idFianza).idTipoFianza; 
            lblCargoList.Text = cbxCargo.Text;
            lblNumeroMemorandoList.Text = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianza).idFuncionario).numero_Memorando;
           
            txtResolucionAdministrativa.Text = servicio.fianzaGet(Util.header, idFianza).resolucion_Administrativa ;
            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianza).idFuncionario).idPersona).imagen1);
            }
            catch
            {

            }

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);

            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");

        }


        public void pintarDatosFianzaAnterior(Color color)
        {
            lblNumeroMemorandoAnterior.ForeColor = color;
            lblTipoFianzaAnterior.ForeColor = color;
            lblOficinaAnterior.ForeColor = color;
            lblCargoAnterior.ForeColor = color;
    
            lblMontoFianza.ForeColor = color;

            lblNumeroMemorandoListAnterior.ForeColor = color;
            lblTipoFianzaAnterior.ForeColor = color;
            lblOficinaListAnterior.ForeColor = color;
            lblCargoListAnterior.ForeColor = color;

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


            if (!verificarSiYaValidado())
            {
                try
                {
                        SrMidasD.Transferencia transferencia = servicio.transferenciaGet(Util.header, Convert.ToInt32((dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idTransferencia"].Value).ToString()));

                        transferencia.usuario_Contabilidad_Transferencia = usuario.nombre_Usuario;
                        transferencia.fecha_Contabilidad_Transferencia = servicio.fechaServidor(); ;
                        transferencia.mes_Transferencia = Convert.ToInt32(cbxMes.SelectedValue.ToString());
                        transferencia.anio_Tranferencia = Convert.ToInt32(txtAnio.Text.ToString());
                        transferencia.observacion_Transferencia = txtObservacion.Text;

                        transferencia.registroActivo = true;
                        transferencia.usuarioRegistro = usuario.nombre_Usuario;
                        transferencia.fechaRegistro = fechaActualServidor;

                        servicio.transferenciaEditar(Util.header, transferencia);

                    await cancelar();
                    MessageBox.Show("Se ha Validado Correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ya no se puede Editar Porque el funcionario ya tiene esta de Fianza Validada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarErrores();

                //if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
                Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                await cancelar();
            }


        }


        //Verificamos si el Funcionario Tiene esta Fianza ya Validada
        public bool verificarSiYaValidado()/*Para no poder editar si el funcionario ya tiene una fianza corriendo*/
        {
            try
            {
                idTransferencia = Convert.ToInt32((dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idTransferencia"].Value).ToString());
            }
            catch
            {
                idTransferencia = -1;/*No tiene validada*/
            }

            if (idTransferencia == -1)
            {
                return false;
            }
            else
            {
                if (servicio.transferenciaGet(Util.header, idTransferencia).usuario_Contabilidad_Transferencia !=null)
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
   
            txtBuscar.Clear();
 

            limpiarErrores();
            await listar();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
           

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
            
            txtBuscar.Clear();
   

            limpiarErrores();
            listarNoAsync();
            //if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            

            reiniciarCamposFianzaAnterior();
            reiniciarCamposFianzaNueva();
            reiniciarCamposPersona();

            pnlCargoAnterior.Visible = true;
            pnlCargoActual.Visible = true;
            pnlCargoAnterior.Location = new Point(5, 64);
            pnlCargoActual.Location = new Point(468, 64);
        }

        private async void btnBaja_Click(object sender, EventArgs e)
        {
            limpiarErrores();

            DialogResult ResultadoDialogo = MessageBox.Show("El Funcionario será dado de baja.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFucnionario"].Value);
                servicio.funcionarioEliminar(Util.header, idFuncionario);
                MessageBox.Show("El Funcionario ha sido dado de baja.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await cancelar();
            }
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

            await listar();
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item seleccion = cbxMes.SelectedItem as Item;

            if (seleccion == null)
                return;
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


        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            reiniciarVerificacion();

            await listar();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
                await editar();
                Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (!verificarSiYaValidado())
            {
                txtAnio.Text = servicio.fechaServidor().Year.ToString();
                cbxMes.SelectedItem = servicio.fechaServidor().Month;

                limpiarErrores();
                await cargarCampos();
                verificarNuevo();
            }
            else
            {
                MessageBox.Show("Ya no se puede Editar Porque el funcionario ya tiene esta de Fianza Validada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarErrores();

                //if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
                Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                await cancelar();
            }
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

        private void dgvLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow item in dgvLista.Rows)
            {
                int index = item.Index;
                if ((item.Cells["usuario_Contabilidad_Transferencia"].Value) is null)
                { }
                else
                {
                    Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Sienna");
                }
            }

            dgvLista.ClearSelection();
        }

        private void FrmPersona_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private async void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarErrores();
            await cargarCampos();
            verificarNuevo();
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

    
  
       


        //private async void tbcFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string namepage = tbcFuncionarios.SelectedTab.Name;
           
        //    if (namepage == "tabPage3".ToString())
        //    {
        //        usuarioParaLista = " ";
        //        ch30Dias.Checked = true;
        //        txtBuscar.Clear();
        //        await listarDiasRestantes();

        //    }
        //    if (namepage == "tabPage2".ToString())
        //    {
        //        if (chkUsuarioRHASE.Checked == true)
        //        {
        //            chkUsuarioRHASE.Text = usuario.nombre_Usuario;
        //            usuarioParaLista = usuario.nombre_Usuario;
        //        }
        //        else
        //        {
        //            usuarioParaLista = " ";
        //        }
        //        txtBuscar.Clear();
        //        await listarConResolucion();
        //    }
        //}
    }
}
