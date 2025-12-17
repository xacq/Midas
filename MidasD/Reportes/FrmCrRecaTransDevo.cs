
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MidasD.Reportes
{
    public partial class FrmCrRecaTransDevo : Form
    {
        MidasD.SrMidasD.MidasDServiceClient servicio;
       
        CrReclasificaciones reporte;
        CrDevoluciones reporteDev;
        CrTransferencias reporteTran;
        FrmCargando frmCargando;
        string usuario, tipoReporte;
        DateTime fecha1, fecha2;


        public FrmCrRecaTransDevo(string tipoReporte,string usuario,DateTime fecha1, DateTime fecha2)
        {
            InitializeComponent();
          
            reporte = new CrReclasificaciones();
            reporteDev = new CrDevoluciones();
            reporteTran = new CrTransferencias();
            this.usuario = usuario;
            this.tipoReporte = tipoReporte;
            this.fecha1 = fecha1.Date;
            this.fecha2 = fecha2.Date;
            servicio = new SrMidasD.MidasDServiceClient();
           
        }

        private async Task cargarReporteReclasificaciones()
        {

            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            reporte = new CrReclasificaciones();
            List<SrMidasD.paListarFianzasReclasificacionReporte_Result> datos = servicio.paListarFianzasReclasificacionReporte(Util.header, Convert.ToDateTime(fecha1).Date, Convert.ToDateTime(fecha2).Date).ToList();
          
            

            if (datos.Count > 0)
                {
                    try
                {
                        reporte.SetDataSource(datos);
                        reporte.SetParameterValue("fecha1", fecha1);
                        reporte.SetParameterValue("fecha2", fecha2);
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


        private async Task cargarReporteDevoluciones()
        {

            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            reporteDev = new CrDevoluciones();
            List<SrMidasD.paListarFuncionariosFianzaDevolucionContabilidadReporte_Result> datosDev = servicio.paListarFuncionariosFianzaDevolucionContabilidadReporte(Util.header, Convert.ToDateTime(fecha1).Date, Convert.ToDateTime(fecha2).Date).ToList();



            if (datosDev.Count > 0)
            {
                try
                {
                    reporteDev.SetDataSource(datosDev);
                    reporteDev.SetParameterValue("fecha1", fecha1);
                    reporteDev.SetParameterValue("fecha2", fecha2);
                    reporteDev.SetParameterValue("usuario", usuario);
                    crReporte.ReportSource = reporteDev;
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


        private async Task cargarReporteTransferencias()
        {

            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            reporteTran = new CrTransferencias();
            List<SrMidasD.paListarFuncionariosFianzaTranferenciasReporte_Result> datosTran = servicio.paListarFuncionariosFianzaTranferenciasReporte(Util.header, Convert.ToDateTime(fecha1).Date, Convert.ToDateTime(fecha2).Date).ToList();



            if (datosTran.Count > 0)
            {
                try
                {
                    reporteTran.SetDataSource(datosTran);
                    reporteTran.SetParameterValue("fecha1", fecha1);
                    reporteTran.SetParameterValue("fecha2", fecha2);
                    reporteTran.SetParameterValue("usuario", usuario);
                    crReporte.ReportSource = reporteTran;
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



        private async void FrmCrResumenGeneral_Load(object sender, EventArgs e)
        {
            if (tipoReporte == "Reclasificaciones")
            {
                await cargarReporteReclasificaciones();
            }

            if (tipoReporte == "Devoluciones")
            {
                await cargarReporteDevoluciones();
            }


            if (tipoReporte == "Transferencias")
            {
                await cargarReporteTransferencias();
            }
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
