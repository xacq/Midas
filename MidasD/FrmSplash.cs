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
    public partial class FrmSplash : Form
    {
        String texto;
        public FrmSplash()
        {
            InitializeComponent();
            lbVersion.Text = "Versión " + this.ProductVersion;

            texto = "Copyright © 2019-"+DateTime.Now.Year+ "- Seccion de Administracion de Sistemas Informaticos y Comunicaciones..........................";
            pb.Maximum = texto.Length * 2;
        }

        private void timerIniciar_Tick(object sender, EventArgs e)
        {
            pb.Value += 1;
            if (pb.Value == pb.Maximum)
            {
                pb.Value = 0;
                timerIniciar.Enabled = false;
                this.Close();
            }
            if (pb.Value % 2 == 0) labelInicio.Text = texto.Substring(0, pb.Value / 2);
        }
    }
}
