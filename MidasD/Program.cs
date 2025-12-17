using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace MidasD
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
    

           [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ////////////////CultureInfo info = new CultureInfo("es-BO")
            ////////////////{
            ////////////////    DateTimeFormat = { ShortDatePattern = "dd/MM/yyyy" },
            ////////////////    NumberFormat = {
            ////////////////        NumberGroupSeparator = ".",
            ////////////////        NumberDecimalSeparator = ","
            ////////////////    }
            ////////////////};
            ////////////////Thread.CurrentThread.CurrentCulture = info;
            ////////////////Thread.CurrentThread.CurrentUICulture = info;
            //FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            //MidasD.Util.path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            //MidasD.Util.sistema = versionInfo.ProductName;
            //MidasD.Util.version = versionInfo.ProductVersion;
            //MidasD.Util.archivoExe = versionInfo.InternalName;
            //Wfa.actualizador(new FrmAuntenticacion(), MidasD.Util.sistema, MidasD.Util.version, MidasD.Util.path, MidasD.Util.archivoExe);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAuntenticacion());
        }



      
    }
}
