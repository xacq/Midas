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
    public partial class FrmRolMenu : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        SrMidasD.Usuario usuario;
        List<Control> btnPnlCabeza, btnPnlPie;
        public FrmRolMenu(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.usuario = usuario;
            btnPnlCabeza = new List<Control>() { btnAsignar, btnSalir, grbRol };
            btnPnlPie = new List<Control>() { btnGuardar, btnCancelar, gbxMenu };
            Util.btn_Mouse(new List<PictureBox>() { btnAsignar, btnSalir, btnCancelar, btnGuardar });
            cargarComboRol();
            cargarMenu();
            cargarChl();
        }

        private void cargarComboRol()
        {
            cbxRol.DataSource = servicio.rolListar(Util.header);
            cbxRol.ValueMember = "idRol";
            cbxRol.DisplayMember = "rol1";
        }

        private void cargarMenu()
        {
            chlMenu.DataSource = servicio.menuListar(Util.header);
            chlMenu.DisplayMember = "menu1";
            chlMenu.ValueMember = "idMenu";
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
                for (int i = 0; i < chlMenu.Items.Count; i++)
                    chlMenu.SetItemChecked(i, false);
                foreach (SrMidasD.Menu m in servicio.rolMenuListarPorRol(Util.header, Convert.ToInt32(cbxRol.SelectedValue)))
                {
                    for (int i = 0; i < chlMenu.Items.Count; i++)
                    {
                        SrMidasD.Menu a = (SrMidasD.Menu)chlMenu.Items[i];
                        if (a.menu1 == m.menu1.ToString())
                        {
                            chlMenu.SetItemChecked(i, true);
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
            for (int i = 0; i < chlMenu.Items.Count; i++)
                chlMenu.SetItemChecked(i, false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idRol = Convert.ToInt32(cbxRol.SelectedValue);
            if (chlMenu.CheckedItems.Count < 1)
            {
                MessageBox.Show("No se han seleccionado menús.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                servicio.rolMenuEliminarMenu(Util.header, idRol);
                foreach (SrMidasD.Menu itemChecked in chlMenu.CheckedItems)
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

        private void cbxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarChl();
        }
    }
}
