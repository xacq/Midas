using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MidasD
{
    public partial class FrmManualUsuario : Form
    {

        public FrmManualUsuario()
        {
            InitializeComponent();
            
        }

     

        private void cargar()
        {
            

            try
            {
                string filename = Application.StartupPath;
                filename = Path.GetFullPath(Path.Combine(filename, Directory.GetCurrentDirectory() + @"\Manual_MidasD.pdf"));
                webBrowserPDF.Navigate(filename);

                //webBrowserPDF.Visible = true;
                ////axAcroPDF1.Visible = false;
                //webBrowserPDF.Navigate(Directory.GetCurrentDirectory() + @"\Manual_MidasD.pdf");
            }
            catch (Exception)
            {
                //webBrowserPDF.Visible = false;
                //axAcroPDF1.Visible = true;
                //string path = Directory.GetCurrentDirectory() + @"\Manual_MidasD.pdf";
                //this.axAcroPDF1.LoadFile(path);
                //this.axAcroPDF1.src = path;
                //this.axAcroPDF1.setShowToolbar(true);
                //this.axAcroPDF1.setView("FitH");
                //this.axAcroPDF1.setLayoutMode("SinglePage");
                //this.axAcroPDF1.Show(); 
            }

        }

 


        private  void FrmManualUsuario_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void FrmManualUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.axAcroPDF1.Dispose();
            //this.axAcroPDF1 = null;
        }

        
    }
}
