using MidasD.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MidasD.SrMidasD;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
//using MidasD.Reportes;

namespace MidasD
{
    public partial class FrmSeleccionarFianzaPorPersona : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        public static SrMidasD.Fianza fianza;
        SrMidasD.Usuario usuario;
        string ci;
        bool consultaExterna;
        List<Control> btnPnlLista3;

        public FrmSeleccionarFianzaPorPersona(string ci,SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            this.ci = ci;
            this.usuario = usuario;
            servicio = new SrMidasD.MidasDServiceClient();

            btnPnlLista3 = new List<Control>() { btnSalir, btnImprimir };

            Util.btn_Mouse(new List<PictureBox>() { btnSalir, btnImprimir });

            if (ci=="0")
            {
                consultaExterna = true;
                txtParametro.Focus();
            }
            else
            {
                consultaExterna = false;
                txtParametro.Text = ci;
                listar();
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            fianza = null;
            this.Close();
        }

        private void listar()
        {
            try
            {
                dgvLista.DataSource = servicio.paFianzasPorFuncionarioBuscar(Util.header,/* Utils.Utils.unaccented(*/txtParametro.Text.Trim().ToLower())/*)*/;
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

      

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(consultaExterna==true)
            {
                fianza = servicio.fianzaGet(Util.header, Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value));
                verFianza();
                this.tabControl1.SelectedTab = tabPage2;
            }
            if (consultaExterna==false)
            {
                if (dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["Estado_Fianza"].Value.ToString() == "Devuelta")
                {
                    fianza = null;
                    MessageBox.Show(" Esta Fianza ya se encuentra debidamente devuelta\n Seleccione una Activa para proseguir e Intente Nuevamente", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["Estado_Fianza"].Value.ToString() == "Activa")
                {
                    fianza = servicio.fianzaGet(Util.header, Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value));
                    verFianza();
                    this.tabControl1.SelectedTab = tabPage2;
                }
            }
               
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void cbxUnidadEjecutora_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Utils.Wfa.onlyNumbers(sender, e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender, e);
            }
        }

