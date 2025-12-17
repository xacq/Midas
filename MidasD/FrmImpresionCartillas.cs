
using CrystalDecisions.Shared;
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
    public partial class FrmImpresionCartillas: Form
    {
        SrMidasD.MidasDServiceClient servicio;

        SrMidasD.Usuario usuario;
        Reportes.CrCartilla reporte;
        string folderPath,montoDevolucion,notaDevolucion;
        List<Control>  btnPnlLista3;
        FrmCargando frmCargando;

        public FrmImpresionCartillas(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
    
            this.usuario = usuario;

          
            btnPnlLista3 = new List<Control>() { btnImprimir};

            Util.btn_Mouse(new List<PictureBox>() { btnImprimir,btnSalir});

        }


        public async Task imprimir()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            reporte = new Reportes.CrCartilla();
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DiskFileDestinationOptions dest = new DiskFileDestinationOptions();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowser.SelectedPath;
            }

            foreach (DataGridViewRow dr in dgvLista.Rows)
            {

                if (dr.Cells["idDescuento"].Value == null || Convert.ToInt32(dr.Cells["idDescuento"].Value) == 0)
                {
                    

                    List<SrMidasD.paReporteCartilla_Result> datos = servicio.paFianzaReporteCartilla(Util.header, Convert.ToInt32(dr.Cells["idFianza"].Value)).ToList();
                    int idFianza = Convert.ToInt32(dr.Cells["idFianza"].Value);
                    Funcionario funciDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header,idFianza).idFuncionario);
                    SrMidasD.Persona persoDatos = servicio.personaGet(Util.header, (int)funciDatos.idPersona);
                    Cargo cargoDatos = servicio.cargoGet(Util.header,(int) funciDatos.idCargo);
                    Oficina ofiDatos = servicio.oficinaGet(Util.header, (int)funciDatos.idOficina);
                    EscalaSalarial escaDatos = servicio.escalaSalarialGet(Util.header,(int)cargoDatos.idEscalaSalarial);

                    string nroMemorando = funciDatos.numero_Memorando;
                    string nombreCompleto = persoDatos.paterno.ToUpper() + " " + persoDatos.materno.ToUpper() + " " + persoDatos.nombres.ToUpper();
                    string numeroDocumento = persoDatos.numero_Documento;
                    string tipoContrato = funciDatos.vigencia_Contrato.ToUpper();
                    string item = funciDatos.tipo_Contrato_Item.ToString();
                    string cargoOficina = cargoDatos.descripcion_Puesto.ToUpper() + " " + ofiDatos.oficina1.ToUpper();
                    string haberMensual = string.Format("{0:#,0.00}", servicio.sueldoMensualGet(Util.header, (int)escaDatos.idSueldoMensual).monto);
                    string cuantia = ofiDatos.cuantia.ToString();
                    string totalDescontar =string.Format("{0:#,0.00}", Convert.ToDouble(haberMensual) * Convert.ToDouble(cuantia));
                    string porcentajeDescuento = (ofiDatos.porcentaje_Descuento).ToString();
                    string totalDescuentoMes =Convert.ToString((Convert.ToDouble(haberMensual)  * ofiDatos.porcentaje_Descuento));
                    string cantidadMeses = Math.Round(Convert.ToDouble(totalDescontar)/Convert.ToDouble(totalDescuentoMes)).ToString();
                    string nroFianza = servicio.fianzaGet(Util.header,idFianza).Nro_Fianza.ToString();

                    try
                    {
                         montoDevolucion = servicio.devolucionGetidFianza(Util.header, idFianza).monto_Devolucion.ToString();
                         notaDevolucion = servicio.devolucionGetidFianza(Util.header, idFianza).observacion.ToString();
                    }
                    catch
                    {
                         montoDevolucion = "0";
                         notaDevolucion = "";
                    }

                    if (datos.Count > 0)
                    {
                        try
                        {

                            reporte.Subreports["CrSCartilla.rpt"].SetDataSource(datos);
                            reporte.SetParameterValue("nroMemorando", nroMemorando);
                            reporte.SetParameterValue("nombresApellidos", nombreCompleto);
                            reporte.SetParameterValue("ci", numeroDocumento);
                            reporte.SetParameterValue("contrato", tipoContrato);
                            reporte.SetParameterValue("item", item);
                            reporte.SetParameterValue("cargo", cargoOficina);
                            reporte.SetParameterValue("hb", haberMensual);
                            reporte.SetParameterValue("cuantia", cuantia);
                            reporte.SetParameterValue("porcentaje", porcentajeDescuento);
                            reporte.SetParameterValue("total", totalDescontar);
                            reporte.SetParameterValue("totalMes", totalDescuentoMes);
                            reporte.SetParameterValue("cantidadMeses", cantidadMeses);
                            if(servicio.fianzaGet(Util.header, idFianza).Nro_Fianza!=null)
                            {
                                reporte.SetParameterValue("fianza", servicio.fianzaGet(Util.header, idFianza).Nro_Fianza);
                            }
                            else
                            {
                                reporte.SetParameterValue("fianza", "0");
                            }
                            if (servicio.fianzaGet(Util.header,idFianza).idTipoFianza == 2)
                            {
                                reporte.SetParameterValue("tipoFianza", "PLANILLA DE CONTROL DE DESCUENTO DEL 20% PARA FIANZA ECONOMICA");
                            }
                            if (servicio.fianzaGet(Util.header, idFianza).idTipoFianza == 3)
                            {
                                reporte.SetParameterValue("tipoFianza", "PLANILLA DE CONTROL DE FIANZA ECONOMICA EN DEPOSITO TOTAL");
                            }
                            reporte.SetParameterValue("montoDevolucion",montoDevolucion);
                            reporte.SetParameterValue("notaDevolucion", notaDevolucion);
                            reporte.SetParameterValue("usuario", usuario.nombre_Usuario);
                           
                            //Esportamos a una ruta Fisica
                            dest.DiskFileName = folderPath + "\\" + nroFianza + "_"+nombreCompleto + ".pdf";
                            // 
                            PdfFormatOptions formatOpt = new PdfFormatOptions();
                            formatOpt.FirstPageNumber = 0;
                            formatOpt.LastPageNumber = 0;
                            formatOpt.UsePageRange = false;
                            formatOpt.CreateBookmarksFromGroupTree = false;
                            // 
                            ExportOptions ex = new ExportOptions();
                            ex.ExportDestinationType = ExportDestinationType.DiskFile;
                            ex.ExportDestinationOptions = dest;
                            ex.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ex.ExportFormatOptions = formatOpt;
                            // 
                            reporte.Export(ex);
                          
                        }
                        catch
                        {
                            MessageBox.Show("No se Puede Imprimir - Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }

            }

          
            frmCargando.Close();
            MessageBox.Show(" Se ha Guardado los PDF correctamente", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



        //Busqueda de Funcionarios segun Unidad Ejecutora
        private async void btnFuncionarios_Click(object sender, EventArgs e)
        {
            new FrmSeleccionarFuncionario("CartillaContabilidad").ShowDialog();
            await insertarListaprevia(FrmSeleccionarFuncionario.listaFuncionarioFianza);
        }

        /*Insertar en una Lista previa para cargar los datos*/
        private async Task insertarListaprevia(string[] listaFuncionarioFianza)
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            int contador = 0;
            SrMidasD.Fianza fianz;
            foreach (string itemChecked in listaFuncionarioFianza)
            {
                fianz = new Fianza();
                fianz = servicio.fianzaGet(Util.header, Convert.ToInt32(listaFuncionarioFianza[contador]));
                insertarLista(fianz);
                contador++;

            }

            frmCargando.Close();
        }

        /*se inserta en una lista auxiliar para luego cargar en la lista oficial*/
        private void insertarLista(SrMidasD.Fianza fianz)
        {
            if (fianz != null)
            {
                int row = existeFianzDgv(fianz.idFianza);
                if (row == -1)
                {
                    int idFuncionario = (int)servicio.fianzaGet(Util.header, (int)fianz.idFianza).idFuncionario;
                    int idOficina = (int)servicio.funcionarioGet(Util.header, (int)idFuncionario).idOficina;
                    dgvListaAux.DataSource = servicio.pafuncionarioFianzaActualBuscaridFianza(Util.header,(int) servicio.oficinaGet(Util.header,idOficina).idUnidadEjecutora,fianz.idFianza);
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
                        dgvLista.Rows.Add(cargo, nombre_Completo, ci, item, haber_mensual,total_Descuento, total_Descontar, falta_Descontar, a_Descontar,fianz.idFianza,0);
                    }
                }
                else
                {
                    dgvLista.Rows[row].Cells[0].Selected = true;
                    MessageBox.Show("El Funcionario ya se encuentra en la Lista", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (dgvLista.Rows.Count > 0)
                btnImprimir.Enabled = true;
            else btnImprimir.Enabled = false;
        }

        //Verificar si existe ya insertada la idfianza de un funcionario
        private int existeFianzDgv(int idFianza)
        {
            foreach (DataGridViewRow dr in dgvLista.Rows)
                if (Convert.ToInt32(dr.Cells["idFianza"].Value.ToString()) == idFianza)
                    return dr.Index;
            return -1;
        }

       
      

       


      

        //Datos para validar el formulario
        private void frmEntrada_Load(object sender, EventArgs e)
        {
            
            dgvLista.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
        }



       
        private void dgvLista_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = dgvLista.Rows[e.RowIndex];
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        
       

       

 
        //Opcion Imprimir
        private async void btnImprimir_Click(object sender, EventArgs e)
        {
            
           await imprimir();
        }

    }
}
