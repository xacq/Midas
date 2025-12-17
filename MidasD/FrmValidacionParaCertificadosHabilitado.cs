
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
    public partial class FrmValidacionParaCertificadosHabilitado : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        FrmCargando frmCargando;
        SrMidasD.Usuario usuario;
  
        public int idFianzaIns, idUnidadEjecutoraIns,idTipoFianzaIns,mesIns,anioIns;
        public DateTime f;
        public bool bandera;


        public bool c21 = false;


        List<Control>  btnPnlDatos, btnPnlLista3;

        public FrmValidacionParaCertificadosHabilitado(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
    
            this.usuario = usuario;

           
            btnPnlLista3 = new List<Control>() { btnSalir,grpListaSalidas};
       
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos,panFuncionario,panBotones,grProductos };
            Util.btn_Mouse(new List<PictureBox>() { btnSalir });

            List<Item> listaAnio = new List<Item>();

            for (int i = 0; i < 4; i++)
            {
                listaAnio.Add(new Item((DateTime.Now.Year - i).ToString(), i));
            }

            cbxAnio.DisplayMember = "Name";
            cbxAnio.ValueMember = "Value";
            cbxAnio.DataSource = listaAnio;

            cbxAnio.SelectedValue = 0;

            cargarUnidadEjecutora();
        }

        //Listar las Unidades Encargadas
        private void cargarUnidadEjecutora()
        {
            cbxUnidadEjecutora.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutora.DisplayMember = "descripcion";
            cbxUnidadEjecutora.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutora.SelectedIndex = 0;
            cbxUnidadEjecutora.DropDownWidth = widthComboBox(cbxUnidadEjecutora);
        }

        //Redimencionar un Combo Box
        public static int widthComboBox(ComboBox cbx)
        {
            int num = 0;
            int preferredWidth = 0;
            Label label = new Label
            {
                Font = new Font(cbx.Font.FontFamily, cbx.Font.Size, cbx.Font.Style, GraphicsUnit.Point, 0)
            };
            foreach (object obj2 in cbx.Items)
            {
                label.Text = ((UnidadEjecutora)obj2).descripcion.Trim();
                preferredWidth = label.PreferredWidth;
                if (preferredWidth > num)
                {
                    num = preferredWidth;
                }
            }
            return (num + 20);
        }

        //Limpiar Campos
        public void limpiarcampos()
        {
            try
            {
                dgvLista.Rows.Clear();
            }
            catch { }
        }

        //Reiniciar Verificacion
        public void reiniciarVerificacion()
        {
            c21 = false;
        }

      
        private async Task fianzaDescuentoEditar()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());


            foreach (DataGridViewRow dr in dgvLista.Rows)
            {

                if (dr.Cells["idFianza"].Value != null)
                {
                    Fianza fianza = servicio.fianzaGet(Util.header, Convert.ToInt32(dr.Cells["idFianza"].Value));
                    //Aqui Editamos casa Descuento
                    fianza.idFianza = fianza.idFianza;
                    fianza.fianza_Completa_Habilitado = true;
                    fianza.fecha_Completa_Habilitado = DateTime.Now;
                    fianza.usuario_Completa_Habilitado = usuario.nombre_Usuario;
                    servicio.fianzaEditar(Util.header, fianza);
                }
            }
            MessageBox.Show("La Fianza ha sido Validada.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult ResultadoDialogo = MessageBox.Show("Desea Imprimir Reporte/Nota de Validacion.\r¿Desea continuar?.", "::: Midas - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                imprimir();
            }

            limpiarcampos();

            frmCargando.Close();
            await listarFianzas();
        }

       

        public void imprimir()
        {
            //string fecha = Convert.ToDateTime(servicio.salidaGet(Util.header, idFianza).fecha_Salida).ToString("yyyy") + Convert.ToDateTime(servicio.salidaGet(Util.header, idFianza).fecha_Salida).ToString("MM") + Convert.ToDateTime(servicio.salidaGet(Util.header, idFianza).fecha_Salida).ToString("dd");
            //new FrmReporteEntradaSalida(idFianza, usuario,true).ShowDialog();
        }

       


        //Se cargan campos para Editar y cambiar Datos
        private async Task cargarCamposFianzas()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            int idFianza = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["idFianza"].Value);

            int row = existeFianzDgv(idFianza);
            if (row == -1)
            {


                //Cargamos los Datos Dinamicos a una Grilla Auxiliar para luego Añadirlos Uno a Uno al la Grilla de Trabajo
                dgvListaAux.DataSource = servicio.paFuncionarioVerificaridFianzaCompleta(Util.header, Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()), idFianza);


                foreach (DataGridViewRow dr in dgvListaAux.Rows)
                {

                    string cargo = dr.Cells["cargoAux"].Value.ToString();
                    string nombre_Completo = dr.Cells["nombre_CompletoAux"].Value.ToString();
                    string ci = dr.Cells["ciAux"].Value.ToString();
                    string item = dr.Cells["itemAux"].Value.ToString();
                    string haber_mensual = dr.Cells["haber_mensualAux"].Value.ToString();
                    double total_Descuento = Convert.ToDouble(dr.Cells["total_DescuentoAux"].Value);
                    double total_Descontar = Convert.ToDouble(dr.Cells["total_DescontarAux"].Value);
                    double falta_descontar = Convert.ToDouble(dr.Cells["falta_DescontarAux"].Value);
                    //double a_Validar = Convert.ToDouble(dr.Cells["a_ValidarAux"].Value);

                    dgvLista.Rows.Add(cargo, nombre_Completo, ci, item, haber_mensual, total_Descuento, total_Descontar, falta_descontar, idFianza);
                }

            }
            else
            {
                dgvLista.Rows[row].Cells[0].Selected = true;
                MessageBox.Show("El Funcionario ya se encuentra en la Lista", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            frmCargando.Close();
        }

        //Verificar si existe ya insertada la idfianza de un funcionario
        private int existeFianzDgv(int idFianza)
        {
            foreach (DataGridViewRow dr in dgvLista.Rows)
                if (Convert.ToInt32(dr.Cells["idFianza"].Value.ToString()) == idFianza)
                    return dr.Index;
            return -1;
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
            paValidacionParaCertificadosHabilitado_Result[] asyncVariable1 = await this.servicio.paValidacionParaCertificadosHabilitadoAsync(Util.header, txtBuscar.Text, Convert.ToInt32(cbxAnio.SelectedItem.ToString()), Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvListaFianzas, new List<string>() { "idFianza","Nro_Fianza" });
            Utils.Wfa.positionHeadersDGV(dgvListaFianzas, new List<string>() { "cargo", "apellidos_Y_Nombres", "ci", "item", "h_b", "estado_Cuenta_Gestion_Pasada", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre", "total_Descuento", "total_Descontar" });
            Utils.Wfa.setHeadersDGV(dgvListaFianzas);
            dgvListaFianzas.AutoResizeColumns();
            dgvListaFianzas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlDatos);

            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pintarDatagridwiew(dgvListaFianzas, "Black", "Gray");
            limpiarcampos();

            frmCargando.Close();
        }

        //Listar Fianzas Validadas Por Contabilidad
        public async Task listarFianzasValidadasHabilitado()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvValidadasHabilitado;
            paValidacionEstadoFianzaHabilitado_Result[] asyncVariable1 = await this.servicio.paValidacionEstadoFianzaHabilitadoAsync(Util.header, txtBuscar.Text, Convert.ToInt32(cbxAnio.SelectedItem.ToString()), Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvValidadasHabilitado, new List<string>() { "idFianza", "Validado_Por_Habilitacion", "fecha_Habilitacion", "Usuario_Habilitacion" });
            Utils.Wfa.positionHeadersDGV(dgvValidadasHabilitado, new List<string>() { "cargo", "apellidos_Y_Nombres", "ci", "item", "h_b", "estado_Cuenta_Gestion_Pasada", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre", "totalDescuento", "totalDescontar", "Validado_Por_Habilitado", "fecha_Habilitado", "Usuario_Habilitado" });
            Utils.Wfa.setHeadersDGV(dgvValidadasHabilitado);
            dgvValidadasHabilitado.AutoResizeColumns();
            dgvValidadasHabilitado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            frmCargando.Close();
        }

        //Listar Fianzas Su Estado
        public async Task listarEstadoValidaciones()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvEstadoValidaciones;
            paValidacionEstadoFianzaRRHH_Result[] asyncVariable1 = await this.servicio.paValidacionEstadoFianzaRRHHAsync(Util.header, txtBuscar.Text, Convert.ToInt32(cbxAnio.SelectedItem.ToString()), Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvEstadoValidaciones, new List<string>() { "idFianza" });
            Utils.Wfa.positionHeadersDGV(dgvEstadoValidaciones, new List<string>() { "cargo", "apellidos_Y_Nombres", "ci", "item", "h_b","totalDescuento", "totalDescontar", "Validado_Por_Habilitacion", "fecha_Habilitacion", "Usuario_Habilitacion", "Validado_Por_Contabilidad", "fecha_Contabilidad", "Usuario_Contabilidad" });
            Utils.Wfa.setHeadersDGV(dgvEstadoValidaciones);
            dgvEstadoValidaciones.AutoResizeColumns();
            dgvEstadoValidaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            frmCargando.Close();
        }

        //Boton Cancelar
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        private async Task cancelar()
        {
            limpiarErrores();
            limpiarcampos();
            await listarFianzas();

            //if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bandera)
            {
               
            }
            else
            {
                await fianzaDescuentoEditar();
            }
        }

     

        //Datos para validar el formulario
        private async void frmEntrada_Load(object sender, EventArgs e)
        {
            //txtAnioBuscar.Text = DateTime.Now.Year.ToString();
            //txtAnioBuscar.KeyPress += Utils.Wfa.onlyNumbers;
            dgvLista.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            dgvListaFianzas.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            dgvEstadoValidaciones.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            dgvValidadasHabilitado.RowPostPaint += Utils.Wfa.rowPostPaintDGV;

            txtBuscar.Enabled = false;
            cbxAnio.Enabled = false;
            cbxUnidadEjecutora.Enabled = false;
            await listarFianzas();
            txtBuscar.Enabled = true;
            cbxAnio.Enabled = true;
            cbxUnidadEjecutora.Enabled = true;
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

       

        //Opciones Habilitar 
        private async void dgvListaFianzas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(true, btnPnlDatos);
            //Util.pnlListaActivar(true, btnPnlLista2);

            await cargarCamposFianzas();
        }

        //Habilitar las opciones Editar
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            await cargarCamposFianzas();
          

            bandera = false;

            //Util.pnlListaActivar(false, btnPnlLista);
            //Util.pnlListaActivar(false, btnPnlLista3);
          
            //Util.pnlListaActivar(false, btnPnlLista2);
        }

      

        //Habilitar Opciones de Registro Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarErrores();
         
            limpiarcampos();

            bandera = true;
           
            Util.pnlListaActivar(false, btnPnlLista3);

            Util.pnlListaActivar(true, btnPnlDatos);

            Util.pintarDatagridwiew(dgvListaFianzas,"Gray","Gray");


            if (dgvLista.Rows.Count > 0)
                btnGuardar.Enabled = true;
            else btnGuardar.Enabled = false;
        }

        //Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Listar segun el cambio de unidad Ejecutora
        private async void cbxUnidadEjecutora_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string namepage = tbpValidacionHabi.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                await listarFianzas();
            }
            if (namepage == "tabPage2".ToString())
            {
                await listarFianzasValidadasHabilitado();
            }
            if (namepage == "tabPage3".ToString())
            {
                await listarEstadoValidaciones();
            }
        }

        void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here)  
        }
       

        private void dgvLista_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = dgvLista.Rows[e.RowIndex];
           
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string namepage = tbpValidacionHabi.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                await listarFianzas();
            }
            if (namepage == "tabPage2".ToString())
            {
                await listarFianzasValidadasHabilitado();
            }
            if (namepage == "tabPage3".ToString())
            {
                await listarEstadoValidaciones();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void dgvValidadasContabilidad_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void dgvEstadoValidaciones_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private async void tbpValidacionConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            string namepage = tbpValidacionHabi.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                await listarFianzas();
            }
            if (namepage == "tabPage2".ToString())
            {
                await listarFianzasValidadasHabilitado();
            }
            if (namepage == "tabPage3".ToString())
            {
                await listarEstadoValidaciones();
            }

        }

        private void dgvValidadasContabilidad_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvValidadasHabilitado.Rows)
                {
                    int index = item.Index;
                    Util.pintarDatagridwiewIndex(dgvValidadasHabilitado, index, "Black", "Coral");
                    dgvValidadasHabilitado.ClearSelection();
                }
            }
            catch { }
        }

        private async void txtAnioBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string namepage = tbpValidacionHabi.SelectedTab.Name;
                if (namepage == "tabPage1".ToString())
                {
                    await listarFianzas();
                }
                if (namepage == "tabPage2".ToString())
                {
                    await listarFianzasValidadasHabilitado();
                }
                if (namepage == "tabPage3".ToString())
                {
                    await listarEstadoValidaciones();
                }
            }
        }

        private async void cbxAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string namepage = tbpValidacionHabi.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                await listarFianzas();
            }
            if (namepage == "tabPage2".ToString())
            {
                await listarFianzasValidadasHabilitado();
            }
            if (namepage == "tabPage3".ToString())
            {
                await listarEstadoValidaciones();
            }
        }

        //Opcion Solo Numeros
        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyNumbers(sender, e);

            string nombre = ((TextBox)sender).Name.ToString();
            if (nombre == "txtNit")
            {
                erpError.Clear();
                //numerodoc = true;
            }
        }

        //Limpiar al hacer Click
        private void txtAnio_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Clear();
        }

 

        //Opcion Imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //new FrmImpresionFianza().ShowDialog();
            //idFianza = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["idFianza"].Value);
            //imprimir();
        }


        private void dgvLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvEstadoValidaciones.Rows)
                {

                    string validadoHabilitacion = (item.Cells["Validado_Por_Habilitacion"].Value).ToString();
                    string validadoContabilidad = (item.Cells["Validado_Por_Contabilidad"].Value).ToString();

                    int index = item.Index;

                    if (validadoContabilidad == "Validado" || validadoHabilitacion == "Validado")
                    {
                        if (validadoContabilidad == "Validado" && validadoHabilitacion == "Validado")
                        {

                            Util.pintarDatagridwiewIndex(dgvEstadoValidaciones, index, "Black", "DeepSkyBlue");
                        }
                        else
                        {
                            if (validadoContabilidad == "Validado")
                            {

                                Util.pintarDatagridwiewIndex(dgvEstadoValidaciones, index, "Black", "Gold");
                            }
                            else
                            {
                                Util.pintarDatagridwiewIndex(dgvEstadoValidaciones, index, "Black", "Coral");
                            }
                        }
                        
                    }
                    else
                    {
                        
                    }

                    dgvEstadoValidaciones.ClearSelection();

                }
            }
            catch { }


        }

        //Insertamos numeracion
        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
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
