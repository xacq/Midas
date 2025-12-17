
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MidasD.Reportes
{
    public partial class FrmCrCartillaVerFianza : Form
    {
        MidasD.SrMidasD.MidasDServiceClient servicio;
        SrMidasD.Funcionario funcionarioDatos;
        SrMidasD.Fianza fianzaDatos;
        CrCartilla reporte;
        CrCartillaBienesGravados reporteBG;
        FrmCargando frmCargando;
        string usuario,esAdministrador;
        public string montoDevolucion,notaDevolucion;
        int idFianzaAdministrador,idFianza;

        public FrmCrCartillaVerFianza(int idFianza,string usuario,string esAdministrador,int idFianzaAdministrador)
        {
            InitializeComponent();
            this.idFianza = idFianza;
            reporte = new CrCartilla();
            reporteBG = new CrCartillaBienesGravados();
            this.usuario = usuario;
            this.esAdministrador = esAdministrador;
            this.idFianzaAdministrador = idFianzaAdministrador;
            servicio = new SrMidasD.MidasDServiceClient();


           
        }

        private async Task cargarReporte()
        {
            int tipoFianza = (int)servicio.fianzaGet(Util.header, (int)idFianza).idTipoFianza;

            //*Fianzas Economicas*//
            if (tipoFianza==2 || tipoFianza ==3)
            {
                frmCargando = new FrmCargando();
                frmCargando.Show();
                await Task.Delay(250);
                WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

                if (esAdministrador == "Administrador")
                {
                    fianzaDatos = servicio.fianzaGet(Util.header, idFianzaAdministrador);
                }
                else
                {
                    funcionarioDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianza).idFuncionario);
                    fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);
                }

                DataTable dt;
                dt = new DataTable("qr");
                dt.Columns.Add("qr", typeof(byte[]));


                List<SrMidasD.paReporteCartilla_Result> datos = servicio.paFianzaReporteCartilla(Util.header, fianzaDatos.idFianza).ToList();
                SrMidasD.Funcionario funciDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, fianzaDatos.idFianza).idFuncionario);
                SrMidasD.Persona persoDatos = servicio.personaGet(Util.header, (int)funciDatos.idPersona);
                SrMidasD.Cargo cargoDatos = servicio.cargoGet(Util.header, (int)funciDatos.idCargo);
                SrMidasD.Oficina ofiDatos = servicio.oficinaGet(Util.header, (int)funciDatos.idOficina);
                SrMidasD.EscalaSalarial escaDatos = servicio.escalaSalarialGet(Util.header, (int)cargoDatos.idEscalaSalarial);

                string nroMemorando = funciDatos.numero_Memorando;
                string nombreCompleto = persoDatos.paterno.ToUpper() + " " + persoDatos.materno.ToUpper() + " " + persoDatos.nombres.ToUpper();
                string numeroDocumento = persoDatos.numero_Documento;
                string tipoContrato = funciDatos.vigencia_Contrato.ToUpper();
                string item = "";
                if (funciDatos.tipo_Contrato_Item.ToString() == "0")
                {
                    item = "--";
                }
                else
                {
                    item = funciDatos.tipo_Contrato_Item.ToString();
                }
                string cargoOficina = cargoDatos.descripcion_Puesto.ToUpper() + " " + ofiDatos.oficina1.ToUpper();
                string haberMensual = string.Format("{0:#,0.00}", servicio.sueldoMensualGet(Util.header, (int)escaDatos.idSueldoMensual).monto);
                string cuantia = ofiDatos.cuantia.ToString();
                string totalDescontar = string.Format("{0:#,0.00}", Convert.ToDouble(haberMensual) * Convert.ToDouble(cuantia));
                string porcentajeDescuento = (ofiDatos.porcentaje_Descuento).ToString();
                string totalDescuentoMes = Convert.ToString((Convert.ToDouble(haberMensual) * ofiDatos.porcentaje_Descuento));
                string cantidadMeses = Math.Round(Convert.ToDouble(totalDescontar) / Convert.ToDouble(totalDescuentoMes)).ToString();

                try
                {
                    montoDevolucion = servicio.devolucionGetidFianza(Util.header, fianzaDatos.idFianza).monto_Devolucion.ToString();
                    notaDevolucion = "Resolucion Administrativa :" + servicio.devolucionGetidFianza(Util.header, fianzaDatos.idFianza).resolucion_Administrativa + "/  Nro. c31 :" + servicio.devolucionGetidFianza(Util.header, fianzaDatos.idFianza).c31 + " / Nro. Cheque: " + servicio.devolucionGetidFianza(Util.header, fianzaDatos.idFianza).nro_Cheque.ToString();
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

                        string texto = "\nNro.Fianza: " + (fianzaDatos.Nro_Fianza.ToString()) + "  Item:" + (item) +
                        "\nMemorando.: " + (nroMemorando) +
                        "\nNombre: " + (Utils.Utils.unaccented(Utils.Utils.uppercaseFirstLetter(nombreCompleto))) +
                         "\nCI: " + (numeroDocumento) +
                        "\nCargo: " + (cargoOficina) +
                        "\nHaber Mensual: " + (haberMensual) +
                        "\nMonto Beneficiario: " + (Convert.ToDouble(servicio.pafuncionarioFianzaActualBuscaridFianza(Util.header, (int)ofiDatos.idUnidadEjecutora, fianzaDatos.idFianza).FirstOrDefault().total_Descuento).ToString());
                        dt.Rows.Add(Utils.Utils.qrCode(texto));
                        reporte.Subreports["Crqr"].SetDataSource(dt);

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
                        reporte.SetParameterValue("fianza", fianzaDatos.Nro_Fianza.ToString());
                        if (montoDevolucion == "")
                        {
                            reporte.SetParameterValue("montoDevolucion", "0");
                        }
                        else
                        {
                            reporte.SetParameterValue("montoDevolucion", montoDevolucion);
                        }
                        if (fianzaDatos.idTipoFianza == 2)
                        {
                            reporte.SetParameterValue("tipoFianza", "PLANILLA DE CONTROL DE DESCUENTO DEL 20% PARA FIANZA ECONOMICA");
                        }
                        if (fianzaDatos.idTipoFianza == 3)
                        {
                            reporte.SetParameterValue("tipoFianza", "PLANILLA DE CONTROL DE FIANZA ECONOMICA EN DEPOSITO TOTAL");
                        }
                        if (fianzaDatos.idTipoFianza == 1)
                        {
                            reporte.SetParameterValue("tipoFianza", "PLANILLA DE CONTROL DE FIANZA BIEN GRABADO");
                        }

                        reporte.SetParameterValue("notaDevolucion", notaDevolucion);
                        reporte.SetParameterValue("usuario", usuario);
                        crReporte.ReportSource = reporte;


                    }
                    catch
                    {
                    }
                }

                else
                {
                    MessageBox.Show("No se Puede Imprimir - Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                frmCargando.Close();
            }

            //*Fianzas Reales*//
            if(tipoFianza==1)
            {
                frmCargando = new FrmCargando();
                frmCargando.Show();
                await Task.Delay(250);
                WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

                if (esAdministrador == "Administrador")
                {
                    fianzaDatos = servicio.fianzaGet(Util.header, idFianzaAdministrador);
                }
                else
                {
                    funcionarioDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianza).idFuncionario);
                    fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);
                }

                DataTable dt;
                dt = new DataTable("qr");
                dt.Columns.Add("qr", typeof(byte[]));


                List<SrMidasD.paReporteCartilla_Result> datos = servicio.paFianzaReporteCartilla(Util.header, fianzaDatos.idFianza).ToList();
                SrMidasD.Funcionario funciDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, fianzaDatos.idFianza).idFuncionario);
                SrMidasD.Persona persoDatos = servicio.personaGet(Util.header, (int)funciDatos.idPersona);
                SrMidasD.Cargo cargoDatos = servicio.cargoGet(Util.header, (int)funciDatos.idCargo);
                SrMidasD.Oficina ofiDatos = servicio.oficinaGet(Util.header, (int)funciDatos.idOficina);

                string nroMemorando = funciDatos.numero_Memorando;
                string nombreCompleto = persoDatos.paterno.ToUpper() + " " + persoDatos.materno.ToUpper() + " " + persoDatos.nombres.ToUpper();
                string numeroDocumento = persoDatos.numero_Documento;
                string tipoContrato = funciDatos.vigencia_Contrato.ToUpper();
                string item = "";
                if (funciDatos.tipo_Contrato_Item.ToString() == "0")
                {
                    item = "--";
                }
                else
                {
                    item = funciDatos.tipo_Contrato_Item.ToString();
                }
                string cargoOficina = cargoDatos.descripcion_Puesto.ToUpper() + " " + ofiDatos.oficina1.ToUpper();
                string cpbte = servicio.fianzaGet(Util.header, idFianza).comprobante_CPBTE;
                string tipo1 = servicio.fianzaGet(Util.header, idFianza).tipo_Fianza_Real;
                //string t727bg = (Convert.ToDouble(servicio.pafuncionarioFianzaActualBuscaridFianza(Util.header, (int)ofiDatos.idUnidadEjecutora, fianzaDatos.idFianza).FirstOrDefault().t).ToString());
                string montobeneficiario = (Convert.ToDouble(servicio.pafuncionarioFianzaActualBuscaridFianza(Util.header, (int)ofiDatos.idUnidadEjecutora, fianzaDatos.idFianza).FirstOrDefault().total_Descuento).ToString());
                string tipobiengrabado = servicio.fianzaGet(Util.header, idFianza).descripcion_Tipo_Fianza_Real;
                string ubicacion = servicio.fianzaGet(Util.header, idFianza).ubicacion_Fianza_Real;
                string folionro = servicio.fianzaGet(Util.header, idFianza).folio_Fianza_Real;
                string concepto = servicio.fianzaGet(Util.header, idFianza).concepto_Fianza_Real;
                string afavor1 = servicio.fianzaGet(Util.header, idFianza).a_Favor_Fianza_Real;
                string ultimoregistro = Math.Round(Convert.ToDouble(servicio.fianzaGet(Util.header, idFianza).ultimo_Registro_Fianza_Real)).ToString();
                string afavor2 = servicio.fianzaGet(Util.header, idFianza).a_Favor_2_Fianza_Real.ToString();
                string estadobieninmueble = servicio.fianzaGet(Util.header, idFianza).estado_Bien_Inmueble_Fianza_Real;
                string resolucionadministrativa = servicio.fianzaGet(Util.header, idFianza).resolucion_Administrativa;
                //string mesanio = 
                string observacion = servicio.fianzaGet(Util.header, idFianza).observacion;

                try
                {
                    montoDevolucion = servicio.devolucionGetidFianza(Util.header, fianzaDatos.idFianza).monto_Devolucion.ToString();
                    notaDevolucion = "Resolucion Administrativa :" + servicio.devolucionGetidFianza(Util.header, fianzaDatos.idFianza).resolucion_Administrativa + "/  Nro. c31 :" + servicio.devolucionGetidFianza(Util.header, fianzaDatos.idFianza).c31 + " / Nro. Cheque: " + servicio.devolucionGetidFianza(Util.header, fianzaDatos.idFianza).nro_Cheque.ToString();
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

                        string texto = "\nNro.Fianza Real: " + (fianzaDatos.Nro_Fianza_Fianza_Real.ToString()) + "  Item:" + (item) +
                        "\nMemorando.: " + (nroMemorando) +
                        "\nNombre: " + (Utils.Utils.unaccented(Utils.Utils.uppercaseFirstLetter(nombreCompleto))) +
                         "\nCI: " + (numeroDocumento) +
                        "\nCargo: " + (cargoOficina) +
                        "\nCpbte: " + (cpbte) +
                        "\nTipo Bien Grabado: " + (tipobiengrabado) +
                        "\nFolio/s: " + (folionro) +
                        "\nConcepto: " + (concepto) +
                        "\nA Favor: " + (afavor1+" - "+afavor2) +
                        "\nEstado: " + (estadobieninmueble) +
                        "\nRes. Adm.: " + (resolucionadministrativa) +
                        "\nMonto Beneficiario: " + (Convert.ToDouble(servicio.pafuncionarioFianzaActualBuscaridFianza(Util.header, (int)ofiDatos.idUnidadEjecutora, fianzaDatos.idFianza).FirstOrDefault().total_Descuento).ToString());
                        dt.Rows.Add(Utils.Utils.qrCode(texto));
                        reporteBG.Subreports["Crqr"].SetDataSource(dt);

                        reporteBG.Subreports["CrSCartilla.rpt"].SetDataSource(datos);
                        reporteBG.SetParameterValue("nroMemorando", nroMemorando);
                        reporteBG.SetParameterValue("nombresApellidos", nombreCompleto);
                        reporteBG.SetParameterValue("ci", numeroDocumento);
                        reporteBG.SetParameterValue("contrato", tipoContrato);
                        reporteBG.SetParameterValue("item", item);
                        reporteBG.SetParameterValue("cargo", cargoOficina);
                        reporteBG.SetParameterValue("cpbte", cpbte);
                        reporteBG.SetParameterValue("tipo1", tipo1);
                        reporteBG.SetParameterValue("montobeneficiario", montobeneficiario);
                        reporteBG.SetParameterValue("tipobiengravado", tipobiengrabado);
                        reporteBG.SetParameterValue("ubicacion", ubicacion);
                        reporteBG.SetParameterValue("folionro", folionro);
                        reporteBG.SetParameterValue("concepto", concepto);
                        reporteBG.SetParameterValue("afavor1", afavor1);
                        reporteBG.SetParameterValue("ultimoregistro", ultimoregistro);
                        reporteBG.SetParameterValue("afavor2", afavor2);
                        reporteBG.SetParameterValue("estadodelbieninmueble", estadobieninmueble);
                        reporteBG.SetParameterValue("resolucionadministrativa", resolucionadministrativa);
                        reporteBG.SetParameterValue("observacion", observacion);
                        reporteBG.SetParameterValue("fianza", fianzaDatos.Nro_Fianza_Fianza_Real.ToString());
                        if (montoDevolucion == "")
                        {
                            reporteBG.SetParameterValue("montoDevolucion", "0");
                        }
                        else
                        {
                            reporteBG.SetParameterValue("montoDevolucion", montoDevolucion);
                        }
                        if (fianzaDatos.idTipoFianza == 2)
                        {
                            reporteBG.SetParameterValue("tipoFianza", "PLANILLA DE CONTROL DE DESCUENTO DEL 20% PARA FIANZA ECONOMICA");
                        }
                        if (fianzaDatos.idTipoFianza == 3)
                        {
                            reporteBG.SetParameterValue("tipoFianza", "PLANILLA DE CONTROL DE FIANZA ECONOMICA EN DEPOSITO TOTAL");
                        }
                        if (fianzaDatos.idTipoFianza == 1)
                        {
                            reporteBG.SetParameterValue("tipoFianza", "PLANILLA DE CONTROL DE FIANZA BIEN GRABADO");
                        }

                        reporteBG.SetParameterValue("notaDevolucion", notaDevolucion);
                        reporteBG.SetParameterValue("usuario", usuario);
                        crReporte.ReportSource = reporteBG;


                    }
                    catch
                    {
                    }
                }

                else
                {
                    MessageBox.Show("No se Puede Imprimir - Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                frmCargando.Close();
            }
            else
            {

            }
           
        }

       





        private async void FrmCrResumenGeneral_Load(object sender, EventArgs e)
        {
            await cargarReporte();
   
        }

        private void FrmCrResumenGeneral_FormClosing(object sender, FormClosingEventArgs e)
        {
            reporte.Close();
            crReporte.Refresh();
            crReporte.Dispose();
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
