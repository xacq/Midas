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
    public partial class FrmDatosUsuario : Form
    {
        SrMidasD.Usuario usuario;
       
        SrMidasD.MidasDServiceClient servicio;

        public FrmDatosUsuario(SrMidasD.Usuario usuario)
        {
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();
            InitializeComponent();
            try
            {
                SrMidasD.Persona persona=servicio.personaGet(Util.header,usuario.idPersona);
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header,persona.idPersona).imagen1);
                lblNombres.Text = persona.nombres + " " + persona.paterno + " " + persona.materno;
                lblCi.Text =servicio.tipoDocumentoGet(Util.header,(int)persona.idTipoDocumento).descripcion+" - "+ persona.numero_Documento;
                lblRol.Text ="Rol - "+ servicio.rolGet(Util.header,(int)servicio.rolUsuarioGetIdUsuario(Util.header, usuario.idUsuario).idRol).rol1;
            }
            catch
            {

            }
        }
    }
}
