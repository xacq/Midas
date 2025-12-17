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
    public partial class FrmOficinas : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        SrMidasD.Usuario usuario;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2;
        bool bandera;
        public FrmOficinas(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.usuario = usuario;
            btnPnlLista = new List<Control>() { btnBaja, btnEditar, btnNuevo, btnSalir, btnBuscar, pnlLista };
            btnPnlLista2 = new List<Control>() { btnBaja, btnEditar };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar, pnlDatos };
            Util.btn_Mouse(new List<PictureBox>() { btnNuevo, btnEditar, btnBaja, 
                btnCancelar, btnGuardar, btnSalir, btnBuscar });
            listarOficinas();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            cargarUnidadEjecutora();
        }

        private void cargarUnidadEjecutora()
        {
            cbxUnidadEjecutora.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutora.DisplayMember = "descripcion";
            cbxUnidadEjecutora.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutora.SelectedIndex = -1;
        }

        private void listarOficinas()
        {
            dgvLista.DataSource = servicio.OficinasListarBuscar(Util.header,txtParametro.Text);
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idOficina", "fechaRegistro", "registroActivo","idZeus" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "oficina","unidad_Ejecutora","codigo_Distrito", "codigo_Zeus", "cuantia", "porcentaje_Descuento","usuarioRegistro" });
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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
            txtOficina.Clear();
            cbxUnidadEjecutora.SelectedValue = -1;
            txtCuantia.Clear();
            txtPorcentaje.Clear();
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
            txtOficina.Focus();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult ResultadoDialogo = MessageBox.Show("La oficina será dado de baja.\r¿Desea continuar?.", "::: Midas - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idOficina = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idOficina"].Value);
                servicio.oficinaEliminar(Util.header, idOficina);
                MessageBox.Show("La oficina ha sido dado de baja.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Util.pnlListaActivar(true, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlDatos);
                limpiar();
                listarOficinas();
            }
        }

        private void cargarCampos()
        {
            int idOficina = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idOficina"].Value);
            SrMidasD.Oficina oficinaDatos = servicio.oficinaGet(Util.header, idOficina);
            txtOficina.Text = oficinaDatos.oficina1;
            cbxUnidadEjecutora.SelectedValue = oficinaDatos.idUnidadEjecutora;
            txtPorcentaje.Text = oficinaDatos.porcentaje_Descuento.ToString();
            txtCuantia.Text = oficinaDatos.cuantia.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cargarCampos();
            bandera = false;
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(true, btnPnlDatos);
            txtOficina.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (bandera)
            {
                if (!validar())
                {
                    MessageBox.Show("El campo Oficina debe estar lleno.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SrMidasD.Menu menuDatos = servicio.menuValidarNuevo(Util.header, txtOficina.Text.Trim());
                    if (menuDatos != null)
                    {
                        string menu = menuDatos.menu1;

                        if (Convert.ToBoolean(menuDatos.registroActivo))
                        {
                            MessageBox.Show("La Oficina ya está registrado.\rMenú: " + menu + ".", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult ResultadoDialogo = MessageBox.Show("La Oficina está dado de baja. ¿Desea activarlo?.\rMenú: " + menu + ".", "::: Midas - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ResultadoDialogo == DialogResult.Yes)
                            {
                                //Activar Menu
                                activarMenu(menuDatos.idMenu);
                                MessageBox.Show("La Oficina ha sido activado.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        guardar();
                        MessageBox.Show("La OFicina ha sido registrado.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (!validar())
                {
                    MessageBox.Show("El campo Oficina debe estar lleno.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    editar();
                    MessageBox.Show("La Oficina ha sido editado.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            erpMenu.SetError(txtOficina, "");
            if ((String.IsNullOrWhiteSpace(txtOficina.Text))) { erpMenu.SetError(txtOficina, "Debe introducir una Oficina"); aux = false; }
            return aux;
        }

        private void activarMenu(int idMenu)
        {
            servicio.menuActivar(Util.header, idMenu);
            listarOficinas();
            limpiar();
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
        }

        private void guardar()
        {
            SrMidasD.Oficina oficina = new SrMidasD.Oficina();
            oficina.oficina1 = txtOficina.Text.Trim();
            oficina.codigo_Distrito = "06";
            oficina.codigo_Zeus = "00";
            oficina.idZeus = 0;
            oficina.idUnidadEjecutora = Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString());
            oficina.cuantia = Convert.ToInt32(txtCuantia.Text);
            oficina.porcentaje_Descuento =Convert.ToDouble(txtPorcentaje.Text);
            oficina.usuarioRegistro = usuario.nombre_Usuario;

            servicio.oficinaInsertar(Util.header, oficina);
   
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
            listarOficinas();
        }

        private void editar()
        {
            int idOficina = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idOficina"].Value);
            SrMidasD.Oficina oficina = servicio.oficinaGet(Util.header, idOficina);
            oficina.oficina1 = txtOficina.Text.Trim();
            oficina.codigo_Distrito = "06";
            oficina.codigo_Zeus = "00";
            oficina.idZeus = 0;
            oficina.idUnidadEjecutora = Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString());
            oficina.cuantia = Convert.ToInt32(txtCuantia.Text);
            oficina.porcentaje_Descuento = Convert.ToDouble(txtPorcentaje.Text);
            oficina.usuarioRegistro = usuario.nombre_Usuario;

            servicio.oficinaEditar(Util.header, oficina);

            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
            listarOficinas();
        }

        private void dgvLista_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarOficinas();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listarOficinas();
            }
        }
    }
}
