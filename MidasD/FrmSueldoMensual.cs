using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidasD
{
    public partial class FrmSueldoMensual : Form
    {
        SrMidasD.Usuario usuario;
        SrMidasD.MidasDServiceClient servicio;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2;
        bool bandera;
        public FrmSueldoMensual(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.usuario =usuario;

            DateTime  fechaActualServidor;

            btnPnlLista = new List<Control>() { btnBaja, btnEditar, btnNuevo, btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() { btnBaja, btnEditar };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar, pnlDatos };
            Util.btn_Mouse(new List<PictureBox>() { btnNuevo, btnEditar, btnBaja, 
                btnCancelar, btnGuardar, btnSalir });

            fechaActualServidor = servicio.fechaServidor();
            string mayo = ConfigurationManager.AppSettings.Get("1Mayo");
            if (mayo == "1")
            {
                if (fechaActualServidor.Month > 6)
                {
                    txtAnio.Text = fechaActualServidor.Year.ToString();
                }
                else
                {
                    txtAnio.Text = (fechaActualServidor.Year - 1).ToString();
                }
            }
            else
            {
                txtAnio.Text = fechaActualServidor.Year.ToString();
            }

            listarSueldosMensuales();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
        }

        private void listarSueldosMensuales()
        {
            dgvLista.DataSource = servicio.paSueldosMensuales(Util.header,Convert.ToInt32(txtAnio.Text));
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idSueldoMensual","fechaRegistro", "registroActivo" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "monto", "gestion", "incremento","usuarioRegistro"});
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void limpiar()
        {
            txtMonto.ResetText() ;
            txtGestion.ResetText();
            txtIncremento.ResetText();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bandera = true;
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(true, btnPnlDatos);
            txtMonto.Focus();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult ResultadoDialogo = MessageBox.Show("El Sueldo Mensual en la Escala Salarial será dado de baja.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idSueldoMensual = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idSueldoMensual"].Value);
                int idEscalaSalarial = servicio.escalaSalarialId(Util.header, idSueldoMensual).idEscalaSalarial;
                servicio.escalaSalarialEliminar(Util.header, idEscalaSalarial);
             
                MessageBox.Show("El Sueldo Mensual y la Escala Salarial ha sido dado de baja.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarSueldosMensuales();
                Util.pnlListaActivar(true, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlDatos);
                limpiar();
            }
        }

        private void cargarCampos()
        {
            int idSueldosMensuales = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idSueldoMensual"].Value);
            SrMidasD.SueldoMensual sueldosMensualDatos = servicio.sueldoMensualGet(Util.header, idSueldosMensuales);
            txtMonto.Text = sueldosMensualDatos.monto.ToString();
            txtGestion.Text = sueldosMensualDatos.gestion.ToString();
            txtIncremento.Text = sueldosMensualDatos.incremento.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cargarCampos();
            bandera = false;
          
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(true, btnPnlDatos);
            txtMonto.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bandera)
            {
                if (!validarCampos())
                {
                    MessageBox.Show("El campo monto debe estar lleno.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SrMidasD.SueldoMensual sueldoMensualDatos = servicio.sueldoMensualValidarNuevo(Util.header,Convert.ToDouble(txtMonto.Text));
                    if (sueldoMensualDatos != null)
                    {
                        double monto = (double)sueldoMensualDatos.monto;

                        int idSueldoMensual = sueldoMensualDatos.idSueldoMensual;

                        if (Convert.ToBoolean(servicio.escalaSalarialId(Util.header, idSueldoMensual).registroActivo))
                        {
                            MessageBox.Show("El Monto ya está registrado.\rRol: " + monto + ".", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult ResultadoDialogo = MessageBox.Show("La Escala Salarial esta dado de baja. ¿Desea activarlo?.\rSueldo Mensual: " + monto + ".", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ResultadoDialogo == DialogResult.Yes)
                            {
                                //Activar Rol
                                activarEscalaSalarial(servicio.escalaSalarialId(Util.header, idSueldoMensual).idEscalaSalarial);
                                MessageBox.Show("El Sueldo Mensual con la Escala Salarial ha sido activado.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        //guardar();
                        MessageBox.Show("El Sueldo Mensual ha sido registrado.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else
            {
                if (!validarCampos())
                {
                    MessageBox.Show("El campo monto debe estar lleno.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //editar();
                    MessageBox.Show("El Sueldo Mensual ha sido editado.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void activarEscalaSalarial(int idEscalaSalarial)
        {
            servicio.escalaSalariallActivar(Util.header, idEscalaSalarial);
           

            listarSueldosMensuales();
            limpiar();
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            limpiar();
        }

        private bool validarCampos()
        {
            bool aux = true;
            erpRol.SetError(txtMonto, "");
            if ((String.IsNullOrWhiteSpace(txtMonto.Text))) { erpRol.SetError(txtMonto, "Debe introducir un Monto"); aux = false; }
            return aux;
        }

     

        private void guardar()
        {
            SrMidasD.SueldoMensual sueldoMensual = new SrMidasD.SueldoMensual();
            sueldoMensual.monto =Convert.ToDouble(txtMonto.Text.Trim());
            sueldoMensual.gestion =Convert.ToInt32(txtGestion.Text.Trim());
            sueldoMensual.incremento =Convert.ToDouble(txtIncremento.Text.Trim());
            sueldoMensual.usuarioRegistro = usuario.nombre_Usuario;
            servicio.sueldoMensualInsertar(Util.header, sueldoMensual);
            pnlLista.Enabled = true;
            pnlDatos.Enabled = false;
     
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
            listarSueldosMensuales();
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listarSueldosMensuales();
            }
        }
        private void editar()
        {
            int idSueldoMensual = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idSueldoMensual"].Value);
            SrMidasD.SueldoMensual sueldoMensual = servicio.sueldoMensualGet(Util.header, idSueldoMensual);
            sueldoMensual.monto = Convert.ToDouble(txtMonto.Text.Trim());
            sueldoMensual.gestion = Convert.ToInt32(txtGestion.Text.Trim());
            sueldoMensual.incremento = Convert.ToDouble(txtIncremento.Text.Trim());
            sueldoMensual.usuarioRegistro = usuario.nombre_Usuario;
            servicio.sueldoMensualEditar(Util.header, sueldoMensual);

            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
            listarSueldosMensuales();
        }

        private void dgvLista_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }
    }
}
