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
using System.Configuration;
using MidasD.Reportes;

namespace MidasD
{
    public partial class FrmValidacionBienesGravamenes : Form
    {
        SrMidasD.Usuario usuario;
      
        FrmCargando frmCargando;
        public int idFuncionario,idPersona,idFianza;
        SrMidasD.MidasDServiceClient servicio;
        SrArgos.ArgosServiceClient servicioArgos;
        public Persona1 personaArgos;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;
        string c31;
        public bool nombres, apellido, bandera,
        tipodocumento, numerodoc, unidadEjecutora,
        oficina, cargo, numeroMemorando,resolucionAdministrativa,montoBeneficiario,item,tipoContrato,fechaMemorando, cpbte
            , TipoFianzaReal, aFavorFianzaReal1, TipoBienInmueble, EstadoBienInmueble, nroFianzaReal = false;
        DateTime fechaActualDiauno, fechaActualServidor;

        public FrmValidacionBienesGravamenes(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();
            servicioArgos = new SrArgos.ArgosServiceClient();
            btnPnlLista = new List<Control>() { 
            btnBuscar,txtBuscar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlLista2 = new List<Control>() {  btnEditar, btnImprimir, btnQuitarSeleccion };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() { btnEditar, btnBuscar, 
            btnCancelar, btnGuardar, btnSalir,btnImprimir,btnQuitarSeleccion });


            cargarTipoDocumento();
            cargarUnidadEjecutora();

            cbxOficina.Enabled = false;
            cbxCargo.Enabled = false;

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
        }

        private async Task listar()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);
            WinAPI.SiempreEncima(frmCargando.Handle.ToInt32());

