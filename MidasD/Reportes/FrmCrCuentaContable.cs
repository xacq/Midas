using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MidasD.Reportes
{
    public partial class FrmCrCuentaContable : Form
    {
        MidasD.SrMidasD.MidasDServiceClient servicio;
        CrDetalleFianzasCuentaContable reporte;
        CrDetalleFianzasReales reporteReales;
        string usuario;
        FrmCargando frmCargando;
        public int idTipoFianza1, idTipoFianza2, mes, anio;

        public FrmCrCuentaContable(int idTipoFianza1, int idTipoFianza2, int mes, int anio, string usuario)
        {
            InitializeComponent();
            this.idTipoFianza1 = idTipoFianza1;
            this.idTipoFianza2 = idTipoFianza2;
            this.mes = mes;
            this.anio = anio;
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();
            reporte = new CrDetalleFianzasCuentaContable();
            reporteReales = new CrDetalleFianzasReales();
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        private async Task cargarReporteGlobal()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            List<SrMidasD.paListarFianzasEconomicasReporteGlobal_Result> lista = servicio.paListarFianzasEconomicasReporteGlobal(Util.header, idTipoFianza1, idTipoFianza2, mes, anio).ToList();

            if (lista.Count > 0)
            {

                reporte.SetDataSource(lista);
                reporte.SetParameterValue("cuentaContable", "CUENTA CONTABLE(2.1.5.2)");
                reporte.SetParameterValue("distrito", "LA PAZ");
                reporte.SetParameterValue("gestion", anio);
                reporte.SetParameterValue("gestionPasada", Convert.ToString(anio - 1));
                int dias = System.DateTime.DaysInMonth(anio, mes);
                reporte.SetParameterValue("totalalmes", dias + "/" + mes + "/" + anio);
                reporte.SetParameterValue("usuario", usuario);
                reporte.SetParameterValue("mes", MonthName(mes).ToUpper());

                crReporte.ReportSource = reporte;
                //crReporte.Refresh();
                
            }
            else
            {
                MessageBox.Show("No se Puede Imprimir - Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            frmCargando.Close();
        }

        private async Task cargarReporteT727()
        {

            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            List<SrMidasD.paListarFianzasEconomicasReporteT727_Result> lista = servicio.paListarFianzasEconomicasReporteT727(Util.header, mes, anio).ToList();


            if (lista.Count > 0)
            {

                reporte.SetDataSource(lista);

                reporte.SetParameterValue("cuentaContable", "CUENTA CONTABLE(2.1.5.2) - GRUPO T727");
                reporte.SetParameterValue("distrito", "LA PAZ");
                reporte.SetParameterValue("gestion", anio);
                reporte.SetParameterValue("gestionPasada", Convert.ToString(anio - 1));
                int dias = System.DateTime.DaysInMonth(anio, mes);
                reporte.SetParameterValue("totalalmes", dias + "/" + mes + "/" + anio);
                reporte.SetParameterValue("usuario", usuario);
                reporte.SetParameterValue("mes", MonthName(mes).ToUpper());
                crReporte.ReportSource = reporte;
            }
            else
            {
                MessageBox.Show("No se Puede Imprimir - Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            frmCargando.Close();
        }

        private async Task cargarReporteDescuento()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            List<SrMidasD.paListarFianzasEconomicasReporteGlobal_Result> lista = servicio.paListarFianzasEconomicasReporteGlobal(Util.header, idTipoFianza1, idTipoFianza2, mes, anio).ToList();


            if (lista.Count > 0)
            {

                reporte.SetDataSource(lista);


                reporte.SetParameterValue("cuentaContable", "CUENTA CONTABLE(2.1.5.2) - DESCUENTOS 20%");
                reporte.SetParameterValue("distrito", "LA PAZ");
                reporte.SetParameterValue("gestion", anio);
                reporte.SetParameterValue("gestionPasada", Convert.ToString(anio - 1));
                int dias = System.DateTime.DaysInMonth(anio, mes);
                reporte.SetParameterValue("totalalmes", dias + "/" + mes + "/" + anio);
                reporte.SetParameterValue("usuario", usuario);
                reporte.SetParameterValue("mes", MonthName(mes).ToUpper());
                crReporte.ReportSource = reporte;
            }
            else
            {
                MessageBox.Show("No se Puede Imprimir - Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            frmCargando.Close();
        }


        private async Task cargarReporteTotales()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            List<SrMidasD.paListarFianzasEconomicasReporteGlobal_Result> lista = servicio.paListarFianzasEconomicasReporteGlobal(Util.header, idTipoFianza1, idTipoFianza2, mes, anio).ToList();


            if (lista.Count > 0)
            {

                reporte.SetDataSource(lista);

                reporte.SetParameterValue("cuentaContable", "CUENTA CONTABLE(2.1.5.2) - DEPOSITO EN EFECTIVO");
                reporte.SetParameterValue("distrito", "LA PAZ");
                reporte.SetParameterValue("gestion", anio);
                reporte.SetParameterValue("gestionPasada", Convert.ToString(anio - 1));
                int dias = System.DateTime.DaysInMonth(anio, mes);
                reporte.SetParameterValue("totalalmes", dias + "/" + mes + "/" + anio);
                reporte.SetParameterValue("usuario", usuario);
                reporte.SetParameterValue("mes", MonthName(mes).ToUpper());
                crReporte.ReportSource = reporte;
            }
            else
            {
                MessageBox.Show("No se Puede Imprimir - Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            frmCargando.Close();
        }

        private async Task cargarReporteBienes()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            List<SrMidasD.paListarFianzasRealesReporteGlobal_Result> lista = servicio.paListarFianzasRealesReporteGlobal(Util.header, idTipoFianza1, idTipoFianza2, mes, anio).ToList();


            if (lista.Count > 0)
            {

                reporteReales.SetDataSource(lista);

                reporteReales.SetParameterValue("cuentaContable", "DE 'BIENES GRAVADOS'  CUENTA 81700 - ");
                reporteReales.SetParameterValue("distrito", "LA PAZ");
                reporteReales.SetParameterValue("gestion", anio);
                reporteReales.SetParameterValue("gestionPasada", Convert.ToString(anio - 1));
                int dias = System.DateTime.DaysInMonth(anio, mes);
                reporteReales.SetParameterValue("totalalmes", dias + "/" + mes + "/" + anio);
                reporteReales.SetParameterValue("usuario", usuario);
                reporteReales.SetParameterValue("totalalmes","MES DE "+ MonthName(mes).ToUpper());
                crReporte.ReportSource = reporteReales;
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
            try
            {
                if (idTipoFianza1 == 0 && idTipoFianza2 == 0)
                {
                    await cargarReporteT727();
                }
                if (idTipoFianza1 == 2 && idTipoFianza2 == 3)
                {
                    await cargarReporteGlobal();
                }
                if (idTipoFianza1 == 2 && idTipoFianza2 == 2)
                {
                    await cargarReporteDescuento();
                }
                if (idTipoFianza1 == 3 && idTipoFianza2 == 3)
                {
                    await cargarReporteTotales();
                }
                if (idTipoFianza1 == 1 && idTipoFianza2 == 1)
                {
                    await cargarReporteBienes();
                }
            }
            catch
            {
                frmCargando.Close();
                this.Close();
                MessageBox.Show("Ha sucedido un error o el mes seleccionado no tiene descuentos aun.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
