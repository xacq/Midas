
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
    public partial class FrmContabilidadValidacion: Form
    {
        SrMidasD.MidasDServiceClient servicio;

        SrMidasD.Usuario usuario;
        FrmCargando frmCargando;
        public int idFianzaIns, idUnidadEjecutoraIns,idTipoFianzaIns,mesIns,anioIns;
        public DateTime fechaActualServidor;
        public bool bandera;


        public bool c21 = false;


        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public FrmContabilidadValidacion(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
    
            this.usuario = usuario;

            btnPnlLista = new List<Control>() { 
             };
            btnPnlLista3 = new List<Control>() { btnSalir,grpListaSalidas};
            btnPnlLista2 = new List<Control>() {  btnEditar, btnImprimir,btnQuitarSeleccion };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos,panFuncionario,panBotones,grProductos };
            Util.btn_Mouse(new List<PictureBox>() {  btnEditar, btnImprimir,btnQuitarSeleccion,
            btnSalir });

            fechaActualServidor = servicio.fechaServidor();
            List<Item> listaAnio = new List<Item>();

            for (int i = 0; i < 4; i++)
            {
                listaAnio.Add(new Item((fechaActualServidor.Year - i).ToString(), i));
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
            txtc21.ResetText();
            
         
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

                if (dr.Cells["idDescuento"].Value != null)
                {
                    Descuento descuento = servicio.descuentoGet(Util.header, Convert.ToInt32(dr.Cells["idDescuento"].Value));
                    //Aqui Editamos casa Descuento
                    descuento.idFianza = descuento.idFianza;
                    descuento.c21 =Convert.ToInt32(txtc21.Text.ToString());
                    descuento.validado = true;
                    descuento.validado_Por = usuario.nombre_Usuario;
                    servicio.descuentoEditar(Util.header,descuento);
                }
            }
            MessageBox.Show("Los descuentos del mes han sido validados correctamente.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult ResultadoDialogo = MessageBox.Show("Desea Imprimir Reporte/Nota de Validacion.\r¿Desea continuar?.", "::: Midas - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                imprimir();
            }

            limpiarcampos();

            frmCargando.Close();

            await listarFianzas();
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

            idUnidadEjecutoraIns = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["idUnidadEjecutora"].Value);
            mesIns = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["mes"].Value);
            anioIns = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["anio"].Value);

            //Cargamos los Datos Dinamicos a una Grilla Auxiliar para luego Añadirlos Uno a Uno al la Grilla de Trabajo
            dgvListaAux.DataSource = servicio.pafuncionarioFianzaActualBuscarContaVali(Util.header, "",idUnidadEjecutoraIns,2,mesIns,anioIns);
            
            foreach (DataGridViewRow dr in dgvListaAux.Rows)
            {
                int idDescuento =Convert.ToInt32(dr.Cells["idDescuentoAux"].Value.ToString());
                string cargo = dr.Cells["cargoAux"].Value.ToString();
                string nombre_Completo = dr.Cells["nombre_CompletoAux"].Value.ToString();
                string haber_mensual = dr.Cells["haber_mensualAux"].Value.ToString();
                double total_Descuento = Convert.ToDouble(dr.Cells["total_DescuentoAux"].Value);
                double total_Descontar = Convert.ToDouble(dr.Cells["total_DescontarAux"].Value);
                double falta_descontar = Convert.ToDouble(dr.Cells["falta_DescontarAux"].Value);
                double a_Validar = Convert.ToDouble(dr.Cells["a_ValidarAux"].Value);
                int c_21 = Convert.ToInt32(dr.Cells["c_21Aux"].Value);

                dgvLista.Rows.Add(cargo, nombre_Completo, haber_mensual, total_Descuento,total_Descontar,falta_descontar, a_Validar,c_21, 0, idDescuento);
                try
                {
                    txtc21.Text = dr.Cells["c_21Aux"].Value.ToString();
                }
                catch { }
            }
            Util.pintarDatagridwiew(dgvListaFianzas, "Gray", "Gray");

            frmCargando.Close();
        }

        //Verificacion de un Nuevo Registro
        public void verificarNuevo()
        {

            if (string.IsNullOrEmpty(txtc21.Text))
            {
                c21 = false;
            }
            else
            {
                c21 = true;
            }
        }

        //Validacion de Campos
        private bool validarCampos()
        {
            limpiarErrores();
            verificarNuevo();

            if (!c21)
            {
                Util.errorMensaje(erpError, txtc21, "Debe Introducir el c21");
            }

           
            if (c21 == true)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            paFianzasListarMesAnioContaVali_Result[] asyncVariable1 = await this.servicio.pafianzaListarFianzasMesAnioContaValiAsync(Util.header, Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()), 2, Convert.ToInt32(cbxAnio.SelectedItem.ToString()));
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvListaFianzas, new List<string>() { "idUnidadEjecutora" });
            Utils.Wfa.positionHeadersDGV(dgvListaFianzas, new List<string>() { "Unidad_Ejecutora", "mes","anio", "Funcionarios", "Registrado_Por","Validado_Por","todos_Validados"});
            Utils.Wfa.setHeadersDGV(dgvListaFianzas);
            dgvListaFianzas.AutoResizeColumns();
            dgvListaFianzas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                Util.pnlListaActivar(false, btnPnlDatos);
                Util.pnlListaActivar(false, btnPnlLista2);
                Util.pnlListaActivar(true, btnPnlLista);
                Util.pnlListaActivar(true, btnPnlLista3);
                Util.pintarDatagridwiew(dgvListaFianzas,"Black","Gray");
                limpiarcampos();

            frmCargando.Close();
        }

        //Boton Cancelar
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
           await cancelar();
        }


        public async Task cancelar()
        {
            limpiarErrores();
            limpiarcampos();
            await listarFianzas();

            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bandera)
            {
                if (!validarCampos())
                { }
                else
                {
                   //fianzaDescuentoInsertar();     
                }
            }
            else
            {
                if (!validarCampos())
                { }
                else
                {
                    await fianzaDescuentoEditar();
                }
            }
        }

     

        //Datos para validar el formulario
        private async void frmEntrada_Load(object sender, EventArgs e)
        {
            txtc21.KeyPress += Utils.Wfa.onlyNumbers;
            txtc21.MouseDown += Utils.Wfa.notButtonRight;
            //txtAnioBuscar.KeyPress += Utils.Wfa.onlyNumbers;
            dgvLista.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            dgvListaFianzas.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            //txtAnioBuscar.Text = servicio.fechaServidor().Year.ToString();

            cbxAnio.Enabled = false;
            cbxUnidadEjecutora.Enabled = false;
            await listarFianzas();
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
        private void dgvListaFianzas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
        }

        //Habilitar las opciones Editar
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            await cargarCamposFianzas();
            verificarNuevo();

            bandera = false;

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
        }

      

        //Habilitar Opciones de Registro Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            verificarNuevo();
            limpiarcampos();

            bandera = true;
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlLista2);
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
            
            await listarFianzas();
        }

        private async void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        private async void dgvListaFianzas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarErrores();
            await cargarCamposFianzas();
            verificarNuevo();

            bandera = false;

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
        }

        private async void cbxAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await listarFianzas();
        }

        void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here)  
        }
       

        private void dgvLista_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = dgvLista.Rows[e.RowIndex];
           
        }
       
        
        //Opcion Solo Numeros
        private async void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyNumbers(sender, e);

            string nombre = ((TextBox)sender).Name.ToString();
            if (nombre == "txtc21")
            {
                erpError.Clear();
                c21= true;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                await listarFianzas();
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
                foreach (DataGridViewRow item in dgvListaFianzas.Rows)
                {

                    string todos_Validados = item.Cells["todos_Validados"].Value.ToString();
                  
                    int index = item.Index;

                    if (todos_Validados== "Si")
                    {
                        Util.pintarDatagridwiewIndex(dgvListaFianzas, index, "Black", "Lime");
                    }
                    else
                    {
                        Util.pintarDatagridwiewIndex(dgvListaFianzas, index, "White", "Black");
                    }

                    dgvLista.ClearSelection();

                }
            }
            catch { }

        }

        //Insertamos numeracion
        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

    }

   
}
