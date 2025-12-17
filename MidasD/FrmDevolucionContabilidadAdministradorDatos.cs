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
using CrystalDecisions.Shared;
using MidasD.SrMidasD;
using MidasD.Reportes;

namespace MidasD
{
    public partial class FrmDevolucionContabilidadAdministradorDatos : Form
    {
        SrMidasD.Usuario usuario;
       
        public int idFuncionario,idPersona,idFianza,idOficina;
        SrMidasD.MidasDServiceClient servicio;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;
        FrmCargando frmCargando;
        public bool montoDevolucionBool,c31,nroCheque,mes,anio = false;

        public FrmDevolucionContabilidadAdministradorDatos(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();

            btnPnlLista = new List<Control>() { 
            btnBuscar,txtBuscar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() {  btnEditar, btnQuitarSeleccion,btnImprimir };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() { btnEditar,btnBuscar, 
            btnCancelar, btnGuardar, btnSalir ,btnQuitarSeleccion,btnImprimir});
        }



        private async Task listarDevoluciones()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);

            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvLista;
            paListarFuncionariosFianzaDevolucionContabilidad_Result[] asyncVariable1 = await this.servicio.pafianzaListarFuncionariosBuscarDevolucionContabilidadAsync(Util.header, txtBuscar.Text);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFianza","idFuncionario","fecha_Memorando","numero_Fianza_Solicitud","gestion","numero_Memorando", "tipo_contrato_item" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "Nro_Fianza", "numero_Documento","nombre_Completo", "fecha_limite_fianza" ,"vigencia_Contrato", "cargo", "haber_Mensual", "tipo_Fianza","resolucion_Administrativa","monto_beneficiario","c31","nro_Cheque","mes","anio","observacion","estado_Fianza" });
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




