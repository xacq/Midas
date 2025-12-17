using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidasD
{
    public partial class FrmRol : Form
    {
        SrMidasD.Usuario usuario;
        SrMidasD.MidasDServiceClient servicio;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2;
        bool bandera;
        public FrmRol(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.usuario =usuario;

            btnPnlLista = new List<Control>() { btnBaja, btnEditar, btnNuevo, btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() { btnBaja, btnEditar };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar, pnlDatos };
            Util.btn_Mouse(new List<PictureBox>() { btnNuevo, btnEditar, btnBaja, 
                btnCancelar, btnGuardar, btnSalir });
            listar();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
        }

        private void listar()
        {
            dgvLista.DataSource = servicio.rolListar(Util.header);
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { 
                "idRol", "usuarioRegistro", "fechaRegistro", "registroActivo" });
            Utils.Wfa.setHeadersDGV(dgvLista);
             dgvLista.Columns["rol1"].HeaderText = "Rol";
        }

        private void limpiar()
        {
            txtRol.Clear(); ;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nudJerarquia.Maximum = dgvLista.Rows.Count + 1;
            nudJerarquia.Value = nudJerarquia.Maximum;
            bandera = true;
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(true, btnPnlDatos);
            txtRol.Focus();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult ResultadoDialogo = MessageBox.Show("El Rol será dado de baja.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idRol = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idRol"].Value);
                servicio.rolEliminar(Util.header, idRol);
             
                MessageBox.Show("El Rol ha sido dado de baja.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                Util.pnlListaActivar(true, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlDatos);
                limpiar();
            }
        }

        private void cargarCampos()
        {
            int idRol = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idRol"].Value);
            SrMidasD.Rol rolDatos = servicio.rolGet(Util.header, idRol);
            txtRol.Text = rolDatos.rol1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cargarCampos();
            bandera = false;
            nudJerarquia.Maximum = dgvLista.Rows.Count;
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(true, btnPnlDatos);
            txtRol.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bandera)
            {
                if (!validarCampos())
                {
                    MessageBox.Show("El campo Rol debe estar lleno.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SrMidasD.Rol rolDatos = servicio.rolValidarNuevo(Util.header, txtRol.Text);
                    if (rolDatos != null)
                    {
                        string rol = rolDatos.rol1;

                        if (Convert.ToBoolean(rolDatos.registroActivo))
                        {
                            MessageBox.Show("El rol ya está registrado.\rRol: " + rol + ".", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult ResultadoDialogo = MessageBox.Show("El rol está dado de baja. ¿Desea activarlo?.\rRol: " + rol + ".", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ResultadoDialogo == DialogResult.Yes)
                            {
                                //Activar Rol
                                activarRol(rolDatos.idRol);
                                MessageBox.Show("El Rol ha sido activado.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        guardar();
                        MessageBox.Show("El Rol ha sido registrado.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else
            {
                if (!validarCampos())
                {
                    MessageBox.Show("El campo Rol debe estar lleno.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    editar();
                    MessageBox.Show("El Rol ha sido editado.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
            erpRol.SetError(txtRol, "");
            if ((String.IsNullOrWhiteSpace(txtRol.Text))) { erpRol.SetError(txtRol, "Debe introducir un Rol"); aux = false; }
            return aux;
        }

        private void activarRol(int idRol)
        {
            servicio.rolActivar(Util.header, idRol);
            var rol = servicio.rolGet(Util.header, idRol);
           
            listar();
            limpiar();
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
        }

        private void guardar()
        {
            SrMidasD.Rol rol = new SrMidasD.Rol();
            rol.rol1 = txtRol.Text.Trim();
            rol.usuarioRegistro = usuario.nombre_Usuario;
            servicio.rolInsertar(Util.header, rol);
            pnlLista.Enabled = true;
            pnlDatos.Enabled = false;
     
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
            listar();
        }

        private void editar()
        {
            int idRol = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idRol"].Value);
            SrMidasD.Rol rol = servicio.rolGet(Util.header, idRol);
            rol.rol1 = txtRol.Text.Trim();
            rol.usuarioRegistro = usuario.nombre_Usuario;
            servicio.rolEditar(Util.header, rol);

            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
            listar();
        }

        private void dgvLista_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }
    }
}
