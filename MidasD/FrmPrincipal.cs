using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidasD
{
    public partial class FrmPrincipal : Form
    {
        private SrMidasD.Usuario usuario;
        SrMidasD.MidasDServiceClient servicio;
        bool iniciar = false;
        bool cerrarSesion;
        SoundPlayer player;
        string pathSound;
        FrmAuntenticacion frmAutenticacion;

        private List<SrMidasD.viRolUsuarioListar> roles;
        public FrmPrincipal(SrMidasD.Usuario usuario, FrmAuntenticacion frmAuntenticacion)
        {
            InitializeComponent();
            this.usuario = usuario;
            cerrarSesion = false;
            this.frmAutenticacion = frmAuntenticacion;

            servicio = new SrMidasD.MidasDServiceClient();
            this.roles = servicio.rolUsuarioListarRoles(Util.header, usuario.idUsuario).ToList();
            pathSound = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            this.Text = Text + "       Version " + this.ProductVersion;
            lblBarra.Text = "Derechos Reservados ©2019-"+DateTime.Now.Year+" - Sistema de Control de Fianzas Judiciales - Midas Desktop *** Usuario: " + this.usuario.nombre_Usuario + " *** " + DateTime.Now.Date.ToLongDateString()+ " ***";
            lblBarra.Location = new System.Drawing.Point(2, this.Height - 60);

            btnDatosUsuario.Click += new System.EventHandler(this.btnDatosUsuario_Click);
            btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            btnCambiarClave.Click += new System.EventHandler(this.btnCambiarClave_Click);
            btnCambiarUsuario.Click += btnCambiarUsuario_Click;

            /*Actualizaciones*/
            
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\actualizacion.txt";
                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                txtNotificaciones.Text=sr.ReadLine();

                while (sr != null)
                {
                    //write the lie to console window
                    Console.WriteLine(sr);
                    //Read the next line
                    txtNotificaciones.Text = txtNotificaciones.Text+"\n\n"+ sr.ReadLine();
                    txtNotificaciones.Text = txtNotificaciones.Text + "\n\n" + sr.ReadLine();
                    txtNotificaciones.Text = txtNotificaciones.Text + "\n\n" + sr.ReadLine();
                    break;
                }

            }
            catch (Exception)
            {
                throw;
            }

            timer.Start();
            activarUsuarioMenu();
        }

        private void btnDatosUsuario_Click(object sender, EventArgs e)
        {
            new FrmDatosUsuario(usuario).ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            if (!cerrarSesion) Application.Exit();
            //this.Close();
        }

        private void btnCambiarUsuario_Click(object sender, EventArgs e)
        {
            cerrarSesion = true;
            this.Close();
            frmAutenticacion.Visible = true;
        }

        private void FrmPrincipal_SizeChanged(object sender, EventArgs e)
        {
            lblBarra.Location = new System.Drawing.Point(2, this.Height - 60);
            chkNotificacion.Location = new System.Drawing.Point(this.Width - 275, this.Height - 65);
            grbNotificacion.Location = new System.Drawing.Point(this.Width - 322, grbNotificacion.Location.Y);
        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            new FrmCambiarClave(usuario,usuario.clave).ShowDialog();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            new FrmUsuario(usuario).ShowDialog();
        }

        private void btnRol_Click(object sender, EventArgs e)
        {
            new FrmRol(usuario).ShowDialog();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            new FrmMenu(usuario).ShowDialog();
        }

        private void btnUsuarioRol_Click(object sender, EventArgs e)
        {
            new FrmUsuarioRol(usuario).ShowDialog();
        }

        private void btnRolMenu_Click(object sender, EventArgs e)
        {
            new FrmRolMenu(usuario).ShowDialog();
        }

        private void activarUsuarioMenu()
        {
            foreach (C1.Win.C1Ribbon.RibbonTab t in mnuPrincipal.Tabs)
            {
                t.Visible = false;
                foreach (C1.Win.C1Ribbon.RibbonGroup g in t.Groups)
                {
                    foreach (C1.Win.C1Ribbon.RibbonButton b in g.Items)
                    {
                        b.Visible = false;
                    }
                }
            }
            int cantItems = 0;
            List<SrMidasD.viUsuarioMenu> usuarioMenu = servicio.usuarioListarMenu(Util.header, usuario.idUsuario).ToList();
            foreach (SrMidasD.viUsuarioMenu um in usuarioMenu)
            {
                foreach (C1.Win.C1Ribbon.RibbonTab t in mnuPrincipal.Tabs)
                {
                    if (um.nombre_Elemento == t.Name)
                    {
                        t.Visible = true;
                        t.Text = um.menu;
                        foreach (C1.Win.C1Ribbon.RibbonGroup g in t.Groups)
                        {
                            cantItems = 0;
                            foreach (C1.Win.C1Ribbon.RibbonButton b in g.Items)
                            {
                                foreach (SrMidasD.viUsuarioMenu btn in usuarioMenu)
                                {
                                    if (btn.nombre_Elemento == b.Name)
                                    {
                                        b.Visible = true;
                                        b.Text = btn.menu;
                                        cantItems++;
                                    }
                                }
                            }
                            if (cantItems == 0) g.Visible = false;
                        }
                    }
                }
            }
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            new FrmPersona(usuario).ShowDialog();
        }

 
        private void btnAlmacenes_Click(object sender, EventArgs e)
        {
            new FrmAsesoriaLegal(usuario).ShowDialog();
        }

       

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmRegistroSolicitud(usuario).ShowDialog();
            }
           catch(ArgumentException er)
            {
                MessageBox.Show("La Oficina que Eligio no tenia Cargos para Fianza: \n Consulte El Reglamento"+er.Message.ToString());
            }
        }

        
        private void btnDescuentoFianza_Click(object sender, EventArgs e)
        {
            new FrmHabilitadoDescuento(usuario).ShowDialog();
        }

        private void btnFianzasReales_Click(object sender, EventArgs e)
        {
            new FrmValidacionBienesGravamenes(usuario).ShowDialog();

        }

        private void btnFianzasCompletas_Click(object sender, EventArgs e)
        {
            new FrmRegistroFianzaTotal(usuario).ShowDialog();
        }

        private void btnValidarFianzasDescuento_Click(object sender, EventArgs e)
        {
            new FrmContabilidadValidacion(usuario).ShowDialog();
        }

        private void btnValiCertificados_Click(object sender, EventArgs e)
        {
            new FrmValidacionParaCertificadosHabilitado(usuario).ShowDialog();
        }

        private void btnCertificados_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmCertificadoImprimir(usuario).ShowDialog();
            }
            catch { }
        }

        private void btnDarBajaFianza_Click(object sender, EventArgs e)
        {
            new FrmFianzaDeBaja(usuario).ShowDialog();
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            new FrmContabilidadReportes(usuario).ShowDialog();
        }

        private void btnReclasificar_Click(object sender, EventArgs e)
        {
            new FrmReclasificacion(usuario).ShowDialog();
        }

        private void brnRegBienes_Click(object sender, EventArgs e)
        {
            new FrmRegistroFianzaBienes(usuario).ShowDialog();

        }

        private void btnDarAltaFianza_Click(object sender, EventArgs e)
        {
            new FrmFianzaDeAlta(usuario).ShowDialog();
        }

        private void btnDevolucionFianza_Click(object sender, EventArgs e)
        {
            new FrmDevolucionContabilidad(usuario).ShowDialog();
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            new FrmTransferenciasRealizadas(usuario).ShowDialog();
        }

        private void btnVerFianza_Click(object sender, EventArgs e)
        {
            new FrmSeleccionarFianzaPorPersona("0",usuario).ShowDialog();
        }

        private void btnRsCorreccionDatos_Click(object sender, EventArgs e)
        {
            new FrmAsesoriaLegalCorreccionDatos(usuario).ShowDialog();
        }

        private void btnFianzasCorreccion_Click(object sender, EventArgs e)
        {
            new FrmHabilitadoDescuentoCorreccion(usuario,"","Administrador").ShowDialog();
        }

        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            new FrmAcercaDe().ShowDialog();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            new FrmContactos().ShowDialog();
        }

        private void btnValiCertificadosConta_Click(object sender, EventArgs e)
        {
            new FrmValidacionParaCertificadosContabilidad(usuario).ShowDialog();
        }

        private void btnValidarCiHabi_Click(object sender, EventArgs e)
        {
            new FrmValidarFianzaCompleta(usuario,"0",0,"Habilitado").ShowDialog();
        }

        private void btnValidarCiConta_Click(object sender, EventArgs e)
        {
            new FrmValidarFianzaCompleta(usuario,"0",0,"Contabilidad").ShowDialog();
        }

        private void btDepositoEfectivo_Click(object sender, EventArgs e)
        {
            new FrmActualizacionDepositoEfectivo(usuario).ShowDialog();
        }

        private void btActualizacion_Click(object sender, EventArgs e)
        {
            new FrmEnDesarrollo().ShowDialog();
        }

        private void btnRegistroSolicitudAdministrador_Click(object sender, EventArgs e)
        {
            new FrmRegistroSolicitudAdministrador(usuario).ShowDialog();
        }

        private void btnCorreccionFuncionario_Click(object sender, EventArgs e)
        {
            new FrmFuncionarioFianzaAdministracionDatos(usuario).ShowDialog();
        }

        private void btnConsultaPersonas_Click(object sender, EventArgs e)
        {
            new FrmPersonaConsulta(usuario).ShowDialog();
        }

        private void btnOficinas_Click(object sender, EventArgs e)
        {
            new FrmOficinas(usuario).ShowDialog();
        }

        private void btnOficinaCargo_Click(object sender, EventArgs e)
        {
            new FrmOficinaCargo(usuario).ShowDialog();
        }

        private void btnCargos_Click(object sender, EventArgs e)
        {
            new FrmCargos(usuario).ShowDialog();
        }

        private void btnSueldoMensual_Click(object sender, EventArgs e)
        {
            new FrmSueldoMensual(usuario).ShowDialog();
        }

        private void btnDevolucionFianzaAdm_Click(object sender, EventArgs e)
        {
            new FrmDevolucionContabilidadAdministradorDatos(usuario).ShowDialog();
        }

        private void btnFianzasUnidad_Click(object sender, EventArgs e)
        {
            new FrmFianzasUnidadEjecutora(usuario).ShowDialog();
        }

        private async Task notificacionAsesoriaLegal() /*OK*/
                                                                                                                                              {
            //var notificaciones = (await servicio.notificacionListarPendienteAsync(Util.usuario.idOficina, string.Empty, 0)).Where(x => !x.tipoNotificacion.Contains("Ciudadan")).Count();
            var contarFianzasParaResolucion = (await servicio.contarFianzasParaResolucionAsync(Util.header));
            if (contarFianzasParaResolucion > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesAL.wav";
                player.Play();
                nAsesoriaLegal.Visible = true;
                nAsesoriaLegal.BalloonTipText = $"Tiene {contarFianzasParaResolucion} solicitudes de Fianzas registradas en transito para asignar Resolución.";
                nAsesoriaLegal.BalloonTipTitle = "::: MidasD - NOTIFICACIONES ASESORIA LEGAL:::";
                nAsesoriaLegal.BalloonTipIcon = ToolTipIcon.Info;
                nAsesoriaLegal.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nAsesoriaLegal.Visible = false;
            }

        }

        private async Task notificacionRRHHSinResolucion() /*Ok*/
        {
            //var notificaciones = (await servicio.notificacionListarPendienteAsync(Util.usuario.idOficina, string.Empty, 0)).Where(x => !x.tipoNotificacion.Contains("Ciudadan")).Count();
            var contarFianzasRRHHSinResolucion = (await servicio.contarFianzasSinResolucionAsync(Util.header));
            if (contarFianzasRRHHSinResolucion > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesRRHHSINRESO.wav";
                player.Play();

                nRecursosHumanosSR.Visible = true;
                nRecursosHumanosSR.BalloonTipText = $"Tiene {contarFianzasRRHHSinResolucion} solicitudes de Fianzas sin Resolución.";
                nRecursosHumanosSR.BalloonTipTitle = "::: MidasD - NOTIFICACIONES RRHH:::";
                nRecursosHumanosSR.BalloonTipIcon = ToolTipIcon.Info;
                nRecursosHumanosSR.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nRecursosHumanosSR.Visible = false;
            }


        }

        private async Task notificacionRRHHImpresionCertificados() /*OK*/
        {
            //var notificaciones = (await servicio.notificacionListarPendienteAsync(Util.usuario.idOficina, string.Empty, 0)).Where(x => !x.tipoNotificacion.Contains("Ciudadan")).Count();
            var contarFianzasRRHHParaImpresionCertificados =(await servicio.paContador_ImpresionAsync(Util.header));
            int cantidadCertificados = 0;
            foreach (var item in contarFianzasRRHHParaImpresionCertificados)
            {
                cantidadCertificados = cantidadCertificados + (int)item.cantidad;
            }

            if (cantidadCertificados > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesRRHHCERT.wav";
                player.Play();
                nRecursosHumanosCertificados.Visible = true;
                nRecursosHumanosCertificados.BalloonTipText = $"Tiene {cantidadCertificados} certificados de Fianzas pendientes para Impresión.";
                nRecursosHumanosCertificados.BalloonTipTitle = "::: MidasD - NOTIFICACIONES RRHH-DAF:::";
                nRecursosHumanosCertificados.BalloonTipIcon = ToolTipIcon.Info;
                nRecursosHumanosCertificados.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nRecursosHumanosCertificados.Visible = false;
            }
        }

        private async Task notificacionDevolucionesPendientesContabilidad() /*OK*/
        {
            //var notificaciones = (await servicio.notificacionListarPendienteAsync(Util.usuario.idOficina, string.Empty, 0)).Where(x => !x.tipoNotificacion.Contains("Ciudadan")).Count();
            var contardevolucionesPendientesContabilidad = (await servicio.contardevolucionesPendientesContabilidadAsync(Util.header));
            if (contardevolucionesPendientesContabilidad > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesCTBDEVO.wav";
                player.Play();

                nContabilidadDevoluciones.Visible = true;
                nContabilidadDevoluciones.BalloonTipText = $"Tiene {contardevolucionesPendientesContabilidad} solicitudes de Fianzas pendientes para Devolucion.";
                nContabilidadDevoluciones.BalloonTipTitle = "::: MidasD - NOTIFICACIONES CONTABILIDAD:::";
                nContabilidadDevoluciones.BalloonTipIcon = ToolTipIcon.Info;
                nContabilidadDevoluciones.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nContabilidadDevoluciones.Visible = false;
            }
            //else
            //{
            //    player.SoundLocation = pathSound + "\\notificacionesCTBDEVONO.wav";
            //    player.Play();

            //    nContabilidadDevoluciones.Visible = true;
            //    nContabilidadDevoluciones.BalloonTipText = $"No tiene ninguna Devolucion pendiente.";
            //    nContabilidadDevoluciones.BalloonTipTitle = "::: MidasD - NOTIFICACIONES :::";
            //    nContabilidadDevoluciones.BalloonTipIcon = ToolTipIcon.Info;
            //    nContabilidadDevoluciones.ShowBalloonTip(1000);
            //    await Task.Delay(5000);
            //    nContabilidadDevoluciones.Visible = false;
            //}
        }

        private async Task notificacionFianzasCompletasValidacionCertificacionHabilitado() /*ok*/
        {
            //var notificaciones = (await servicio.notificacionListarPendienteAsync(Util.usuario.idOficina, string.Empty, 0)).Where(x => !x.tipoNotificacion.Contains("Ciudadan")).Count();
            var contarFianzasCompletasValidacionCertificacionHabilitado = (await servicio.contarFianzasCompletasValidacionCertificacionHabilitadoAsync(Util.header,servicio.fechaServidor().Year));
            if (contarFianzasCompletasValidacionCertificacionHabilitado > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesHABVAL.wav";
                player.Play();

                nHabilitadoValidacionCompletos.Visible = true;
                nHabilitadoValidacionCompletos.BalloonTipText = $"Tiene {contarFianzasCompletasValidacionCertificacionHabilitado} Fianzas completas para Validacion.";
                nHabilitadoValidacionCompletos.BalloonTipTitle = "::: MidasD - NOTIFICACIONES HABILITADO:::";
                nHabilitadoValidacionCompletos.BalloonTipIcon = ToolTipIcon.Info;
                nHabilitadoValidacionCompletos.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nContabilidadValidacionCompletos.Visible = false;
            }
            //else
            //{
            //    player.SoundLocation = pathSound + "\\notificacionesHABVALNO.wav";
            //    player.Play();

            //    nHabilitadoValidacionCompletos.Visible = true;
            //    nHabilitadoValidacionCompletos.BalloonTipText = $"No tiene ninguna fianza completa para validar.";
            //    nHabilitadoValidacionCompletos.BalloonTipTitle = "::: MidasD - NOTIFICACIONES :::";
            //    nHabilitadoValidacionCompletos.BalloonTipIcon = ToolTipIcon.Info;
            //    nHabilitadoValidacionCompletos.ShowBalloonTip(1000);
            //    await Task.Delay(5000);
            //    nHabilitadoValidacionCompletos.Visible = false;
            //}
        }

        private async Task notificacionFianzasCompletasValidacionCertificacionContabilidad() /*ok*/
        {
            var contarFianzasCompletasValidacionCertificacionContabilidad = (await servicio.contarFianzasCompletasValidacionCertificacionContabilidadAsync(Util.header, servicio.fechaServidor().Year));
            if (contarFianzasCompletasValidacionCertificacionContabilidad > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesCTBVAL.wav";
                player.Play();

                nContabilidadValidacionCompletos.Visible = true;
                nContabilidadValidacionCompletos.BalloonTipText = $"Tiene {contarFianzasCompletasValidacionCertificacionContabilidad} Fianzas completas para Validacion.";
                nContabilidadValidacionCompletos.BalloonTipTitle = "::: MidasD - NOTIFICACIONES CONTABILIDAD:::";
                nContabilidadValidacionCompletos.BalloonTipIcon = ToolTipIcon.Info;
                nContabilidadValidacionCompletos.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nContabilidadValidacionCompletos.Visible = false;
            }
            //else
            //{
            //    player.SoundLocation = pathSound + "\\notificacionesCTBVALNO.wav";
            //    player.Play();

            //    nContabilidadValidacionCompletos.Visible = true;
            //    nContabilidadValidacionCompletos.BalloonTipText = $"No tiene ninguna fianza completa para validar.";
            //    nContabilidadValidacionCompletos.BalloonTipTitle = "::: MidasD - NOTIFICACIONES :::";
            //    nContabilidadValidacionCompletos.BalloonTipIcon = ToolTipIcon.Info;
            //    nContabilidadValidacionCompletos.ShowBalloonTip(1000);
            //    await Task.Delay(5000);
            //    nContabilidadValidacionCompletos.Visible = false;
            //}
        }

        private async Task notificacionMesDescuentoHabilitado()  /*ok*/
        {
            //var notificaciones = (await servicio.notificacionListarPendienteAsync(Util.usuario.idOficina, string.Empty, 0)).Where(x => !x.tipoNotificacion.Contains("Ciudadan")).Count();
            var contarMesDescuentoHabilitado = (await servicio.contarMesDescuentoHabilitadoAsync(Util.header,servicio.fechaServidor().Month,servicio.fechaServidor().Year));
            if (contarMesDescuentoHabilitado > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesHABDESC.wav";
                player.Play();

                nHabilitadoDescuentosMes.Visible = true;
                nHabilitadoDescuentosMes.BalloonTipText = $"Tiene {contarMesDescuentoHabilitado} Unidades Ejecutoras que aun no tienen descuentos en el mes actual.";
                nHabilitadoDescuentosMes.BalloonTipTitle = "::: MidasD - NOTIFICACIONES HABILITADO:::";
                nHabilitadoDescuentosMes.BalloonTipIcon = ToolTipIcon.Info;
                nHabilitadoDescuentosMes.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nHabilitadoDescuentosMes.Visible = false;
            }
        }


        private async Task notificacionTransferenciasContabilidad() /*ok*/
        {
            var contarTransferenciasContabilidad = (await servicio.contarTransferenciasContabilidadAsync(Util.header));
            if (contarTransferenciasContabilidad > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesCTBTRANSVAL.wav";
                player.Play();

                nTransferencias.Visible = true;
                nTransferencias.BalloonTipText = $"Tiene {contarTransferenciasContabilidad} transferencias de fianzas pendientes para validar.";
                nTransferencias.BalloonTipTitle = "::: MidasD - NOTIFICACIONES CONTABILIDAD:::";
                nTransferencias.BalloonTipIcon = ToolTipIcon.Info;
                nTransferencias.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nTransferencias.Visible = false;
            }
        }

        private async Task notificacionMesDescuentoContabilidad() /*Rev*/
        {
          
            var contarMesDescuentoContabilidad = (await servicio.contarValidarMesDescuentoContabilidadAsync(Util.header, servicio.fechaServidor().Month, servicio.fechaServidor().Year));
            if (contarMesDescuentoContabilidad > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesCTBVALMES.wav";
                player.Play();

                nContabilidadDescuentosMes.Visible = true;
                nContabilidadDescuentosMes.BalloonTipText = $"Tiene {contarMesDescuentoContabilidad} Unidades Ejecutoras que aun no tienen validados en el mes actual.";
                nContabilidadDescuentosMes.BalloonTipTitle = "::: MidasD - NOTIFICACIONES CONTABILIDAD:::";
                nContabilidadDescuentosMes.BalloonTipIcon = ToolTipIcon.Info;
                nContabilidadDescuentosMes.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nContabilidadDescuentosMes.Visible = false;
            }
        }

        private async Task notificacionFianzasValidacionBienesGravadosContabilidad()
        {

            var contarBienesGravadosContabilidad = (await servicio.contarFianzasValidacionBienesGravadosContabilidadAsync(Util.header, usuario.nombre_Usuario));
            if (contarBienesGravadosContabilidad > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesCTBVALBIENES.wav";
                player.Play();

                nBienesGravados.Visible = true;
                nBienesGravados.BalloonTipText = $"Tiene {contarBienesGravadosContabilidad} fianzas de bienes gravados para validar.";
                nBienesGravados.BalloonTipTitle = "::: MidasD - NOTIFICACIONES CONTABILIDAD:::";
                nBienesGravados.BalloonTipIcon = ToolTipIcon.Info;
                nBienesGravados.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nBienesGravados.Visible = false;
            }
        }

        private async Task notificacionFianzasTotalesValidacionContabilidad()
        {

            var contarTotalesContabilidad = (await servicio.contarFianzasTotalesValidacionContabilidadAsync(Util.header));
            if (contarTotalesContabilidad > 0)
            {
                player.SoundLocation = pathSound + "\\notificacionesCTBVALTOTAL.wav";
                player.Play();

                nFianzasTotales.Visible = true;
                nFianzasTotales.BalloonTipText = $"Tiene {contarTotalesContabilidad} fianzas totales para validar.";
                nFianzasTotales.BalloonTipTitle = "::: MidasD - NOTIFICACIONES CONTABILIDAD:::";
                nFianzasTotales.BalloonTipIcon = ToolTipIcon.Info;
                nFianzasTotales.ShowBalloonTip(1000);
                await Task.Delay(5000);
                nFianzasTotales.Visible = false;
            }
        }


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
            nAsesoriaLegal.BalloonTipClicked += NAsesoriaLegal_BalloonTipClicked;
            nRecursosHumanosSR.BalloonTipClicked += NRRHHSinResolucion_BalloonTipClicked;
            nRecursosHumanosCertificados.BalloonTipClicked += NRRHHParaImpresion_BalloonTipClicked;
            nContabilidadDevoluciones.BalloonTipClicked += CTBDevoluciones_BalloonTipClicked;
            nHabilitadoValidacionCompletos.BalloonTipClicked += HBTCompletas_BalloonTipClicked;
            nContabilidadValidacionCompletos.BalloonTipClicked += CBTCompletas_BalloonTipClicked;
            nHabilitadoDescuentosMes.BalloonTipClicked += HBTMesDescuentos_BalloonTipClicked;
            nTransferencias.BalloonTipClicked += CBTTransferencias_BalloonTipClicked;
            nContabilidadDescuentosMes.BalloonTipClicked += CBTMesDescuentos_BalloonTipClicked;
            nBienesGravados.BalloonTipClicked += CBTBienes_BalloonTipClicked;
            nFianzasTotales.BalloonTipClicked += CBTTotales_BalloonTipClicked;

            iniciar = true;

            //grbNotificacion.Visible = true;
            chkNotificacion.Checked = true;
           
        }

        private void NAsesoriaLegal_BalloonTipClicked(object sender, EventArgs e)
        {
             new FrmAsesoriaLegal(usuario).ShowDialog();
        }

        private void NRRHHSinResolucion_BalloonTipClicked(object sender, EventArgs e)
        {
            new FrmRegistroSolicitud(usuario).ShowDialog();
        }

        private void NRRHHParaImpresion_BalloonTipClicked(object sender, EventArgs e)
        {
           new FrmCertificadoImprimir(usuario).ShowDialog(); 
        }

        private void CTBDevoluciones_BalloonTipClicked(object sender, EventArgs e)
        {
            new FrmDevolucionContabilidad(usuario).ShowDialog();
        }

        private void HBTCompletas_BalloonTipClicked(object sender, EventArgs e)
        {
            new FrmValidacionParaCertificadosHabilitado(usuario).ShowDialog();
        }

        private void CBTCompletas_BalloonTipClicked(object sender, EventArgs e)
        {
            new FrmValidacionParaCertificadosContabilidad(usuario).ShowDialog();
        }

        private void HBTMesDescuentos_BalloonTipClicked(object sender, EventArgs e)
        {
            new FrmHabilitadoDescuento(usuario).ShowDialog();
        }

        private void CBTTransferencias_BalloonTipClicked(object sender, EventArgs e)
        {
            new FrmTransferenciasRealizadas(usuario).ShowDialog();
        }

        private void CBTMesDescuentos_BalloonTipClicked(object sender, EventArgs e)
        {
            new FrmContabilidadValidacion(usuario).ShowDialog();
        }

        private void CBTBienes_BalloonTipClicked(object sender, EventArgs e)
        {
            new FrmValidacionBienesGravamenes(usuario).ShowDialog();
        }

        private void CBTTotales_BalloonTipClicked(object sender, EventArgs e)
        {
            new FrmRegistroFianzaTotal(usuario).ShowDialog();
        }



        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            if (iniciar)
            {
                DialogResult ResultadoDialogo = MessageBox.Show("¿Esta seguro que desea pausar las notificaciones?", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ResultadoDialogo == DialogResult.Yes)
                {
                    timer.Stop();
                    iniciar = false;
                }
            }
            else
            {
                DialogResult ResultadoDialogo = MessageBox.Show("¿Esta seguro que desea reanudar las notificaciones?", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ResultadoDialogo == DialogResult.Yes)
                {
                    timer.Start();
                    iniciar = true;
                }
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            int idRol= Convert.ToInt32(servicio.rolUsuarioGetIdUsuario(Util.header, usuario.idUsuario).idRol);

            if ( idRol == 3 || idRol == 4 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionRRHHSinResolucion();
                    await Task.Delay(5000);
                    
                }
                catch { }
            }

            if (idRol == 4 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionRRHHImpresionCertificados();
                    await Task.Delay(5000);
                }
                catch { }
            }

            if (idRol == 6 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionAsesoriaLegal();
                    await Task.Delay(5000);
                }
                catch { }
            }

            if (idRol == 7 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionMesDescuentoContabilidad();
                    await Task.Delay(5000);
                }
                catch { }
            }

            if (idRol == 7 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionFianzasValidacionBienesGravadosContabilidad();
                    await Task.Delay(5000);
                }
                catch { }
            }

            if (idRol == 7 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionFianzasTotalesValidacionContabilidad();
                    await Task.Delay(5000);
                }
                catch { }
            }


            if (idRol == 7 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionDevolucionesPendientesContabilidad();
                    await Task.Delay(5000);
                }
                catch { }
            }

            if (idRol == 7 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionTransferenciasContabilidad();
                    await Task.Delay(5000);
                }
                catch { }
            }

            if (idRol == 7 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionFianzasCompletasValidacionCertificacionContabilidad();
                    await Task.Delay(5000);
                }
                catch { }
            }

          

            if (idRol == 5 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionMesDescuentoHabilitado();
                    await Task.Delay(5000);
                }
                catch { }
            }

            if (idRol == 5 || idRol == 1)
            {
                try
                {
                    if (timer.Interval != 1000 * 60 * 30) timer.Interval = 1000 * 60 * 30; //30 minutos
                    await notificacionFianzasCompletasValidacionCertificacionHabilitado();
                    await Task.Delay(5000);
                }
                catch { }
            }

            else
            {
                timer.Stop();
            }

        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            nAsesoriaLegal.Dispose();
            nRecursosHumanosSR.Dispose();
            nRecursosHumanosCertificados.Dispose();
            nAsesoriaLegal.Dispose();
            nContabilidadDevoluciones.Dispose();
            nHabilitadoValidacionCompletos.Dispose();
            nContabilidadValidacionCompletos.Dispose();
            nHabilitadoDescuentosMes.Dispose();
            nTransferencias.Dispose();
            nContabilidadDescuentosMes.Dispose();
            nFianzasTotales.Dispose();
            nContabilidadDescuentosMes.Dispose();
            System.Threading.Thread.Sleep(1000);
            if (!cerrarSesion) Application.Exit();
        }

        private void btnManualUsuario_Click(object sender, EventArgs e)
        {
           
                new FrmManualUsuario().ShowDialog();
            
        }

     

        private void btnEscalaSalarial_Click(object sender, EventArgs e)
        {
            new FrmSueldoMensualEscalaSalarial(usuario).ShowDialog();
        }

        private void chkNotificacion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (((Control)sender).Name == "btnCerrarPanelNotificacion")
                    chkNotificacion.Checked = false;
                grbNotificacion.Visible = ((CheckBox)sender).Checked;
            }
            catch { }
        }

        private void btnFlujo_Click(object sender, EventArgs e)
        {
            new FrmFlujo().ShowDialog();
        }

        private void btnFlujoReales_Click(object sender, EventArgs e)
        {
            new FrmFlujoReales().ShowDialog();
        }

        private void btnRegBienesAdm_Click(object sender, EventArgs e)
        {
            new FrmRegistroFianzaBienesAdministrador(this.usuario).ShowDialog();
        }

        private void btnCertificadosR_Click(object sender, EventArgs e)
        {
            new FrmCertificadoImprimirReales(this.usuario).ShowDialog();
        }
    }
}
