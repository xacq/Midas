using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace MidasD.Reportes
{
    public partial class FrmCrSolicitudFianza : Form
    {
        MidasD.SrMidasD.MidasDServiceClient servicio;
        CrSolicitudFianza reporte;
        CrSolicitudFianzaTotal reporteTotal;
        CrSolicitudDevolucion reporteDevolucion;
        CrSolicitudTransferenciaDescuento reporteTrans20;
        CrSolicitudTransferenciaTotal reporteTransTotal;
        CrSolicitudTransferenciaMontoSuperior reporteTransSuperior;
        string usuario;
        public int idSolicitud, idTipoFianza;
        DataTable dt;

        public FrmCrSolicitudFianza(int idSolicitud,int idTipoFianza,string usuario)
        {
            InitializeComponent();
            this.idSolicitud = idSolicitud;
            this.idTipoFianza = idTipoFianza;
            servicio = new SrMidasD.MidasDServiceClient();
            reporte = new CrSolicitudFianza();
            reporteTotal = new CrSolicitudFianzaTotal();
            reporteDevolucion = new CrSolicitudDevolucion();
            reporteTrans20 = new CrSolicitudTransferenciaDescuento();
            reporteTransTotal = new CrSolicitudTransferenciaTotal();
            reporteTransSuperior = new CrSolicitudTransferenciaMontoSuperior();
            this.usuario = usuario;

            if (idTipoFianza == 2)/*Fianza en Descuento del 20%*/
            {
                cargarReporte();
            }
            if (idTipoFianza == 3)/*Fianza en Deposito Total de Fianza*/
            {
                cargarReporteTotal();
            }
            if(idTipoFianza==-1)/*Devolucion de Fianza*/
            {
                cargarReporteDevolucion();
            }
            if (idTipoFianza == 0)/*Transferencia*/
            {
                if(servicio.solicitudesGet(Util.header,(int)idSolicitud).idTipoFianza==2)
                {
                    cargarReporteTransferencia20();
                }
                if (servicio.solicitudesGet(Util.header, (int)idSolicitud).idTipoFianza == 3)
                {
                    cargarReporteTransferenciaTotal();
                }
                if (servicio.solicitudesGet(Util.header, (int)idSolicitud).idTipoFianza == 0)
                {
                    cargarReporteTransferenciaNorequiereDescuento();
                }

            }

        }

        private void cargarReporte()
        {

           
            List<SrMidasD.paReporteSolFianEconomica_Result> lista = servicio.paFuncionarioFianzaActpaReporteSolFianEconomica(Util.header, idSolicitud).ToList();
            dt = new DataTable("qr");
            SrMidasD.paReporteSolFianEconomica_Result pa = lista.FirstOrDefault();
            dt.Columns.Add("qr", typeof(byte[]));


            if (lista.Count > 0)
            {
                reporte.SetDataSource(lista);

                string unidadEjecutora = servicio.unidadEjecutoraGet(Util.header, (int)servicio.oficinaGet(Util.header,(int)servicio.solicitudesGet(Util.header,idSolicitud).idOficina).idUnidadEjecutora).descripcion;
                
                if(unidadEjecutora.Substring(0,2)=="TR" || unidadEjecutora.Substring(0, 2) == "CO")
                {
                    unidadEjecutora = "DEL " + unidadEjecutora;
                }
                else
                {
                    unidadEjecutora = "DE LA " + unidadEjecutora;
                }

                string texto = "\nNro.Solic: " + (pa.numero_Fianza_Solicitud) +
                "\nOficina.: " + (Utils.Utils.unaccented(servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header,Convert.ToInt32(pa.idSolicitud)).idOficina).oficina1) +
                "\nCargo: " + (Utils.Utils.unaccented(pa.cargo)) +
                "\nNombre: " + (Utils.Utils.unaccented(pa.nombres+" "+pa.paterno+" "+pa.materno)) +
                "\nCI: " + (Utils.Utils.unaccented(pa.tipo_Documento+" "+pa.numero_Documento+" "+pa.lugar_Documento)) +
                "\nTipo Solicitud: " + (servicio.solicitudesGet(Util.header,Convert.ToInt32(pa.idSolicitud)).tipo_Solicitud_Fianza+" - "+ pa.tipo_Fianza.Remove(0, 6))) +
                "\nFecha Reg. Fianza: " + ((servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).fecha_Registro_RRHH));
                dt.Rows.Add(Utils.Utils.qrCode(texto));
                reporte.Subreports["CRqr"].SetDataSource(dt);

                reporte.SetParameterValue("UnidadEjecutora", unidadEjecutora);
                //int idFianza = servicio.fianzaIdFuncionario(Util.header, idSolicitud).idFianza;
                int idEncargadoJefeFinanciero = servicio.encargadosGetIdEncargado(Util.header, 68).idEncargado;//Se saca al Jefe Administrativo y Financiero cargo nro 68
                int idPersona = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idPersona;
                int idCargo = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idCargo;
                reporte.SetParameterValue("fechaRegistroFianza", string.Format("{0:D}", (servicio.solicitudesGet(Util.header,idSolicitud).fechaRegistro)));
                reporte.SetParameterValue("Encargado", (servicio.personaGet(Util.header, idPersona).nombres) + " " + servicio.personaGet(Util.header, idPersona).paterno + " " + servicio.personaGet(Util.header, idPersona).materno);
                reporte.SetParameterValue("cargoEncargado", servicio.cargoGet(Util.header, idCargo).descripcion_Puesto);
                reporte.SetParameterValue("usuario", usuario);

                crReporteSolFianza.ReportSource = reporte;
            }
            else
            {
                MessageBox.Show("No se Puede Imprimir \n1.- El funcionario ya tiene una fianza en Curso.\n2.- Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void cargarReporteTotal()
        {


            List<SrMidasD.paReporteSolFianEconomicaTotal_Result> lista = servicio.paFuncionarioFianzaActpaReporteSolFianEconomicaTotal(Util.header, idSolicitud).ToList();
            dt = new DataTable("qr");
            SrMidasD.paReporteSolFianEconomicaTotal_Result pa = lista.FirstOrDefault();
            dt.Columns.Add("qr", typeof(byte[]));

            if (lista.Count > 0)
            {

                reporteTotal.SetDataSource(lista);

                string unidadEjecutora = servicio.unidadEjecutoraGet(Util.header, (int)servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idOficina).idUnidadEjecutora).descripcion;

                if (unidadEjecutora.Substring(0, 2) == "TR" || unidadEjecutora.Substring(0, 2) == "CO")
                {
                    unidadEjecutora = "EL " + unidadEjecutora;
                }
                else
                {
                    unidadEjecutora = "LA " + unidadEjecutora;
                }

                string texto = "\nNro.Solic: " + (pa.numero_Fianza_Solicitud) +
                "\nOficina.: " + (Utils.Utils.unaccented(servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).idOficina).oficina1) +
                "\nCargo: " + (Utils.Utils.unaccented(pa.cargo)) +
                "\nNombre: " + (Utils.Utils.unaccented(pa.nombres + " " + pa.paterno + " " + pa.materno)) +
                "\nDocumento: " + (Utils.Utils.unaccented(pa.tipo_Documento + " " + pa.numero_Documento + " " + pa.lugar_Documento)) +
                "\nTipo Solicitud: " + (servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).tipo_Solicitud_Fianza + " - " + pa.tipo_Fianza.Remove(0, 6))) +
                "\nFecha Reg. Fianza: " + ((servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).fecha_Registro_RRHH));
                dt.Rows.Add(Utils.Utils.qrCode(texto));
                reporteTotal.Subreports["CRqr"].SetDataSource(dt);

                reporteTotal.SetParameterValue("UnidadEjecutora", unidadEjecutora);
                //int idFianza = servicio.fianzaIdFuncionario(Util.header, idSolicitud).idFianza;
                int idEncargadoJefeFinanciero = servicio.encargadosGetIdEncargado(Util.header, 68).idEncargado;//Se saca al Jefe Administrativo y Financiero cargo nro 68
                int idPersona = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idPersona;
                int idCargo = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idCargo;
                reporteTotal.SetParameterValue("fechaRegistroFianza", string.Format("{0:D}", (servicio.solicitudesGet(Util.header, idSolicitud).fechaRegistro)));
                reporteTotal.SetParameterValue("Encargado", (servicio.personaGet(Util.header, idPersona).nombres) + " " + servicio.personaGet(Util.header, idPersona).paterno + " " + servicio.personaGet(Util.header, idPersona).materno);
                reporteTotal.SetParameterValue("cargoEncargado", servicio.cargoGet(Util.header, idCargo).descripcion_Puesto);
                reporteTotal.SetParameterValue("usuario", usuario);


                crReporteSolFianza.ReportSource = reporteTotal;
            }
            else
            {
                MessageBox.Show("No se Puede Imprimir \n1.- El funcionario ya tiene una fianza en Curso.\n2.- Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }


        private void cargarReporteDevolucion()
        {


            List<SrMidasD.paReporteSolDevolucion_Result> lista = servicio.paReporteSolDevolucion(Util.header, idSolicitud).ToList();
            dt = new DataTable("qr");
            SrMidasD.paReporteSolDevolucion_Result pa = lista.FirstOrDefault();
            dt.Columns.Add("qr", typeof(byte[]));


            if (lista.Count > 0)
            {


                reporteDevolucion.SetDataSource(lista);

               

                string texto = "\nNro.Solic: " + (pa.numero_Fianza_Solicitud) +
               "\nOficina.: " + (Utils.Utils.unaccented(servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).idOficina).oficina1) +
               "\nCargo: " + (Utils.Utils.unaccented(pa.cargo)) +
               "\nNombre: " + (Utils.Utils.unaccented(pa.nombres + " " + pa.paterno + " " + pa.materno)) +
               "\nDocumento: " + (Utils.Utils.unaccented(pa.tipo_Documento + " " + pa.numero_Documento + " " + pa.lugar_Documento)) +
               "\nTipo Solicitud: " + (Utils.Utils.unaccented(servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).tipo_Solicitud_Fianza + " - " + pa.tipo_Fianza.Remove(0, 6)))) +
               "\nFecha Reg. Fianza: " + (Convert.ToDateTime(servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).fecha_Registro_RRHH));
                dt.Rows.Add(Utils.Utils.qrCode(texto));
                reporteDevolucion.Subreports["CRqr"].SetDataSource(dt);

                //int idFianza = servicio.fianzaIdFuncionario(Util.header, idSolicitud).idFianza;
                int idEncargadoJefeFinanciero = servicio.encargadosGetIdEncargado(Util.header, 68).idEncargado;//Se saca al Jefe Administrativo y Financiero cargo nro 68
                int idPersona = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idPersona;
                int idCargo = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idCargo;
                reporteDevolucion.SetParameterValue("fechaRegistroFianza", string.Format("{0:D}", (servicio.solicitudesGet(Util.header, idSolicitud).fechaRegistro)));
                reporteDevolucion.SetParameterValue("Encargado", (servicio.personaGet(Util.header, idPersona).nombres) + " " + servicio.personaGet(Util.header, idPersona).paterno + " " + servicio.personaGet(Util.header, idPersona).materno);
                reporteDevolucion.SetParameterValue("cargoEncargado", servicio.cargoGet(Util.header, idCargo).descripcion_Puesto);
                reporteDevolucion.SetParameterValue("usuario", usuario);
                try
                {
                    reporteDevolucion.SetParameterValue("montoLetra", "(" + Utils.ConvertNumberLetter.Convert(pa.total_descontado_en_planilla_literal).ToUpper() + ")");
                    reporteDevolucion.SetParameterValue("montoLetra", "(" + Utils.ConvertNumberLetter.Convert(pa.total_descontado_en_planilla_literal).ToUpper() + ")");
                }
                catch
                {
                    reporteDevolucion.SetParameterValue("montoLetra", "(0)");
                    reporteDevolucion.SetParameterValue("montoLetra", "(Cero)");
                }
                
                crReporteSolFianza.ReportSource = reporteDevolucion;
            }
            else
            {
                MessageBox.Show("No se Puede Imprimir \n1.- El funcionario ya tiene una fianza en Curso.\n2.- Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }


        private void cargarReporteTransferencia20()
        {

            List<SrMidasD.paReporteSolFianEconomica_Result> lista = servicio.paFuncionarioFianzaActpaReporteSolFianEconomica(Util.header, idSolicitud).ToList();
            dt = new DataTable("qr");
            SrMidasD.paReporteSolFianEconomica_Result pa = lista.FirstOrDefault();
            dt.Columns.Add("qr", typeof(byte[]));


            if (lista.Count > 0)
            {
                reporteTrans20.SetDataSource(lista);

                string unidadEjecutora = servicio.unidadEjecutoraGet(Util.header, (int)servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idOficina).idUnidadEjecutora).descripcion;

                if (unidadEjecutora.Substring(0, 2) == "TR" || unidadEjecutora.Substring(0, 2) == "CO")
                {
                    unidadEjecutora = "DEL " + unidadEjecutora;
                }
                else
                {
                    unidadEjecutora = "DE LA " + unidadEjecutora;
                }

                string texto = "\nNro.Solic: " + (pa.numero_Fianza_Solicitud) +
                "\nOficina.: " + (Utils.Utils.unaccented(servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).idOficina).oficina1) +
                "\nCargo: " + (Utils.Utils.unaccented(pa.cargo)) +
                "\nNombre: " + (Utils.Utils.unaccented(pa.nombres + " " + pa.paterno + " " + pa.materno)) +
                "\nDocumento: " + (Utils.Utils.unaccented(pa.tipo_Documento + " " + pa.numero_Documento + " " + pa.lugar_Documento)) +
                "\nTipo Solicitud: " + (servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).tipo_Solicitud_Fianza + " - " + pa.tipo_Fianza.Remove(0, 6))) +
                "\nFecha Reg. Fianza: " + ((servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).fecha_Registro_RRHH));
                dt.Rows.Add(Utils.Utils.qrCode(texto));
                reporteTrans20.Subreports["CRqr"].SetDataSource(dt);

                reporteTrans20.SetParameterValue("UnidadEjecutora", unidadEjecutora);
                //int idFianza = servicio.fianzaIdFuncionario(Util.header, idSolicitud).idFianza;
                int idEncargadoJefeFinanciero = servicio.encargadosGetIdEncargado(Util.header, 68).idEncargado;//Se saca al Jefe Administrativo y Financiero cargo nro 68
                int idPersona = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idPersona;
                int idCargo = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idCargo;
                reporteTrans20.SetParameterValue("fechaRegistroFianza", string.Format("{0:D}", (servicio.solicitudesGet(Util.header, idSolicitud).fechaRegistro)));
                reporteTrans20.SetParameterValue("Encargado", (servicio.personaGet(Util.header, idPersona).nombres) + " " + servicio.personaGet(Util.header, idPersona).paterno + " " + servicio.personaGet(Util.header, idPersona).materno);
                reporteTrans20.SetParameterValue("cargoEncargado", servicio.cargoGet(Util.header, idCargo).descripcion_Puesto);
                reporteTrans20.SetParameterValue("usuario", usuario);

                /*Campos especiales*/
                int idFianzaAnterior = (int)servicio.solicitudesGet(Util.header, idSolicitud).idFianza_Nueva;
                int idFuncionarioAnterior= (int)servicio.fianzaGet(Util.header, idFianzaAnterior).idFuncionario;
                int idOficinaAnterior = (int)servicio.funcionarioGet(Util.header, idFuncionarioAnterior).idOficina;
                int idCargoAnterior = (int)servicio.funcionarioGet(Util.header, idFuncionarioAnterior).idCargo;
                int idEscalaSalarialAnterior = (int)servicio.cargoGet(Util.header, idCargoAnterior).idEscalaSalarial;
                int idSueldoMensualAnterior = (int)servicio.escalaSalarialGet(Util.header, idEscalaSalarialAnterior).idSueldoMensual;
                List<SrMidasD.paFuncionarioFianzaActualBuscaridFianza_Result> listas = servicio.pafuncionarioFianzaActualBuscaridFianza(Util.header,(int)servicio.oficinaGet(Util.header,idOficinaAnterior).idUnidadEjecutora,Convert.ToInt32(servicio.solicitudesGet(Util.header,idSolicitud).idFianza_Nueva)).ToList();
                SrMidasD.paFuncionarioFianzaActualBuscaridFianza_Result pa1 = listas.FirstOrDefault();

                int fianzaRequerida = (int)((servicio.oficinaGet(Util.header,(int)servicio.solicitudesGet(Util.header,idSolicitud).idOficina).cuantia) * ((servicio.sueldoMensualGet(Util.header,(int)servicio.solicitudesGet(Util.header,idSolicitud).idSueldoMensual).monto)));
                double saldoActual =Convert.ToDouble(fianzaRequerida - pa1.total_Descuento);
                reporteTrans20.SetParameterValue("CargoAnterior", pa1.cargo);
                reporteTrans20.SetParameterValue("MemorandoAnterior", servicio.funcionarioGet(Util.header,idFuncionarioAnterior).numero_Memorando);
                reporteTrans20.SetParameterValue("TotalDescontadoEnPlatilla", pa1.total_Descuento);
                reporteTrans20.SetParameterValue("TotalDescontadoEnPlanillaLiteral", "(" + Utils.ConvertNumberLetter.Convert(Convert.ToDouble(pa1.total_Descuento).ToString()).ToUpper() + ")");
                reporteTrans20.SetParameterValue("FianzaRequeridaNuevo", fianzaRequerida);
                reporteTrans20.SetParameterValue("SaldoActual", saldoActual);

                crReporteSolFianza.ReportSource = reporteTrans20;
            }
            else
            {
                MessageBox.Show("No se Puede Imprimir \n1.- El funcionario ya tiene una fianza en Curso.\n2.- Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }


        private void cargarReporteTransferenciaTotal()
        {

            List<SrMidasD.paReporteSolFianEconomica_Result> lista = servicio.paFuncionarioFianzaActpaReporteSolFianEconomica(Util.header, idSolicitud).ToList();
            dt = new DataTable("qr");
            SrMidasD.paReporteSolFianEconomica_Result pa = lista.FirstOrDefault();
            dt.Columns.Add("qr", typeof(byte[]));


            if (lista.Count > 0)
            {
                reporteTransTotal.SetDataSource(lista);

                string unidadEjecutora = servicio.unidadEjecutoraGet(Util.header, (int)servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idOficina).idUnidadEjecutora).descripcion;

                if (unidadEjecutora.Substring(0, 2) == "TR" || unidadEjecutora.Substring(0, 2) == "CO")
                {
                    unidadEjecutora = "DEL " + unidadEjecutora;
                }
                else
                {
                    unidadEjecutora = "DE LA " + unidadEjecutora;
                }

                string texto = "\nNro.Solic: " + (pa.numero_Fianza_Solicitud) +
                "\nOficina.: " + (Utils.Utils.unaccented(servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).idOficina).oficina1) +
                "\nCargo: " + (Utils.Utils.unaccented(pa.cargo)) +
                "\nNombre: " + (Utils.Utils.unaccented(pa.nombres + " " + pa.paterno + " " + pa.materno)) +
                "\nDocumento: " + (Utils.Utils.unaccented(pa.tipo_Documento + " " + pa.numero_Documento + " " + pa.lugar_Documento)) +
                "\nTipo Solicitud: " + (servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).tipo_Solicitud_Fianza + " - " + pa.tipo_Fianza.Remove(0, 6))) +
                "\nFecha Reg. Fianza: " + ((servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).fecha_Registro_RRHH));
                dt.Rows.Add(Utils.Utils.qrCode(texto));
                reporteTransTotal.Subreports["CRqr"].SetDataSource(dt);

                reporteTransTotal.SetParameterValue("UnidadEjecutora", unidadEjecutora);
                //int idFianza = servicio.fianzaIdFuncionario(Util.header, idSolicitud).idFianza;
                int idEncargadoJefeFinanciero = servicio.encargadosGetIdEncargado(Util.header, 68).idEncargado;//Se saca al Jefe Administrativo y Financiero cargo nro 68
                int idPersona = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idPersona;
                int idCargo = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idCargo;
                reporteTransTotal.SetParameterValue("fechaRegistroFianza", string.Format("{0:D}", (servicio.solicitudesGet(Util.header, idSolicitud).fechaRegistro)));
                reporteTransTotal.SetParameterValue("Encargado", (servicio.personaGet(Util.header, idPersona).nombres) + " " + servicio.personaGet(Util.header, idPersona).paterno + " " + servicio.personaGet(Util.header, idPersona).materno);
                reporteTransTotal.SetParameterValue("cargoEncargado", servicio.cargoGet(Util.header, idCargo).descripcion_Puesto);
                reporteTransTotal.SetParameterValue("usuario", usuario);

                /*Campos especiales*/
                int idFianzaAnterior = (int)servicio.solicitudesGet(Util.header, idSolicitud).idFianza_Nueva;
                int idFuncionarioAnterior = (int)servicio.fianzaGet(Util.header, idFianzaAnterior).idFuncionario;
                int idOficinaAnterior = (int)servicio.funcionarioGet(Util.header, idFuncionarioAnterior).idOficina;
                int idCargoAnterior = (int)servicio.funcionarioGet(Util.header, idFuncionarioAnterior).idCargo;
                int idEscalaSalarialAnterior = (int)servicio.cargoGet(Util.header, idCargoAnterior).idEscalaSalarial;
                int idSueldoMensualAnterior = (int)servicio.escalaSalarialGet(Util.header, idEscalaSalarialAnterior).idSueldoMensual;
                List<SrMidasD.paFuncionarioFianzaActualBuscaridFianza_Result> listas = servicio.pafuncionarioFianzaActualBuscaridFianza(Util.header, (int)servicio.oficinaGet(Util.header, idOficinaAnterior).idUnidadEjecutora, Convert.ToInt32(servicio.solicitudesGet(Util.header, idSolicitud).idFianza_Nueva)).ToList();
                SrMidasD.paFuncionarioFianzaActualBuscaridFianza_Result pa1 = listas.FirstOrDefault();

                int fianzaRequerida = (int)((servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idOficina).cuantia) * ((servicio.sueldoMensualGet(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idSueldoMensual).monto)));
                double saldoActual = Convert.ToDouble(fianzaRequerida - pa1.total_Descuento);
                reporteTransTotal.SetParameterValue("CargoAnterior", pa1.cargo);
                reporteTransTotal.SetParameterValue("MemorandoAnterior", servicio.funcionarioGet(Util.header, idFuncionarioAnterior).numero_Memorando);
                reporteTransTotal.SetParameterValue("TotalDescontadoEnPlatilla", pa1.total_Descuento);
                reporteTransTotal.SetParameterValue("TotalDescontadoEnPlanillaLiteral", "(" + Utils.ConvertNumberLetter.Convert(Convert.ToDouble(pa1.total_Descuento).ToString()).ToUpper() + ")");
                reporteTransTotal.SetParameterValue("FianzaRequeridaNuevo", fianzaRequerida);
                reporteTransTotal.SetParameterValue("SaldoActual", saldoActual);

                crReporteSolFianza.ReportSource = reporteTransTotal;
            }
            else
            {
                MessageBox.Show("No se Puede Imprimir \n1.- El funcionario ya tiene una fianza en Curso.\n2.- Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }


        private void cargarReporteTransferenciaNorequiereDescuento()
        {

            List<SrMidasD.paReporteSolFianEconomicaNoRequiereFianza_Result> lista = servicio.paFuncionarioFianzaActpaReporteSolNoRequiereFianza(Util.header, idSolicitud).ToList();
            dt = new DataTable("qr");
            SrMidasD.paReporteSolFianEconomicaNoRequiereFianza_Result pa = lista.FirstOrDefault();
            dt.Columns.Add("qr", typeof(byte[]));


            if (lista.Count > 0)
            {
                reporteTransSuperior.SetDataSource(lista);

                string unidadEjecutora = servicio.unidadEjecutoraGet(Util.header, (int)servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idOficina).idUnidadEjecutora).descripcion;

                if (unidadEjecutora.Substring(0, 2) == "TR" || unidadEjecutora.Substring(0, 2) == "CO")
                {
                    unidadEjecutora = "DEL " + unidadEjecutora;
                }
                else
                {
                    unidadEjecutora = "DE LA " + unidadEjecutora;
                }

                string texto = "\nNro.Solic: " + (pa.numero_Fianza_Solicitud) +
                "\nOficina.: " + (Utils.Utils.unaccented(servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).idOficina).oficina1) +
                "\nCargo: " + (Utils.Utils.unaccented(pa.cargo)) +
                "\nNombre: " + (Utils.Utils.unaccented(pa.nombres + " " + pa.paterno + " " + pa.materno)) +
                "\nDocumento: " + (Utils.Utils.unaccented(pa.tipo_Documento + " " + pa.numero_Documento + " " + pa.lugar_Documento)) +
                "\nTipo Solicitud: " + (servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).tipo_Solicitud_Fianza + " - " + "No Requiere Fianza")) +
                "\nFecha Reg. Fianza: " + ((servicio.solicitudesGet(Util.header, Convert.ToInt32(pa.idSolicitud)).fecha_Registro_RRHH));
                dt.Rows.Add(Utils.Utils.qrCode(texto));
                reporteTransSuperior.Subreports["CRqr"].SetDataSource(dt);

                reporteTransSuperior.SetParameterValue("UnidadEjecutora", unidadEjecutora);
                //int idFianza = servicio.fianzaIdFuncionario(Util.header, idSolicitud).idFianza;
                int idEncargadoJefeFinanciero = servicio.encargadosGetIdEncargado(Util.header, 68).idEncargado;//Se saca al Jefe Administrativo y Financiero cargo nro 68
                int idPersona = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idPersona;
                int idCargo = (int)servicio.encargadosGet(Util.header, idEncargadoJefeFinanciero).idCargo;
                reporteTransSuperior.SetParameterValue("fechaRegistroFianza", string.Format("{0:D}", (servicio.solicitudesGet(Util.header, idSolicitud).fechaRegistro)));
                reporteTransSuperior.SetParameterValue("Encargado", (servicio.personaGet(Util.header, idPersona).nombres) + " " + servicio.personaGet(Util.header, idPersona).paterno + " " + servicio.personaGet(Util.header, idPersona).materno);
                reporteTransSuperior.SetParameterValue("cargoEncargado", servicio.cargoGet(Util.header, idCargo).descripcion_Puesto);
                reporteTransSuperior.SetParameterValue("usuario", usuario);

                /*Campos especiales*/
                int idFianzaAnterior = (int)servicio.solicitudesGet(Util.header, idSolicitud).idFianza_Nueva;
                int idFuncionarioAnterior = (int)servicio.fianzaGet(Util.header, idFianzaAnterior).idFuncionario;
                int idOficinaAnterior = (int)servicio.funcionarioGet(Util.header, idFuncionarioAnterior).idOficina;
                int idCargoAnterior = (int)servicio.funcionarioGet(Util.header, idFuncionarioAnterior).idCargo;
                int idEscalaSalarialAnterior = (int)servicio.cargoGet(Util.header, idCargoAnterior).idEscalaSalarial;
                int idSueldoMensualAnterior = (int)servicio.escalaSalarialGet(Util.header, idEscalaSalarialAnterior).idSueldoMensual;
                List<SrMidasD.paFuncionarioFianzaActualBuscaridFianza_Result> listas = servicio.pafuncionarioFianzaActualBuscaridFianza(Util.header, (int)servicio.oficinaGet(Util.header, idOficinaAnterior).idUnidadEjecutora, Convert.ToInt32(servicio.solicitudesGet(Util.header, idSolicitud).idFianza_Nueva)).ToList();
                SrMidasD.paFuncionarioFianzaActualBuscaridFianza_Result pa1 = listas.FirstOrDefault();

                int fianzaRequerida = (int)((servicio.oficinaGet(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idOficina).cuantia) * ((servicio.sueldoMensualGet(Util.header, (int)servicio.solicitudesGet(Util.header, idSolicitud).idSueldoMensual).monto)));
                double saldoActual = Convert.ToDouble(fianzaRequerida - pa1.total_Descuento);
                reporteTransSuperior.SetParameterValue("CargoAnterior", pa1.cargo);
                reporteTransSuperior.SetParameterValue("MemorandoAnterior", servicio.funcionarioGet(Util.header, idFuncionarioAnterior).numero_Memorando);
                reporteTransSuperior.SetParameterValue("TotalDescontadoEnPlatilla", pa1.total_Descuento);
                reporteTransSuperior.SetParameterValue("TotalDescontadoEnPlanillaLiteral", "(" + Utils.ConvertNumberLetter.Convert(Convert.ToDouble(pa1.total_Descuento).ToString()).ToUpper() + ")");
                reporteTransSuperior.SetParameterValue("FianzaRequeridaNuevo", fianzaRequerida);
                reporteTransSuperior.SetParameterValue("SaldoActual", saldoActual);

                crReporteSolFianza.ReportSource = reporteTransSuperior;
            }
            else
            {
                MessageBox.Show("No se Puede Imprimir \n1.- El funcionario ya tiene una fianza en Curso.\n2.- Sucedio un Error en la impresion Intente de Nuevo.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void FrmCrResumenGeneral_Load(object sender, EventArgs e)
        {
            //cargarReporte();
        }

        private void FrmCrResumenGeneral_FormClosing(object sender, FormClosingEventArgs e)
        {
            reporte.Close();
            reporteTotal.Close();
            crReporteSolFianza.Refresh();
            crReporteSolFianza.Dispose();
        }
    }
}
