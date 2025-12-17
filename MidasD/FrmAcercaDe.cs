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
    public partial class FrmAcercaDe : Form
    {
        public FrmAcercaDe()
        {
            InitializeComponent();
            lbVersion.Text = lbVersion.Text + " " + ProductVersion;
            lbacercaDe.Text = "'Sistema de Control de Fianzas Judiciales'\nTodos los derechos reservados "+ DateTime.Now.Year+"\n\nSeccion de Administración de Sistemas\nInformáticos y Comunicaciones\nDirección Administrativa y Financiera\nÓrgano Judicial de Bolivia Distrito La Paz";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
