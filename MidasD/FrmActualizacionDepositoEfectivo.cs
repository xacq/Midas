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
using System.Globalization;
using MidasD.SrMidasD;

namespace MidasD
{
    public partial class FrmActualizacionDepositoEfectivo : Form
    {
        SrMidasD.Usuario usuario;
        //string mesLetra;
        FrmCargando frmCargando;
        public int idFuncionario,idPersona,idFianza;
        SrMidasD.MidasDServiceClient servicio;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public bool resolucionAdministrativa = false;

        public FrmActualizacionDepositoEfectivo(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();

            btnPnlLista = new List<Control>() { 
            btnBuscar,txtBuscar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() { btnEditar };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() { btnEditar,btnBuscar, 
            btnCancelar, btnGuardar, btnSalir });

            List<Item> listaAnio = new List<Item>();

            for (int i = 0; i < 4; i++)
            {
                listaAnio.Add(new Item((DateTime.Now.Year - i).ToString(), i));
            }

            cbxAnio.DisplayMember = "Name";
            cbxAnio.ValueMember = "Value";
            cbxAnio.DataSource = listaAnio;

            cbxAnio.SelectedValue = 0;
        }

        private async Task listar()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvLista;
            paFuncionarioFianzaActualBuscarGeneralAdministrador_Result[] asyncVariable1 = await this.servicio.pafuncionarioFianzaActualBuscarGeneralAdministradorAsync(Util.header, txtBuscar.Text, 2, 3);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFianza", "idFuncionario", "a_Descontar", });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "Nro_Fianza", "ci", "cargo", "nombre_Completo", "fecha_Memorando", "resolucion_Administrativa", "item", "vigencia_Contrato", "haber_mensual", "total_Descuento", "total_Descontar", "falta_Descontar" });
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);

            frmCargando.Close();
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
            if (string.IsNullOrEmpty(mxbMontoBeneficiario.Text))
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
           
            int cuantia = (int)servicio.oficinaGet(Util.header, (int)servicio.funcionarioGet(Util.header, idFuncionario).idOficina).cuantia;
            int idCargo = (int)servicio.funcionarioGet(Util.header, idFuncionario).idCargo;
            int idEscalaSalarial = (int)servicio.cargoGet(Util.header, idCargo).idEscalaSalarial;
            int idSueldoMensual = (int)servicio.escalaSalarialGet(Util.header, idEscalaSalarial).idSueldoMensual;


