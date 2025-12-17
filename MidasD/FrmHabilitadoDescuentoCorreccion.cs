
using MidasD.Reportes;
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
//using MidasD.Reportes;


namespace MidasD
{
    public partial class FrmHabilitadoDescuentoCorreccion: Form
    {
        SrMidasD.MidasDServiceClient servicio;

        SrMidasD.Usuario usuario;
  
        public int idFianzaIns, c21Int;
        public DateTime f;
        public bool bandera,validadoBool;
        public string validadoPorString,observacionString,esAdministrador;
        public double  cantidadDescuento, t727Double;
        FrmCargando frmCargando;
        DataGridViewCellEventArgs ee;
        public double CantidadActual;

        List<Control>  btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public FrmHabilitadoDescuentoCorreccion(SrMidasD.Usuario usuario,string ci,string esAdministrador)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
    
            this.usuario = usuario;
            this.esAdministrador = esAdministrador;
 
            btnPnlLista3 = new List<Control>() { btnSalir,grpListaSalidas};
            btnPnlLista2 = new List<Control>() {  btnEditar,tpgSelec,btnQuitarSeleccion };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos,panFuncionario,panBotones,grProductos,tpgEditarDatos };
            Util.btn_Mouse(new List<PictureBox>() { btnEditar, btnSalir,btnQuitarSeleccion });

