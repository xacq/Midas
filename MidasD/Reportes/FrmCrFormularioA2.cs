using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MidasD.Reportes
{
    public partial class FrmCrFormularioA2: Form
    {
        int idTipoFianza,mes,anio,idUnidadEjecutora;
        string mesLit,usuario;
        CrFormularioA2 reporte;
        FrmCargando frmCargando;
        SrMidasD.MidasDServiceClient servicio;

        private async void FrmCrFormularioA2_Load(object sender, EventArgs e)
        {
            await cargarReporte();
        }

        public FrmCrFormularioA2(int idTipoFianza,int mes,string mesLit,int anio,int idUnidadEjecutora,string usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.idTipoFianza = idTipoFianza;
            this.idUnidadEjecutora = idUnidadEjecutora;
            this.mes = mes;
            this.mesLit = mesLit;
            this.anio = anio;
            this.usuario = usuario;
        }

        private async Task  cargarReporte()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            reporte = new CrFormularioA2();
            List<SrMidasD.paReporteFormularioA2_Result> lista = servicio.paFianzaReporteFormularioA2(Util.header, " ", idTipoFianza, mes, anio, idUnidadEjecutora).ToList();
            reporte.SetDataSource(lista);
            SrMidasD.paReporteFormularioA2_Result pa = lista.FirstOrDefault();
            string unidadEjecutoraDes = servicio.unidadEjecutoraGet(Util.header, idUnidadEjecutora).descripcion;

            reporte.SetParameterValue("unidadEjecutora", unidadEjecutoraDes);
            reporte.SetParameterValue("mes", mesLit);
            reporte.SetParameterValue("anio", anio);
            reporte.SetParameterValue("anioPasado", anio-1);
            reporte.SetParameterValue("aniocorto",anio.ToString().Substring(2));
            reporte.SetParameterValue("usuario", usuario);
            crvFormularioA2.ReportSource = reporte;

            frmCargando.Close();
        }

        private void FrmReporteRestitucionEfectivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            reporte.Close();
            crvFormularioA2.Refresh();
            crvFormularioA2.Dispose();
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
