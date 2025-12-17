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
using MidasD.SrMidasD;
using MidasD.Reportes;
using System.Configuration;

namespace MidasD
{
    public partial class FrmFuncionarioFianzaAdministracionDatos : Form
    {
        SrMidasD.Usuario usuario;


        public int idFuncionario, idPersona, idFianza;
        SrMidasD.MidasDServiceClient servicio;
        FrmCargando frmCargando;
        SrArgos.ArgosServiceClient servicioArgos;
        public Persona1 personaArgos;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;

        public bool nombres, apellido,
        tipodocumento, numerodoc, unidadEjecutora,
        oficina, cargo, numeroMemorando, tipodeFianza = false;

        DateTime fechaActualDiauno, fechaActualServidor;

        public FrmFuncionarioFianzaAdministracionDatos(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();
            servicioArgos = new SrArgos.ArgosServiceClient();

            btnPnlLista = new List<Control>() {
            btnBuscar,txtBuscar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() { btnEditar,btnQuitarSeleccion,btnEditarDescuentos,btnImpCartilla,btnImpCertificado,btnValidarHb,btnValidarCb };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar, pnlDatos };
            Util.btn_Mouse(new List<PictureBox>() { btnEditar,btnBuscar,btnQuitarSeleccion,
            btnCancelar, btnGuardar, btnSalir });

            fechaActualServidor = servicio.fechaServidor();
            string mayo = ConfigurationManager.AppSettings.Get("1Mayo");
            if (mayo == "1")
            {
                if (fechaActualServidor.Month > 6)
                {
                    txtGestion.Text = fechaActualServidor.Year.ToString();
                }
                else
                {
                    txtGestion.Text = (fechaActualServidor.Year - 1).ToString();
                }
            }
            else
            {
                txtGestion.Text = fechaActualServidor.Year.ToString();
            }

            fechaActualDiauno = new DateTime(fechaActualServidor.Year, fechaActualServidor.Month, 01);
            mtxtFechaMemorando.Text = fechaActualDiauno.ToString("dd-MM-yyyy");

            cargarTipoDocumento();
            cargarUnidadEjecutora();
            cargarTipoFianza();

            cbxOficina.Enabled = false;
            cbxCargo.Enabled = false;

            txtBuscar.Focus();
        }

        public class WinAPI
        {
            // Constantes para SetWindowsPos
            //   Valores de wFlags
            const int SWP_NOSIZE = 0x1;
            const int SWP_NOMOVE = 0x2;
            const int SWP_NOACTIVATE = 0x10;
            const int wFlags = SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE;
            //   Valores de hwndInsertAfter
            const int HWND_TOPMOST = -1;
            const int HWND_NOTOPMOST = -2;
            //
            /// <summary>
            /// Para mantener la ventana siempre visible
            /// </summary>
            /// <remarks>No utilizamos el valor devuelto</remarks>
            [DllImport("user32.DLL")]
            private extern static void SetWindowPos(
                int hWnd, int hWndInsertAfter,
                int X, int Y,
                int cx, int cy,
                int wFlags);

            public static void SiempreEncima(int handle)
            {
                SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, wFlags);
            }

            public static void NoSiempreEncima(int handle)
            {
                SetWindowPos(handle, HWND_NOTOPMOST, 0, 0, 0, 0, wFlags);
            }
        }



