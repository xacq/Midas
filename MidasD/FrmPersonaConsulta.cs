using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using MidasD.SrArgos;

namespace MidasD
{
    public partial class FrmPersonaConsulta : Form
    {
        SrMidasD.Usuario usuario;

        public string tipoPersona,personadministrador;
       
        public int idPersona;
        public Persona1 personaArgos;
        SrMidasD.MidasDServiceClient servicio;
        SrArgos.ArgosServiceClient servicioArgos;
        List<Control>  btnPnlDatos, btnPnlLista3;

        public bool nombres,apellido,
        direccion,sexo,estadocivil,
        tipodocumento,numerodoc,
        fechaNac = false;

        

        public FrmPersonaConsulta(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();
            servicioArgos = new SrArgos.ArgosServiceClient();

            btnPnlLista3 = new List<Control>() { btnSalir};
            btnPnlDatos = new List<Control>() { pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() {btnSalir });

            cargarTipoDocumento();

            Util.pnlListaActivar(true, btnPnlDatos);
        }

        private void cargarTipoDocumento() 
        {
            cbxTipoDocumento.DataSource = servicio.tipoDocumentoListar(Util.header);
            cbxTipoDocumento.ValueMember = "idTipoDocumento";
            cbxTipoDocumento.DisplayMember = "descripcion";
            cbxTipoDocumento.SelectedIndex = 1;
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                try
                {
                    limpiarcampos();
                    buscarCi();

                }
                catch
                { }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void textleave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        }

        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyLetters(sender, e);
        }


        private void buscarCi()
        {
            try
            {
                personaArgos = this.servicioArgos.segipConsulta(this.txtNumeroDocumento.Text.Trim(), "7644473", this.txtNombre.Text.Trim(), this.txtPaterno.Text.Trim(), this.txtMaterno.Text.Trim(), "Harper");
                this.erpSexo.Clear();
                this.erpNombre.Clear();
                this.erpApellido.Clear();
                this.erpCelularTelefono.Clear();
                if (personaArgos.estado == 2)//Cuando Existe Cedula Real
                {
                    this.txtNombre.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.nombres);
                    this.txtPaterno.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.paterno);
                    this.txtMaterno.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.materno);
                    this.pbImagen.Image = Utils.Utils.byteArrayToImage(personaArgos.fotografia);
                    this.txtDepartamento.Text= Utils.Utils.uppercaseFirstLetter(personaArgos.departamentoNacimiento);
                    string estadoCivil = Utils.Utils.uppercaseFirstLetter(personaArgos.estadoCivil).Trim();
                    try
                    {
                        this.cbxSexo.SelectedItem = personaArgos.estadoCivil.Substring(estadoCivil.Length - 1, 1).ToLower() == "o" ? "M" : "F";
                    }
                    catch { }
                  
                    this.mtbFechaNacimiento.Text = Convert.ToDateTime(personaArgos.fechaNacimiento).ToString("dd-MM-yyyy");
                    if (string.IsNullOrEmpty(personaArgos.domicilio))
                    {
                        this.txtDomicilio.Text = txtDomicilio.Text.Trim();
                    }
                    else
                    {
                        this.txtDomicilio.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.domicilio);
                    } 
                    this.cbxTipoDocumento.SelectedIndex = 5;
                    this.cbxEstadoCivil.SelectedItem = Utils.Utils.uppercaseFirstLetter(personaArgos.estadoCivil);

                    

                  
                }
                else if (personaArgos.estado == 1)//No Existe Cedula Real y se Procedera a su Creacion Manual
                {
                    this.txtNombre.Text = string.Empty;
                    this.txtPaterno.Text = string.Empty;
                    this.txtMaterno.Text = string.Empty;
                    this.txtUsuario.Text = string.Empty;
                    this.pbImagen.Image = null;
                
                        this.erpSexo.SetError(this.txtNumeroDocumento, "La C\x00e9dula de Identidad es inv\x00e1lida.");
                        this.txtNumeroDocumento.Focus();
                    

                }
                else
                {
                    this.txtNombre.Text = string.Empty;
                    this.txtPaterno.Text = string.Empty;
                    this.txtMaterno.Text = string.Empty;
                    this.txtUsuario.Text = string.Empty;
                    this.pbImagen.Image = null;
                    MessageBox.Show("Se encontr\x00f3 m\x00e1s de un registro con la c\x00e9dula de identidad\rIntroduzca el apellido paterno!", "::: Midas - Consulta :::", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.txtPaterno.Focus();
                  
                }
            }
            catch
            {
                MessageBox.Show("No se pudo establecer conexi\x00f3n con el servicio Segip Consulta", "::: Midas - Error :::", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }



        private void FrmPersona_Load(object sender, EventArgs e)
        {
            cargarTipoDocumento();       
        }

        void limpiarcampos()
        {
            txtNombre.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            txtDomicilio.Clear();

            cbxSexo.SelectedIndex = -1;
            cbxSexo.ResetText();

            cbxEstadoCivil.SelectedIndex = -1;
            cbxEstadoCivil.ResetText();


            cbxTipoDocumento.SelectedIndex = -1;
            cbxTipoDocumento.ResetText();

            mtbFechaNacimiento.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");

            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1; 
        }

       
        

        private void FrmPersona_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

       
    }
}