        //Insertamos numeracion
        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void dgvListaOficinas_DoubleClick(object sender, EventArgs e)
        {
            if (consultaExterna == true)
            {
                fianza = servicio.fianzaGet(Util.header, Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value));
                verFianza();
                this.tabControl1.SelectedTab = tabPage2;
            }
            if (consultaExterna == false)
            {
                if (dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["Estado_Fianza"].Value.ToString() == "Devuelta")
                {
                    fianza = null;
                    MessageBox.Show(" Esta Fianza ya se encuentra debidamente devuelta\n Seleccione una Activa para proseguir e Intente Nuevamente", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["Estado_Fianza"].Value.ToString() == "Activa")
                {
                    fianza = servicio.fianzaGet(Util.header, Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value));
                    verFianza();
                    this.tabControl1.SelectedTab = tabPage2;
                }
            }
        }

        private void dgvLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvLista.Rows)
                {
                    int index = item.Index;
                    try
                    {
                        if ((item.Cells["Estado_Fianza"].Value).ToString()=="Devuelta")
                        {
                           Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "OrangeRed");
                        }
                        else
                        {
                            Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "LimeGreen");
                        }

                    }
                    catch
                    {
                        Util.pintarDatagridwiewIndex(dgvLista, index, "Black", "OrangeRed");
                    }


                    dgvLista.ClearSelection();

                }
            }
            catch { }
        }

        /*VerFianza****************************************************************************************************************/

        public void imprimir()
        {

            new FrmCrCartillaVerFianza(fianza.idFianza, usuario.nombre_Usuario, "", 0).ShowDialog();

        }

        private void verFianza()
        {
            //Verificar si existe Funcionario con Fianza
            try
            {
                SrMidasD.Funcionario funcionarioDatos = servicio.funcionarioGet(Util.header, (int)servicio.fianzaGet(Util.header, fianza.idFianza).idFuncionario);
                SrMidasD.Fianza fianzaDatos = servicio.fianzaIdFuncionario(Util.header, funcionarioDatos.idFuncionario);

                double suma = 0;
                try
                {
                    dgvListaCartilla.DataSource = servicio.paFianzaReporteCartilla(Util.header, fianzaDatos.idFianza);
                    foreach (DataGridViewRow row in dgvListaCartilla.Rows)
                    {
                        if (row.Cells["importe_descontado_s_g_ofrecimiento"].Value != null)
                            suma += Convert.ToDouble(row.Cells["importe_descontado_s_g_ofrecimiento"].Value);
                    }
                    string specifier;
                    CultureInfo culture;
                    specifier = "N";
                    culture = CultureInfo.CreateSpecificCulture("es-ES");
                    lblTotalDescontadoPlanilla.Text = "Bs " + suma.ToString(specifier, culture);
                }
                catch { }

                if (suma > 0)
                {
                    dgvListaCartilla.DataSource = servicio.paFianzaReporteCartilla(Util.header, fianzaDatos.idFianza);
                    Utils.Wfa.hideHeadersDGV(dgvListaCartilla, new List<string>() { "idFianza", "saldo_a_descontar", "total_descontado_en_planilla", "Nro_Fianza" });
                    Utils.Wfa.positionHeadersDGV(dgvListaCartilla, new List<string>() { "mes_anio", "importe_descontado_s_g_ofrecimiento" });
                    dgvListaCartilla.AutoResizeColumns();
                    dgvListaCartilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    suma = 0;
                    foreach (DataGridViewRow row in dgvListaCartilla.Rows)
                    {
                        if (row.Cells["importe_descontado_s_g_ofrecimiento"].Value != null)
                            suma += Convert.ToDouble(row.Cells["importe_descontado_s_g_ofrecimiento"].Value);
                    }
                    string specifier;
                    CultureInfo culture;
                    specifier = "N";
                    culture = CultureInfo.CreateSpecificCulture("es-ES");
                    lblTotalDescontadoPlanilla.Text = "Bs " + suma.ToString(specifier, culture);
                }
                else
                {
                    dgvListaCartilla.DataSource = servicio.paFianzaReporteCartillaT727(Util.header, fianzaDatos.idFianza);
                    Utils.Wfa.hideHeadersDGV(dgvListaCartilla, new List<string>() { "idFianza", "Nro_Fianza" });
                    Utils.Wfa.positionHeadersDGV(dgvListaCartilla, new List<string>() { "mes_anio", "t727" });

                    suma = 0;
                    foreach (DataGridViewRow row in dgvListaCartilla.Rows)
                    {
                        if (row.Cells["t727"].Value != null)
                            suma += Convert.ToDouble(row.Cells["t727"].Value);
                    }
                    string specifier;
                    CultureInfo culture;
                    specifier = "N";
                    culture = CultureInfo.CreateSpecificCulture("es-ES");
                    lblTotalDescontadoPlanilla.Text = "Bs " + suma.ToString(specifier, culture);
                }


                Utils.Wfa.setHeadersDGV(dgvListaCartilla);
                dgvLista.AutoResizeColumns();
                dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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
                lblTotalDescontar.Text = totalDescontar;
                if (string.IsNullOrEmpty(fianzaDatos.Nro_Fianza.ToString()))
                {
                    lblidFianza.Text = fianzaDatos.Nro_Fianza_Fianza_Real.ToString();
                }
                else
                {
                    lblidFianza.Text = fianzaDatos.Nro_Fianza.ToString();
                }
               
                lblTipoFianza.Text = servicio.tipoFianzaGet(Util.header, (int)fianzaDatos.idTipoFianza).descripcion_Fianza;

                if (fianzaDatos.idTipoFianza == 2 || fianzaDatos.idTipoFianza == 3)
                {
                    lbl9.Visible = true; lbl10.Visible = true; lbl11.Visible = true; lbl12.Visible = true;
                    lblCalculoSueldos.Text = cuantia;
                    lblDescuentoSalario.Text = porcentajeDescuento;
                    lblTotalDescuentoMes.Text = totalDescuentoMes;
                    lblCantidadMesesDescontar.Text = cantidadMeses;
                }
                else
                {
                    lbl9.Visible = false; lbl10.Visible = false; lbl11.Visible = false; lbl12.Visible = false; lbl13.Visible = false;
                    lblCalculoSueldos.Visible = false; lblDescuentoSalario.Visible = false; lblTotalDescuentoMes.Visible = false; lblCantidadMesesDescontar.Visible = false;
                }


                try
                {
                    this.pbImagen.Image = Utils.Utils.byteArrayToImage(servicio.imagenGetidPersona(Util.header, persoDatos.idPersona).imagen1);
                }
                catch
                {

                }



            }
            catch
            {
                MessageBox.Show(" No se Encontro Fianzas para este Número de Documento\n Intente Nuevamente", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Opcion Imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            imprimir();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
