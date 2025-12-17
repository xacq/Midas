
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace MidasD
{
    public partial class FrmAuntenticacion : Form
    {

        private FrmPrincipal FrmPrincipal;
        SrMidasD.MidasDServiceClient servicio;
        private int intentos;
        public FrmAuntenticacion()
        {
            InitializeComponent();
            this.servicio = new SrMidasD.MidasDServiceClient();
            Util.btn_Mouse(new List<PictureBox>() { btnAcceder, btnSalir });
        }

        



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
                if (validar())
                {
                SrMidasD.Usuario usuario;
                bool bandera = false;
                SrMidasD.Header header = new SrMidasD.Header();
                header.applitation = Utils.Utils.getAplicationNameD();
                header.hostName = Utils.Utils.getHostNameD();
                header.macAddress = Utils.Utils.getMacAddressD();
                header.token = Utils.Utils.token();
                Util.header = header;

                try
                    {
                       usuario = servicio.usuarioGetId(Util.header, (txtUsuario.Text));
                    }
                    catch
                    {
                       usuario = null;
                    }                 

                    if (usuario != null)
                    {
                        if (usuario.clave == Utils.Utils.Encrypt("hola123"))
                        {
                            MessageBox.Show("Su clave es genérica.\rPor favor cambie de clave.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Visible = false;
                            FrmCambiarClave frm = new FrmCambiarClave(usuario,usuario.clave);
                            frm.ShowDialog();

                            if (frm.DialogResult == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                        else if (usuario.clave == Utils.Utils.Encrypt(txtClave.Text.Trim()))
                        {
                        this.Visible = false;
                        FrmPrincipal = new FrmPrincipal(usuario,this);
                            FrmPrincipal.ShowDialog();
                            bandera = true;
                            txtUsuario.Text = String.Empty;
                            txtClave.Text = String.Empty;
                            //this.Hide();
                            txtUsuario.Focus();
                            intentos = 0;
                        }

                        else
                            if (!bandera) if (intentos < 3)
                                {
                                    MessageBox.Show("Usuario y/o clave Incorrecta", "::: Midas - Error de Auntenticación :::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    intentos++;
                                }
                                else
                                {
                                    MessageBox.Show("Números de Intentos Agotado...!!!", "::: Midas - Error de Auntenticación :::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Close();
                                }
                    }
                    else
                    {
                        MessageBox.Show("Usuario No Registrado", "::: Midas - Error de Auntenticación :::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }        
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnAcceder_Click(sender, e);
            }
        }


        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnAcceder_Click(sender, e);
            }
        }

        public bool validar()
        {
            bool aux = true;
            erpError.SetError(txtUsuario, "");
            erpError.SetError(txtUsuario, "");
            if ((String.IsNullOrEmpty(txtUsuario.Text))) { erpError.SetError(txtUsuario, "Debe introducir un usuario"); aux = false; }
            if ((String.IsNullOrEmpty(txtClave.Text))) { erpError.SetError(txtClave, "Debe introducir una clave"); aux = false; }
            return aux;
        }

        private void FrmAuntenticacion_Load(object sender, EventArgs e)
        {
            ClientSection clientSettings = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            string address = null;
            foreach (ChannelEndpointElement endpoint in clientSettings.Endpoints)
            {
                if (endpoint.Name == "BasicHttpBinding_MidasDService")
                {
                    address = endpoint.Address.ToString();
                    break;
                }

            }
            if (VerificarConexionURL(address))
            {
                FrmSplash fs = new FrmSplash();
                fs.ShowDialog();
                intentos = 0;
                txtUsuario.Focus();
            }

            else
            {
                MessageBox.Show("No se puede establecer conexion con el servicio Web", "::: Midas - Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public bool VerificarConexionURL(string mURL)
        {
            System.Net.WebRequest Peticion = default(System.Net.WebRequest);
            System.Net.WebResponse Respuesta = default(System.Net.HttpWebResponse);
            try
            {
                Peticion = System.Net.WebRequest.Create(mURL);
                Respuesta = Peticion.GetResponse();
                return true;
            }
            catch (System.Net.WebException)
            {
                return false;
            }
        }

      


    }
}
