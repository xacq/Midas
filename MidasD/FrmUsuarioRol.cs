using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MidasD.SrMidasD;

namespace MidasD
{
    public partial class FrmUsuarioRol : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        SrMidasD.Usuario usuario;
        List<Control> btnPnlHeader;
        public FrmUsuarioRol(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.usuario = usuario;

            btnPnlHeader = new List<Control>() { btnAsignar, btnSalir, grbUsuario };
            Util.btn_Mouse(new List<PictureBox>() { btnNuevo, btnAsignar, btnBaja, 
                btnCancelar, btnGuardar, btnSalir });
            cargarComboUsuario();
            listarRoles();
        }

        private void cargarComboUsuario()
        {       
            cbxUsuario.DataSource = servicio.usuarioListar(Util.header);
            cbxUsuario.ValueMember = "idUsuario";
            cbxUsuario.DisplayMember = "nombre_Usuario";
        }

        private void cargarRoles()
        {
            cbxRol.DataSource = servicio.rolListar(Util.header);
            cbxRol.DisplayMember = "rol1";
            cbxRol.ValueMember = "idRol";
        }

        private void listarRoles()
        {
            try
            {
                dgvLista.DataSource = servicio.rolUsuarioListarRoles(Util.header, Convert.ToInt32(cbxUsuario.SelectedValue));
                dgvLista.Columns["idRolUsuario"].Visible = false;
                dgvLista.Columns["idRol"].Visible = false;
                dgvLista.Columns["idUsuario"].Visible = false;
                dgvLista.Columns["rol1"].HeaderText = "Rol";
            }
            catch (Exception) { }
        }

      
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlHeader);
            Util.pnlListaActivar(true, new List<Control>() { btnNuevo, btnCancelar, grbRoles });
            Util.pnlListaActivar(false, new List<Control>() { btnGuardar, btnBaja, cbxRol });
            if (dgvLista.Rows.Count > 0) Util.pnlListaActivar(true, new List<Control>() { btnBaja });
            cargarRoles();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Util.pnlListaActivar(true, btnPnlHeader);
            Util.pnlListaActivar(false, new List<Control>() { btnNuevo, btnCancelar, btnGuardar, btnBaja, grbRoles });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Util.pnlListaActivar(true, new List<Control>() { btnGuardar, cbxRol });
            Util.pnlListaActivar(false, new List<Control>() { btnNuevo, btnBaja });
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult ResultadoDialogo = MessageBox.Show("el rol del usuario será dada de baja.\r¿Desea continuar?.", "::: Midas - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idUsuarioRol = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idRolUsuario"].Value);
                servicio.rolUsuarioEliminar(Util.header, idUsuarioRol);
                MessageBox.Show("El rol del usuario ha sido dado de baja", "::: Midas - Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarRoles();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(cbxUsuario.SelectedValue);
            SrMidasD.RolUsuario rolUsuario = new SrMidasD.RolUsuario();
            rolUsuario.idUsuario = idUsuario;
            rolUsuario.idRol = Convert.ToInt32(cbxRol.SelectedValue);
            rolUsuario.usuarioRegistro = usuario.nombre_Usuario;
            servicio.rolUsuarioInsertar(Util.header, rolUsuario);
            MessageBox.Show("Rol asignado.", "::: Midas - Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbxRol.Enabled = false;
            btnNuevo.Enabled = true;
            btnBaja.Enabled = true;
            btnGuardar.Enabled = false;
            listarRoles();
        }

        private void cbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarRoles();
        }

        private void dgvLista_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }
    }
}