            DataGridView asyncVariable0 = this.dgvLista;
            paListarFuncionariosFianzaConResolucionBienesGravados_Result[] asyncVariable1 = await this.servicio.paListarFuncionariosFianzaConResolucionBienesGravadosAsync(Util.header, txtBuscar.Text, usuario.nombre_Usuario);
            asyncVariable0.DataSource = asyncVariable1;
            asyncVariable0 = null;
            asyncVariable1 = null;

           
                Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFuncionario", "idFianza" });
                Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "gestion", "Nro_Fianza", "Cpbte", "nombre_Completo", "ci", "cargo", "tipo", "t727", "monto_Beneficiario", "tipo_t", "ubicacion", "folio", "concepto", "a_favor", "ultimo_registro", "a_favor_a", "estado_Bien_Inmueble", "estado_Actual", "numero_Memorando", "fecha_Memorando", "oficina", "tipo_contrato_item", "vigencia_Contrato", "resolucion_Administrativa", "fecha_Resolucion", "usuario_Asesor", "fianza_Validada_Contabilidad", "observacion", "fechaRegistro" });
                Utils.Wfa.setHeadersDGV(dgvLista);
                dgvLista.AutoResizeColumns();
                dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           
            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);

            frmCargando.Close();

        }

        private void listarNoAsyn()
        {
            dgvLista.DataSource= servicio.paListarFuncionariosFianzaConResolucionBienesGravados(Util.header, txtBuscar.Text, usuario.nombre_Usuario);

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFuncionario", "idFianza" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "Nro_Fianza", "gestion", "tipo_Fianza", "numero_Memorando", "fecha_Memorando", "numero_Documento", "nombre_Completo", "cargo", "oficina", "haber_Mensual", "tipo_contrato_item", "vigencia_Contrato", "resolucion_Administrativa", "usuario_Asesor", "fecha_Resolucion", "comprobante_CPBTE", "descripcion_Tipo_Fianza_Real", "ubicacion_Fianza_Real", "folio_Fianza_Real", "concepto_Fianza_Real", "a_Favor_Fianza_Real", "tipo_Fianza_Real", "monto_Beneficiario", "fianza_Validada_Contabilidad", "observacion", "fechaRegistro" });
            Utils.Wfa.setHeadersDGV(dgvLista);
            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);
        }

       

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bandera = false;
            limpiarErrores();
            cargarCampos();
            Util.pnlListaActivar(false, btnPnlLista3);
            verificarNuevo();
        }

        public void verificarNuevo()
        {//Numero de Documento
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
            //TipoContratoItem
            if (cbxTipoContrato.SelectedIndex == -1)
            {
                tipoContrato = false;
            }
            else
            {
                tipoContrato = true;
            }

            //Numero item
            if (string.IsNullOrEmpty(txtItem.Text))
            {
                item = false;
            }
            else
            {
                item = true;
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

            //Fecha Memorando
            if (string.IsNullOrEmpty(mtxtFechaMemorando.Text))
            {
                fechaMemorando = false;
            }
            else
            {
                fechaMemorando = true;
            }

            //Resolucion Administrativa
            if (string.IsNullOrEmpty(txtResolucionAdministrativa.Text))
            {
                resolucionAdministrativa = false;
            }
            else
            {
                resolucionAdministrativa = true;
            }

            //Cpbte
            if (string.IsNullOrEmpty(txtcpbte.Text))
            {
                cpbte = false;
            }
            else
            {
                cpbte = true;
            }

            //Tipo de Fianza Real **
            if (cbxTipoFianzaReal.SelectedIndex == -1)
            {
                TipoFianzaReal = false;
            }
            else
            {
                TipoFianzaReal = true;
            }

            //A favor 1
            if (string.IsNullOrEmpty(txtaFavorFianzaReal1.Text))
            {
                aFavorFianzaReal1 = false;
            }
            else
            {
                aFavorFianzaReal1 = true;
            }

            
            //Tipo de Inmueble
            if (string.IsNullOrEmpty(txtTipoBienInmueble.Text))
            {
                TipoBienInmueble = false;
            }
            else
            {
                TipoBienInmueble = true;
            }

           
            //Estado del Inmueble
            if (cbxEstadoBienInmueble.SelectedIndex == -1)
            {
                EstadoBienInmueble = false;
            }
            else
            {
                EstadoBienInmueble = true;
            }

            //Monto Beneficiario
            if (string.IsNullOrEmpty(mxbMontoBeneficiario.Text) && string.IsNullOrEmpty(txt727BG.Text))
            {
                montoBeneficiario = false;
            }
            else
            {
                montoBeneficiario = true;
            }

           //Nro Fianza
            if (string.IsNullOrEmpty(txtNroFianzaReal.Text))
            {
                nroFianzaReal = false;
            }
            else
            {
                nroFianzaReal = true;
            }
        }

        private async  void cargarCampos()
        {
            bool validado = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["fianza_Validada_Contabilidad"].Value);
            int comprobante;
            try
            {
                comprobante =Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["cpbte"].Value.ToString());
            }
            catch
            {
                comprobante = 100;
            }
            
            if (!validado || comprobante ==0)
            {
                idFianza = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value);
                SrMidasD.Fianza fianzaDatos = servicio.fianzaGet(Util.header, idFianza);
                idFuncionario = (int)servicio.fianzaGet(Util.header, idFianza).idFuncionario;
                SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, idFuncionario);
                txtNroFianzaReal.Text = fianzaDatos.Nro_Fianza_Fianza_Real.ToString();
                txtNombre.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).nombres;
                txtPaterno.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).paterno;
                txtMaterno.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).materno;
                txtNumeroDocumento.Text = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento;
                cbxTipoDocumento.SelectedValue = servicio.tipoDocumentoGet(Util.header, (int)servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).idTipoDocumento).idTipoDocumento;
                cbxUnidadEjecutora.SelectedValue = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina).idUnidadEjecutora;
                cbxOficina.SelectedValue = funcionarioDatos.idOficina;
                txtOficinaLiteral.Text = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina).oficina1;//Cargamos los Cargos

                int idEscalaSalarial = (int)servicio.cargoGet(Util.header, (int)funcionarioDatos.idCargo).idEscalaSalarial;
                int idHaberBasico = (int)servicio.escalaSalarialGet(Util.header, idEscalaSalarial).idSueldoMensual;
                cbxCargo.DataSource = servicio.cargoListarOficina(Util.header, (int)funcionarioDatos.idOficina, (int)servicio.sueldoMensualGet(Util.header, idHaberBasico).gestion);
                try
                {
                    txtResolucionAdministrativa.Text = servicio.fianzaGet(Util.header, idFianza).resolucion_Administrativa;
                    txtcpbte.Text = fianzaDatos.comprobante_CPBTE;
                    cbxTipoFianzaReal.Text = fianzaDatos.tipo_Fianza_Real;
                    txtUbicacionFianzaReal.Text = fianzaDatos.ubicacion_Fianza_Real;
                    txtFolioFianzaReal.Text = fianzaDatos.folio_Fianza_Real;
                    txtConceptoFianzaReal.Text = fianzaDatos.concepto_Fianza_Real;
                    txtaFavorFianzaReal1.Text = fianzaDatos.a_Favor_Fianza_Real;
                    txtUltimoRegistro.Text =fianzaDatos.ultimo_Registro_Fianza_Real.ToString();
                    txtTipoBienInmueble.Text = fianzaDatos.descripcion_Tipo_Fianza_Real;
                    txtaFavorFianzaReal2.Text = fianzaDatos.a_Favor_2_Fianza_Real;
                    cbxEstadoBienInmueble.SelectedItem = fianzaDatos.estado_Bien_Inmueble_Fianza_Real;
                    try
                    {
                        mxbMontoBeneficiario.Text = dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["monto_Beneficiario"].Value.ToString();
                        //mxbMontoBeneficiario.Text = servicio.paFianzaReporteCartilla(Util.header, idFianza).FirstOrDefault().total_descontado_en_planilla;
                        //txt727BG.Text = servicio.descuentoGetIdFianzaReclasificacion(Util.header, fianzaDatos.idFianza).t727_Fianza_Real.ToString();
                        txt727BG.Text = dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["t727"].Value.ToString();
                    }
                    catch { }
                    
                    cbxUnidadEjecutora.SelectedValue = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina).idUnidadEjecutora;
                    cbxOficina.SelectedValue = funcionarioDatos.idOficina;
                    txtObservacion.Text = fianzaDatos.observacion;

                    /*Consulta para obtener el mes y año de los descuentos*/
                    string mes;
                    string anio;
                    try
                    {
                        mes = servicio.paFianzaReporteCartilla(Util.header, fianzaDatos.idFianza).FirstOrDefault().mes_anio.Substring(0, 3);
                        anio = servicio.paFianzaReporteCartilla(Util.header, fianzaDatos.idFianza).FirstOrDefault().mes_anio.Substring(5, 5);

                        switch (mes)
                        {
                            case "Ene":
                                mes = "1";
                                break;
                            case "Feb":
                                mes = "2";
                                break;
                            case "Mar":
                                mes = "3";
                                break;
                            case "Abr":
                                mes = "4";
                                break;
                            case "May":
                                mes = "5";
                                break;
                            case "Jun":
                                mes = "6";
                                break;
                            case "Jul":
                                mes = "7";
                                break;
                            case "Ago":
                                mes = "8";
                                break;
                            case "Sep":
                                mes = "9";
                                break;
                            case "Oct":
                                mes = "10";
                                break;
                            case "Nov":
                                mes = "11";
                                break;
                            case "Dic":
                                mes = "12";
                                break;

                            default:
                                mes = fechaActualServidor.Month.ToString();
                                break;
                        }
                    }
                    catch
                    {
                        mes = fechaActualServidor.Month.ToString();
                        anio = fechaActualServidor.Year.ToString();
                    }
                    //txtMes.Text = fechaActualServidor.Month.ToString();
                    //txtAnio.Text = fechaActualServidor.Year.ToString();
                    txtMes.Text = mes;
                    txtAnio.Text = anio;
                }
                catch { }
                cbxCargo.ValueMember = "idCargo";
                cbxCargo.DisplayMember = "cargo";
                cbxCargo.SelectedValue = funcionarioDatos.idCargo;

                //cbxTipoContrato.ValueMember = "idTipoContrato";
                //cbxTipoContrato.DisplayMember = "TipoContrato";
                cbxTipoContrato.SelectedItem = funcionarioDatos.vigencia_Contrato;

                txtItem.Text = funcionarioDatos.tipo_Contrato_Item.ToString();
                mtxtFechaMemorando.Text = Convert.ToDateTime(funcionarioDatos.fecha_Memorando).ToString("dd-MM-yyyy");

                txtNumeroMemorando.Text = funcionarioDatos.numero_Memorando;
                //txtTipoFianzaReal.Text = servicio.fianzaVerificarPendiente(Util.header, funcionarioDatos.idFuncionario).resolucionAdministrativa;
                try
                {
                    pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, (int)funcionarioDatos.idPersona).imagen1);
                }
                catch { }
                Util.pnlListaActivar(false, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlLista3);
                Util.pnlListaActivar(true, btnPnlDatos);
                Util.pnlListaActivar(false, btnPnlLista2);
                txtNroFianzaReal.Focus();
                Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
            }
            else
            {
                MessageBox.Show("Ya no se puede Editar Porque el funcionario ya tiene esta fianza con Resolucion y esta validada por Contabilidad.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarErrores();

                if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
                Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                await cancelar();
            }
           

        }
        private bool validarCampos()
        {
            limpiarErrores();
            verificarNuevo();

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

            if (!tipoContrato)
            {
                Util.errorMensaje(erpError, lblTipoContratoItem, "Debe Introducir el Tipo Contrato");

            }

            if (!item)
            {
                Util.errorMensaje(erpError, lblItem, "Debe Introducir el numero de Item (Cuando es Contrato coloque '0')");

            }

            if (!numeroMemorando)
            {
                Util.errorMensaje(erpError, lblNumeroMemorando, "Debe Introducir el Número de Memorando");

            }

            if (!fechaMemorando)
            {
                Util.errorMensaje(erpError, lblFechaMemorando, "Debe Introducir el Fecha de Memorando");

            }

            if (!resolucionAdministrativa)
            {
                Util.errorMensaje(erpError, lblResolucionAdm, "Debe Introducir la Resolucion Administrativa");
            }

            if (!montoBeneficiario)
            {
                Util.errorMensaje(erpError, lblMontoBeneficiario, "Debe Introducir el monto del Bien Gravado");
                Util.errorMensaje(erpError, lbl727BG, "Debe Introducir el monto del Bien Gravado");
            }

            if(!cpbte)
            {
                Util.errorMensaje(erpError, lblCpbte, "Debe Introducir el Comprobante");
            }

            if (!TipoFianzaReal)
            {
                Util.errorMensaje(erpError, lblTipo, "Debe Introducir el Tipo de Inmueble");
            }

       

            if (numerodoc == true && tipodocumento == true && nombres == true && apellido == true && unidadEjecutora == true && oficina == true && cargo == true && numeroMemorando == true && resolucionAdministrativa == true && montoBeneficiario == true && tipoContrato == true && item == true && fechaMemorando == true)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bandera)
            {
                //if (validarCampos())
                //{
                //    await guardar();
                //    Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                //}
            }
            else
            {
                if (validarCampos())
                {
                    await editar();
                    Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                }
            }
        }
     
      

      
        public void reiniciarVerificacion()
        {
            nombres = false;
            apellido = false;
            unidadEjecutora = false;
            oficina = false;
            cargo = false;
            numeroMemorando = false;
            tipodocumento = false;
            numerodoc = false;

            montoBeneficiario = false;
            resolucionAdministrativa = false;       
        }

        public void limpiarErrores()
        {
            erpError.Clear();
          
        }

        private async Task guardar()
        {
            if (!verificarFianzaCurso())
            {
                try
                {
                    limpiarErrores();

                    //Verificamos si tenemos a la Persona Registrada en nuestra BD
                    try
                    {
                        idPersona = servicio.personaGetPorNumeroDocumento(Util.header, txtNumeroDocumento.Text).idPersona;
                    }
                    catch
                    {
                        idPersona = 0;
                    }

                    //Sino esta registrado lo registramos
                    if (idPersona == 0)
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
                            case "CASADO":
                                persona.sexo = "F";
                                break;
                            case "CASADA":
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
                        persona.fechaRegistro = fechaActualServidor;

                        idPersona = servicio.personaInsertar(Util.header, persona);

                        //Insertar Imagen
                        SrMidasD.Imagen imagen = new SrMidasD.Imagen();
                        imagen.idPersona = imagen.idPersona;
                        imagen.idPersona = idPersona;
                        imagen.registroActivo = true;
                        imagen.usuarioRegistro = usuario.nombre_Usuario;
                        imagen.fechaRegistro = fechaActualServidor;
                        imagen.imagen1 = Utils.Utils.imageToByteArray(pbImagen.Image);

                        servicio.imagenInsertar(Util.header, imagen);
                    }

                    try
                    {
                        //Registro del Funcionario
                        SrMidasD.Funcionario funcionario = new SrMidasD.Funcionario();
                        funcionario.idPersona = idPersona;
                        funcionario.numero_Memorando = txtNumeroMemorando.Text.Trim();
                        funcionario.tipo_Contrato_Item = Convert.ToInt32(txtItem.Text.Trim());
                        funcionario.vigencia_Contrato = cbxTipoContrato.SelectedItem.ToString();
                        funcionario.idCargo = Convert.ToInt32(cbxCargo.SelectedValue.ToString());
                        funcionario.idOficina = Convert.ToInt32(cbxOficina.SelectedValue.ToString());
                        funcionario.codigo_Distrito = "06";
                        funcionario.fecha_Memorando =Convert.ToDateTime(mtxtFechaMemorando.Text);
                        funcionario.registroActivo = true;
                        funcionario.usuarioRegistro = usuario.nombre_Usuario;
                        funcionario.fechaRegistro = fechaActualServidor;

                        int idFuncionario = servicio.funcionarioInsertar(Util.header, funcionario);

                        //Se registra la  Fianza
                        SrMidasD.Fianza fianza = new SrMidasD.Fianza();
                        fianza.idFuncionario = idFuncionario;
                        //fianza.Nro_Fianza_Fianza_Real = servicio.ultimoNumeroFianzaBienesGravados(Util.header) + 1;
                        fianza.Nro_Fianza_Fianza_Real =Convert.ToDouble(txtNroFianzaReal.Text.ToString());
                        fianza.comprobante_CPBTE = txtcpbte.Text;
                        fianza.tipo_Fianza_Real = cbxTipoFianzaReal.SelectedItem.ToString();//Tipo de Bien Gravado
                        fianza.ubicacion_Fianza_Real = txtUbicacionFianzaReal.Text;
                        fianza.folio_Fianza_Real = txtFolioFianzaReal.Text;
                        fianza.concepto_Fianza_Real = txtConceptoFianzaReal.Text;
                        fianza.a_Favor_Fianza_Real = txtaFavorFianzaReal1.Text;
                        try
                        {
                            fianza.ultimo_Registro_Fianza_Real = Convert.ToDouble(txtUltimoRegistro.Text);
                        }
                        catch { };
                        fianza.descripcion_Tipo_Fianza_Real = txtTipoBienInmueble.Text;//El Tipo de Bien
                        fianza.a_Favor_2_Fianza_Real = txtaFavorFianzaReal2.Text;
                        fianza.estado_Bien_Inmueble_Fianza_Real = cbxEstadoBienInmueble.SelectedItem.ToString();
                        fianza.idTipoFianza = 1;
                        fianza.registroActivo = true;
                        fianza.resolucion_Administrativa = txtResolucionAdministrativa.Text.ToString();
                        fianza.observacion = txtObservacion.Text;
                        fianza.usuarioRegistro = usuario.nombre_Usuario;
                        fianza.fechaRegistro = servicio.fechaServidor();
                        fianza.fianza_Completa_Habilitado = true;
                        fianza.fecha_Completa_Habilitado = fechaActualServidor;
                        fianza.usuario_Completa_Habilitado = usuario.nombre_Usuario;
                        fianza.usuario_RRHH = usuario.nombre_Usuario;
                        fianza.fecha_RRHH = fechaActualServidor;
                        fianza.usuario_Resolucion = usuario.nombre_Usuario;
                        fianza.fecha_Resolucion = fechaActualServidor;
                        int idFianza = servicio.fianzaInsertar(Util.header, fianza);

                        //Se crea el descuento una sola vez
                        SrMidasD.Descuento descuento;
                        descuento = new SrMidasD.Descuento();
                        descuento.idFianza = idFianza;
                        try
                        {
                            descuento.t727_Fianza_Real = Convert.ToDouble(txt727BG.Text.ToString());
                        }
                        catch { };
                        descuento.monto_Beneficiario = Convert.ToDouble(mxbMontoBeneficiario.Text.ToString());
                        descuento.observacion = txtObservacion.Text.Trim() + " (Registro Unico de Bien Gravado)";
                        descuento.usuarioRegistro = usuario.nombre_Usuario;
                        descuento.mes =Convert.ToInt32(txtMes.Text.ToString());
                        descuento.anio = Convert.ToInt32(txtAnio.Text.ToString());
                        //descuento.mes = servicio.fechaServidor().Month;
                        //descuento.anio = servicio.fechaServidor().Year;
                        descuento.registroActivo = true;
                        descuento.fechaRegistro = servicio.fechaServidor();
                        int idDescuento = servicio.descuentoInsertar(Util.header, descuento);

                        await cancelar();
                        MessageBox.Show("Se ha registrado la Resolucion Correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    catch
                    {
                        MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Ya no se puede Editar Porque el funcionario ya tiene una Solicitud de Fianza Aceptada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarErrores();

                if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
                Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                await cancelar();
            }
                    
        }


        private async Task editar()
        {
            limpiarErrores();



            try
            {
                int idFianza = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value);
                SrMidasD.Fianza fianza = servicio.fianzaGet(Util.header, idFianza);
                fianza.idFianza = fianza.idFianza;
                fianza.fecha_Validada_Contabilidad = servicio.fechaServidor();
                fianza.usuario_Validada_Contabilidad = usuario.nombre_Usuario;
                fianza.fianza_Validada_Contabilidad = true;
                fianza.usuarioRegistro = usuario.nombre_Usuario;
                fianza.fechaRegistro = DateTime.Now.Date;
                servicio.fianzaEditar(Util.header, fianza);

                //Eliminamos y Despues registramos
                servicio.descuentoEliminarfisicoEditar(Util.header, idFianza);
                SrMidasD.Descuento descuento = new Descuento();
                descuento.idFianza = idFianza;
                try
                {
                    descuento.t727_Fianza_Real = Convert.ToDouble(txt727BG.Text.ToString());

                }
                catch { };
                try
                {
                    descuento.monto_Beneficiario = Convert.ToDouble(mxbMontoBeneficiario.Text.ToString());
                }
                catch { }
                descuento.observacion = txtObservacion.Text.Trim() + " (Registro Unico de Bien Gravado)";
                descuento.usuarioRegistro = usuario.nombre_Usuario;
                descuento.mes = Convert.ToInt32(txtMes.Text.ToString());
                descuento.anio = Convert.ToInt32(txtAnio.Text.ToString());
                //descuento.mes = servicio.fechaServidor().Month;
                //descuento.anio = servicio.fechaServidor().Year;
                descuento.validado = true;
                descuento.validado_Por= usuario.nombre_Usuario;
                descuento.registroActivo = true;
                descuento.c21 =Convert.ToInt32(txtPreventivo.Text.ToString());
                descuento.fechaRegistro = servicio.fechaServidor();
                int idDescuento = servicio.descuentoInsertar(Util.header, descuento);


                limpiarcampos();
                MessageBox.Show("Se ha Validado Correctamente.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            await cancelar();

        }

        public bool verificarFianzaCurso()/*Para no poder editar si el funcionario ya tiene una fianza corriendo*/
        {
            int fianza_Validada_Contabilidad;
            try
            {
                fianza_Validada_Contabilidad = Convert.ToInt32((dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["fianza_Validada_Contabilidad"].Value).ToString()); 
            }
            catch
            {
                fianza_Validada_Contabilidad = 0;/*Aun no ha sido validada por contabilidad*/
            }

            if (fianza_Validada_Contabilidad == 0)
            {
                return false;
            }
            else
            { 
              return true;
            }
        }

        private async void cancelarNoAsync()
        {
            await cancelar();
            txtBuscar.Focus();
        }

        private async Task cancelar()
        {
            limpiarErrores();
            await listar();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            limpiarcampos();
           
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            await cancelar();   
        }

       

        private async void btnBaja_Click(object sender, EventArgs e)
        {
            limpiarErrores();

            DialogResult ResultadoDialogo = MessageBox.Show("El Funcionario será dado de baja.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idFuncionario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFucnionario"].Value);
                servicio.funcionarioEliminar(Util.header, idFuncionario);
                MessageBox.Show("El Funcionario ha sido dado de baja.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await listar();
                limpiarcampos();
            }
        }

        public void textleave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        }


        private async void FrmPersona_Load(object sender, EventArgs e)
        {
            txtBuscar.Enabled = false;
            await listar();
            txtBuscar.Enabled = true;
        }

        void limpiarcampos()
        {
            txtNombre.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            txtNumeroDocumento.Clear();
            txtNumeroMemorando.Clear();
            txtItem.Clear();
            txt727BG.Clear();
            txtaFavorFianzaReal2.Clear();
            txtcpbte.Clear();
            txtPreventivo.Clear();
          
            txtUbicacionFianzaReal.Clear();
            txtFolioFianzaReal.Clear();
            txtConceptoFianzaReal.Clear();
            txtaFavorFianzaReal1.Clear();
            txtaFavorFianzaReal2.Clear();
            txtUltimoRegistro.Clear();
            txtTipoBienInmueble.Clear();
            mxbMontoBeneficiario.ResetText();
            txtResolucionAdministrativa.Clear();
            txtObservacion.Clear();
            txtNroFianzaReal.Clear();

            cbxTipoDocumento.SelectedIndex = -1;
            cbxTipoDocumento.ResetText();

            cbxUnidadEjecutora.SelectedIndex = -1;
            cbxUnidadEjecutora.ResetText();

            cbxOficina.SelectedIndex = -1;
            cbxOficina.ResetText();

            cbxCargo.SelectedIndex = -1;
            cbxCargo.ResetText();

            cbxTipoContrato.SelectedIndex = -1;
            cbxTipoContrato.ResetText();

            cbxTipoFianzaReal.SelectedIndex = -1;
            cbxTipoFianzaReal.ResetText();

            cbxEstadoBienInmueble.SelectedIndex = -1;
            cbxEstadoBienInmueble.ResetText();

            mtxtFechaMemorando.Text = fechaActualDiauno.ToString("dd-MM-yyyy");

            txtOficinaLiteral.Clear();

            btnBuscarOficina.BackColor = Color.Transparent;

            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;

            txtMes.Clear();
            txtAnio.Clear();
           
        }

        private void cbxUnidadEjecutora_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarOficinas();
        }

        private void btnBuscarOficina_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmSeleccionarOficina(Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString())).ShowDialog();
                insertarOficinaCbx(FrmSeleccionarOficina.oficina);
            }
            catch { }
        }

        private void insertarOficinaCbx(SrMidasD.Oficina oficina)
        {
            try
            {
                cbxOficina.SelectedValue = oficina.idOficina;
                txtOficinaLiteral.Text = oficina.oficina1;
                erpError.Clear();
                cargarCargo();
                cbxCargo.Focus();
                cbxCargo.DroppedDown = true;
            }
            catch { }
        }

        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                switch (txtMes.Text)
                {
                    case "1":
                        lblMes.Text = "Enero";
                        break;
                    case "2":
                        lblMes.Text = "Febrero";
                        break;
                    case "3":
                        lblMes.Text = "Marzo";
                        break;
                    case "4":
                        lblMes.Text = "Abril";
                        break;
                    case "5":
                        lblMes.Text = "Mayo";
                        break;
                    case "6":
                        lblMes.Text = "Junio";
                        break;
                    case "7":
                        lblMes.Text = "Julio";
                        break;
                    case "8":
                        lblMes.Text = "Agosto";
                        break;
                    case "9":
                        lblMes.Text = "Septiembre";
                        break;
                    case "10":
                        lblMes.Text = "Octubre";
                        break;
                    case "11":
                        lblMes.Text = "Noviembre";
                        break;
                    case "12":
                        lblMes.Text = "Diciembre";
                        break;
                    default:
                        
                            //txtMes.Text = fechaActualServidor.Month.ToString();
                            //txtMes_KeyPress(this, e);
                        
                        break;
                }
            }
        }

        private void txtMes_KeyUp(object sender, KeyEventArgs e)
        {
            switch (txtMes.Text)
            {
                case "1":
                    lblMes.Text = "Enero";
                    break;
                case "2":
                    lblMes.Text = "Febrero";
                    break;
                case "3":
                    lblMes.Text = "Marzo";
                    break;
                case "4":
                    lblMes.Text = "Abril";
                    break;
                case "5":
                    lblMes.Text = "Mayo";
                    break;
                case "6":
                    lblMes.Text = "Junio";
                    break;
                case "7":
                    lblMes.Text = "Julio";
                    break;
                case "8":
                    lblMes.Text = "Agosto";
                    break;
                case "9":
                    lblMes.Text = "Septiembre";
                    break;
                case "10":
                    lblMes.Text = "Octubre";
                    break;
                case "11":
                    lblMes.Text = "Noviembre";
                    break;
                case "12":
                    lblMes.Text = "Diciembre";
                    break;
                default:
                    try
                    {
                        if (Convert.ToInt32(txtMes.Text) >= 13)
                        {
                            txtMes.Text = fechaActualServidor.Month.ToString();
                        }
                    }
                    catch { }
                    break;
            }
        }

        private async void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            await cancelar();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            reiniciarVerificacion();
            await listar();
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

            cbxUnidadEjecutora.SelectedIndex = -1;
            cbxOficina.SelectedIndex = -1;
            cbxCargo.SelectedIndex = -1;
            cbxTipoDocumento.SelectedIndex = -1;
            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
            limpiarcampos();
            mtxtFechaMemorando.Text = fechaActualDiauno.ToString("dd-MM-yyyy");
            txtNumeroDocumento.Enabled = true;
            cbxUnidadEjecutora.Enabled = true;
            cbxTipoContrato.Enabled = true;
            mtxtFechaMemorando.Enabled = true;
            txtItem.Enabled = true;
            btnBuscarOficina.Enabled = false;
            txtNumeroDocumento.Focus();
            txtMes.Text=servicio.fechaServidor().Month.ToString();
            txtAnio.Text = servicio.fechaServidor().Year.ToString();

            switch (txtMes.Text)
            {
                case "1":
                    lblMes.Text = "Enero";
                    break;
                case "2":
                    lblMes.Text = "Febrero";
                    break;
                case "3":
                    lblMes.Text = "Marzo";
                    break;
                case "4":
                    lblMes.Text = "Abril";
                    break;
                case "5":
                    lblMes.Text = "Mayo";
                    break;
                case "6":
                    lblMes.Text = "Junio";
                    break;
                case "7":
                    lblMes.Text = "Julio";
                    break;
                case "8":
                    lblMes.Text = "Agosto";
                    break;
                case "9":
                    lblMes.Text = "Septiembre";
                    break;
                case "10":
                    lblMes.Text = "Octubre";
                    break;
                case "11":
                    lblMes.Text = "Noviembre";
                    break;
                case "12":
                    lblMes.Text = "Diciembre";
                    break;
                default:
                    // code block
                    break;
            }


        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            idFianza = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value);
            new FrmCrCartillaVerFianza(idFianza, usuario.nombre_Usuario, "", 0).ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtTipoBienInmueble_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmPersona_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void txtGestion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cargarCargo();
            }
        }

        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
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
                    txtNombre.Clear();
                    txtPaterno.Clear();
                    txtMaterno.Clear();
                    txtNumeroMemorando.Clear();
                    txtItem.Clear();

                    cbxTipoDocumento.SelectedIndex = -1;
                    cbxTipoDocumento.ResetText();

                    cbxUnidadEjecutora.SelectedIndex = -1;
                    cbxUnidadEjecutora.ResetText();

                    cbxOficina.SelectedIndex = -1;
                    cbxOficina.ResetText();

                    cbxCargo.SelectedIndex = -1;
                    cbxCargo.ResetText();

                    cbxTipoContrato.SelectedIndex = -1;
                    cbxTipoContrato.ResetText();

                    mtxtFechaMemorando.Text = fechaActualDiauno.ToString("dd-MM-yyyy");

                    pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;

                    try
                    {
                        if (!verificarSiFuncionarioFianza())
                        {
                            buscarCi();
                        }
                    }
                catch
                    { }
            }
        }


      

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarErrores();
            cargarCampos();
            verificarNuevo();

           
        }

        //Funcion Buscar Ci Segip
        private void buscarCi()
        {
            SrMidasD.Persona personaBDL = servicio.personaGetPorNumeroDocumento(Util.header, txtNumeroDocumento.Text);

            if (personaBDL != null)
            {
                idPersona = personaBDL.idPersona;
                this.txtNombre.Text = Utils.Utils.uppercaseFirstLetter(personaBDL.nombres);
                this.txtPaterno.Text = Utils.Utils.uppercaseFirstLetter(personaBDL.paterno);
                this.txtMaterno.Text = Utils.Utils.uppercaseFirstLetter(personaBDL.materno);
                this.pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, personaBDL.idPersona).imagen1);
            }

            else
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
                        this.txtNombre.Text = string.Empty;
                        this.txtPaterno.Text = string.Empty;
                        this.txtMaterno.Text = string.Empty;
                        this.txtUsuario.Text = string.Empty;
                        this.pbImagen.Image = null;

                        MessageBox.Show("No se pudo encontrar el Carnet de Identidad verifique el numero de documento", "::: MidasD - Error :::", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        this.txtNombre.Text = string.Empty;
                        this.txtPaterno.Text = string.Empty;
                        this.txtMaterno.Text = string.Empty;
                        this.txtUsuario.Text = string.Empty;
                        this.pbImagen.Image = null;
                        MessageBox.Show("Se encontr\x00f3 m\x00e1s de un registro con la c\x00e9dula de identidad\rConsulte con la Unidad de Sistemas DAF!", "::: MidasD - Consulta :::", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtPaterno.Focus();
                        this.btnGuardar.Enabled = false;
                    }
                }
                catch
                {
                    MessageBox.Show("No se pudo establecer conexi\x00f3n con el servicio Segip Consulta", "::: MidasD - Error :::", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            cbxTipoDocumento.SelectedValue = 1;
        }

        //Verificamos si el Funcionario Tiene ya una Fianza
        private bool verificarSiFuncionarioFianza()
        {
            //Verificar si existe Funcionario con Fianza y habilitamos para el registro de transferencia o devolucion
                try
                {
                    SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioValidarNuevo(Util.header, txtNumeroDocumento.Text.Trim());
                    SrMidasD.Fianza fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);
                    int idFianzaDevolucion;
                    try
                    {
                        SrMidasD.Devolucion devolucionDatos = servicio.devolucionGetidFianza(Util.header, fianzaDatos.idFianza);
                        idFianzaDevolucion = (int)devolucionDatos.idFianza;
                        c31 = devolucionDatos.c31;
                    }
                    catch
                    {
                        idFianzaDevolucion = 0;
                        c31 = "0";
                    }

                    if (fianzaDatos.idFianza > 0)
                    {
                        if (idFianzaDevolucion == 0)/*Sino Tiene registrado una devolucion le decimos que tiene una fianza pendiente*/
                        {
                            string nombre = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).nombres;
                            string paterno = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).paterno;
                            string materno = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).materno;
                            string documento = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento;

                            DialogResult ResultadoDialogo = MessageBox.Show("El Funcionario ya está registrado.\rNombre: " + nombre + ".\rApellido Paterno: " + paterno + ".\rApelllido Materno: " + materno + ".\rDoc. Identidad: " + documento + "\nTeniendo una Fianza Pendiente.\n\n Quiere Ver la Fianza?", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ResultadoDialogo == DialogResult.Yes)
                            {
                                new FrmSeleccionarFianzaPorPersona(documento, usuario).ShowDialog();
                            }
                            else
                            {
                                cancelarNoAsync();
                            }

                            return true;
                        }
                        else
                        {
                            string nombre = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).nombres;
                            string paterno = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).paterno;
                            string materno = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).materno;
                            string documento = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona).numero_Documento;


                            if (c31 == null)//Puede Existir Devolucion pero no una finalizada por eso verificamos su c31
                            {

                                DialogResult ResultadoDialogo = MessageBox.Show("El Funcionario ya está registrado.\rNombre: " + nombre + ".\rApellido Paterno: " + paterno + ".\rApelllido Materno: " + materno + ".\rDoc. Identidad: " + documento + "\nTeniendo una Fianza Pendiente.\n\n Quiere Ver la Fianza?", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (ResultadoDialogo == DialogResult.Yes)
                                {
                                    new FrmSeleccionarFianzaPorPersona(documento, usuario).ShowDialog();

                                }
                                else
                                {
                                    cancelarNoAsync();
                                }

                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                } 
           
        }

        

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender,e);
            }
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
                cbxOficina.DataSource = servicio.oficinaListarUnidadEjecutora(Util.header, Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
                cbxOficina.SelectedIndex = -1;
            }
            catch
            { }
        }

        //Listar Cargos de Acuerdo a la Oficina
        private void cargarCargo()
        {
            try
            {
                cbxCargo.DataSource = servicio.cargoListarOficina(Util.header, Convert.ToInt32(cbxOficina.SelectedValue.ToString()), Convert.ToInt32(txtGestion.Text));
                cbxCargo.ValueMember = "idCargo";
                cbxCargo.DisplayMember = "cargo";
                cbxCargo.DropDownWidth = widthComboBoxCargos(cbxCargo);
                cbxCargo.SelectedIndex = -1;
                cbxCargo.Enabled = true;
            }
            catch
            { }
        }

        //Dependiendo al combo box navegamos de manera facil
        private void combo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string nombre = ((ComboBox)sender).Name.ToString();

            if (nombre == "cbxUnidadEjecutora")
            {
                erpError.Clear();
                btnBuscarOficina.Enabled = true;
                btnBuscarOficina.Focus();
                btnBuscarOficina.BackColor = Color.LimeGreen;
                txtOficinaLiteral.Clear();
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

        private void btnBuscarOficina_MouseHover(object sender, EventArgs e)
        {
            btnBuscarOficina.BackColor = Color.LimeGreen;
        }

        private void dgvConResolucion_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvLista.Rows)
                {

                    bool validada = Convert.ToBoolean(item.Cells["fianza_Validada_Contabilidad"].Value);
                    int comprobante;
                    try
                    {
                        comprobante = Convert.ToInt32(item.Cells["cpbte"].Value);
                    }
                    catch
                    {
                        comprobante = 100;
                    }



                    int index = item.Index;

                    if (validada && comprobante!=0)
                    {
                        Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "Sienna");
                    }
                    if (validada && comprobante==0)
                    {
                        Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "LimeGreen");
                    }


                    dgvLista.ClearSelection();

                }
            }
            catch { }
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

    }
}