        private void dgvFuncionarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvLista.Rows)
                {


                    SrMidasD.Devolucion devolucionDato = servicio.devolucionGetidFianza(Util.header, Convert.ToInt32(item.Cells["idFianza"].Value));

                    int index = item.Index;

                    if (devolucionDato.c31 is null)
                    {
                        Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "White");
                    }
                    else
                    {
                        Util.pintarDatagridwiewIndex(dgvLista, index, "White", "Sienna");
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
            limpiarErrores();
            await cargarCampos();
            verificarNuevo();
            this.tabControl1.SelectedTab = tpEditar;
        }

        public void verificarNuevo()
        {
            if (string.IsNullOrEmpty(txtMontoDevolucion.Text))
            {
                montoDevolucionBool = false;
            }
            else
            {
                montoDevolucionBool = true;
            }

            if (string.IsNullOrEmpty(txtC31.Text))
            {
                c31 = false;
            }
            else
            {
                c31 = true;
            }

            if (string.IsNullOrEmpty(txtNroCheque.Text))
            {
                nroCheque = false;
            }
            else
            {
                nroCheque = true;
            }

            //Tipo de Documento
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

            if (!verificarFianzaDevueltaConta())
            {
                MessageBox.Show("El funcionario ya tiene una esta fianza devuelta. Tenga Cuidado al Editar", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { }
               
                idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFuncionario"].Value);
                idFianza = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value);
                idOficina = (int)servicio.funcionarioGet(Util.header, idFuncionario).idOficina;
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
                cbxCargo.SelectedValue = (int)funcionarioDatos.idCargo;
                lblTipoFianzaList.Text = servicio.tipoFianzaGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianza).idTipoFianza).descripcion_Fianza;
             
                lblNumeroMemorandoList.Text = funcionarioDatos.numero_Memorando;
                try
                {
                    txtResolucionAdministrativa.Text = servicio.devolucionGetidFianza(Util.header, idFianza).resolucion_Administrativa;
                }
                catch { }

                List<SrMidasD.paFuncionarioVerificaridFianzaCompleta_Result> lista = servicio.paFuncionarioVerificaridFianzaCompleta(Util.header, (int)servicio.oficinaGet(Util.header, idOficina).idUnidadEjecutora, idFianza).ToList();
                SrMidasD.paFuncionarioVerificaridFianzaCompleta_Result pa = lista.FirstOrDefault();

                txtMontoDevolucion.Text = string.Format("{0:n}", pa.total_Descuento);

                try
                {
                    txtAnio.Text = servicio.devolucionGetidFianza(Util.header, idFianza).anio.ToString();
                }
                catch
                { }
                try
                {
                    cbxMes.SelectedValue = servicio.devolucionGetidFianza(Util.header, idFianza).mes;
                }
                catch
                { }
                try
                {
                    txtC31.Text = servicio.devolucionGetidFianza(Util.header, idFianza).c31;
                }
                catch
                { }
                try
                {
                    txtNroCheque.Text = servicio.devolucionGetidFianza(Util.header, idFianza).nro_Cheque;
                }
                catch
                { }

                try
                {
                    pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)funcionarioDatos.idPersona).imagen1);
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
        private bool validarCampos()
        {
            limpiarErrores();
            verificarNuevo();

            if (!montoDevolucionBool)
            {
                Util.errorMensaje(erpError,txtMontoDevolucion,"Debe Introducir el monto de la Devolucion");
            }

            if (!c31)
            {
                Util.errorMensaje(erpError,txtC31,"Debe Introducir el c31 de la Devolucion");
            }

            if (!nroCheque)
            {
                Util.errorMensaje(erpError, txtNroCheque, "Debe Introducir el Número de Cheque");
            }


            if (!mes)
            {
                Util.errorMensaje(erpError, cbxMes, "Debe Introducir el mes de la Devolucion");
            }

            if (!anio)
            {
                Util.errorMensaje(erpError, txtNroCheque, "Debe Introducir el año de la Devolucion");
            }

            if (montoDevolucionBool == true && c31 == true && nroCheque == true && mes == true && anio == true)
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

            await cancelar();

        }
     
      
        public void reiniciarVerificacion()
        {
            montoDevolucionBool = false;
            c31 = false;
            nroCheque = false;
            mes = false;
            anio = false;
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

                try
                {
                    SrMidasD.Fianza fianza = servicio.fianzaIdFuncionario(Util.header, idFuncionario);
                    //Aqui Editamos cada Descuento
                    fianza.idFianza = fianza.idFianza;
                    fianza.fianza_Devuelta_Contabilidad = true;
                    fianza.fecha_Devuelta_Contabilidad = servicio.fechaServidor();
                    fianza.usuario_Devuelta_Contabilidad = usuario.nombre_Usuario;
                    servicio.fianzaEditar(Util.header, fianza);

                    //Aqui editamos la observacion de la devolucion en contabilidad
                    SrMidasD.Devolucion devolucion = servicio.devolucionGetidFianza(Util.header, fianza.idFianza);
                    devolucion.idFianza = fianza.idFianza;
                    devolucion.idFuncionario = fianza.idFuncionario;
                    devolucion.usuarioRegistro = usuario.nombre_Usuario;
                    devolucion.fechaRegistro = servicio.fechaServidor();
                    devolucion.monto_Devolucion =Convert.ToDouble(txtMontoDevolucion.Text);
                    devolucion.c31 = txtC31.Text;
                    devolucion.nro_Cheque = txtNroCheque.Text;
                    devolucion.mes = Convert.ToInt32(cbxMes.SelectedValue.ToString());
                    devolucion.anio = Convert.ToInt32(txtAnio.Text.ToString());
                    devolucion.registroActivo = true;

                    servicio.devolucionEditar(Util.header, devolucion);


                    //Aqui editamos la el funcionario y lo damos de baja
                    servicio.funcionarioEliminar(Util.header,idFuncionario);

                   
                    limpiarcampos();
                    MessageBox.Show("Se ha registrado la Resolucion Correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    frmCargando.Close();
                    MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            frmCargando.Close();
            await cancelar();
        }


        public bool verificarFianzaDevueltaConta()
        {
            idFianza = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value);
            if (servicio.fianzaVerificarDevueltaContabilidad(Util.header, idFianza) is null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        public async Task cancelar()
        {
            limpiarErrores();
            await listarDevoluciones();
           
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            limpiarcampos();

            this.tabControl1.SelectedTab = tpLista;
        }

        //private void btnBaja_Click(object sender, EventArgs e)
        //{
        //    limpiarErrores();

        //    DialogResult ResultadoDialogo = MessageBox.Show("El Funcionario será dado de baja.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (ResultadoDialogo == DialogResult.Yes)
        //    {
        //        int idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFucnionario"].Value);
        //        servicio.funcionarioEliminar(Util.header, idFuncionario);
        //        MessageBox.Show("El Funcionario ha sido dado de baja.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //listar();
        //        limpiarcampos();
        //    }
        //}

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
            await listarDevoluciones();
            txtBuscar.Enabled = true;

        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item seleccion = cbxMes.SelectedItem as Item;

            if (seleccion == null)
                return;
        }

        private void cbxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private async void rbListaDevoluciones_CheckedChanged(object sender, EventArgs e)
        {
           await listarDevoluciones();
        }

        private async void rbListaFuncionarios_CheckedChanged(object sender, EventArgs e)
        {
            await listarDevoluciones();
        }

        private async void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        void limpiarcampos()
        {
            txtResolucionAdministrativa.Clear();
            txtMontoDevolucion.Clear();
            txtC31.Clear();
            txtNroCheque.Clear();
            cbxMes.SelectedValue = -1;
            txtAnio.Clear();
            lblNumeroDocumentoList.ResetText();
            lblTipoDocumentoList.ResetText();
            lblNombresList.ResetText();
            lblPaternoList.ResetText();
            lblMaternoList.ResetText();
            lblOficinaList.ResetText();
          
            lblNumeroMemorandoList.ResetText();
            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1; 
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            new FrmCrCartillaVerFianza(idFianza, usuario.nombre_Usuario, "", 0).ShowDialog();
        }
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            reiniciarVerificacion();

            await listarDevoluciones();
        }


        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.notPaste = true;

            string nombre = ((TextBox)sender).Name.ToString();
            
            if (nombre == "txtMontoDevolucion")
            {
                erpError.Clear();
                montoDevolucionBool = true;
            }

            if (nombre == "txtC31")
            {
                erpError.Clear();
                c31 = true;
            }

            if (nombre == "txtNroCheque")
            {
                erpError.Clear();
                nroCheque = true;
            }

            if (nombre == "txtAnio")
            {
                erpError.Clear();
                anio = true;
            }
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFuncionario"].Value);
            idFianza = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value);
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