            if(!string.IsNullOrEmpty(ci))
            {
                txtBuscar.Text = ci;
            }
            txtBuscar.Focus();
        }

        //Limpiar Campos
        public void limpiarcampos()
        {        
            try
            {
                txtBuscar.Clear();
                lblNumMemorando.ResetText();
                lblNombresApellidos.ResetText();
                lblCi.ResetText();
                lblTipoContrato.ResetText();
                lblVigenciaItem.ResetText();
                lblCargo.ResetText();
                lblHaberMensual.ResetText();
                lblCalculoSueldos.ResetText();
                lblTotalDescontar.ResetText();
                lblDescuentoSalario.ResetText();
                lblTotalDescuentoMes.ResetText();
                lblCantidadMesesDescontar.ResetText();
                lblidFianza.ResetText();
                pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;

                try
                {
                    dgvListaAux.Rows.Clear();

                }
                catch { }
                try
                {
                    dgvLista.Rows.Clear();

                }
                catch { }
            }
            catch { }
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


        public void fianzaDescuentoInsertar()
        {
            limpiarErrores();
            try
            {
                foreach (DataGridViewRow dr in dgvLista.Rows)
                {
                    SrMidasD.Descuento descuento = new SrMidasD.Descuento();

                    insertarFDN(Convert.ToInt32(dr.Cells["idFianza"].Value), descuento, dr);
                } 
            }
            catch
            {
                MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task fianzaDescuentoEditar()
        {
            idFianzaIns =Convert.ToInt32(lblidFianza.Text.ToString());


            foreach (DataGridViewRow dr in dgvListaAux.Rows)/*Eliminacion Fisica Descuento*/
            {
                servicio.descuentoEliminarfisicoEditar(Util.header, Convert.ToInt32(dr.Cells["idFianzaAux"].Value));
            }

            int filasDescuento = Convert.ToInt32(dgvLista.Rows.Count) - 1;

            for (int i = 0; i < filasDescuento; i++)
            {
                
                SrMidasD.Descuento descuento = new SrMidasD.Descuento();
                descuento.monto_Beneficiario = Convert.ToDouble(dgvLista.Rows[i].Cells[5].Value);
                descuento.idFianza = idFianzaIns;
                if(Convert.ToDouble(dgvLista.Rows[i].Cells[1].Value) != 0)
                {
                    descuento.t727 = Convert.ToDouble(dgvLista.Rows[i].Cells[1].Value);
                }
                if (Convert.ToInt32(dgvLista.Rows[i].Cells[2].Value) != 0)
                {
                    descuento.c21 = Convert.ToInt32(dgvLista.Rows[i].Cells[2].Value);
                }
                descuento.mes = Convert.ToInt32(dgvLista.Rows[i].Cells[3].Value);
                descuento.anio = Convert.ToInt32(dgvLista.Rows[i].Cells[4].Value);

                if (Convert.ToBoolean(dgvLista.Rows[i].Cells[6].Value) != false)
                {
                    descuento.validado = Convert.ToBoolean(dgvLista.Rows[i].Cells[6].Value);
                }

                if (dgvLista.Rows[i].Cells[7].Value!=null)
                {
                    descuento.validado_Por = Convert.ToString(dgvLista.Rows[i].Cells[7].Value);
                }

                if (dgvLista.Rows[i].Cells[8].Value == null)
                {
                    descuento.observacion = "Mes Descuento Regular Editado";
                }
                else
                {
                    descuento.observacion = Convert.ToString(dgvLista.Rows[i].Cells[8].Value);
                }


                if (dgvLista.Rows[i].Cells[9].Value == null)
                {
                    descuento.usuarioRegistro = usuario.nombre_Usuario;
                }
                else
                {
                    descuento.usuarioRegistro = Convert.ToString(dgvLista.Rows[i].Cells[9].Value);
                }


                if (dgvLista.Rows[i].Cells[10].Value == null)
                {
                    descuento.fechaRegistro = DateTime.Now.Date;
                }
                else
                {
                    descuento.fechaRegistro = Convert.ToDateTime(dgvLista.Rows[i].Cells[10].Value);
                }


                if (Convert.ToBoolean(dgvLista.Rows[i].Cells[11].Value) == false)
                {
                    descuento.registroActivo = true;
                }
                else
                {
                    descuento.registroActivo = Convert.ToBoolean(dgvLista.Rows[i].Cells[11].Value);
                }
                servicio.descuentoInsertar(Util.header, descuento);
            }

           
            MessageBox.Show("La Fianza ha sido Editada.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);

            limpiarcampos();

            await listarFianzas();
        }


        public void insertarFDN(int idFianzaFD, SrMidasD.Descuento descuento, DataGridViewRow dr)//Reutilizamos Insertar Detalle Venta Como para Insertar Un Nuevo Detalle venta en su Editar
        {
 
            descuento.idFianza = idFianzaFD;
            descuento.anio = Convert.ToInt32(dr.Cells["anio"].Value);
            descuento.mes = Convert.ToInt32(dr.Cells["mes"].Value);
            descuento.monto_Beneficiario = Math.Round(Convert.ToDouble(dr.Cells["monto"].Value), 2);

            descuento.usuarioRegistro = usuario.nombre_Usuario;
            descuento.registroActivo = true;
            descuento.fechaRegistro = DateTime.Now.Date;

            servicio.descuentoInsertar(Util.header, descuento);
        }

        //Se cargan campos para Editar y cambiar Datos
        private async Task cargarCamposFianzas()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            bool validadoHabilitado, validadoContabilidad, fianzaImpresa;

            SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["idFuncionario"].Value));
            SrMidasD.Fianza fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);

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


            //Cargamos los Datos Dinamicos a una Grilla Auxiliar para luego Añadirlos Uno a Uno al la Grilla de Trabajo
            dgvListaAux.DataSource = servicio.paFianzaReporteCartillaHabilitadoEditar(Util.header, Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["idFianza"].Value));
            foreach (DataGridViewRow dr in dgvListaAux.Rows)
            {
                reiniciarDatos();

                string idFianza = dr.Cells["idFianzaAux"].Value.ToString();
                if(dr.Cells["t727Aux"].Value != null)
                {
                    t727Double = Convert.ToDouble(dr.Cells["t727Aux"].Value);
                }
               
                if(dr.Cells["c21Aux"].Value!=null)
                {
                    c21Int = Convert.ToInt32(dr.Cells["c21Aux"].Value);
                }
               
                string mes = dr.Cells["mesAux"].Value.ToString();
                string anio = (dr.Cells["anioAux"].Value).ToString();
                double montoBeneficiario = Convert.ToDouble(dr.Cells["montoAux"].Value);
                if(dr.Cells["validadoAux"].Value!=null)
                {
                    validadoBool = Convert.ToBoolean(dr.Cells["validadoAux"].Value.ToString());
                }
                if(dr.Cells["validadoPorAux"].Value!=null)
                {
                    validadoPorString = (dr.Cells["validadoPorAux"].Value).ToString();
                }
                if(dr.Cells["observacionAux"].Value!=null)
                {
                    observacionString = dr.Cells["observacionAux"].Value.ToString();
                }
               

                string usuarioRegistro = (dr.Cells["usuarioRegistroAux"].Value).ToString();
                DateTime fechaRegistro = Convert.ToDateTime((dr.Cells["fechaRegistroAux"].Value).ToString());
                bool registroActivo= Convert.ToBoolean(dr.Cells["registroActivoAux"].Value.ToString());

                double totalDescuentoPlanilla = Convert.ToDouble(dr.Cells["totaldescontadoenplanillaAux"].Value);

                dgvLista.Rows.Add(idFianza,t727Double,c21Int,mes, anio, montoBeneficiario,validadoBool,validadoPorString,observacionString,usuarioRegistro,fechaRegistro,registroActivo);


                dgvLista.Rows[dgvLista.Rows.Count - 1].Cells["monto"].Selected = true;
                lblTotalDescontadoPlanilla.Text = (dr.Cells["totaldescontadoenplanillaAux"].Value).ToString() + " Bs.";
            }
            Util.pintarDatagridwiew(dgvListaFianzas, "Black", "Gray");

            try
            {
                SrMidasD.Persona persoDatos = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona);
                Cargo cargoDatos = servicio.cargoGet(Util.header, (int)funcionarioDatos.idCargo);
                Oficina ofiDatos = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina);
                EscalaSalarial escaDatos = servicio.escalaSalarialGet(Util.header, (int)cargoDatos.idEscalaSalarial);

                string nroMemorando = funcionarioDatos.numero_Memorando;
                string nombreCompleto = persoDatos.paterno.ToUpper() + " " + persoDatos.materno.ToUpper() + " " + persoDatos.nombres.ToUpper();
                string numeroDocumento = persoDatos.numero_Documento;
                string tipoContrato = funcionarioDatos.vigencia_Contrato.ToUpper();
                string item = funcionarioDatos.tipo_Contrato_Item.ToString();
                string cargoOficina = cargoDatos.descripcion_Puesto.ToUpper() + " " + ofiDatos.oficina1.ToUpper();
                string haberMensual = string.Format("{0:#,0.00}", servicio.sueldoMensualGet(Util.header, (int)escaDatos.idSueldoMensual).monto);
                string cuantia = ofiDatos.cuantia.ToString();
                string totalDescontar = string.Format("{0:#,0.00}", Convert.ToDouble(haberMensual) * Convert.ToDouble(cuantia));
                string porcentajeDescuento = (ofiDatos.porcentaje_Descuento).ToString();
                string totalDescuentoMes = Convert.ToString((Convert.ToDouble(haberMensual) * ofiDatos.porcentaje_Descuento));
                string cantidadMeses = Math.Round(Convert.ToDouble(totalDescontar) / Convert.ToDouble(totalDescuentoMes)).ToString();
               

                lblNumMemorando.Text = nroMemorando;
                lblNombresApellidos.Text = nombreCompleto;
                lblCi.Text = persoDatos.numero_Documento;
                lblTipoContrato.Text = tipoContrato;
                lblVigenciaItem.Text = item;
                lblCargo.Text = cargoOficina;
                lblHaberMensual.Text = haberMensual;
                lblCalculoSueldos.Text = cuantia;
                lblTotalDescontar.Text = totalDescontar;
                lblDescuentoSalario.Text = porcentajeDescuento;
                lblTotalDescuentoMes.Text = totalDescuentoMes;
                lblCantidadMesesDescontar.Text = cantidadMeses;
                lblNroFianza.Text = servicio.fianzaGet(Util.header,(int)fianzaDatos.idFianza).Nro_Fianza.ToString();
                lblidFianza.Text = fianzaDatos.idFianza.ToString();


                this.pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, persoDatos.idPersona).imagen1);
            }
            catch { }


            if (validadoHabilitado == true && validadoContabilidad == true)
            {
                if(esAdministrador=="Administrador")
                {
                    Util.pnlListaActivar(false, btnPnlLista2);
                    Util.pnlListaActivar(true, btnPnlDatos);
                }
                else
                {
                    Util.pnlListaActivar(true, btnPnlLista2);
                    Util.pnlListaActivar(false, btnPnlDatos);
                    MessageBox.Show(" La Fianza se encuentra Validada por\r***Habilitado y Contabilidad***\rYa no se puede Modificar", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                    Util.pintarDatagridwiew(dgvListaFianzas, "Black", "White");
                }
               
            }
            else
            {
                Util.pnlListaActivar(false, btnPnlLista2);
                Util.pnlListaActivar(true, btnPnlDatos);
            }

            frmCargando.Close();
        }

        //Limpiar Errores
        public void reiniciarDatos()
        {
                t727Double = 0;
                c21Int = 0;
                validadoBool =false;
                validadoPorString =null;
                observacionString =null;
        }

        //Limpiar Errores
        public void limpiarErrores()
        {
            erpError.Clear();
        }

        //Listar Fianzas Registradas Por Unidad Ejecutora
        public async Task listarFianzas()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvListaFianzas;
           

            if (esAdministrador=="Administrador")
            {
                paFuncionarioFianzaActualBuscarGeneralAdministrador_Result[] asyncVariable1 = await this.servicio.pafuncionarioFianzaActualBuscarGeneralAdministradorAsync(Util.header, txtBuscar.Text, 2, 3);
                asyncVariable0.DataSource = asyncVariable1;
                asyncVariable0 = null;
                asyncVariable1 = null;
            }
            else
            {
                paFuncionarioFianzaActualBuscarGeneralAdministrador_Result[] asyncVariable1 = await this.servicio.pafuncionarioFianzaActualBuscarGeneralAdministradorAsync(Util.header, txtBuscar.Text, 2, 2);
                asyncVariable0.DataSource = asyncVariable1;
                asyncVariable0 = null;
                asyncVariable1 = null;
            }
          
            Utils.Wfa.hideHeadersDGV(dgvListaFianzas, new List<string>() { "idFianza","idFuncionario", "item", "vigencia_Contrato", "fecha_Memorando", "a_Descontar", "resolucion_Administrativa"});
            Utils.Wfa.positionHeadersDGV(dgvListaFianzas, new List<string>() { "Nro_Fianza", "ci", "cargo", "nombre_Completo", "haber_mensual", "total_Descuento", "total_Descontar", "falta_Descontar" });
            Utils.Wfa.setHeadersDGV(dgvListaFianzas);
            dgvListaFianzas.AutoResizeColumns();
            dgvListaFianzas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(true, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);

            frmCargando.Close();
        }

        //Boton Cancelar
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        

        //validar el campo descontar
        private int validarTotalDgv()
        {
            foreach (DataGridViewRow dr in dgvLista.Rows)
                if (Convert.ToDouble(dr.Cells["monto"].Value) <= 0)
                    return dr.Index;
            return -1;
        }

        private void dgvLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                /*Solo Refrescamos la Columnna Evitando que se Realize todo El Calculo Innesesario*/
                if (e.ColumnIndex == 2)
                {
                    CantidadActual = Math.Round(Convert.ToDouble(dgvLista.Rows[e.RowIndex].Cells["monto"].Value), 2);
                    /*Sacamos la cantidad Actual que se edita que no sea menor a 0*/
                    
                    if (CantidadActual <= 0)
                    {
                        MessageBox.Show("Cantidad Solicitada no debe ser menor a\n" + ": " + 0, "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else//Si es cero se coloca de nuevo el valor de descuento por mes
                    {
                        dgvLista.Rows[e.RowIndex].Cells["monto"].Value = CantidadActual;
                    }

                }
                else
                {/*Calculamos Todos Los Demas Valores*/

                    double suma = 0;
                    //foreach (DataGridViewRow dr in dgvLista.Rows)
                    //    suma += Convert.ToDouble(dr.Cells["precio_Unitario"].Value) * Convert.ToDouble(dr.Cells["cantidad"].Value);

                    foreach (DataGridViewRow dr in dgvLista.Rows)
                        suma += Convert.ToDouble(dr.Cells["monto"].Value);

                    lblTotalDescontadoPlanilla.Text= suma.ToString()+" Bs.";
                }
            }
            catch (Exception) { }
        }

       

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            await fianzaDescuentoEditar();
            limpiarErrores();
            limpiarcampos();

            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            this.tabControl.SelectedTab = tpgSelec;
        }

        
        private void dgvLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dgvLista.CurrentCell.ColumnIndex;
            if (column == 2)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    Util.notPaste = false;
                    txt.KeyPress += Utils.Wfa.onlyDecimals;
                    txt.MouseDown += Utils.Wfa.notButtonRight;
                }
            }
            //if (column == 0)
            //{
            //    ComboBox cbx = e.Control as ComboBox;
            //    cbx.ValueMember = "value";
            //    cbx.DisplayMember = "name";
            //}
        }


        //private void Estilos_dgvMes()
        //{
        //    List<Item> lista = new List<Item>();

        //    lista.Add(new Item("Enero", 1));
        //    lista.Add(new Item("Febrero", 2));
        //    lista.Add(new Item("Marzo", 3));
        //    lista.Add(new Item("Abril", 4));
        //    lista.Add(new Item("Mayo", 5));
        //    lista.Add(new Item("Junio", 6));
        //    lista.Add(new Item("Julio", 7));
        //    lista.Add(new Item("Agosto", 8));
        //    lista.Add(new Item("Septiembre", 9));
        //    lista.Add(new Item("Octubre", 10));
        //    lista.Add(new Item("Noviembre", 11));
        //    lista.Add(new Item("Diciembre", 12));

        //    DataGridViewComboBoxColumn cbxMes= (DataGridViewComboBoxColumn)dgvLista.Columns["mes"];
        //    cbxMes.ValueMember = "value";
        //    cbxMes.DisplayMember = "name";
        //    cbxMes.DataSource = lista;



        //    foreach (DataGridViewRow row in dgvLista.Rows)
        //    {
        //        DataGridViewComboBoxCell cellTa = (DataGridViewComboBoxCell)row.Cells["mes"];
        //        if (cellTa.Items.Count > 0) cellTa.Value = lista[0].Value;

        //        break;
        //    }
        //    dgvLista.DataError += new DataGridViewDataErrorEventHandler(dgvCombo_DataError);
        //}

       

        //Datos para validar el formulario
        private async void frmEntrada_Load(object sender, EventArgs e)
        {
            DialogResult ResultadoDialogo = MessageBox.Show("Desea listar todas las Fianzas?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                txtBuscar.Enabled = false;
                await listarFianzas();
                txtBuscar.Enabled = true;
                dgvLista.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
                dgvListaFianzas.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            }
            else
            {
                txtBuscar.Focus();
            }

            //await listarFianzas();
            //txtAnioBuscar.MouseDown += Utils.Wfa.notButtonRight;
            //dgvLista.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            //dgvListaFianzas.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
        }

        //public class Item
        //{
        //    public string Name { get; set; }
        //    public int Value { get; set; }

        //    public Item(string name, int value)
        //    {
        //        Name = name;
        //        Value = value;
        //    }
        //    public override string ToString()
        //    {
        //        return Name;
        //    }
        //}

       

        //Opciones Habilitar 
        private void dgvListaFianzas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
        }

        //Habilitar las opciones Editar
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            await editarCampos();
        }

        public async Task editarCampos()
        {
            limpiarErrores();
            await cargarCamposFianzas();

            bandera = false;

            this.tabControl.SelectedTab = tpgEditarDatos;


            if (dgvLista.RowCount >= 1)
            {
                int fila = dgvLista.RowCount;
            }
            else
            {
                dgvLista.AllowUserToAddRows = true;
                MessageBox.Show("No existen Descuento Inserte Filas y Registre", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void dgvListaFianzas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            await editarCampos();
        }

        private async void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        private async Task cancelar()
        {
            limpiarErrores();
            limpiarcampos();
            await listarFianzas();

            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(true, btnPnlLista2); Util.pnlListaActivar(false, btnPnlDatos);
            this.tabControl.SelectedTab = tpgSelec;
        }


        //Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        //void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    // (No need to write anything in here)  
        //}
       

        //private void dgvLista_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    DataGridViewRow row = dgvLista.Rows[e.RowIndex];

        //    tring SelectedText = Convert.ToString((DataGridView1.Rows[0].Cells["dgcombocell"] as DataGridViewComboBoxCell).FormattedValue.ToString());
        //    int SelectedVal = Convert.ToInt32(DataGridView1.Rows[0].Cells["dgcombocell"].Value);

        //}
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                this.ee = e;
            }
            catch { }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await listarFianzas();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender, e);
            }
        }

        //Opcion eliminar Fila
        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount >= 1)
            {
                int fila = dgvLista.CurrentRow.Index;
                if (fila != dgvLista.RowCount)
                {
                    DialogResult ResultadoDialogo = MessageBox.Show("Se va a eliminar el Descuento seleccionado.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ResultadoDialogo == DialogResult.Yes)
                    {
                        dgvLista.Rows.RemoveAt(fila);
                        MessageBox.Show("Descuento Salida eliminada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Entrada Salida", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No existen Descuento para eliminar", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count >1)
            {
                dgvLista.AllowUserToAddRows = true;
                int fila = dgvLista.CurrentRow.Index;
                if (fila != dgvLista.Rows.Count)
                {
                    try
                    {
                        dgvLista.Rows.Insert(dgvLista.Rows.Count);
                    }
                    catch { }
                   
                }
            }
            else
            {
                dgvLista.AllowUserToAddRows = true;
            }

        }

    }
}
