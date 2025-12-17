using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace MidasD
{
    public partial class FrmContactos : Form
    {
    //    string path, fileName;
    //    int idRol;
        SrMidasD.MidasDServiceClient servicio;
        public FrmContactos()
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            //path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName) + "\\";
            //idRol = (int)servicio.rolUsuarioListarRoles(Util.header, Util.usuario.idUsuario).ToList().Min(x => x.idRol);
            //fileName = servicio.reporteAyudaActual(idRol);
        }

        private void cargarPdf()
        {
            //if (!File.Exists(path + fileName))
            //{
            //    //File.WriteAllBytes(path + fileName, servicio.reporteAyudaPdf(fileName));
            //}
            //pdfAyuda.LoadFile(path + fileName);
        }

        private void FrmAyuda_Load(object sender, EventArgs e)
        {

            //cargarPdf();



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://daf.organojudicial.gob.bo/");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
