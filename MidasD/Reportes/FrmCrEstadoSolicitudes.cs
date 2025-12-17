
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MidasD.Reportes
{
    public partial class FrmCrEstadoSolicitudes : Form
    {
        MidasD.SrMidasD.MidasDServiceClient servicio;
     
        CrEstadoSolicitudes reporte;
        FrmCargando frmCargando;
        string usuario;
        public string montoDevolucion,notaDevolucion;
        int dia1,dia2;

        public FrmCrEstadoSolicitudes(int dia1,int dia2,string usuario)
        {
            InitializeComponent();
            this.dia1 = dia1;
            this.dia2 = dia2;
            reporte = new CrEstadoSolicitudes();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();
        }

        private async Task cargarReporte()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());
            if (usuario == null)
            {
                usuario = " ";
            }
           

            List<SrMidasD.paListarSolicitudesFianzaDiasRestantesReporte_Result> datos = servicio.paListarSolicitudesFianzaDiasRestantesReporte(Util.header, " ",dia1,dia2,usuario).ToList();

            if (dia2 < 0)
            {
                dia2 = 0;
            }

            if (datos.Count > 0)
                {
                    try
                    {
                        reporte.SetDataSource(datos);
                        reporte.SetParameterValue("dias", dia2);
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
