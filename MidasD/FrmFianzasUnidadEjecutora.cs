
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
    public partial class FrmFianzasUnidadEjecutora : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        public DateTime fechaActualServidor;
        SrMidasD.Usuario usuario;
        FrmCargando frmCargando;
        public int idFianzaIns, idUnidadEjecutoraIns,idTipoFianzaIns,mesIns,anioIns;
        public DateTime f;
        public bool bandera;
        public bool c21 = false;


        List<Control>  btnPnlLista3;

        public FrmFianzasUnidadEjecutora(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();

            this.usuario = usuario;

            btnPnlLista3 = new List<Control>() { btnSalir,grpListaSalidas};

            Util.btn_Mouse(new List<PictureBox>() { btnSalir,btnImprimir });

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

            //await listarFianzas();
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

        public async void imprimir()
        {
            new FrmCrFianzasUnidadEjecutora(2,3, Convert.ToInt32(cbxMes.SelectedValue.ToString()),Convert.ToInt32(cbxAnio.SelectedItem.ToString()),usuario.nombre_Usuario,Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString())).ShowDialog();
            await listarFianzas();
        }



        //Limpiar Errores
        public void limpiarErrores()
        {
            erpError.Clear();
        }

        //Listar Fianzas Registradas Por Unidad Ejecutora
        private async Task listarFianzas()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvListaFianzas;
            paListarFianzasEconomicasReporteGlobalUnidadEjecutora_Result[] asyncVariable1=await this.servicio.paListarFianzasEconomicasReporteGlobalUnidadEjecutoraAsync(Util.header, txtBuscar.Text, 2, 3, Convert.ToInt32(cbxMes.SelectedValue), Convert.ToInt32(cbxAnio.SelectedItem.ToString()), Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            dgvListaFianzas.Columns["Nro_Fianza"].DisplayIndex = 01;
            dgvListaFianzas.Columns["apellidos_Y_Nombres"].DisplayIndex = 02;
            dgvListaFianzas.Columns["sigma"].DisplayIndex = 03;
            dgvListaFianzas.Columns["cargo"].DisplayIndex = 04;
            dgvListaFianzas.Columns["oficina"].DisplayIndex = 05;
            dgvListaFianzas.Columns["total_Descuento"].DisplayIndex = 06;


            Utils.Wfa.hideHeadersDGV(dgvListaFianzas, new List<string>() {"idFianza" });
            Utils.Wfa.setHeadersDGV(dgvListaFianzas);
            dgvListaFianzas.AutoResizeColumns();
            dgvListaFianzas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

             
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pintarDatagridwiew(dgvListaFianzas,"Black","Gray");
            frmCargando.Close();
              
        }

        //Boton Cancelar
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
           
             await  listarFianzas();
        }

        //Datos para validar el formulario
        private async void frmEntrada_Load(object sender, EventArgs e)
        {
          
            //txtAnioBuscar.KeyPress += Utils.Wfa.onlyNumbers;
            dgvListaFianzas.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            //txtAnioBuscar.Text = DateTime.Now.Year.ToString();

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

            cbxMes.SelectedValue = fechaActualServidor.Month;

            txtBuscar.Enabled = false;
            cbxAnio.Enabled = false;
            cbxMes.Enabled = false;
            cbxUnidadEjecutora.Enabled = false;
            await listarFianzas();
            txtBuscar.Enabled = true;
            cbxAnio.Enabled = true;
            cbxMes.Enabled = true;
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

        //Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            //frmCargando = new FrmCargando();
            //frmCargando.Show();
            //await Task.Delay(250);
            imprimir();
            txtBuscar.Focus();
            //frmCargando.Close();
        }


        //Opcion Solo Numeros
        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyNumbers(sender, e);
        }

        private async void cbxAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await listarFianzas();
        }

        private void dgvEstadoValidaciones_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }


        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item seleccion = cbxMes.SelectedItem as Item;

            if (seleccion == null)
                return;
        }

        //Limpiar al hacer Click
        private void txtAnio_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Clear();
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
