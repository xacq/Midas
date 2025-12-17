using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MidasD.Reportes
{
    public partial class FrmCrFianzasUnidadEjecutora : Form
    {
        MidasD.SrMidasD.MidasDServiceClient servicio;
        CrFianzasUnidadEjecutora reporte;
        string usuario;
        FrmCargando frmCargando;
        public int idTipoFianza1,idTipoFianza2,mes,anio,idUnidadEjecutora;

        public FrmCrFianzasUnidadEjecutora(int idTipoFianza1,int idTipoFianza2,int mes, int anio,string usuario,int idUnidadEjecutora)
        {
            InitializeComponent();
            this.idTipoFianza1 = idTipoFianza1;
            this.idTipoFianza2 = idTipoFianza2;
            this.mes = mes;
            this.anio = anio;
            this.usuario = usuario;
            this.idUnidadEjecutora = idUnidadEjecutora;
            servicio = new SrMidasD.MidasDServiceClient();
            reporte = new CrFianzasUnidadEjecutora();

        }

        //public string MonthName(int month)
        //{
        //    DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
        //    return dtinfo.GetMonthName(month);
        //}

        private async Task cargarReporte()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());


            List<SrMidasD.paListarFianzasEconomicasReporteGlobalUnidadEjecutora_Result> lista = servicio.paListarFianzasEconomicasReporteGlobalUnidadEjecutora(Util.header,"", idTipoFianza1,idTipoFianza2,mes,anio,idUnidadEjecutora).ToList();

            if (lista.Count > 0)
            {
                reporte.SetDataSource(lista);
                int dias = System.DateTime.DaysInMonth(anio, mes);
                reporte.SetParameterValue("totalalmes", dias+"/"+mes+"/"+anio);
                reporte.SetParameterValue("usuario", usuario);
                string letraUnidadEjecutora = servicio.unidadEjecutoraGet(Util.header,idUnidadEjecutora).descripcion;
                reporte.SetParameterValue("unidadEjecutora", letraUnidadEjecutora);
                crReporte.ReportSource = reporte;
                
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
