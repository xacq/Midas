
using CrystalDecisions.Shared;
using MidasD.Reportes;
using MidasD.SrArgos;
using MidasD.SrMidasD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MidasD.Reportes;


namespace MidasD
{
    public partial class FrmValidarFianzaCompleta: Form
    {
        SrMidasD.MidasDServiceClient servicio;

        SrMidasD.Usuario usuario;
        public static SrMidasD.Fianza fianza;

        List<Control> btnPnlLista, btnPnlDatos;

        string unidad;

        public FrmValidarFianzaCompleta(SrMidasD.Usuario usuario,string numeroDoc,int idFianza, string unidad)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
    
            this.usuario = usuario;
            this.unidad = unidad;
            lblTitulo.Text = lblTitulo.Text + " " + unidad;

            btnPnlLista = new List<Control>() {  btnSalir, btnBuscar };
            btnPnlDatos = new List<Control>() { pnlDatos, pnlLista, btnCancelar,btnValidar };
            Util.btn_Mouse(new List<PictureBox>() { btnValidar, btnSalir, btnBuscar,btnCancelar });


            if (numeroDoc!="0" && idFianza!=0)
            {
                txtBuscar.Text = numeroDoc.ToString();
                fianza = servicio.fianzaGet(Util.header, idFianza);
                verFianza();
                this.tabControl1.SelectedTab = tabPage2;
            }
            if (dgvListaCartilla.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlDatos);
        }





