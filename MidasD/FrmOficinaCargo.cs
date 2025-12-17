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
    public partial class FrmOficinaCargo : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        SrMidasD.Usuario usuario;
        List<Control> btnPnlCabeza, btnPnlPie;

        DateTime  fechaActualServidor;
        public FrmOficinaCargo(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.usuario = usuario;
            btnPnlCabeza = new List<Control>() { btnAsignar, btnSalir, grbRol };
            btnPnlPie = new List<Control>() { btnGuardar, btnCancelar, gbxMenu };
            Util.btn_Mouse(new List<PictureBox>() { btnAsignar, btnSalir, btnCancelar, btnGuardar });
            fechaActualServidor = servicio.fechaServidor();
            if (fechaActualServidor.Month > 6)
            {
                txtGestion.Text = fechaActualServidor.Year.ToString();
            }
            else
            {
                txtGestion.Text = (fechaActualServidor.Year - 1).ToString();
            }
            cargarUnidadEjecutora();
            cargarOficinas();
            cargarCargo();
            cargarChl();
        }


        private void cargarUnidadEjecutora()
        {
            cbxUnidadEjecutora.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutora.DisplayMember = "descripcion";
            cbxUnidadEjecutora.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutora.SelectedIndex = -1;
        }

        private void cargarOficinas()
        {
            try
            {
                cbxOficina.ValueMember = "idOficina";
                cbxOficina.DisplayMember = "oficina";
                cbxOficina.DataSource = servicio.oficinaListarUnidadEjecutora(Util.header, Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
                cbxOficina.SelectedIndex = -1;
            }
            catch
            { }
        }

        private void cargarCargo()
        {
            try
            {

                chlCargos.DataSource = servicio.cargoListarOficina(Util.header, Convert.ToInt32(cbxOficina.SelectedValue.ToString()), Convert.ToInt32(txtGestion.Text));
                chlCargos.DisplayMember = "cargo";
                chlCargos.ValueMember = "idCargo";
            }
            catch
            { }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlCabeza);
            Util.pnlListaActivar(true, btnPnlPie);
            cargarChl();
        }

        private void cargarChl()
        {
            try
            {
                for (int i = 0; i < chlCargos.Items.Count; i++)
                    chlCargos.SetItemChecked(i, false);
                foreach (SrMidasD.Menu m in servicio.rolMenuListarPorRol(Util.header, Convert.ToInt32(cbxOficina.SelectedValue)))
                {
                    for (int i = 0; i < chlCargos.Items.Count; i++)
                    {
                        SrMidasD.Menu a = (SrMidasD.Menu)chlCargos.Items[i];
                        if (a.menu1 == m.menu1.ToString())
                        {
                            chlCargos.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Util.pnlListaActivar(true, btnPnlCabeza);
            Util.pnlListaActivar(false, btnPnlPie);
            for (int i = 0; i < chlCargos.Items.Count; i++)
                chlCargos.SetItemChecked(i, false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idRol = Convert.ToInt32(cbxOficina.SelectedValue);
            if (chlCargos.CheckedItems.Count < 1)
            {
                MessageBox.Show("No se han seleccionado menús.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                servicio.rolMenuEliminarMenu(Util.header, idRol);
                foreach (SrMidasD.Menu itemChecked in chlCargos.CheckedItems)
                {
                    SrMidasD.RolMenu rolmenu = new SrMidasD.RolMenu();
                    rolmenu.idRol = idRol;
                    rolmenu.idMenu = itemChecked.idMenu;
                    rolmenu.usuarioRegistro = usuario.nombre_Usuario;
                    servicio.rolMenuInsertar(Util.header, rolmenu);
                }
                MessageBox.Show("Menús asignados.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbxUnidadEjecutora_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarOficinas();
        }

        private void cbxUnidadEjecutora_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string nombre = ((ComboBox)sender).Name.ToString();

            if (nombre == "cbxUnidadEjecutora")
            {
                btnBuscarOficina.Enabled = true;
                btnBuscarOficina.Focus();
                btnBuscarOficina.BackColor = Color.LimeGreen;
                txtOficinaLiteral.Clear();
                ((ComboBox)sender).MouseLeave += new System.EventHandler(cbxOficina_Leave);
            }
            if (nombre == "cbxOficina")
            {
                //erpError.Clear();
                //cbxCargo.Focus();
                //cbxCargo.DroppedDown = true;
                //((ComboBox)sender).MouseLeave += new System.EventHandler(cbxCargo_Leave);
            }

            //if (nombre == "cbxCargo")
            //{
            //    erpError.Clear();
            //    txtNumeroMemorando.Focus();
            //    txtNumeroMemorando.Enabled = true;
            //}
        }

        private void btnBuscarOficina_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmSeleccionarOficina(Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString())).ShowDialog();
                insertarOficinaCbx(FrmSeleccionarOficina.oficina);
            }
            catch { }
        }

        private void btnBuscarOficina_MouseHover(object sender, EventArgs e)
        {
            btnBuscarOficina.BackColor = Color.LimeGreen;
        }

        private void cbxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarChl();
        }

        private void txtOficinaLiteral_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbxOficina_Leave(object sender, EventArgs e)
        {

        }

        private void insertarOficinaCbx(SrMidasD.Oficina oficina)
        {
            try
            {
                cbxOficina.SelectedValue = oficina.idOficina;
                txtOficinaLiteral.Text = oficina.oficina1;
                //erpError.Clear();
                cargarCargo();
                //cbxCargo.Focus();
                //cbxCargo.DroppedDown = true;
            }
            catch { }
        }
    }
}
