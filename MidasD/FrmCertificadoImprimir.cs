
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
    public partial class FrmCertificadoImprimir : Form
    {
        SrMidasD.MidasDServiceClient servicio;

        SrMidasD.Usuario usuario;
  
        public int idFianzaIns, idUnidadEjecutoraIns,idTipoFianzaIns,mesIns,anioIns;
        public DateTime f;
        public bool bandera;
        FrmCargando frmCargando;

        public bool c21 = false;


        List<Control>  btnPnlLista3;

        public FrmCertificadoImprimir(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
    
            this.usuario = usuario;

            btnPnlLista3 = new List<Control>() { btnSalir,grpListaSalidas};

            Util.btn_Mouse(new List<PictureBox>() { btnSalir,btnImprimir });

            cargarUnidadEjecutora();

            List<Item> listaAnio = new List<Item>();

            for (int i = 0; i < 4; i++)
            {
                listaAnio.Add(new Item((DateTime.Now.Year - i).ToString(), i));
            }

            cbxAnio.DisplayMember = "Name";
            cbxAnio.ValueMember = "Value";
            cbxAnio.DataSource = listaAnio;

            cbxAnio.SelectedValue = 0;

            txtBuscar.Focus();

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

       

        //Reiniciar Verificacion
        public void reiniciarVerificacion()
        {
            c21 = false;
        }


        public async Task imprimir()
        {


            int idFianza = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["idFianza"].Value);

  
            Fianza fianza = servicio.fianzaGet(Util.header, idFianza);

            if (fianza.fianza_Impresa_RRHH == false || fianza.fianza_Impresa_RRHH == null)
            {
                fianza.idFianza = fianza.idFianza;
                fianza.fianza_Impresa_RRHH = true;
                fianza.usuario_Impresa_RRHH = usuario.nombre_Usuario;
                fianza.fecha_Impresa_RRHH = DateTime.Now;
                servicio.fianzaEditar(Util.header, fianza);
            }
           

            string fecha = string.Format("{0:D}",servicio.fianzaGet(Util.header,idFianza).fechaRegistro);
            new FrmCrCertificado(idFianza,Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()),fecha, usuario).ShowDialog();
            await listarFianzas();
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
            paValidacionParaCertificadosRRHH_Result[] asyncVariable1 = await this.servicio.paValidacionParaCertificadosRRHHAsync(Util.header, txtBuscar.Text, 2, Convert.ToInt32(cbxAnio.SelectedItem.ToString()), Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            dgvListaFianzas.Columns["cargo"].DisplayIndex = 01;
            dgvListaFianzas.Columns["apellidos_Y_Nombres"].DisplayIndex = 02;
            dgvListaFianzas.Columns["ci"].DisplayIndex = 03;
            dgvListaFianzas.Columns["item"].DisplayIndex = 04;
            dgvListaFianzas.Columns["h_b"].DisplayIndex = 05;
            dgvListaFianzas.Columns["estado_Cuenta_Gestion_Pasada"].DisplayIndex = 06;
            dgvListaFianzas.Columns["enero"].DisplayIndex = 07;
            dgvListaFianzas.Columns["febrero"].DisplayIndex = 08;
            dgvListaFianzas.Columns["marzo"].DisplayIndex = 09;
            dgvListaFianzas.Columns["abril"].DisplayIndex = 10;
            dgvListaFianzas.Columns["mayo"].DisplayIndex = 11;
            dgvListaFianzas.Columns["junio"].DisplayIndex = 12;
            dgvListaFianzas.Columns["julio"].DisplayIndex = 13;
            dgvListaFianzas.Columns["agosto"].DisplayIndex = 14;
            dgvListaFianzas.Columns["septiembre"].DisplayIndex = 15;
            dgvListaFianzas.Columns["octubre"].DisplayIndex = 16;
            dgvListaFianzas.Columns["noviembre"].DisplayIndex = 17;
            dgvListaFianzas.Columns["diciembre"].DisplayIndex = 18;
            dgvListaFianzas.Columns["total_Descuento"].DisplayIndex = 19;
            dgvListaFianzas.Columns["total_Descontar"].DisplayIndex = 20;
            dgvListaFianzas.Columns["fianza_Impresa"].DisplayIndex = 21;

            Utils.Wfa.hideHeadersDGV(dgvListaFianzas, new List<string>() { "idUnidadEjecutora","idFianza" });
            Utils.Wfa.setHeadersDGV(dgvListaFianzas);
            dgvListaFianzas.AutoResizeColumns();
            dgvListaFianzas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

             
                Util.pnlListaActivar(true, btnPnlLista3);
                Util.pintarDatagridwiew(dgvListaFianzas,"Black","Gray");

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

        //Boton Cancelar
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            string namepage = tabControl1.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                await listarFianzas();
            }
            if (namepage == "tabPage2".ToString())
            {
                await listarEstadoValidaciones();
            }
        }

        //Datos para validar el formulario
        private async void frmEntrada_Load(object sender, EventArgs e)
        {
          
            //txtAnioBuscar.KeyPress += Utils.Wfa.onlyNumbers;
            dgvListaFianzas.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            //txtAnioBuscar.Text = DateTime.Now.Year.ToString();
            string namepage = tabControl1.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                txtBuscar.Enabled = false;
                cbxUnidadEjecutora.Enabled = false;
                cbxAnio.Enabled = false;
                await listarFianzas();
                txtBuscar.Enabled = true;
                cbxUnidadEjecutora.Enabled = true;
                cbxAnio.Enabled = true;
            }
            if (namepage == "tabPage2".ToString())
            {
                txtBuscar.Enabled = false;
                cbxUnidadEjecutora.Enabled = false;
                cbxAnio.Enabled = false;
                await listarEstadoValidaciones();
                txtBuscar.Enabled = true;
                cbxUnidadEjecutora.Enabled = true;
                cbxAnio.Enabled = true;
            }

            listarContador();
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

        //Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Listar segun el cambio de unidad Ejecutora
        private async void cbxUnidadEjecutora_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string namepage = tabControl1.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                await listarFianzas();
            }
            if (namepage == "tabPage2".ToString())
            {
                await listarEstadoValidaciones();
            }
            listarContador();
        }


        public void listarContador()
        {
            dgvContador_Impresion.DataSource = servicio.paContador_Impresion(Util.header);
            lblDafContador.Text = Utils.Utils.uppercaseFirstLetter(dgvContador_Impresion.Rows[0].Cells[2].Value.ToString()) + " -- " + dgvContador_Impresion.Rows[0].Cells[0].Value.ToString();
            lbTribunalAgroContador.Text = Utils.Utils.uppercaseFirstLetter(dgvContador_Impresion.Rows[1].Cells[2].Value.ToString()) + " -- " + dgvContador_Impresion.Rows[1].Cells[0].Value.ToString();
            lbConcejocontador.Text = Utils.Utils.uppercaseFirstLetter(dgvContador_Impresion.Rows[2].Cells[2].Value.ToString()) + " -- " + dgvContador_Impresion.Rows[2].Cells[0].Value.ToString();
            lbTribunalContador.Text = Utils.Utils.uppercaseFirstLetter(dgvContador_Impresion.Rows[3].Cells[2].Value.ToString()) + " -- " + dgvContador_Impresion.Rows[3].Cells[0].Value.ToString();
            lbJudicaturaContador.Text = Utils.Utils.uppercaseFirstLetter(dgvContador_Impresion.Rows[4].Cells[2].Value.ToString()) + " -- " + dgvContador_Impresion.Rows[4].Cells[0].Value.ToString();
        }

        void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here)  
        }
       
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                    string namepage = tabControl1.SelectedTab.Name;
                    if (namepage == "tabPage1".ToString())
                    {
                        await listarFianzas();
                    }
                    if (namepage == "tabPage2".ToString())
                    {
                        await listarEstadoValidaciones();
                    }
 
            }
            catch { };

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender, e);
            }
        }

        private async void btnImprimir_Click_1(object sender, EventArgs e)
        {
            await imprimir();
            listarContador();
            txtBuscar.Focus();
        }


        //Opcion Solo Numeros
        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyNumbers(sender, e);
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string namepage = tabControl1.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                await listarFianzas();
            }
            if (namepage == "tabPage2".ToString())
            {
                await listarEstadoValidaciones();
            }
        }

        private void dgvEstadoValidaciones_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void dgvEstadoValidaciones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private async void cbxAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string namepage = tabControl1.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                await listarFianzas();
            }
            if (namepage == "tabPage2".ToString())
            {
                await listarEstadoValidaciones();
            }
            listarContador();
        }



        //Limpiar al hacer Click
        private void txtAnio_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Clear();
        }

 
        private void dgvLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvListaFianzas.Rows)
                {

                    string validadoPor = item.Cells["fianza_impresa"].Value.ToString();
                  
                    int index = item.Index;

                    if (validadoPor=="Si")
                    {
                        Util.pintarDatagridwiewIndex(dgvListaFianzas, index, "Black", "Lime");
                    }
                    else
                    {
                        Util.pintarDatagridwiewIndex(dgvListaFianzas, index, "White", "Black");
                    }

                    dgvListaFianzas.ClearSelection();

                }
            }
            catch { }

        }

        //Insertamos numeracion
        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
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
            Utils.Wfa.positionHeadersDGV(dgvEstadoValidaciones, new List<string>() { "cargo", "apellidos_Y_Nombres", "ci", "item", "h_b", "total_Descuento", "total_Descontar", "Validado_Por_Habilitacion", "fecha_Habilitacion", "Usuario_Habilitacion", "Validado_Por_Contabilidad", "fecha_Contabilidad", "Usuario_Contabilidad" });
            Utils.Wfa.setHeadersDGV(dgvEstadoValidaciones);
            dgvEstadoValidaciones.AutoResizeColumns();
            dgvEstadoValidaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            frmCargando.Close();
        }
    }

   
}
