
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
    public partial class FrmHabilitadoDescuento: Form
    {
        SrMidasD.MidasDServiceClient servicio;
        FrmCargando frmCargando;
        SrMidasD.Usuario usuario;
  
        public int idFianzaIns, idUnidadEjecutoraIns,idTipoFianzaIns,mesIns,anioIns;
        public DateTime fechaActualServidor;
        public bool bandera;

        public double  cantidadDescuento;

        DataGridViewCellEventArgs ee;
        public double CantidadActual;
        public bool mesDescuento = false;
        public bool anioDescuento = false;

        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public FrmHabilitadoDescuento(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
    
            this.usuario = usuario;

            btnPnlLista = new List<Control>() { btnNuevo };
            btnPnlLista3 = new List<Control>() { btnSalir,grpListaSalidas};
            btnPnlLista2 = new List<Control>() {  btnEditar, btnImprimir };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos,panFuncionario,panBotones,grProductos };
            Util.btn_Mouse(new List<PictureBox>() { btnNuevo, btnEditar, btnImprimir,
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

            cbxAnioDescuento.DisplayMember = "Name";
            cbxAnioDescuento.ValueMember = "Value";
            cbxAnioDescuento.DataSource = listaAnio;

            cbxAnioDescuento.SelectedValue = 0;

            cargarUnidadEjecutora();

            if(servicio.rolUsuarioGetIdUsuario(Util.header,usuario.idUsuario).idRol==1)
            {
                btnEditar.Visible=true;
            }
            else
            {
                btnEditar.Visible = false;
            }
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
            //txtAnio.Text = fechaActualServidor.Year.ToString();
            //txtAnioBuscar.Text = fechaActualServidor.Year.ToString();
            cbxAnio.SelectedValue = 0;
            cbxAnioDescuento.SelectedValue = 0;

            cbxMes.SelectedValue = fechaActualServidor.Month;
            cbxMes.Enabled = true;
            cbxAnioDescuento.Enabled = false;
         
            try
            {
                dgvLista.Rows.Clear();
            }
            catch { }
        }

        //Reiniciar Verificacion
        public void reiniciarVerificacion()
        {
            mesDescuento = false;
            anioDescuento = false;
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
                MessageBox.Show("La Fianza ha sido registrada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult ResultadoDialogo = MessageBox.Show("Desea Imprimir Reporte/Nota de Fianza.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ResultadoDialogo == DialogResult.Yes)
                {
                    imprimir();
                }
            }
            catch
            {
                MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fianzaDescuentoEditar()
        {
            foreach (DataGridViewRow dr in dgvListaAux.Rows)/*Eliminacion Fisica Descuento*/
            {
                servicio.descuentoEliminarfisico(Util.header, Convert.ToInt32(dr.Cells["idFianzaAux"].Value),mesIns,anioIns);
            }

            foreach (DataGridViewRow dr in dgvLista.Rows)
            {

                if (dr.Cells["idDescuento"].Value == null || Convert.ToInt32(dr.Cells["idDescuento"].Value) == 0)
                {
                    SrMidasD.Descuento descuento = new SrMidasD.Descuento();
                    insertarFDN(Convert.ToInt32(dr.Cells["idFianza"].Value), descuento, dr);//Si es es registro nuevo en  detalle salida Nornal mandamos como idDescuento 0
                }
            }
            MessageBox.Show("La Fianza ha sido Editada.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult ResultadoDialogo = MessageBox.Show("Desea Imprimir Reporte/Nota de Salida.\r¿Desea continuar?.", "::: Midas - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                imprimir();
            }

            limpiarcampos();
        }

        public void insertarFDN(int idFianzaFD, SrMidasD.Descuento descuento, DataGridViewRow dr)//Reutilizamos Insertar Detalle Venta Como para Insertar Un Nuevo Detalle venta en su Editar
        {
 
            descuento.idFianza = idFianzaFD;
         
            descuento.idFianza = Convert.ToInt32(dr.Cells["idFianza"].Value);
            descuento.monto_Beneficiario = Math.Round(Convert.ToDouble(dr.Cells["a_Descontar"].Value), 2);
            descuento.mes = Convert.ToInt32(cbxMes.SelectedValue.ToString());
            descuento.anio = Convert.ToInt32(cbxAnioDescuento.SelectedItem.ToString());
            descuento.observacion = "Mes Descuento Regular";
            descuento.usuarioRegistro = usuario.nombre_Usuario;
            descuento.registroActivo = true;
            descuento.fechaRegistro = fechaActualServidor;

            int idDescuento = servicio.descuentoInsertar(Util.header, descuento);
        }

        //Se cargan campos para Editar y cambiar Datos
        private void cargarCamposFianzas()
        {
            idUnidadEjecutoraIns = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["idUnidadEjecutora"].Value);
            mesIns = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["mes"].Value);
            anioIns = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["anio"].Value);
            cbxMes.SelectedValue = mesIns;
            cbxAnio.SelectedItem = anioIns.ToString();

            //Cargamos los Datos Dinamicos a una Grilla Auxiliar para luego Añadirlos Uno a Uno al la Grilla de Trabajo
            dgvListaAux.DataSource = servicio.palistarFianzasMesAnioEditar(Util.header,"",idUnidadEjecutoraIns,2,mesIns,anioIns);
            foreach (DataGridViewRow dr in dgvListaAux.Rows)
            {

                string cargo = dr.Cells["cargoAux"].Value.ToString();
                string idFianza = dr.Cells["idFianzaAux"].Value.ToString();
                string nombre_Completo = dr.Cells["nombre_CompletoAux"].Value.ToString();
                string ci = dr.Cells["ciAux"].Value.ToString();
                string item = dr.Cells["itemAux"].Value.ToString();
                string haber_mensual = dr.Cells["haber_mensualAux"].Value.ToString();
                double total_Descuento = Convert.ToDouble(dr.Cells["total_DescuentoAux"].Value);
                double total_Descontar = Convert.ToDouble(dr.Cells["total_DescontarAux"].Value);
                double falta_Descontar = Convert.ToDouble(dr.Cells["falta_DescontarAux"].Value);
                double a_Descontar = Convert.ToDouble(dr.Cells["a_DescontarAux"].Value);

                dgvLista.Rows.Add(cargo, nombre_Completo, ci, item, haber_mensual, total_Descontar,total_Descuento, falta_Descontar, a_Descontar, idFianza, 0);
                dgvLista.Rows[dgvLista.Rows.Count - 1].Cells["a_Descontar"].Selected = true;
            }
            Util.pintarDatagridwiew(dgvListaFianzas, "Gray", "Gray");
        }

        //Verificacion de un Nuevo Registro
        public void verificarNuevo()
        {


            if (cbxMes.SelectedIndex == -1)
            {
                mesDescuento = false;
            }
            else
            {
                mesDescuento = true;
            }

            if (cbxAnioDescuento.SelectedIndex == -1)
            {
                anioDescuento = false;
            }
            else
            {
                anioDescuento = true;
            }
        }

        //Validacion de Campos
        private bool validarCampos()
        {
            limpiarErrores();
            verificarNuevo();

            if (!mesDescuento)
            {
                Util.errorMensaje(erpError, cbxMes, "Debe Introducir Mes Descuento");
            }

            if (!anioDescuento)
            {
                Util.errorMensaje(erpError, cbxAnio, "Debe Introducir Año");
            }

            

            if (mesDescuento == true && anioDescuento == true)
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
            paFianzasListarMesAnioDescuentos_Result[] asyncVariable1 = await this.servicio.pafianzaListarFianzasMesAnioDescuentosAsync(Util.header, Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()), 2, Convert.ToInt32(cbxAnio.SelectedItem.ToString()));
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvListaFianzas, new List<string>() { "idUnidadEjecutora" });
            Utils.Wfa.positionHeadersDGV(dgvListaFianzas, new List<string>() { "Unidad_Ejecutora", "mes","anio", "Funcionarios"});
            Utils.Wfa.setHeadersDGV(dgvListaFianzas);
            dgvListaFianzas.AutoResizeColumns();
            dgvListaFianzas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                Util.pnlListaActivar(false, btnPnlDatos);
                Util.pnlListaActivar(false, btnPnlLista2);
                Util.pnlListaActivar(true, btnPnlLista);
                Util.pnlListaActivar(true, btnPnlLista3);
                Util.pintarDatagridwiew(dgvListaFianzas,"Black","Gray");

            frmCargando.Close();
        }

        //Boton Cancelar
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            await cancelar();
            tabControl1.SelectedTab = tpgRegEntes;
        }

        private async Task cancelar()
        {
            limpiarErrores();
            limpiarcampos();
            await listarFianzas();

            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
        }

        //Busqueda de Funcionarios segun Unidad Ejecutora
        private void btnFuncionarios_Click(object sender, EventArgs e)
        { 
                new FrmSeleccionarFuncionario("Habilitado").ShowDialog();
                insertarListaprevia(FrmSeleccionarFuncionario.listaFuncionarioFianza);  
        }

        /*Insertar en una Lista previa para cargar los datos*/
        private void insertarListaprevia(string[] listaFuncionarioFianza)
        {
                int contador = 0;
                SrMidasD.Fianza fianz;
                foreach (string itemChecked in listaFuncionarioFianza)
                {
                    fianz = new Fianza();
                    fianz = servicio.fianzaGet(Util.header, Convert.ToInt32(listaFuncionarioFianza[contador]));
                    insertarLista(fianz);
                    contador++;

                }
        }

        /*se inserta en una lista auxiliar para luego cargar en la lista oficial*/
        private void insertarLista(SrMidasD.Fianza fianz)
        {
            if (fianz != null)
            {
                Descuento fianzaFuncionarioMes = servicio.descuentoVerificarMesRegistrado(Util.header, fianz.idFianza, Convert.ToInt32(cbxMes.SelectedValue.ToString()), Convert.ToInt32(cbxAnio.SelectedItem.ToString()));
                if (fianzaFuncionarioMes == null)
                {
                    int row = existeFianzDgv(fianz.idFianza);
                    if (row == -1)
                    {
                        int idFuncionario = (int)servicio.fianzaGet(Util.header, (int)fianz.idFianza).idFuncionario;
                        int idOficina = (int)servicio.funcionarioGet(Util.header, (int)idFuncionario).idOficina;
                        dgvListaAux.DataSource = servicio.pafuncionarioFianzaActualBuscaridFianza(Util.header, (int)servicio.oficinaGet(Util.header, idOficina).idUnidadEjecutora, fianz.idFianza);
                        foreach (DataGridViewRow dr in dgvListaAux.Rows)
                        {
                            string cargo = dr.Cells["cargoAux"].Value.ToString();
                            string nombre_Completo = dr.Cells["nombre_CompletoAux"].Value.ToString();
                            string ci = dr.Cells["ciAux"].Value.ToString();
                            string item = dr.Cells["itemAux"].Value.ToString();
                            string haber_mensual = dr.Cells["haber_mensualAux"].Value.ToString();
                            double total_Descuento = Convert.ToDouble(dr.Cells["total_DescuentoAux"].Value);
                            double total_Descontar = Convert.ToDouble(dr.Cells["total_DescontarAux"].Value);
                            double falta_Descontar = Convert.ToDouble(dr.Cells["falta_DescontarAux"].Value);
                            double a_Descontar = Convert.ToDouble(dr.Cells["a_DescontarAux"].Value);

                            /*cargo,nombre_Completo,ci,item,haber_mensual,total_Descuento,total_Descontar,falta_descontar,a_Descontar,idFianza,idDescueno*/
                            dgvLista.Rows.Add(cargo, nombre_Completo, ci, item, haber_mensual, total_Descuento, total_Descontar, falta_Descontar, a_Descontar, fianz.idFianza, 0);
                        }
                    }
                    else
                    {
                        dgvLista.Rows[row].Cells[0].Selected = true;
                        MessageBox.Show("El Funcionario ya se encuentra en la Lista", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El Funcionario ya tiene el mes de Descuento Registrado", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (dgvLista.Rows.Count > 0)
                btnGuardar.Enabled = true;
            else btnGuardar.Enabled = false;
        }

        //Verificar si existe ya insertada la idfianza de un funcionario
        private int existeFianzDgv(int idFianza)
        {
            foreach (DataGridViewRow dr in dgvLista.Rows)
                if (Convert.ToInt32(dr.Cells["idFianza"].Value.ToString()) == idFianza)
                    return dr.Index;
            return -1;
        }

       //validar el campo descontar
        private int validarTotalDgv()
        {
            foreach (DataGridViewRow dr in dgvLista.Rows)
                if (Convert.ToDouble(dr.Cells["a_Descontar"].Value) <= 0)
                    return dr.Index;
            return -1;
        }

        private void dgvLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ///*Solo Refrescamos la Columnna Evitando que se Realize todo El Calculo Innesesario*/
                if (e.ColumnIndex == 7)
                {
                    CantidadActual = Math.Round(Convert.ToDouble(dgvLista.Rows[e.RowIndex].Cells["a_Descontar"].Value), 2);
                    /*Sacamos la cantidad Actual que se edita que no sea menor a 0*/
                    
                    if (CantidadActual <= 0)
                    {
                        MessageBox.Show("Cantidad Solicitada no debe ser menor a\n" + ": " + 0, "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int idFuncionario = (int)servicio.fianzaGet(Util.header, Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["idFianza"].Value.ToString())).idFuncionario;
                        int idOficina = (int)servicio.funcionarioGet(Util.header, idFuncionario).idOficina;
                        dgvLista.Rows[e.RowIndex].Cells["a_Descontar"].Value = Math.Round(Convert.ToDouble(dgvLista.Rows[e.RowIndex].Cells["haber_Mensual"].Value) * Convert.ToDouble(servicio.oficinaGet(Util.header, idOficina).porcentaje_Descuento),0);
                    }
                    else//Si es cero se coloca de nuevo el valor de descuento por mes
                    {
                        dgvLista.Rows[e.RowIndex].Cells["a_Descontar"].Value = CantidadActual;
                    }

                }
                else
                {/*Calculamos Todos Los Demas Valores*/

                }
            }
            catch (Exception) { }
        }

       

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bandera)
            {
                if (!validarCampos())
                { }
                else
                {
                    
                        int rowTotal = validarTotalDgv();
                        if (rowTotal == -1)
                        {
                            //f = dtpFecha.Value;

                            fianzaDescuentoInsertar();
                            await listarFianzas();
                        }
                        else
                        {
                            dgvLista.Rows[rowTotal].Cells["a_Descontar"].Selected = true;
                            MessageBox.Show("La Cantidad debe ser mayor a Cero (0).", "::: MidasD - Error :::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    //}
                }
            }
            else
            {
                if (!validarCampos())
                { }
                else
                {
                    fianzaDescuentoEditar();
                    await listarFianzas();
                }
            }
        }

        
        private void dgvLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dgvLista.CurrentCell.ColumnIndex;
            if (column == 10)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    Util.notPaste = false;
                    txt.KeyPress += Utils.Wfa.onlyDecimals;
                    txt.MouseDown += Utils.Wfa.notButtonRight;
                }
            }
        }

        //Datos para validar el formulario
        private async void frmEntrada_Load(object sender, EventArgs e)
        {
            //txtAnio.KeyPress += Utils.Wfa.onlyNumbers;
            //txtAnio.MouseDown += Utils.Wfa.notButtonRight;
            //txtAnioBuscar.KeyPress += Utils.Wfa.onlyNumbers;
            //txtAnioBuscar.MouseDown += Utils.Wfa.notButtonRight;
            dgvLista.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            dgvListaFianzas.RowPostPaint += Utils.Wfa.rowPostPaintDGV;


            List<Item> lista = new List<Item>();

            int mesActual = fechaActualServidor.Month;

            if(1<=mesActual)
            {
                lista.Add(new Item("Enero", 1));
            }
            if (2 <= mesActual)
            {
                lista.Add(new Item("Febrero", 2));
            }
            if (3 <= mesActual)
            {
                lista.Add(new Item("Marzo", 3));
            }
            if (4 <= mesActual)
            {
                lista.Add(new Item("Abril", 4));
            }
            if (5 <= mesActual)
            {
                lista.Add(new Item("Mayo", 5));
            }
            if (6 <= mesActual)
            {
                lista.Add(new Item("Junio", 6));
            }
            if (7 <= mesActual)
            {
                lista.Add(new Item("Julio", 7));
            }
            if (8 <= mesActual)
            {
                lista.Add(new Item("Agosto", 8));
            }
            if (9 <= mesActual)
            {
                lista.Add(new Item("Septiembre", 9));
            }
            if (10 <= mesActual)
            {
                lista.Add(new Item("Octubre", 10));
            }
            if (11 <= mesActual)
            {
                lista.Add(new Item("Noviembre", 11));
            }
            if (12 <= mesActual)
            {
                lista.Add(new Item("Diciembre", 12));
            }


           
           
            cbxMes.DisplayMember = "Name";
            cbxMes.ValueMember = "Value";
            cbxMes.DataSource = lista;

            //
            // Se asigna el evento para control el cambio de seleccion
            //
            cbxMes.SelectedIndexChanged += new System.EventHandler(this.cbxMes_SelectedIndexChanged);

            cbxMes.SelectedValue = fechaActualServidor.Month;
            cbxMes.Enabled = false;
            //txtAnio.Text = fechaActualServidor.Year.ToString();
            //txtAnioBuscar.Text = fechaActualServidor.Year.ToString();

            await listarFianzas();
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
            //Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
        }

        //Habilitar las opciones Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            cargarCamposFianzas();
            tabControl1.SelectedTab = tpgNuevoReg;
            verificarNuevo();

            bandera = false;

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
        }

        //Dar de Baja un registro total
        private void btnBaja_Click(object sender, EventArgs e)
        {
            limpiarErrores();

            DialogResult ResultadoDialogo = MessageBox.Show("La Entrada será dado de baja.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                //cargarCamposSalida();
                //int idFianzaAux = 0; 
                //foreach (DataGridViewRow dr in dgvListaAux.Rows)/*Eliminacion Fisica SalidaDetalle-SalidaPorEntrada-ActualizacionSaldo*/
                //{
                //    idFianzaAux = (int)servicio.salidaDetalleGet(Util.header, Convert.ToInt32(dr.Cells["idFianzaDetalleAux"].Value)).idFianza;
                //    servicio.articuloSalidaDevolucion(Util.header, Convert.ToInt32(dr.Cells["idFianzaDetalleAux"].Value), false);
                //}
                //servicio.articuloSalidaDevolucion(Util.header, idFianzaAux, true);//Borramos la Salida unica y le mandamos el codigo de Salida
                //MessageBox.Show("La Salida ha sido dado de baja.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //listarFianzas();
                //limpiarcampos();
            }
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

        void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here)  
        }
       

        private void dgvLista_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = dgvLista.Rows[e.RowIndex];
           
        }
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                this.ee = e;
            }
            catch { }
        }

        private async void txtAnioBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                await listarFianzas();
            }
        }

        private async void cbxAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await listarFianzas();
        }

        //Opcion eliminar Fila
        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount >= 1)
            {
                int fila = dgvLista.CurrentRow.Index;
                if (fila != dgvLista.RowCount)
                {
                    DialogResult ResultadoDialogo = MessageBox.Show("Se va a eliminar la Entrada Venta seleccionada.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ResultadoDialogo == DialogResult.Yes)
                    {
                        dgvLista.Rows.RemoveAt(fila);
                        MessageBox.Show("Entrada Salida eliminada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Entrada Salida", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No existen Entrada Salida para eliminar", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }

        //Limpiar al hacer Click
        private void txtAnio_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Clear();
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item seleccion = cbxMes.SelectedItem as Item;

            if (seleccion == null)
                return;
        }

 
        //Verificar los Estados de las Fianzas
        private void btnProductoSaldo_Click(object sender, EventArgs e)
        {
            new FrmEstadoFianzasActuales(usuario).ShowDialog();
        }

        //Opcion Imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        public void imprimir()
        {
          try
            {
                int mes = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["mes"].Value);
                int anio = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["anio"].Value);
                int idUnidadEjecutora = Convert.ToInt32(dgvListaFianzas.Rows[dgvListaFianzas.CurrentRow.Index].Cells["idUnidadEjecutora"].Value);
                cbxMes.SelectedValue = mes;
                string mesLit = cbxMes.SelectedItem.ToString();
                new FrmCrFormularioA2(2, mes, mesLit, anio, idUnidadEjecutora, usuario.nombre_Usuario).ShowDialog();
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

    }
}