        //Listar Funcionarios para Recursos Humanos
        private async Task listar()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvLista;
            paFuncionarioFianzaActualBuscarGeneralAdministrador_Result[] asyncVariable1 = await this.servicio.pafuncionarioFianzaActualBuscarGeneralAdministradorAsync(Util.header, txtBuscar.Text, 2, 3);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFianza", "idFuncionario","a_Descontar", });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "Nro_Fianza", "ci", "cargo", "nombre_Completo", "fecha_Memorando","resolucion_Administrativa", "item", "vigencia_Contrato","haber_mensual", "total_Descuento", "total_Descontar", "falta_Descontar" });
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);

            frmCargando.Close();
        }


       
        //Listar Tipo de Documento
        private void cargarTipoDocumento()
        {
            cbxTipoDocumento.DataSource = servicio.tipoDocumentoListar(Util.header);
            cbxTipoDocumento.ValueMember = "idTipoDocumento";
            cbxTipoDocumento.DisplayMember = "descripcion";
            cbxTipoDocumento.SelectedIndex = -1;
        }

        //Listar las Unidades Encargadas
        private void cargarUnidadEjecutora()
        {
            cbxUnidadEjecutora.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutora.DisplayMember = "descripcion";
            cbxUnidadEjecutora.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutora.SelectedIndex = -1;
        }

        //Redimencionar Combo Box Oficinas
        public static int widthComboBox(ComboBox cbx)
        {
            int num = 0;
            int preferredWidth = 0;
            Label label = new Label
            {
                Font = new Font(cbx.Font.FontFamily, cbx.Font.Size, cbx.Font.Style, GraphicsUnit.Point, 0)
            };
            foreach (object obj2 in cbx.Items)
            {
                label.Text = ((paListaOficinaUnidadEjecutora_Result)obj2).oficina.Trim();
                preferredWidth = label.PreferredWidth;
                if (preferredWidth > num)
                {
                    num = preferredWidth;
                }
            }
            return (num + 20);
        }

        //Redimencionar Combo Box Cargos
        public static int widthComboBoxCargos(ComboBox cbx)
        {
            int num = 0;
            int preferredWidth = 0;
            Label label = new Label
            {
                Font = new Font(cbx.Font.FontFamily, cbx.Font.Size, cbx.Font.Style, GraphicsUnit.Point, 0)
            };
            foreach (object obj2 in cbx.Items)
            {
                label.Text = ((paListaCargoOficina_Result)obj2).Cargo.Trim();
                preferredWidth = label.PreferredWidth;
                if (preferredWidth > num)
                {
                    num = preferredWidth;
                }
            }
            return (num + 20);
        }

        //Listar las Oficinas de Acuerdo a la Unidad Encargada
        private void cargarOficinas()
        {
            try
            {

                cbxOficina.ValueMember = "idOficina";
                cbxOficina.DisplayMember = "oficina";
                cbxOficina.SelectedIndex = -1;
                cbxOficina.Enabled = true;
                cbxOficina.DataSource = servicio.oficinaListarUnidadEjecutora(Util.header, Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
                cbxOficina.DropDownWidth = widthComboBox(cbxOficina);
                cbxOficina.SelectedIndex = -1;
               
            }
            catch
            {

            }
        }

        //Listar Cargos de Acuerdo a la Oficina
        private void cargarCargo()
        {
            try
            {
                cbxCargo.DataSource = servicio.cargoListarOficinaAdmin(Util.header, Convert.ToInt32(cbxOficina.SelectedValue.ToString()),Convert.ToInt32(txtGestion.Text.ToString()));
                cbxCargo.ValueMember = "idCargo";
                cbxCargo.DisplayMember = "cargo";
                cbxOficina.DropDownWidth = widthComboBoxCargos(cbxCargo);
                cbxCargo.SelectedIndex = -1;
                cbxCargo.Enabled = true;
            }
            catch
            {

            }

        }

        //Listar los tipos de Fianza
        private void cargarTipoFianza()
        {
            cbxTipoFianza.DataSource = servicio.tipoFianzaListar(Util.header);
            cbxTipoFianza.DisplayMember = "descripcion_Fianza";
            cbxTipoFianza.ValueMember = "idTipoFianza";
            cbxTipoFianza.SelectedIndex = -1;
        }

        //Salir dek Firmulario
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        //Editar un Funcionario Registrado desde RRHH
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            await cargarCampos();

        }


        //Cargar Campos del Funcionario Registrado
        private async Task cargarCampos()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            bool validadoHabilitado, validadoContabilidad, fianzaImpresa;

            idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFuncionario"].Value);
            SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, idFuncionario);
            SrMidasD.Fianza fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);
            txtNumeroDocumento.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento;
            cbxTipoDocumento.SelectedValue = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).idTipoDocumento;
            txtNombre.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).nombres;
            txtPaterno.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).paterno;
            txtMaterno.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).materno;
            cbxUnidadEjecutora.SelectedValue = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina).idUnidadEjecutora;
            cbxOficina.SelectedValue = funcionarioDatos.idOficina;
            txtItem.Text = servicio.funcionarioGet(Util.header, idFuncionario).tipo_Contrato_Item.ToString();
            cbxTipoContrato.SelectedItem = servicio.funcionarioGet(Util.header, idFuncionario).vigencia_Contrato;
            SrMidasD.Cargo cargoDatos = servicio.cargoGet(Util.header,(int) funcionarioDatos.idCargo);

            EscalaSalarial escalaSalarialDatos = servicio.escalaSalarialGet(Util.header, (int)cargoDatos.idEscalaSalarial);

            if (escalaSalarialDatos != null)
            {
                txtGestion.Text = servicio.sueldoMensualGet(Util.header, (int)escalaSalarialDatos.idSueldoMensual).gestion.ToString();
               
            }
            else
            {
                txtGestion.Text = fechaActualServidor.Year.ToString();
            }


            cargarCargo();
            mtxtFechaMemorando.Text = Convert.ToDateTime(funcionarioDatos.fecha_Memorando).ToString("dd-MM-yyyy");
            cbxCargo.SelectedValue = funcionarioDatos.idCargo;
            txtNumeroMemorando.Text = funcionarioDatos.numero_Memorando;
            if (string.IsNullOrEmpty(fianzaDatos.Nro_Fianza.ToString()))
            {
                txtNroFianza.Text = fianzaDatos.Nro_Fianza_Fianza_Real.ToString();
            }
            else
            {
                txtNroFianza.Text = fianzaDatos.Nro_Fianza.ToString();
            }
            cbxTipoFianza.SelectedValue = servicio.fianzaIdFuncionario(Util.header, idFuncionario).idTipoFianza;
            try
            {
                pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)funcionarioDatos.idPersona).imagen1);
            }
            catch
            {

            }


            try
            {
                validadoHabilitado = (bool)fianzaDatos.fianza_Completa_Habilitado;
            }
            catch
            {
                validadoHabilitado = false;
            }
            try
            {
                validadoContabilidad = (bool)fianzaDatos.fianza_Validada_Contabilidad;
            }
            catch
            {
                validadoContabilidad = false;
            }
            try
            {
                fianzaImpresa = (bool)fianzaDatos.fianza_Impresa_RRHH;
            }
            catch
            {
                fianzaImpresa = false;
            }


            if (validadoHabilitado == true && validadoContabilidad == true)
            {
                Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
                Util.pnlListaActivar(false, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlLista3);
                Util.pnlListaActivar(true, btnPnlDatos);
                Util.pnlListaActivar(false, btnPnlLista2);
                txtNumeroDocumento.Focus();
                WinAPI.NoSiempreEncima(frmCargando.Handle.ToInt32());
                MessageBox.Show(" La Fianza se encuentra Validada por\r***Habilitado y Contabilidad***\rTenga Cuidado al Modificar", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
                Util.pnlListaActivar(false, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlLista3);
                Util.pnlListaActivar(true, btnPnlDatos);
                Util.pnlListaActivar(false, btnPnlLista2);
                txtNumeroDocumento.Focus();
            }

            frmCargando.Close();
           
        }

    




        //Revisamos que Este todo lleno sino damos Advertencia
        private bool validarCampos()
        {
            limpiarErrores();

            if (!numerodoc)
            {
                Util.errorMensaje(erpError, lblDocumento, "Debe Introducir el Número de Documento");
            }

            if (!tipodocumento)
            {
                Util.errorMensaje(erpError, lblTipoDoc, "Debe Introducir el Tipo de Documento");
            }

            if (!nombres)
            {
                Util.errorMensaje(erpError, lblNombre, "Debe Introducir Nombre");
            }

            if (!apellido)
            {
                Util.errorMensaje(erpError, lblPaterno, "Debe Introducir Por Lo Menos un Apellido");
                Util.errorMensaje(erpError, lblMaterno, "Debe Introducir Por Lo Menos un Apellido");
            }

            if (!unidadEjecutora)
            {
                Util.errorMensaje(erpError, lblUnidadEjecutora, "Debe Introducir la Unidad Ejecutora");

            }

            if (!oficina)
            {
                Util.errorMensaje(erpError, lblOficina, "Debe Introducir Una Oficina");

            }

            if (!cargo)
            {
                Util.errorMensaje(erpError, lblCargo, "Debe Introducir Un Cargo");

            }

            if (!numeroMemorando)
            {
                Util.errorMensaje(erpError, lblNumeroMemorando, "Debe Introducir el Número de Memorando");

            }

            if (!tipodeFianza)
            {
                Util.errorMensaje(erpError, lblTipoFianza, "Debe Introducir el Tipo de Fianza");

            }
            if (numerodoc == true && tipodocumento == true && nombres == true && apellido == true && unidadEjecutora == true && oficina == true && cargo == true && numeroMemorando == true && tipodeFianza == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Registrar un Funcionario por medio de RRHH
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            verificarDatos();
                if (!validarCampos())
                { }
                else
                {
                    editar();
                    MessageBox.Show("El Funcionario se ha editado correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarErrores();
                    await listar();
                    if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
                    Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                    limpiarcampos();
                }

        }

       

    
        //Limpiar errores
        public void limpiarErrores()
        {
            erpError.Clear();
        }

        //Opcion Editar
        private void editar()
        {
            limpiarErrores();

            try
            {
                SrMidasD.Persona persona =servicio.personaGet(Util.header,(int)servicio.funcionarioGet(Util.header, idFuncionario).idPersona);
                SrArgos.Persona1 personaArgos = servicioArgos.segipConsulta(this.txtNumeroDocumento.Text.Trim(), "7644473", this.txtNombre.Text.Trim(), this.txtPaterno.Text.Trim(), this.txtMaterno.Text.Trim(), "Harper");
                if (txtNumeroDocumento.Text == "0")
                {
                    persona.idTipoDocumento = 5;
                }
                else
                {
                    persona.idTipoDocumento = 1;
                }
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


                //Editar del Funcionario
                SrMidasD.Funcionario funcionario = servicio.funcionarioGet(Util.header, idFuncionario);
                    funcionario.numero_Memorando = txtNumeroMemorando.Text.Trim();
                    funcionario.idCargo = Convert.ToInt32(cbxCargo.SelectedValue.ToString());
                    funcionario.idOficina = Convert.ToInt32(cbxOficina.SelectedValue.ToString());
                    funcionario.tipo_Contrato_Item = Convert.ToInt32(txtItem.Text.ToString());
                    funcionario.vigencia_Contrato = cbxTipoContrato.SelectedItem.ToString();
                    funcionario.fecha_Memorando = Convert.ToDateTime(mtxtFechaMemorando.Text.ToString());
                    funcionario.codigo_Distrito = "06";
       
                    idFuncionario = servicio.funcionarioEditar(Util.header, funcionario);

                    //Editar la Fianza
                    SrMidasD.Fianza fianza = servicio.fianzaIdFuncionario(Util.header, funcionario.idFuncionario);
                    fianza.Nro_Fianza =Convert.ToDouble(txtNroFianza.Text);
                    fianza.idTipoFianza = Convert.ToInt32(cbxTipoFianza.SelectedValue.ToString());
                    fianza.registro_Sigma = txtNumeroDocumento.Text.ToString();

                servicio.fianzaEditar(Util.header, fianza);
                
            }
             
            catch
            {
                  MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }

        //Opcion Cancelar
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        public async Task cancelar()
        {
            limpiarErrores();
            await listar();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            limpiarcampos();
        }

        //Primeras Letras Mayusculas
        public void textleave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        }

        //Solo letras
        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyLetters(sender, e);

            string nombre = ((TextBox)sender).Name.ToString();
            if (nombre == "txtNombre")
            {
                erpError.Clear();
                nombres = true;
            }
            if (nombre == "txtPaterno" || nombre == "txtMaterno")
            {
                erpError.Clear();
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
                  
        }

        //Solo numeros y al mismo tiempo verificamos fianza pendiente
        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyNumbers(sender, e);
           
            string nombre = ((TextBox)sender).Name.ToString();
            if (nombre == "txtNumeroDocumento")
            {
                erpError.Clear();
                numerodoc = true;          
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


        //Funcion Buscar Ci Segip
        private void buscarCi()
        {
                try
                {
                    personaArgos = this.servicioArgos.segipConsulta(this.txtNumeroDocumento.Text.Trim(), "7644473", this.txtNombre.Text.Trim(), this.txtPaterno.Text.Trim(), this.txtMaterno.Text.Trim(), "Harper");
                    this.erpError.Clear();
                    if (personaArgos.estado == 2)//Cuando Existe Cedula Real
                    {
                        this.txtNombre.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.nombres);
                        this.txtPaterno.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.paterno);
                        this.txtMaterno.Text = Utils.Utils.uppercaseFirstLetter(personaArgos.materno);
                        this.pbImagen.Image = Utils.Utils.byteArrayToImage(personaArgos.fotografia);

                        this.btnGuardar.Enabled = true;
                    }
                    else if (personaArgos.estado == 1)//No Existe Cedula Real y se Procedera a su Creacion Manual
                    {
                            DialogResult result = MessageBox.Show("La C\x00e9dula de Identidad es inv\x00e1lida\r\x00bfDesea introducir los datos de todas maneras?", "::: Harper - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);     
                    }
                    else
                    {
                        this.txtNombre.Text = string.Empty;
                        this.txtPaterno.Text = string.Empty;
                        this.txtMaterno.Text = string.Empty;
                        this.txtUsuario.Text = string.Empty;
                        this.pbImagen.Image = null;
                        MessageBox.Show("Se encontr\x00f3 m\x00e1s de un registro con la c\x00e9dula de identidad\rIntroduzca el apellido paterno!", "::: Harper - Consulta :::", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtPaterno.Focus();
                        this.btnGuardar.Enabled = false;
                    }
                }
                catch
                {
                    MessageBox.Show("No se pudo establecer conexi\x00f3n con el servicio Segip Consulta", "::: Harper - Error :::", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }    

        }


        //Cargar Inicio
        private async void FrmPersona_Load(object sender, EventArgs e)
        {
            DialogResult ResultadoDialogo = MessageBox.Show("Desea listar todas las Fianzas?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                txtBuscar.Enabled = false;
                await listar();
                txtBuscar.Enabled = true;
                dgvLista.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
               
            }
            else
            {
                txtBuscar.Focus();
            }
        }

      
        //Limpiamos todos los campos
        void limpiarcampos()
        {
            txtNombre.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            txtNumeroDocumento.Clear();
            txtNumeroMemorando.Clear();

            cbxTipoDocumento.SelectedIndex = -1;
            cbxTipoDocumento.ResetText();

            cbxUnidadEjecutora.SelectedIndex = -1;
            cbxUnidadEjecutora.ResetText();

            cbxOficina.SelectedIndex = -1;
            cbxOficina.ResetText();

            cbxCargo.SelectedIndex = -1;
            cbxCargo.ResetText();

            cbxTipoFianza.SelectedIndex = -1;
            cbxTipoFianza.ResetText();

            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1; 
        }

       
        //Al seleccionar Oficina se Cargan los Cargos de la Oficina
        private void cbxOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCargo(); 
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFuncionario"].Value);
            int idTipoFianza = (int)servicio.fianzaIdFuncionario(Util.header,idFuncionario).idTipoFianza;

            try
            {
                new FrmCrSolicitudFianza(idFuncionario, idTipoFianza,usuario.nombre_Usuario).ShowDialog();
            }
            catch
            {

            }
        }

        private void txtGestion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cargarCargo();
            }
        }

        private void btnEditarDescuentos_Click(object sender, EventArgs e)
        {
            idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFuncionario"].Value);
            SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, idFuncionario);
            new FrmHabilitadoDescuentoCorreccion(usuario, servicio.personaGet(Util.header,(int)funcionarioDatos.idPersona).numero_Documento, "Administrador").ShowDialog();
        }

        private async void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        private void btnImpCartilla_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmCrCartillaVerFianza(Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value), usuario.nombre_Usuario, "Administrador", Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value)).ShowDialog();
            }
            catch { }
        }

        private void btnImpCertificado_Click(object sender, EventArgs e)
        {
            try
            {
                int idFianza = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value);
                Fianza fianza = servicio.fianzaGet(Util.header, idFianza);
                int idUnidadEjecutora = (int)servicio.oficinaGet(Util.header, (int)servicio.funcionarioGet(Util.header, (int)fianza.idFuncionario).idOficina).idUnidadEjecutora;
                string fecha = string.Format("{0:D}", servicio.fianzaGet(Util.header, idFianza).fechaRegistro);
                new FrmCrCertificado(idFianza, idUnidadEjecutora, fecha, usuario).ShowDialog();
            }
            catch { MessageBox.Show("No se Puede Imprimir - Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnValidarHb_Click(object sender, EventArgs e)
        {
            idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFuncionario"].Value);
            SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, idFuncionario);
            new FrmValidarFianzaCompleta(usuario,servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento, Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value), "Habilitado").ShowDialog();
        }

        private void btnValidarCb_Click(object sender, EventArgs e)
        {
            idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFuncionario"].Value);
            SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, idFuncionario);
            new FrmValidarFianzaCompleta(usuario, servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento, Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value), "Contabilidad").ShowDialog();
        }

        private async void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarErrores();
            await cargarCampos();
        }

      

        public void imprimir()
        {
           
           new FrmCrSolicitudFianza(idFuncionario, (int)servicio.fianzaIdFuncionario(Util.header, idFuncionario).idTipoFianza,usuario.nombre_Usuario).ShowDialog();

        }

        //Al seleccionar la Unidad Ejecutora se Cargan las Oficinas
        private void cbxUnidadEjecutora_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarOficinas();
        }

        //Buscar Funcionarios
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            await listar();
        }

       

        //Al escribir se limpia los errores
        private void cbxCargo_Leave(object sender, EventArgs e)
        {
            erpError.Clear();
        }

        //Al escribir se limpia los errores
        private void cbxTipoDocumento_Leave(object sender, EventArgs e)
        {
            erpError.Clear();
        }

        //Al escribir se limpia los errores
        private void cbxOficina_Leave(object sender, EventArgs e)
        {
            erpError.Clear();
        }

        //Al escribir se limpia los errores y pasamos a tipo de fianza
        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.notPaste = true;

            string nombre = ((TextBox)sender).Name.ToString();
            
            if (nombre == "txtNumeroMemorando")
            {
                erpError.Clear();
                numeroMemorando = true;

                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    cbxTipoFianza.Focus();
                    cbxTipoFianza.DroppedDown = true;
                }
            }
        }

        //Dependiendo al combo box navegamos de manera facil
        private void combo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string nombre = ((ComboBox)sender).Name.ToString();

            if (nombre == "cbxUnidadEjecutora")
            {
                erpError.Clear();
                cbxOficina.Focus();
                cbxOficina.DroppedDown = true;
                ((ComboBox)sender).MouseLeave += new System.EventHandler(cbxOficina_Leave);
            }
            if (nombre == "cbxOficina")
            {
                erpError.Clear();
                cbxCargo.Focus();
                cbxCargo.DroppedDown = true;
                ((ComboBox)sender).MouseLeave += new System.EventHandler(cbxCargo_Leave);
            }

            if (nombre == "cbxCargo")
            {
                erpError.Clear();
                txtNumeroMemorando.Focus();
                txtNumeroMemorando.Enabled = true;
            }

        }

       
        //Seleccion para evitar errores
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
        }

        //Limpiamos la memoria
        private void FrmFuncionario_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        //Insertamos numeracion
        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        //Opcion buscar presionando enter
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender,e);
            }
        }


        //Validacion de si todo esta lleno
        public void verificarDatos()
        {
            //Numero de Documento
            if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                numerodoc = false;
            }
            else
            {
                numerodoc = true;
            }

            //Nombres
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                nombres = false;
            }
            else
            {
                nombres = true;
            }

            //Apellidos
            if (string.IsNullOrEmpty(txtPaterno.Text) && string.IsNullOrEmpty(txtMaterno.Text))
            {

                apellido = false;
            }
            else
            {
                apellido = true;
            }

            //Tipo de Documento
            if (cbxTipoDocumento.SelectedIndex == -1)
            {
                tipodocumento = false;
            }
            else
            {
                tipodocumento = true;
            }

            //Unidad Ejecutora
            if (cbxUnidadEjecutora.SelectedIndex == -1)
            {
                unidadEjecutora = false;
            }
            else
            {
                unidadEjecutora = true;
            }

            //Oficina
            if (cbxOficina.SelectedIndex == -1)
            {
                oficina = false;
            }
            else
            {
                oficina = true;
            }

            //Cargo
            if (cbxCargo.SelectedIndex == -1)
            {
                cargo = false;
            }
            else
            {
                cargo = true;
            }


            //Numero de Memorando
            if (string.IsNullOrEmpty(txtNumeroMemorando.Text))
            {
                numeroMemorando = false;
            }
            else
            {
                numeroMemorando = true;
            }

            //Tipo de Fianza
            if (cbxTipoFianza.SelectedIndex == -1)
            {
                tipodeFianza = false;
            }
            else
            {
                tipodeFianza = true;
            }

        }
    }
}
