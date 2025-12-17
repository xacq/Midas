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
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
//using MidasD.Reportes;

namespace MidasD
{
    public partial class FrmSeleccionarFuncionario: Form
    {
        SrMidasD.MidasDServiceClient servicio;
        string unidadRequerimiento;
        public static string[] listaFuncionarioFianza = new string[300];
        FrmCargando frmCargando;

        public FrmSeleccionarFuncionario(string unidadRequerimiento)
        {
            InitializeComponent();
           
            servicio = new SrMidasD.MidasDServiceClient();
            this.unidadRequerimiento = unidadRequerimiento;

            cargarUnidadEjecutora();
        }


        //Listar las Unidades Encargadas
        private void cargarUnidadEjecutora()
        {
            cbxUnidadEjecutora.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutora.DisplayMember = "descripcion";
            cbxUnidadEjecutora.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutora.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listaFuncionarioFianza = new string[300];
            this.Close();
        }

        private async Task  listar()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());


            if (unidadRequerimiento == "CartillaContabilidad")
            {
                chlFuncionario.DataSource = servicio.pafuncionarioFianzaActualBuscarCartilla(Util.header, txtParametro.Text.Trim().ToLower(), Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()), 2);
            }
            if (unidadRequerimiento == "Habilitado")
            {
                chlFuncionario.DataSource = servicio.pafuncionarioFianzaActualBuscar(Util.header, txtParametro.Text.Trim().ToLower(), Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()),2);
            }

            chlFuncionario.DisplayMember = "nombre_Completo";
            chlFuncionario.ValueMember = "idFianza";

            frmCargando.Close();
        }

        private void chkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chlFuncionario.Items.Count; i++)
            {
                chlFuncionario.SetItemChecked(i, chkSeleccionarTodo.Checked);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            if (chlFuncionario.CheckedItems.Count < 1)
            {
                MessageBox.Show("No se ha seleccionado ningun Funcionario.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                if (unidadRequerimiento == "CartillaContabilidad")
                {
                    int contador = 0;
                    listaFuncionarioFianza = new string[100];
                    foreach (SrMidasD.paFuncionarioFianzaActualBuscarCartilla_Result itemChecked in chlFuncionario.CheckedItems)
                    {
                        List<SrMidasD.paFuncionarioFianzaActualBuscarCartilla_Result> datos = servicio.pafuncionarioFianzaActualBuscarCartilla(Util.header, Utils.Utils.unaccented(txtParametro.Text.Trim().ToLower()), Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()), 2).ToList();

                        if (datos.Count > 0)
                        {
                            try
                            {
                                listaFuncionarioFianza[contador] = itemChecked.idFianza.ToString();
                                contador++;
                            }

                            catch { }
                        }

                        else
                        {
                            MessageBox.Show("No hay nada que imprimir", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                }
                if (unidadRequerimiento == "Habilitado")
                {
                    int contador = 0;
                    listaFuncionarioFianza = new string[100];
                    foreach (SrMidasD.paFuncionarioFianzaActualBuscar_Result itemChecked in chlFuncionario.CheckedItems)
                    {
                        List<SrMidasD.paFuncionarioFianzaActualBuscar_Result> datos = servicio.pafuncionarioFianzaActualBuscar(Util.header, Utils.Utils.unaccented(txtParametro.Text.Trim().ToLower()), Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()), 2).ToList();

                        if (datos.Count > 0)
                        {
                            try
                            {
                                listaFuncionarioFianza[contador] = itemChecked.idFianza.ToString();
                                contador++;
                            }

                            catch { }
                        }

                        else
                        {
                            MessageBox.Show("No hay nada que imprimir", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                }
            }

            frmCargando.Close();

            this.Close();
        }


        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await listar();
        }

        private async void cbxUnidadEjecutora_SelectionChangeCommitted(object sender, EventArgs e)
        {
           await listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void FrmSeleccionarFuncionario_Load(object sender, EventArgs e)
        {
            //await listar();
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