            lblOficinaList.Text = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina).oficina1;//Cargamos los Cargos
            idEscalaSalarial = (int)servicio.cargoGet(Util.header, (int)funcionarioDatos.idCargo).idEscalaSalarial;
            int idHaberBasico = (int)servicio.escalaSalarialGet(Util.header, idEscalaSalarial).idSueldoMensual;
            cbxCargo.DataSource = servicio.cargoListarOficina(Util.header, (int)funcionarioDatos.idOficina, (int)servicio.sueldoMensualGet(Util.header, idHaberBasico).gestion);
            cbxCargo.ValueMember = "idCargo";
            cbxCargo.DisplayMember = "cargo";
            cbxCargo.SelectedValue = funcionarioDatos.idCargo;
            lblResolucion.Text = servicio.fianzaGet(Util.header,idFianza).resolucion_Administrativa;

            lblCargoList.Text = cbxCargo.Text;
            lblNumeroMemorandoList.Text = funcionarioDatos.numero_Memorando;
            dgvDescuentoTotal.DataSource= servicio.paFuncionarioVerificaridFianzaCompleta(Util.header,(int)servicio.oficinaGet(Util.header,(int)funcionarioDatos.idOficina).idUnidadEjecutora ,idFianza);
            try
            {
                lblTotalDescontadoPlanilla.Text = String.Format("{0:c}", dgvDescuentoTotal.Rows[0].Cells[8].Value);
            }
            catch { }


            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)funcionarioDatos.idPersona).imagen1);
            }
            catch { }
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);

            //try
            //{
            //    double suma = 0;
            //    foreach (DataGridViewRow row in dgvLista.Rows)
            //    {
            //        if (row.Cells["importe_descontado_s_g_ofrecimiento"].Value != null)
            //            suma += Convert.ToDouble(row.Cells["importe_descontado_s_g_ofrecimiento"].Value);
            //    }
            //    string specifier;
            //    CultureInfo culture;
            //    specifier = "N";
            //    culture = CultureInfo.CreateSpecificCulture("es-ES");
            //    lblTotalDescontadoPlanilla.Text = suma.ToString(specifier, culture);
            //}
            //catch { }

            mxbMontoBeneficiario.Focus();
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
            limpiarErrores();

            try
            {
                /*Verificamos que ya no tenga el mes Descontado*/
                Descuento fianzaFuncionarioMes = servicio.descuentoVerificarMesRegistrado(Util.header,idFianza, Convert.ToInt32(cbxMes.SelectedValue.ToString()), Convert.ToInt32(cbxAnio.SelectedItem.ToString()));
                if (fianzaFuncionarioMes == null)
                {
                    //Se crea el descuento una sola vez
                    SrMidasD.Descuento descuento;
                    descuento = new SrMidasD.Descuento();
                    descuento.idFianza = idFianza;
                    descuento.c21 = Convert.ToInt32(txtc21.Text);
                    descuento.mes = Convert.ToInt32(cbxMes.SelectedValue.ToString());
                    descuento.anio = Convert.ToInt32(cbxAnio.SelectedItem.ToString());
                    descuento.monto_Beneficiario = Convert.ToDouble(mxbMontoBeneficiario.Text.ToString());
                    descuento.validado = true;
                    descuento.validado_Por = usuario.nombre_Usuario;
                    descuento.observacion ="Deposito en Efectivo por Actualizacion de Fianza - "+ txtResolucionAdministrativa.Text;
                    descuento.usuarioRegistro = usuario.nombre_Usuario;
                    descuento.fechaRegistro = DateTime.Now.Date;
                    descuento.registroActivo = true;
                    int idDescuento = servicio.descuentoInsertar(Util.header, descuento);

                }
                else
                {
                    //Se crea el descuento una sola vez
                    SrMidasD.Descuento descuentoActualizar = servicio.descuentoGet(Util.header, fianzaFuncionarioMes.idDescuento);

                    //switch (Convert.ToInt32(cbxMes.SelectedValue.ToString()))
                    //{
                    //    case 1:
                    //        mesLetra = "Enero";
                    //        break;
                    //    case 2:
                    //        mesLetra = "Febrero";
                    //        break;
                    //    case 3:
                    //        mesLetra = "Marzo";
                    //        break;
                    //    case 4:
                    //        mesLetra = "Abril";
                    //        break;
                    //    case 5:
                    //        mesLetra = "Mayo";
                    //        break;
                    //    case 6:
                    //        mesLetra = "Junio";
                    //        break;
                    //    case 7:
                    //        mesLetra = "Julio";
                    //        break;
                    //    case 8:
                    //        mesLetra = "Agosto";
                    //        break;
                    //    case 9:
                    //        mesLetra = "Septiembre";
                    //        break;
                    //    case 10:
                    //        mesLetra = "Octubre";
                    //        break;
                    //    case 11:
                    //        mesLetra = "Noviembre";
                    //        break;
                    //    case 12:
                    //        mesLetra = "Diciembre";
                    //        break;
                    //    default:
                    //        Console.WriteLine("Default case");
                    //        break;
                    //}

                    descuentoActualizar.observacion = 
                    "Descuentos en el mismo mes, " +
                    "[" + fianzaFuncionarioMes.monto_Beneficiario +" Bs.  c21-"+fianzaFuncionarioMes.c21+ " correspondiente a " + fianzaFuncionarioMes.observacion + " - "+fianzaFuncionarioMes.usuarioRegistro+" ] " +
                    "[" + mxbMontoBeneficiario.Text.ToString() +" Bs.  c21-"+txtc21.Text+ " correspondiente a un deposito en efectivo por actualizacion de fianza - "+usuario.nombre_Usuario+" ]";

                    descuentoActualizar.idFianza = idFianza;
                    descuentoActualizar.c21 = Convert.ToInt32(txtc21.Text);
                    descuentoActualizar.mes = Convert.ToInt32(cbxMes.SelectedValue.ToString());
                    descuentoActualizar.anio = Convert.ToInt32(cbxAnio.SelectedItem.ToString());
                    descuentoActualizar.monto_Beneficiario = Convert.ToDouble(mxbMontoBeneficiario.Text.ToString()) + fianzaFuncionarioMes.monto_Beneficiario;
                    descuentoActualizar.validado = true;
                    descuentoActualizar.validado_Por = usuario.nombre_Usuario;
                    descuentoActualizar.usuarioRegistro = usuario.nombre_Usuario;
                    descuentoActualizar.fechaRegistro = DateTime.Now.Date;
                    descuentoActualizar.registroActivo = true;
                    servicio.descuentoEditar(Util.header, descuentoActualizar);
                }


                await listar();

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
            await listar();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista,"Black","Gray");
            limpiarcampos();    
        }

       

        public void textleave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        }


        private async void FrmActualizacionFianza_Load(object sender, EventArgs e)
        {
            txtBuscar.Enabled = false;
            await listar();
            txtBuscar.Enabled = true;

            //txtAnio.KeyPress += Utils.Wfa.onlyNumbers;
            //txtAnio.MouseDown += Utils.Wfa.notButtonRight;
            //txtAnioBuscar.MouseDown += Utils.Wfa.notButtonRight;
            dgvLista.RowPostPaint += Utils.Wfa.rowPostPaintDGV;

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

            cbxMes.SelectedValue = DateTime.Now.Month;
            cbxAnio.SelectedValue = 0;


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

        void limpiarcampos()
        {
            mxbMontoBeneficiario.Clear();
           
            lblNumeroDocumentoList.ResetText();
            lblTipoDocumentoList.ResetText();
            lblNombresList.ResetText();
            lblPaternoList.ResetText();
            lblMaternoList.ResetText();
            lblOficinaList.ResetText();
            lblCargoList.ResetText();
            lblNumeroMemorandoList.ResetText();
            cbxAnio.SelectedValue = 0;

          
            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1; 
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            reiniciarVerificacion();

            await listar();
        }

        private void txtc21_KeyPress(object sender, KeyPressEventArgs e)
        {
         
                Utils.Wfa.onlyNumbers(sender, e);
      
        }

        private async void dgvLista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarErrores();
            await cargarCampos();
            verificarNuevo();
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

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
        }

        private void FrmActualizacionFianza_FormClosed(object sender, FormClosedEventArgs e)
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
