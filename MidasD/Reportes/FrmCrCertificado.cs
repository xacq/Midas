using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MidasD.Reportes
{
    public partial class FrmCrCertificado: Form
    {
        int idFianza,idUnidadEjecutora;
        string fecharegistro,expedido;
        SrMidasD.Usuario usuario;
        CrCertificado reporte;
        CrCertificadoBienesGrabados reporteBG;
        DataTable dt;
        FrmCargando frmCargando;
        SrMidasD.MidasDServiceClient servicio;

        public FrmCrCertificado(int idFianza,int idUnidadEjecutora,string fechaRegistro,SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.idFianza = idFianza;
            this.idUnidadEjecutora = idUnidadEjecutora;
            this.usuario = usuario;
            this.fecharegistro = fechaRegistro;
           
        }

        private async Task cargarReporte()
        {
            int tipoFianza=(int)servicio.fianzaGet(Util.header,idFianza).idTipoFianza;
            if(tipoFianza == 2 || tipoFianza == 3)
            {
                frmCargando = new FrmCargando();
                frmCargando.Show();
                await Task.Delay(250);
                WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

                string resolucionDaf;

                string esMartillero =servicio.cargoGet(Util.header,(int)servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, idFianza).idFuncionario).idCargo).descripcion_Puesto;


                if (esMartillero.Contains("MARTILLERO"))
                {
                    resolucionDaf = ConfigurationManager.AppSettings.Get("CertificadoResoMartilleros").ToString();
                   
                }
                else
                {
                    resolucionDaf = ConfigurationManager.AppSettings.Get("CertificadoResoDaf").ToString();
                }

                

                reporte = new CrCertificado();
                List<SrMidasD.paReporteFuncionarioCertificadoidFianza_Result> lista = servicio.paReporteCertificadoidFianza(Util.header, idUnidadEjecutora, idFianza).ToList();
                reporte.SetDataSource(lista);
                dt = new DataTable("qr");
                SrMidasD.paReporteFuncionarioCertificadoidFianza_Result pa = lista.FirstOrDefault();
                dt.Columns.Add("qr", typeof(byte[]));

                expedido = pa.departamento_Nacimiento;

                switch (expedido)
                {
                    case "LA PAZ":
                        expedido = "LP";
                        break;
                    case "CHUQUISACA":
                        expedido = "CH";
                        break;
                    case "ORURO":
                        expedido = "OR";
                        break;
                    case "POTOSI":
                        expedido = "PT";
                        break;
                    case "TARIJA":
                        expedido = "TJ";
                        break;
                    case "SANTA CRUZ":
                        expedido = "SC";
                        break;
                    case "BENI":
                        expedido = "BN";
                        break;
                    case "PANDO":
                        expedido = "PN";
                        break;
                    case "COCHABAMBA":
                        expedido = "CB";
                        break;
                    default:
                        expedido = "--";
                        break;
                }
                string texto = "\nNro.Fianza: " + pa.Nro_Fianza + "\nCargo: " + Utils.Utils.unaccented(pa.cargo) + "\nNombre: " + Utils.Utils.unaccented(pa.nombre_Completo) + "\nDocumento: " + pa.tipo_Documento + "- " + pa.numero_Documento + " - " + expedido + "\nTotal Descuento: " + pa.total_Descuento + "\nFecha Reg. Fianza: " + Utils.Utils.unaccented(fecharegistro) + "\nFecha Emi. Cert.: " + DateTime.Now.Date.ToLongDateString();
                dt.Rows.Add(Utils.Utils.qrCode(texto));
                reporte.Subreports["CRqr"].SetDataSource(dt);
                reporte.SetParameterValue("anio", DateTime.Now.Year);
                reporte.SetParameterValue("expedido", expedido);
                reporte.SetParameterValue("fechaRegistroFianza", string.Format("{0:D}", DateTime.Now.Date));
                reporte.SetParameterValue("montoLetra", "SON: " + Utils.ConvertNumberLetter.Convert(pa.total_DescuentoLetra).ToUpper());
                reporte.SetParameterValue("usuario", usuario.nombre_Usuario);
                reporte.SetParameterValue("NumResoDaf", resolucionDaf);
                crvCertificado.ReportSource = reporte;

                frmCargando.Close();
            }
            if(tipoFianza == 1)
            {
                frmCargando = new FrmCargando();
                frmCargando.Show();
                await Task.Delay(250);
                WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

                string resolucionDaf = ConfigurationManager.AppSettings.Get("CertificadoResoDaf").ToString();

                reporteBG = new CrCertificadoBienesGrabados();
                idUnidadEjecutora = (int)servicio.oficinaGet(Util.header,(int)(servicio.funcionarioGet(Util.header,(int)servicio.fianzaGet(Util.header, idFianza).idFuncionario).idOficina)).idUnidadEjecutora;

                List<SrMidasD.paReporteFuncionarioCertificadoidFianza_Result> lista = servicio.paReporteCertificadoidFianza(Util.header, idUnidadEjecutora, idFianza).ToList();
                reporteBG.SetDataSource(lista);
                dt = new DataTable("qr");
                SrMidasD.paReporteFuncionarioCertificadoidFianza_Result pa = lista.FirstOrDefault();
                dt.Columns.Add("qr", typeof(byte[]));

                string NroFianzaReal = servicio.fianzaGet(Util.header, idFianza).Nro_Fianza_Fianza_Real.ToString();

                expedido = pa.departamento_Nacimiento;

                switch (expedido)
                {
                    case "LA PAZ":
                        expedido = "LP";
                        break;
                    case "CHUQUISACA":
                        expedido = "CH";
                        break;
                    case "ORURO":
                        expedido = "OR";
                        break;
                    case "POTOSI":
                        expedido = "PT";
                        break;
                    case "TARIJA":
                        expedido = "TJ";
                        break;
                    case "SANTA CRUZ":
                        expedido = "SC";
                        break;
                    case "BENI":
                        expedido = "BN";
                        break;
                    case "PANDO":
                        expedido = "PN";
                        break;
                    case "COCHABAMBA":
                        expedido = "CB";
                        break;
                    default:
                        expedido = "--";
                        break;
                }
                string texto = "\nNro.Fianza Real: " + NroFianzaReal + "\nCargo: " + Utils.Utils.unaccented(pa.cargo) + "\nNombre: " + Utils.Utils.unaccented(pa.nombre_Completo) + "\nDocumento: " + pa.tipo_Documento + "- " + pa.numero_Documento + " - " + expedido + "\nBien Gravado Equivalente: " + pa.total_Descuento + "\nFecha Reg. Fianza: " + Utils.Utils.unaccented(fecharegistro) + "\nFecha Emi. Cert.: " + DateTime.Now.Date.ToLongDateString();
                dt.Rows.Add(Utils.Utils.qrCode(texto));
                reporteBG.Subreports["CRqr"].SetDataSource(dt);
                reporteBG.SetParameterValue("anio", DateTime.Now.Year);
                reporteBG.SetParameterValue("expedido", expedido);
                reporteBG.SetParameterValue("fechaRegistroFianza", string.Format("{0:D}", DateTime.Now.Date));
                reporteBG.SetParameterValue("montoLetra", "SON: " + Utils.ConvertNumberLetter.Convert(pa.total_DescuentoLetra).ToUpper());
                reporteBG.SetParameterValue("usuario", usuario.nombre_Usuario);
                reporteBG.SetParameterValue("NumResoDaf", resolucionDaf);
                reporteBG.SetParameterValue("Nro_FianzaReal", NroFianzaReal);
                crvCertificado.ReportSource = reporteBG;

                frmCargando.Close();
            }
            
        }

        private async void FrmCrCertificado_Load(object sender, EventArgs e)
        {
            try
            {
                await cargarReporte();
            }
            catch { frmCargando.Close(); }
        }

        private void FrmReporteRestitucionEfectivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                reporte.Close();
            }catch
            {
                reporteBG.Close();
            }

            crvCertificado.Refresh();
            crvCertificado.Dispose();
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