        public void Validar()
        {
            if(unidad=="Contabilidad")
            {
                
                    Fianza fianza = servicio.fianzaGet(Util.header, Convert.ToInt32(lblidFianza.Text));
                    fianza.idFianza = fianza.idFianza;
                    fianza.fianza_Validada_Contabilidad = true;
                    fianza.fecha_Validada_Contabilidad = DateTime.Now;
                    fianza.usuario_Validada_Contabilidad = usuario.nombre_Usuario;
                    servicio.fianzaEditar(Util.header, fianza);
    
            }

            if (unidad == "Habilitado")
            {
                
                    Fianza fianza = servicio.fianzaGet(Util.header, Convert.ToInt32(lblidFianza.Text));
                    fianza.idFianza = fianza.idFianza;
                    fianza.fianza_Completa_Habilitado = true;
                    fianza.fecha_Completa_Habilitado = DateTime.Now;
                    fianza.usuario_Completa_Habilitado = usuario.nombre_Usuario;
                    servicio.fianzaEditar(Util.header, fianza);
    
            }
            MessageBox.Show("La Fianza ha sido Validada.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Verificar si existe ya insertada la idfianza de un funcionario
        private int existeFianzDgv(int idFianza)
        {
            foreach (DataGridViewRow dr in dgvListaCartilla.Rows)
                if (Convert.ToInt32(dr.Cells["idFianza"].Value.ToString()) == idFianza)
                    return dr.Index;
            return -1;
        }


        //Datos para validar el formulario
        private void frmEntrada_Load(object sender, EventArgs e)
        {
            
            dgvListaCartilla.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
        }


        //Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvLista_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = dgvListaCartilla.Rows[e.RowIndex];
           
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender, e);
            }
        }

   
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void listar()
        {
            try
            {
                dgvLista.DataSource = servicio.paFianzasPorFuncionarioBuscar(Util.header, Utils.Utils.unaccented(txtBuscar.Text.Trim().ToLower()));
                Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFuncionario", "idFianza" });
                Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "Nro_Fianza", "descripcion_Fianza", "cargo", "nombre_Completo", "ci", "item", "vigencia_Contrato", "fecha_Memorando", "resolucion_Administrativa", "haber_mensual", "t727", "total_Descuento", "Estado_Fianza" });
                Utils.Wfa.setHeadersDGV(dgvLista);
                dgvLista.AutoResizeColumns();
                dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                if (dgvLista.Rows.Count == 0) btnAceptar.Enabled = false;
                else btnAceptar.Enabled = true;
            }
            catch { }

        }


        private void verFianza()
        {
            bool validadoHabilitado, validadoContabilidad, fianzaImpresa;

            //Verificar si existe Funcionario con Fianza
            try
            {
                //SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioValidarNuevo(Util.header, txtBuscar.Text.Trim());
                //SrMidasD.Fianza fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);

                SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, fianza.idFianza).idFuncionario);
                SrMidasD.Fianza fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);

                try
                {
                    if((bool)fianzaDatos.fianza_Completa_Habilitado == true)
                        validadoHabilitado = true;
                    else
                        validadoHabilitado = false;
                        ;
                }
               catch
                {
                    validadoHabilitado = false;
                }
                try
                {
                    if((bool)fianzaDatos.fianza_Validada_Contabilidad == true)
                        validadoContabilidad =true;
                    else
                        validadoContabilidad = false;
                }
                catch
                {
                    validadoContabilidad = false;
                }
                try
                {
                    if((bool)fianzaDatos.fianza_Impresa_RRHH == true)
                        fianzaImpresa = true;
                    else
                        fianzaImpresa = false;
                }
                catch
                {
                    fianzaImpresa = false;
                }

                        dgvListaCartilla.DataSource = servicio.paFianzaReporteCartilla(Util.header, fianzaDatos.idFianza);
                        Utils.Wfa.hideHeadersDGV(dgvListaCartilla, new List<string>() { "idFianza", "saldo_a_descontar", "total_descontado_en_planilla", "Nro_Fianza" });
                        Utils.Wfa.positionHeadersDGV(dgvListaCartilla, new List<string>() { "mes_anio", "importe_descontado_s_g_ofrecimiento" });
                        Utils.Wfa.setHeadersDGV(dgvListaCartilla);
                        dgvListaCartilla.AutoResizeColumns();
                        dgvListaCartilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        SrMidasD.Persona persoDatos = servicio.personaGet(Util.header, (int)funcionarioDatos.idPersona);
                        Cargo cargoDatos = servicio.cargoGet(Util.header, (int)funcionarioDatos.idCargo);
                        Oficina ofiDatos = servicio.oficinaGet(Util.header, (int)funcionarioDatos.idOficina);
                        EscalaSalarial escaDatos = servicio.escalaSalarialGet(Util.header, (int)cargoDatos.idEscalaSalarial);

                        string nroMemorando = funcionarioDatos.numero_Memorando;
                        string nombreCompleto = persoDatos.paterno.ToUpper() + " " + persoDatos.materno.ToUpper() + " " + persoDatos.nombres.ToUpper();
                        string numeroDocumento = persoDatos.numero_Documento;
                        string tipoContrato = funcionarioDatos.vigencia_Contrato.ToUpper();
                        string item = funcionarioDatos.tipo_Contrato_Item.ToString();
                        string cargoOficina = cargoDatos.descripcion_Puesto.ToUpper() + " " + ofiDatos.oficina1.ToUpper();
                        string haberMensual = string.Format("{0:#,0.00}", servicio.sueldoMensualGet(Util.header, (int)escaDatos.idSueldoMensual).monto);
                        string cuantia = ofiDatos.cuantia.ToString();
                        string totalDescontar = string.Format("{0:#,0.00}", Convert.ToDouble(haberMensual) * Convert.ToDouble(cuantia));
                        string porcentajeDescuento = (ofiDatos.porcentaje_Descuento).ToString();
                        string totalDescuentoMes = Convert.ToString((Convert.ToDouble(haberMensual) * ofiDatos.porcentaje_Descuento));
                        string cantidadMeses = Math.Round(Convert.ToDouble(totalDescontar) / Convert.ToDouble(totalDescuentoMes)).ToString();

                        lblNumMemorando.Text = nroMemorando;
                        lblNombresApellidos.Text = nombreCompleto;
                        lblCi.Text = persoDatos.numero_Documento;
                        lblTipoContrato.Text = tipoContrato;
                        lblVigenciaItem.Text = item;
                        lblCargo.Text = cargoOficina;
                        lblHaberMensual.Text = haberMensual;
                        lblCalculoSueldos.Text = cuantia;
                        lblTotalDescontar.Text = totalDescontar;
                        lblDescuentoSalario.Text = porcentajeDescuento;
                        lblTotalDescuentoMes.Text = totalDescuentoMes;
                        lblCantidadMesesDescontar.Text = cantidadMeses;
                        lblidFianza.Text = fianzaDatos.idFianza.ToString();
                        lblNroFianza.Text = fianzaDatos.Nro_Fianza.ToString();
                        try
                 {
                            if (((bool)fianzaDatos.fianza_Completa_Habilitado != false))
                            {
                                ckValidadoHabilitado.Checked = true;
                                ckValidadoHabilitado.ForeColor = System.Drawing.Color.White;
                            }
                        }
                        catch
                        {
                            ckValidadoHabilitado.Checked = false;
                        }

                        try
                        {
                            if ((bool)fianzaDatos.fianza_Validada_Contabilidad != false)
                            {
                                ckValidadoContabilidad.Checked = true;
                            }
                        }
                        catch
                        {
                            ckValidadoContabilidad.Checked = false;
                        }
                        try
                        {
                            if ((bool)fianzaDatos.fianza_Impresa_RRHH != false)
                            {
                                ckImpreso.Checked = true;
                            }
                        }
                        catch
                        {
                            ckImpreso.Checked = false;
                        }

                        this.pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, persoDatos.idPersona).imagen1);

                        try
                        {
                            double suma = 0;
                            foreach (DataGridViewRow row in dgvListaCartilla.Rows)
                            {
                                if (row.Cells["importe_descontado_s_g_ofrecimiento"].Value != null)
                                    suma += Convert.ToDouble(row.Cells["importe_descontado_s_g_ofrecimiento"].Value);
                            }
                            string specifier;
                            CultureInfo culture;
                            specifier = "N";
                            culture = CultureInfo.CreateSpecificCulture("es-ES");
                            lblTotalDescontadoPlanilla.Text = suma.ToString(specifier, culture);
                        }
                        catch { }

                if (validadoHabilitado == true && validadoContabilidad == true)
                {
                    Util.pnlListaActivar(true, btnPnlLista);
                    Util.pnlListaActivar(false, btnPnlDatos);
                    MessageBox.Show(" La Fianza se encuentra Validada por\r***Habilitado y Contabilidad***\rYa no se puede validar", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Util.pintarDatagridwiew(dgvListaCartilla, "Black", "Gray"); 
                }
                else
                {
                    if (unidad == "Contabilidad")
                    {
                        if (ckValidadoContabilidad.Checked == true)
                        {
                            Util.pnlListaActivar(true, btnPnlLista);
                            Util.pnlListaActivar(false, btnPnlDatos);
                            MessageBox.Show("La Fianza ya ha sido Validada antes\rNo se puede validar Nuevamente.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Util.pintarDatagridwiew(dgvListaCartilla, "Black", "Gray");
                        }
                        else
                        {
                            Util.pnlListaActivar(false, btnPnlLista);
                            Util.pnlListaActivar(true, btnPnlDatos);
                        }
                    }

                    if (unidad == "Habilitado")
                    {
                        if (ckValidadoHabilitado.Checked == true)
                        {
                            Util.pnlListaActivar(true, btnPnlLista);
                            Util.pnlListaActivar(false, btnPnlDatos);
                            MessageBox.Show("La Fianza ya ha sido Validada antes\rNo se puede validar Nuevamente.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Util.pintarDatagridwiew(dgvListaCartilla, "Black", "Gray");
                        }
                        else
                        {
                            Util.pnlListaActivar(false, btnPnlLista);
                            Util.pnlListaActivar(true, btnPnlDatos);
                        }
                    }

                }

               
            }
            catch
            {
                MessageBox.Show(" No se Encontro Fianzas para este Número de Documento\n Intente Nuevamente", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
                Util.pnlListaActivar(true, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlDatos);
                Util.pintarDatagridwiew(dgvListaCartilla, "Black", "Gray");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            fianza = null;
            if (dgvListaCartilla.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
        }

        private void limpiar()
        {
            txtBuscar.Clear();

            lblNumMemorando.ResetText();
            lblNombresApellidos.ResetText();
            lblCi.ResetText();
            lblTipoContrato.ResetText();
            lblVigenciaItem.ResetText();
            lblCargo.ResetText();
            lblHaberMensual.ResetText();
            lblCalculoSueldos.ResetText();
            lblTotalDescontar.ResetText();
            lblDescuentoSalario.ResetText();
            lblTotalDescuentoMes.ResetText();
            lblCantidadMesesDescontar.ResetText();
            lblidFianza.ResetText();
            ckValidadoHabilitado.Checked = false;
            ckValidadoContabilidad.Checked = false;
            ckImpreso.Checked = false;
          
            try
            {
                dgvListaCartilla.Rows.Clear();
            }
            catch { }

            pbImagen.Image = global::MidasD.Properties.Resources.sin_foto1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            fianza = servicio.fianzaGet(Util.header, Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value));
            verFianza();
            this.tabControl1.SelectedTab = tabPage2;

        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            
            Validar();
            txtBuscar.Clear();
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
        }

    }
}
