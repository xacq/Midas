using MidasD.SrMidasD;
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
    public partial class FrmCambiarClave : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        SrMidasD.Usuario usuario;
        //FrmAuntenticacion frmAutenticacion;

        public FrmCambiarClave(SrMidasD.Usuario usuario,string clave)
        {
            InitializeComponent();
            servicio = new MidasDServiceClient();
            this.usuario = usuario;
            Util.btn_Mouse(new List<PictureBox>() { btnGuardar, btnSalir });

            if (usuario.clave == Utils.Utils.Encrypt("hola123"))
            {
                txtClaveActual.Text = "hola123";
                txtClaveActual.Enabled = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtClaveActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                txtClaveNueva.Focus();
            }
        }

        private void txtClaveNueva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                txtConfirmaClave.Focus();
            }
        }

        private void txtConfirmaClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnGuardar_Click(sender, EventArgs.Empty);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validar())
                if (Utils.Utils.Encrypt(txtClaveActual.Text) == usuario.clave)
                {
                    if ((txtClaveNueva.Text != txtConfirmaClave.Text) || String.IsNullOrEmpty(txtClaveNueva.Text))
                    {
                        MessageBox.Show("Los campos Clave Nueva y Confirmar Clave debe ser iguales. \rNo pueden estar en blanco", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClaveNueva.Focus();
                        txtClaveNueva.SelectAll();
                    }
                    else
                    {
                        if (txtClaveNueva.Text == "hola123")
                        {
                            MessageBox.Show("La clave no puede ser: hola123.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClaveNueva.Focus();
                            txtClaveNueva.SelectAll();
                        }
                        else
                        {
                            if (txtClaveNueva.Text.Length < 4)
                            {
                                MessageBox.Show("La clave debe tener mas de 4 caracteres", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtClaveNueva.Focus();
                                txtClaveNueva.SelectAll();
                            }
                            else
                            {
                                usuario.clave = Utils.Utils.Encrypt(txtClaveNueva.Text.Trim());
                                servicio.usuarioCambiarClave(Util.header, usuario.idUsuario, Utils.Utils.Encrypt(txtClaveNueva.Text.Trim()));
                                MessageBox.Show("La clave se cambió con éxito.\rEl sistema se cerrará.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;

                                System.Threading.Thread.Sleep(1000);
                                Application.Exit();
                            }
                        }
                    }
                }
        }

        public bool validar()
        {
            bool aux = true;
            erpClaveActual.SetError(txtClaveActual, "");
            erpNuevaClave.SetError(txtClaveNueva, "");
            erpConfirmarClave.SetError(txtConfirmaClave, "");
            if ((String.IsNullOrWhiteSpace(txtClaveActual.Text))) { erpClaveActual.SetError(txtClaveActual, "El campo es obligatorio"); aux = false; }
            if ((String.IsNullOrWhiteSpace(txtClaveNueva.Text))) { erpNuevaClave.SetError(txtClaveNueva, "El campo es obligatorio"); aux = false; }
            if ((String.IsNullOrWhiteSpace(txtConfirmaClave.Text))) { erpConfirmarClave.SetError(txtConfirmaClave, "El campo es obligatorio"); aux = false; }
            return aux;
        }
    }
}
