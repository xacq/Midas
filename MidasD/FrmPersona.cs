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
    public partial class FrmPersona: Form
    {
        SrMidasD.Usuario usuario;
  
        private bool esNuevo;
        bool bandera;
      
        public string tipoPersona,personadministrador;
       
        public int idPersona;
        public Persona1 personaArgos;
        SrMidasD.MidasDServiceClient servicio;
        SrArgos.ArgosServiceClient servicioArgos;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public bool nombres,apellido,
        direccion,sexo,estadocivil,
        tipodocumento,numerodoc,
        fechaNac = false;

        public FrmPersona(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();
            servicioArgos = new SrArgos.ArgosServiceClient();

            btnPnlLista = new List<Control>() { btnNuevo,btnBuscar,txtBuscar };
            btnPnlLista2 = new List<Control>() { btnBaja, btnEditar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() { btnNuevo, btnEditar, btnBaja,btnBuscar, 
            btnCancelar, btnGuardar, btnSalir });

            listar();
            cargarTipoDocumento();
        }

        private void cargarTipoDocumento() 
        {
            cbxTipoDocumento.DataSource = servicio.tipoDocumentoListar(Util.header);
            cbxTipoDocumento.ValueMember = "idTipoDocumento";
            cbxTipoDocumento.DisplayMember = "descripcion";
            cbxTipoDocumento.SelectedIndex = -1;
        }
       
       

        private void listar()
        {
            dgvLista.DataSource = servicio.personaBuscar(Util.header,txtBuscar.Text);
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idPersona", "idPais", "imagen", "pin", "idLugarExpedido", "idTipoDocumento","nombres","paterno","materno" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "nombre_Completo", "direccion", "sexo", "estado_civil", "tipo_Documento", "numero_documento", "fecha_Nacimiento" });
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false,btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);
     
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            verificarNuevo();
            
            bandera = true;
           

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlDatos);

         
            cbxTipoDocumento.SelectedIndex = -1;
            cbxSexo.SelectedIndex = -1;
            txtNumeroDocumento.Focus();
            Util.pintarDatagridwiew(dgvLista,"Gray","Gray");
  
            limpiarcampos();
        }      

        private void btnEditar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            cargarCampos();
            verificarNuevo();

            bandera = false;

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            txtNombre.Focus();
        }

        public void verificarNuevo()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                nombres = false;
            }
            else
            {
                nombres = true;
            }

            if (string.IsNullOrEmpty(txtPaterno.Text) && string.IsNullOrEmpty(txtMaterno.Text))
            {

                apellido = false;
            }
            else
            {
                apellido = true;
            }

            if (string.IsNullOrEmpty(txtDomicilio.Text))
            {
                direccion = false;
            }
            else
            {
                direccion = true;
            }

            if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                numerodoc = false;
            }
            else
            {
                numerodoc = true;
            }

           
  
            if (cbxSexo.SelectedIndex == -1)
            {
                sexo = false;
            }
            else
            {
                sexo = true;
            }
      
            erpEstadoCivil.Clear();

            if (cbxEstadoCivil.SelectedIndex == -1)
            {
                estadocivil = false;
            }
            else
            {
                estadocivil = true;
            }

            if (cbxTipoDocumento.SelectedIndex == -1)
            {
                tipodocumento = false;
            }
            else
            {
                tipodocumento = true;
            }
            
        }
      
        private void cargarCampos()
        {
            idPersona = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idPersona"].Value);
            SrMidasD.Persona personaDatos = servicio.personaGet(Util.header,idPersona);
            txtNombre.Text = personaDatos.nombres;
            txtPaterno.Text = personaDatos.paterno;
            txtMaterno.Text = personaDatos.materno;
            txtNumeroDocumento.Text = personaDatos.numero_Documento;
            cbxSexo.SelectedItem = personaDatos.sexo;
            cbxEstadoCivil.SelectedItem = Utils.Utils.uppercaseFirstLetter(personaDatos.estado_Civil);
            txtDomicilio.Text =Utils.Utils.uppercaseFirstLetter(personaDatos.domicilio);
            cbxTipoDocumento.SelectedValue = personaDatos.idTipoDocumento;

            mtbFechaNacimiento.Text = Convert.ToDateTime(personaDatos.fecha_Nacimiento).ToString("dd-MM-yyyy");

            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, personaDatos.idPersona).imagen1);
            }
            catch
            {

            }

            Util.pintarDatagridwiew(dgvLista,"Gray","Gray");
        }
        private bool validarCampos()
        {
            limpiarErrores();
            verificarNuevo();

            if (!nombres)
            {
                Util.errorMensaje(erpNombre,lblNombre,"Debe Introducir Nombre");
            }
            if (!apellido)
            {
                Util.errorMensaje(erpApellido, lblPaterno, "Debe Introducir Por Lo Menos un Apellido");
                Util.errorMensaje(erpApellido,lblMaterno, "Debe Introducir Por Lo Menos un Apellido");
            }
            if (!direccion)
            {
                 Util.errorMensaje(erpDireccion,lblDomicilio, "Debe Introducir Direccion");
            }
            if (!sexo)
            {
                 Util.errorMensaje(erpSexo,lblSexo, "Debe Introducir un Sexo");
            }
            if (!estadocivil)
            {
                 Util.errorMensaje(erpEstadoCivil,lblEstadoCivil, "Debe Introducir un Sexo");
            }
            if (!numerodoc)
            {
                 Util.errorMensaje(erpnumDoc,lblDocumento, "Debe Introducir el Número de Documento");
            }
            if (!tipodocumento)
            {
                 Util.errorMensaje(erptipodocumento,lblTipoDoc, "Debe Introducir el Tipo de Documento");
            }    
           
                        
            if (personadministrador == "admin")
            {
                erpOcupacion.Clear();
                erpLugarTrabajo.Clear();

                if (nombres == true && apellido == true && direccion == true && sexo == true && estadocivil == true && tipodocumento == true && numerodoc == true) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
             }
                if (nombres == true && apellido == true && direccion == true && sexo == true && estadocivil == true && tipodocumento == true && numerodoc == true) 
                {
                    return true;
                }
                else
                {
                    return false;
                }   
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bandera)
            {
                if (!validarCampos())
                {}
                else
                {
                    //Verificar si existe
                    SrMidasD.Persona personaDatos = servicio.personaValidarNuevo(Util.header ,txtNumeroDocumento.Text.Trim());
                    if (personaDatos != null)
                    {
                        string nombre = personaDatos.nombres;
                        string paterno = personaDatos.paterno;
                        string materno = personaDatos.materno;
                        string documento = personaDatos.numero_Documento;

                        if (Convert.ToBoolean(personaDatos.registroActivo))
                        {
                            MessageBox.Show("La persona ya está registrado.\rNombre: " + nombre + ".\rApellido Paterno: " + paterno + ".\rApelllido Materno: " + materno + ".\rDoc. Identidad: " + documento + ".", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult ResultadoDialogo = MessageBox.Show("La persona está dada de baja. ¿Desea activarlo?.\rNombre: " + nombre + ".\rApellido Paterno: " + paterno + ".\rApelllido Materno: " + materno + ".\rDoc. Identidad: " + documento + ".", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ResultadoDialogo == DialogResult.Yes)
                            {
                                //Activar Persona
                                activarPersona(personaDatos.idPersona);
                                MessageBox.Show("La Persona ha sido activada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        guardar();
                        Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                    }
                }
            }
            else
            {
                if (!validarCampos())
                { }
                else
                {
                    editar();
                    Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                }
            }
        }
     
        private void activarPersona(int idPersona)
        {
            servicio.personaActivar(Util.header, idPersona);
            listar();
            limpiarcampos();

            limpiarErrores();
            reiniciarVerificacion();
        }

        private void guardar()
        {
            limpiarErrores();
            try
            {
                SrMidasD.Persona persona = new SrMidasD.Persona();
                persona.idTipoDocumento = 1;
                persona.numero_Documento = txtNumeroDocumento.Text.Trim();
                persona.paterno = txtPaterno.Text.Trim();
                persona.materno = txtMaterno.Text.Trim();
                persona.nombres = txtNombre.Text.Trim();
                persona.domicilio = personaArgos.domicilio;
                persona.estado_Civil = personaArgos.estadoCivil;
                switch (persona.estado_Civil)
                {
                    case "CASADA":
                        persona.sexo = "F";
                        break;
                    case "CASADO":
                        persona.sexo = "M";
                        break;
                    case "SOLTERA":
                        persona.sexo = "F";
                        break;
                    case "SOLTERO":
                        persona.sexo = "M";
                        break;
                    case "VIUDA":
                        persona.sexo = "F";
                        break;
                    case "VIUDO":
                        persona.sexo = "M";
                        break;
                    case "DIVORCIADA":
                        persona.sexo = "F";
                        break;
                    case "DIVORCIADO":
                        persona.sexo = "M";
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                persona.departamento_Nacimiento = personaArgos.departamentoNacimiento;
                persona.pais_Nacimiento = personaArgos.paisNacimiento;
                persona.localidad_Nacimiento = personaArgos.localidadNacimiento;
                persona.provincia_Nacimiento = personaArgos.provinciaNacimiento;
                persona.profesion = personaArgos.profesion;
                persona.fecha_Nacimiento = personaArgos.fechaNacimiento;
                persona.registroActivo = true;
                persona.usuarioRegistro = usuario.nombre_Usuario;
                persona.fechaRegistro = DateTime.Now.Date;

                idPersona = servicio.personaInsertar(Util.header, persona);

                SrMidasD.Imagen imagen = new SrMidasD.Imagen();
                imagen.idPersona = imagen.idPersona;
                imagen.idPersona = idPersona;
                imagen.registroActivo = true;
                imagen.usuarioRegistro = usuario.nombre_Usuario;
                imagen.fechaRegistro = DateTime.Now.Date;
                imagen.imagen1 = Utils.Utils.imageToByteArray(pbImagen.Image);

                servicio.imagenInsertar(Util.header, imagen);

                listar();
                reiniciarVerificacion();
                MessageBox.Show("Se ha registrado correctamente", "::: MidasD - Información :::");
            }
            catch
            {
                MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void reiniciarVerificacion()
        {
            nombres = false;
            apellido = false;
            direccion = false;
            sexo = false;
            estadocivil = false;
            tipodocumento = false;
            numerodoc = false;
            fechaNac = false;          
        }

        public void limpiarErrores()
        {
            erpNombre.Clear();
            erpApellido.Clear();
            erpDireccion.Clear();
            erpSexo.Clear();
            erpEstadoCivil.Clear();
            erptipodocumento.Clear();
            erpnumDoc.Clear();
            erpExpedido.Clear();
            erpPais.Clear();
            erpCelularTelefono.Clear();
            erpFechaNac.Clear();
            erpOcupacion.Clear();
            erpLugarTrabajo.Clear();
        }

        private void editar()
        {
            limpiarErrores();

            try
            {
                buscarCi();
                SrMidasD.Persona persona = servicio.personaGet(Util.header, idPersona);
                persona.idPersona = idPersona;
                persona.idTipoDocumento =Convert.ToInt32(cbxTipoDocumento.SelectedValue.ToString());
                persona.numero_Documento = txtNumeroDocumento.Text.Trim();
                persona.paterno = txtPaterno.Text.Trim();
                persona.materno = txtMaterno.Text.Trim();
                persona.nombres = txtNombre.Text.Trim();
                persona.domicilio = personaArgos.domicilio;
                persona.estado_Civil = personaArgos.estadoCivil;
                switch (persona.estado_Civil)
                {
                    case "CASADA":
                        persona.sexo = "F";
                        break;
                    case "CASADO":
                        persona.sexo = "M";
                        break;
                    case "SOLTERA":
                        persona.sexo = "F";
                        break;
                    case "SOLTERO":
                        persona.sexo = "M";
                        break;
                    case "VIUDA":
                        persona.sexo = "F";
                        break;
                    case "VIUDO":
                        persona.sexo = "M";
                        break;
                    case "DIVORCIADA":
                        persona.sexo = "F";
                        break;
                    case "DIVORCIADO":
                        persona.sexo = "M";
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                persona.departamento_Nacimiento = personaArgos.departamentoNacimiento;
                persona.pais_Nacimiento = personaArgos.paisNacimiento;
                persona.localidad_Nacimiento = personaArgos.localidadNacimiento;
                persona.provincia_Nacimiento = personaArgos.provinciaNacimiento;
                persona.profesion = personaArgos.profesion;
                persona.fecha_Nacimiento = personaArgos.fechaNacimiento;
              
                persona.registroActivo = true;
                persona.usuarioRegistro = usuario.nombre_Usuario;
                persona.fechaRegistro = DateTime.Now.Date;

                servicio.personaEditar(Util.header, persona);

                SrMidasD.Imagen imagen = servicio.imagenGetidPersona(Util.header, Convert.ToInt32(persona.idPersona));
                imagen.idImagen = imagen.idImagen;
                imagen.idPersona = imagen.idPersona;
                imagen.imagen1 = Utils.Utils.imageToByteArray(pbImagen.Image);

                servicio.imagenEditar(Util.header, imagen);
                listar();

                limpiarcampos();
                MessageBox.Show("La Persona ha sido editada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             
            catch
            {
                MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            listar();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista,"Black","Gray");
            limpiarcampos();    
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            limpiarErrores();

            DialogResult ResultadoDialogo = MessageBox.Show("El ususario será dado de baja.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idPersona = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idPersona"].Value);
                servicio.personaEliminar(Util.header,idPersona);
                MessageBox.Show("El Usuario ha sido dado de baja.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                limpiarcampos();
            }
        }

        private void pbImagen_Click(object sender, EventArgs e)
        {
            pbImagen.Refresh();
            pbImagen.Show();
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        public void textleave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        }

        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyLetters(sender, e);

            string nombre = ((TextBox)sender).Name.ToString();
            if (nombre == "txtNombre")
            {
                erpNombre.Clear();
                nombres = true;
            }
            if (nombre == "txtPaterno" || nombre == "txtMaterno")
            {
                erpApellido.Clear();
                apellido = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && nombre == "txtNombre")
            {
                txtPaterno.Focus();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && nombre == "txtPaterno")
            {
                txtMaterno.Focus();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && nombre == "txtMaterno")
            {
                txtDomicilio.Focus();
            }         
        }

        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {

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

                    

                    this.btnGuardar.Enabled = true;
                }
                else if (personaArgos.estado == 1)//No Existe Cedula Real y se Procedera a su Creacion Manual
                {
                    this.txtNombre.Text = string.Empty;
                    this.txtPaterno.Text = string.Empty;
                    this.txtMaterno.Text = string.Empty;
                    this.txtUsuario.Text = string.Empty;
                    this.pbImagen.Image = null;
                    if (this.esNuevo)//Advertimos su Creacion 
                    {
                        DialogResult result = MessageBox.Show("La C\x00e9dula de Identidad es inv\x00e1lida\r\x00bfDesea introducir los datos de todas maneras?", "::: Midas - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        this.txtNombre.Focus();
                        this.btnGuardar.Enabled = true;
                    }
                    else
                    {
                        this.erpSexo.SetError(this.txtNumeroDocumento, "La C\x00e9dula de Identidad es inv\x00e1lida.");
                        this.txtNumeroDocumento.Focus();
                        this.btnGuardar.Enabled = false;
                    }
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
                    this.btnGuardar.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("No se pudo establecer conexi\x00f3n con el servicio Segip Consulta", "::: Midas - Error :::", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }



        private void FrmPersona_Load(object sender, EventArgs e)
        {
            listar();
            cargarTipoDocumento();       
        }

        void limpiarcampos()
        {
            txtNombre.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            txtNumeroDocumento.Clear();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            reiniciarVerificacion();
            listar();
            //dgvLista.DataSource = servicio.personaBuscar(Util.header, txtBuscar.Text);
        }


        private void combo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.AutoCompleteCombo((ComboBox)sender, e, false);

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtDomicilio.Focus();
            }
        }

        private void btnNuevoPersona_Click(object sender, EventArgs e)
        {
            esNuevo = true;
        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarErrores();
            cargarCampos();
            verificarNuevo();

            bandera = false;

            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            txtNombre.Focus();
        }

        private void cbxSexo_Leave(object sender, EventArgs e)
        {
            erpSexo.Clear();
        }

        private void cbxEstadoCivil_Leave(object sender, EventArgs e)
        {
            erpEstadoCivil.Clear();
        }

        private void cbxTipoDocumento_Leave(object sender, EventArgs e)
        {
            erptipodocumento.Clear();
        }

        private void cbxPais_Leave(object sender, EventArgs e)
        {
            erpPais.Clear();
        }

        private void cbxExpedido_Leave(object sender, EventArgs e)
        {
            erpExpedido.Clear();
        }

        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Util.notPaste = true;

            string nombre = ((TextBox)sender).Name.ToString();
            
            if (nombre == "txtDireccion")
            {
                erpDireccion.Clear();
                direccion = true;
            }
            if (nombre == "txtCelular" || nombre == "txtTelefono")
            {
                Utils.Wfa.onlyNumbers(sender, e);
                erpCelularTelefono.Clear();

            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && nombre == "txtDireccion")
            {
                cbxSexo.Focus();
                cbxSexo.DroppedDown = true;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter) && nombre == "txtTelefono")
            {
                mtbFechaNacimiento.Focus();
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter) && nombre == "txtNumeroDocumento")
            {

                try
                {
                    buscarCi();

                }
                catch
                { }
            }

        }

        private void combo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string nombre = ((ComboBox)sender).Name.ToString();

            if (nombre == "cbxTipoDocumento")
            {
                erptipodocumento.Clear();
                txtNumeroDocumento.Focus();
                tipodocumento = true;
                ((ComboBox)sender).MouseLeave += new System.EventHandler(cbxTipoDocumento_Leave);
            }
            if (nombre == "cbxEstadoCivil")
            {
                erpEstadoCivil.Clear();
                cbxTipoDocumento.Focus();
                cbxTipoDocumento.DroppedDown = true;
                estadocivil = true;
                ((ComboBox)sender).MouseLeave += new System.EventHandler(cbxEstadoCivil_Leave);
            }
            if (nombre == "cbxSexo")
            {
                erpSexo.Clear();
                cbxEstadoCivil.Focus();
                cbxEstadoCivil.DroppedDown = true;
                sexo = true;
                ((ComboBox)sender).MouseLeave += new System.EventHandler(cbxSexo_Leave);
            }
            
        }

       

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
        }

        private void FrmPersona_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender,e);
            }
        } 
    }
}
