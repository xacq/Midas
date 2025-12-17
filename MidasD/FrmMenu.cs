using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidasD
{
    public partial class FrmMenu : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        SrMidasD.Usuario usuario;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2;
        bool bandera;
        public FrmMenu(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.usuario = usuario;
            btnPnlLista = new List<Control>() { btnBaja, btnEditar, btnNuevo, btnSalir, btnBuscar, pnlLista };
            btnPnlLista2 = new List<Control>() { btnBaja, btnEditar };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar, pnlDatos };
            Util.btn_Mouse(new List<PictureBox>() { btnNuevo, btnEditar, btnBaja, 
                btnCancelar, btnGuardar, btnSalir, btnBuscar });
            listar();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
        }

        private void listar()
        {
            dgvLista.DataSource = servicio.menuListar(Util.header);
            dgvLista.Columns["menu1"].HeaderText = "Menu";
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { 
                "idMenu", "usuarioRegistro", "fechaRegistro", "registroActivo","nombre_Elemento" });
            Utils.Wfa.setHeadersDGV(dgvLista);

            if (dgvLista.RowCount < 1)
            {
                btnEditar.Enabled = false;
                btnBaja.Enabled = false;
                btnBaja.Image = Properties.Resources.delet_inactive;
                btnEditar.Image = Properties.Resources.edit_inactive;
            }
            else
            {
                btnEditar.Enabled = true;
                btnBaja.Enabled = true;
                btnBaja.Image = Properties.Resources.delete;
                btnEditar.Image = Properties.Resources.edti;
            }  
        }

        private void limpiar()
        {
            txtMenu.Clear();
            txtNombreElemento.Clear();
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
            txtMenu.Focus();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult ResultadoDialogo = MessageBox.Show("El Menú será dado de baja.\r¿Desea continuar?.", "::: Midas - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idMenu = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idMenu"].Value);
                servicio.menuEliminar(Util.header, idMenu);
                MessageBox.Show("El Menú ha sido dado de baja.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Util.pnlListaActivar(true, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlDatos);
                limpiar();
                listar();
            }
        }

        private void cargarCampos()
        {
            int idMenu = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idMenu"].Value);
            SrMidasD.Menu menuDatos = servicio.menuGet(Util.header, idMenu);
            txtMenu.Text = menuDatos.menu1;
            txtNombreElemento.Text = menuDatos.nombre_Elemento;      
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cargarCampos();
            bandera = false;
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(true, btnPnlDatos);
            txtMenu.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (bandera)
            {
                if (!validar())
                {
                    MessageBox.Show("El campo Menú debe estar lleno.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SrMidasD.Menu menuDatos = servicio.menuValidarNuevo(Util.header, txtMenu.Text.Trim());
                    if (menuDatos != null)
                    {
                        string menu = menuDatos.menu1;

                        if (Convert.ToBoolean(menuDatos.registroActivo))
                        {
                            MessageBox.Show("El Menú ya está registrado.\rMenú: " + menu + ".", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult ResultadoDialogo = MessageBox.Show("El Menú está dado de baja. ¿Desea activarlo?.\rMenú: " + menu + ".", "::: Midas - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ResultadoDialogo == DialogResult.Yes)
                            {
                                //Activar Menu
                                activarMenu(menuDatos.idMenu);
                                MessageBox.Show("El Menú ha sido activado.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        guardar();
                        MessageBox.Show("El Menú ha sido registrado.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (!validar())
                {
                    MessageBox.Show("El campo Menú debe estar lleno.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    editar();
                    MessageBox.Show("El Menú ha sido editado.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool validar()
        {
            bool aux = true;
            erpMenu.SetError(txtMenu, "");
            if ((String.IsNullOrWhiteSpace(txtMenu.Text))) { erpMenu.SetError(txtMenu, "Debe introducir un Menú"); aux = false; }
            return aux;
        }

        private void activarMenu(int idMenu)
        {
            servicio.menuActivar(Util.header, idMenu);
            listar();
            limpiar();
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
        }

        private void guardar()
        {
            SrMidasD.Menu menu = new SrMidasD.Menu();
            menu.menu1 = txtMenu.Text.Trim();
            menu.nombre_Elemento = txtNombreElemento.Text.Trim();
            menu.usuarioRegistro = usuario.nombre_Usuario;

            servicio.menuInsertar(Util.header, menu);
   
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
            listar();
        }

        private void editar()
        {
            int idMenu = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idMenu"].Value);
            SrMidasD.Menu menu = servicio.menuGet(Util.header, idMenu);
            menu.menu1 = txtMenu.Text.Trim();
            menu.nombre_Elemento = txtNombreElemento.Text.Trim();
            menu.usuarioRegistro = usuario.nombre_Usuario;
            servicio.menuEditar(Util.header, menu);
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
            listar();
        }

        private void dgvLista_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listar();
            }
        }
    }
}
