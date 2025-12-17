using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;


namespace ClnMidasD
{
     public class FianzaCln
     {
         public static int insertar(Header header, Fianza fianza)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Fianza.Add(fianza);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Fianza", fianza.idFianza.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return fianza.idFianza;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Fianza fianza)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                    var actual = contexto.Fianza.Find(fianza.idFianza);
                    actual.Nro_Fianza = fianza.Nro_Fianza;
                    actual.Nro_Fianza_Fianza_Real = fianza.Nro_Fianza_Fianza_Real;
                    actual.idTipoFianza = fianza.idTipoFianza;
                    actual.idFuncionario = fianza.idFuncionario;
                    actual.registro_Sigma = fianza.registro_Sigma;
                    actual.fecha_Limite_Fianza = fianza.fecha_Limite_Fianza;
                    actual.resolucion_Administrativa = fianza.resolucion_Administrativa;
                    actual.comprobante_CPBTE = fianza.comprobante_CPBTE;
                    actual.descripcion_Tipo_Fianza_Real = fianza.descripcion_Tipo_Fianza_Real;
                    actual.ubicacion_Fianza_Real = fianza.ubicacion_Fianza_Real;
                    actual.folio_Fianza_Real = fianza.folio_Fianza_Real;
                    actual.concepto_Fianza_Real = fianza.concepto_Fianza_Real;
                    actual.a_Favor_Fianza_Real = fianza.a_Favor_Fianza_Real;
                    actual.tipo_Fianza_Real = fianza.tipo_Fianza_Real;
                    actual.a_Favor_2_Fianza_Real= fianza.a_Favor_2_Fianza_Real;
                    actual.fianza_Completa_Habilitado = fianza.fianza_Completa_Habilitado;
                    actual.usuario_Completa_Habilitado = fianza.usuario_Completa_Habilitado;
                    actual.fecha_Completa_Habilitado = fianza.fecha_Completa_Habilitado;
                    actual.fianza_Validada_Contabilidad = fianza.fianza_Validada_Contabilidad;
                    actual.usuario_Validada_Contabilidad = fianza.usuario_Validada_Contabilidad;
                    actual.fecha_Validada_Contabilidad = fianza.fecha_Validada_Contabilidad;
                    actual.fianza_Devuelta_Contabilidad = fianza.fianza_Devuelta_Contabilidad;
                    actual.usuario_Devuelta_Contabilidad = fianza.usuario_Devuelta_Contabilidad;
                    actual.fecha_Devuelta_Contabilidad = fianza.fecha_Devuelta_Contabilidad;
                    actual.fianza_Impresa_RRHH = fianza.fianza_Impresa_RRHH;
                    actual.usuario_Impresa_RRHH = fianza.usuario_Impresa_RRHH;
                    actual.fecha_Impresa_RRHH = fianza.fecha_Impresa_RRHH;
                    actual.observacion = fianza.observacion;
                    actual.usuario_RRHH = fianza.usuario_RRHH;
                    actual.fecha_RRHH = fianza.fecha_RRHH;
                    actual.usuario_Resolucion = fianza.usuario_Resolucion;
                    actual.fecha_Resolucion = fianza.fecha_Resolucion;
                    actual.usuarioRegistro = fianza.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Fianza", fianza.idFianza.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                 else return -1;
             }
         }

        public static int ultimoNumeroFianza(Header header)
        {
            try
            {
                using (var contexto = new MidasDEntities())
                {
                    if (header.token.Equals(Utils.Utils.token()))
                    {
                        return (int)contexto.Fianza.Where(p => p.idTipoFianza == 2 || p.idTipoFianza == 3).Max(p => p.Nro_Fianza);
                    }
                    else return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static int ultimoNumeroFianzaBienesGravados(Header header)
        {
            try
            {
                using (var contexto = new MidasDEntities())
                {
                    if (header.token.Equals(Utils.Utils.token()))
                    {
                        return (int)contexto.Fianza.Where(p=>p.idTipoFianza==1).Max(p => p.Nro_Fianza);
                    }
                    else return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static int eliminar(Header header, int idFianza)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Fianza.Find(idFianza);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Fianza", idFianza.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Fianza> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Fianza.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

        public static List<paListarFuncionariosFianzaRRHH_Result> palistarFuncionariosFianzaBuscarRRHH(Header header,string letra,string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFuncionariosFianzaRRHH(letra,usuario).ToList();
                }
                else return null;
            }
        }

        public static List<paListarFuncionariosFianzaConResolucion_Result> paListarFuncionariosFianzaConResolucion(Header header, string letra, string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFuncionariosFianzaConResolucion(letra,usuario).ToList();
                }
                else return null;
            }
        }

        public static List<paListarFuncionariosFianzaConResolucionBienesGravados_Result> paListarFuncionariosFianzaConResolucionBienesGravados(Header header, string letra, string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFuncionariosFianzaConResolucionBienesGravados(letra, usuario).ToList();
                }
                else return null;
            }
        }

        public static List<paListarFuncionariosFianzaDevolucion_Result> palistarFuncionariosFianzaBuscarDevolucion(Header header, string letra)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFuncionariosFianzaDevolucion(letra).ToList();
                }
                else return null;
            }
        }

        public static List<paListarFuncionariosFianzaDevolucionContabilidad_Result> palistarFuncionariosFianzaBuscarDevolucionContabilidad(Header header, string letra)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFuncionariosFianzaDevolucionContabilidad(letra).ToList();
                }
                else return null;
            }
        }

        public static List<paFuncionarioFianzaActualBuscarTipoFianza_Result> palistarFuncionariosFianzaBuscarTipoFianza(Header header, string letra,int idTipoFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFuncionarioFianzaActualBuscarTipoFianza(letra,idTipoFianza).ToList();
                }
                else return null;
            }
        }

        public static List<paFuncionarioFianzaActualBuscarTipoFianzaTotalEstadoValidado_Result> palistarFuncionariosFianzaBuscarTipoFianzaTotalEstadoValidado(Header header, string letra, int idTipoFianza,int estadoValidacion)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFuncionarioFianzaActualBuscarTipoFianzaTotalEstadoValidado(letra, idTipoFianza, estadoValidacion).ToList();
                }
                else return null;
            }
        }

        public static List<paListarFianzasTipoFianzaGestionUnidadEjecutoraHabilitado_Result> paListarFianzasTipoFianzaGestionUnidadEjecutoraHabilitado(Header header,string letra, int idtipoDeFianza,int gestion,int idUnidadEjecutora)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFianzasTipoFianzaGestionUnidadEjecutoraHabilitado(letra,idtipoDeFianza,gestion,idUnidadEjecutora).ToList();
                }
                else return null;
            }
        }

        public static List<paFianzasListarMesAnioDescuentos_Result> palistarFianzasMesAnioDescuentos(Header header, int idUnidadEjecutora, int idtipoDeFianza, int anio )
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFianzasListarMesAnioDescuentos(idUnidadEjecutora,anio, idtipoDeFianza).ToList();
                }
                else return null;
            }
        }

        public static List<paFianzasListarMesAnioContaVali_Result> palistarFianzasMesAnioContaVali(Header header, int idUnidadEjecutora, int idtipoDeFianza, int anio)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFianzasListarMesAnioContaVali(idUnidadEjecutora, anio, idtipoDeFianza).ToList();
                }
                else return null;
            }
        }

        public static List<paFuncionarioFianzaActualBuscarMesAnioEditar_Result> palistarFianzasMesAnioEditar(Header header,string letra, int idUnidadEjecutora, int idtipoDeFianza,int mes, int anio)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    //return contexto.paFuncionaroFianzaActualBuscarMesAnio(letra, idUnidadEjecutora,idtipoDeFianza, mes,anio).ToList();
                    return contexto.paFuncionarioFianzaActualBuscarMesAnioEditar(letra, idUnidadEjecutora, idtipoDeFianza, mes, anio).ToList();
                }
                else return null;
            }
        }

        
        public static Fianza get(Header header, int idFianza)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Fianza.Find(idFianza);
                 }
                 else return null;
             }
         }

        public static Fianza fianzaIdFuncionario(Header header, int idFuncionario)/*Para Recursos Humanos*/
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Fianza.Where(p => p.idFuncionario == idFuncionario).FirstOrDefault();
                }
                else return null;
            }
        }

        public static int verificarFianzaEnCurso(Header header, int idFuncionario)/*Para Asesoria Legal*/
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    try
                    {
                        return (int)contexto.paFianzaVerificarEnCurso(idFuncionario).FirstOrDefault().idFianza;
                    }
                    catch
                    {
                        return 0;
                    }
                }
                else return 0;
            }
        }

        //public static Fianza verificarFianzaCompletaActiva(Header header, int idfianza)/*Para Recursos Humanos*/
        //{
        //    using (var contexto = new MidasDEntities())
        //    {
        //        if (header.token.Equals(Utils.Utils.token()))
        //        {
        //            return contexto.Fianza.Where(p => p.idFianza == idfianza && p.fianza_Completa_Habilitado==true && p.registroActivo==false).FirstOrDefault();
        //        }
        //        else return null;
        //    }
        //}

        public static Fianza verificarFianzaDevueltaContabilidad(Header header, int idfianza)/*Para Recursos Humanos*/
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Fianza.Where(p => p.idFianza == idfianza && p.fianza_Completa_Habilitado == true && p.registroActivo == true && p.fianza_Devuelta_Contabilidad==true).FirstOrDefault();
                }
                else return null;
            }
        }


        public static List<paValidacionEstadoFianzaContabilidad_Result> paValidacionEstadoFianzaContabilidad(Header header,string letra, int anio, int idUnidadEjecutora)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paValidacionEstadoFianzaContabilidad(letra, anio, idUnidadEjecutora).ToList();
                }
                else return null;
            }
        }

        public static List<paValidacionEstadoFianzaHabilitado_Result> paValidacionEstadoFianzaHabilitado(Header header, string letra, int anio, int idUnidadEjecutora)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paValidacionEstadoFianzaHabilitado(letra, anio, idUnidadEjecutora).ToList();
                }
                else return null;
            }
        }

        public static List<paValidacionEstadoFianzaRRHH_Result> paValidacionEstadoFianzaRRHH(Header header, string letra, int anio, int idUnidadEjecutora)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paValidacionEstadoFianzaRRHH(letra, anio, idUnidadEjecutora).ToList();
                }
                else return null;
            }
        }

        public static List<paValidacionParaCertificadosHabilitado_Result> paValidacionParaCertificadosHabilitado(Header header, string letra, int anio, int idUnidadEjecutora)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paValidacionParaCertificadosHabilitado(letra, anio, idUnidadEjecutora).ToList();
                }
                else return null;
            }
        }
        public static List<paValidacionParaCertificadosContabilidad_Result> paValidacionParaCertificadosContabilidad(Header header, string letra, int anio, int idUnidadEjecutora)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paValidacionParaCertificadosContabilidad(letra, anio, idUnidadEjecutora).ToList();
                }
                else return null;
            }
        }

        public static List<paValidacionParaCertificadosRRHH_Result> paValidacionParaCertificadosRRHH(Header header, string letra, int idtipoDeFianza, int anio, int idUnidadEjecutora)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paValidacionParaCertificadosRRHH(letra, idtipoDeFianza, anio, idUnidadEjecutora).ToList();
                }
                else return null;
            }
        }

        //public static List<paListarFianzasEconomicasReporte_Result> paListarFianzasEconomicasReporte(Header header, int idTipoFianza1, int idtipoDeFianza2,int mes, int anio)
        //{
        //    using (var contexto = new MidasDEntities())
        //    {
        //        if (header.token.Equals(Utils.Utils.token()))
        //        {
        //            return contexto.paListarFianzasEconomicasReporte("",idTipoFianza1,  idtipoDeFianza2, mes,anio).ToList();
        //        }
        //        else return null;
        //    }
        //}

        public static List<paListarFianzasEconomicasReporteGlobal_Result> paListarFianzasEconomicasReporteGlobal(Header header, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFianzasEconomicasReporteGlobal("", idTipoFianza1, idtipoDeFianza2, mes, anio).ToList();
                }
                else return null;
            }
        }


        public static List<paListarFianzasRealesReporteGlobal_Result> paListarFianzasRealesReporteGlobal(Header header, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFianzasRealesReporteGlobal("", idTipoFianza1, idtipoDeFianza2, mes, anio).ToList();
                }
                else return null;
            }
        }

        public static List<paListarFianzasEconomicasReporteT727_Result> paListarFianzasEconomicasReporteT727(Header header,string letra, int mes, int anio)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFianzasEconomicasReporteT727("",2,3, mes, anio).ToList();
                }
                else return null;
            }
        }

        public static List<paReporteCartilla_Result> paFianzaReporteCartilla(Header header, int idFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paReporteCartilla(idFianza).ToList();
                }
                else return null;
            }
        }

        public static List<paReporteCartillaT727_Result> paFianzaReporteCartillaT727(Header header, int idFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paReporteCartillaT727(idFianza).ToList();
                }
                else return null;
            }
        }

        public static List<paFianzasPorFuncionarioBuscar_Result> paFianzasPorFuncionarioBuscar(Header header, string ci)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFianzasPorFuncionarioBuscar(ci).ToList();
                }
                else return null;
            }
        }

        public static List<paReporteCartillaHabilitadoEditar_Result> paFianzaReporteCartillaHabilitadoEditar(Header header, int idFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paReporteCartillaHabilitadoEditar(idFianza).ToList();
                }
                else return null;
            }
        }

        public static List<paReporteFormularioA2_Result> paFianzaReporteFormularioA2(Header header, string letra,int idTipoFianza , int mes ,int gestion , int idunidadEjecutora )
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paReporteFormularioA2(letra,idTipoFianza,mes,gestion,idunidadEjecutora).ToList();
                }
                else return null;
            }
        }

        public static List<Contador_Impresion_Result> paContador_Impresion(Header header)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Contador_Impresion().ToList(); ;
                }
                else return null;
            }
        }


        public static List<paListarFianzasEconomicasReporteGlobalUnidadEjecutora_Result> paListarFianzasEconomicasReporteGlobalUnidadEjecutora(Header header,string letra, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio,int idUnidadEjecutora)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFianzasEconomicasReporteGlobalUnidadEjecutora(letra, idTipoFianza1, idtipoDeFianza2, mes, anio,idUnidadEjecutora).ToList();
                }
                else return null;
            }
        }



        /*Contar fianzas sin resolucion 30 dias atras hasta la fecha actual*/
        public static int contarFianzasParaResolucion(Header header) /*Ok*/
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    //DateTime fechaIncicial=Utilitario.fechaActual().AddDays(-30);
                    //DateTime fechaFinal = Utilitario.fechaActual();
                    //var count = contexto.Fianza.Count(t => t.resolucion_Administrativa == null && t.fecha_RRHH>=fechaIncicial && t.fecha_RRHH<=fechaFinal);
                    int gestionActual = Utilitario.fechaActual().Year;
                    var count = contexto.Solicitudes.Count(t => t.solicitud_Aceptada == null && t.gestion == gestionActual && t.registroActivo == true);
                    return count;
                }
                else return -1;
            }
        }
        public static int contarFianzasSinResolucion(Header header) /*Ok*/
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    int gestionActual = Utilitario.fechaActual().Year;
                    var count = contexto.Solicitudes.Count(t => t.solicitud_Aceptada == null && t.gestion==gestionActual &&(t.tipo_Solicitud_Fianza== "Nueva Fianza" || t.tipo_Solicitud_Fianza== "Transferencia" || t.tipo_Solicitud_Fianza == "Devolucion") && t.registroActivo==true);
                    return count;
                }
                else return -1;
            }
        }

       

        public static int contardevolucionesPendientesContabilidad(Header header)/*ok*/
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var count = contexto.Devolucion.Count(t => t.mes == null && t.anio == null && t.resolucion_Administrativa==null && t.c31 == null);
                    return count;
                }
                else return -1;
            }
        }


        public static int contarFianzasCompletasValidacionCertificacionHabilitado(Header header,int gestion) /*ok*/
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    int cantItems = 0;

                    List <UnidadEjecutora> lista = contexto.UnidadEjecutora.Where(x => x.registroActivo == true).ToList();
                    foreach (UnidadEjecutora um in lista)
                    {
                        cantItems= contexto.paValidacionParaCertificadosHabilitado(" ", gestion, um.idUnidadEjecutora).ToList().Count()+cantItems;
                    }
                    return cantItems;
                }
                else return -1;
            }
        }

        public static int contarFianzasCompletasValidacionCertificacionContabilidad(Header header, int gestion)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    
                    int cantItems = 0;

                    List<UnidadEjecutora> lista = contexto.UnidadEjecutora.Where(x => x.registroActivo == true).ToList();
                    foreach (UnidadEjecutora um in lista)
                    {
                        cantItems = contexto.paValidacionParaCertificadosContabilidad("", gestion, um.idUnidadEjecutora).ToList().Count() + cantItems;
                    }
                    return cantItems;
                }
                else return -1;
            }
        }



        public static int contarMesDescuentoHabilitado(Header header,int mes, int gestion)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    int cantItems = 0;

                    List<UnidadEjecutora> lista = contexto.UnidadEjecutora.Where(x => x.registroActivo == true).ToList();
                    foreach (UnidadEjecutora um in lista)
                    {
                        int mesesUnidadEjecutora = contexto.paFianzasListarMesAnioDescuentos(um.idUnidadEjecutora, gestion, 2).ToList().Count();
                        if (mesesUnidadEjecutora<Utilitario.fechaActual().Month)
                        {
                            cantItems++;
                        }
                    }

                    //var count = contexto.paValidacionEstadoFianzaHabilitado(letra,gestion,).Count(t => t.mes == null && t.anio == null && t.resolucion_Administrativa == null && t.c31 == null);
                    return cantItems;
                }
                else return -1;
            }
        }


        public static int contarTransferenciasContabilidad(Header header)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var count = contexto.Transferencia.Count(t => t.usuario_Contabilidad_Transferencia == null && t.mes_Transferencia == null && t.anio_Tranferencia == null);
                    return count;
                }
                else return -1;
            }
        }


        public static int contarValidarMesDescuentoContabilidad(Header header, int mes, int gestion)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    int cantItems = 0;

                    List<UnidadEjecutora> lista = contexto.UnidadEjecutora.Where(x => x.registroActivo == true).ToList();
                    foreach (UnidadEjecutora um in lista)
                    {
                        int mesesUnidadEjecutora = contexto.paFianzasListarMesAnioContaVali(um.idUnidadEjecutora, gestion, 2).ToList().Count();
                        if (mesesUnidadEjecutora < Utilitario.fechaActual().Month)
                        {
                            cantItems++;
                        }
                    }

                    //var count = contexto.paValidacionEstadoFianzaHabilitado(letra,gestion,).Count(t => t.mes == null && t.anio == null && t.resolucion_Administrativa == null && t.c31 == null);
                    return cantItems;
                }
                else return -1;
            }
        }


        public static int contarFianzasValidacionBienesGravadosContabilidad(Header header, string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {

                    int cantItems = 0;

                    List<paListarFuncionariosFianzaConResolucionBienesGravados_Result> paListarFuncionariosFianzaConResolucionBienesGravados = contexto.paListarFuncionariosFianzaConResolucionBienesGravados(" ", usuario).ToList();
                    foreach (paListarFuncionariosFianzaConResolucionBienesGravados_Result um in paListarFuncionariosFianzaConResolucionBienesGravados)
                    {
                        if (!Convert.ToBoolean(um.fianza_Validada_Contabilidad))
                        {
                            cantItems++;
                        }
                    }

                    if (cantItems != 0)
                    {
                        return cantItems;
                    }
                    else return -1;
                    
                }
                else return -1;
            }
        }

        public static int contarFianzasTotalesValidacionContabilidad(Header header)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {

                    return  contexto.paFuncionarioFianzaActualBuscarTipoFianzaTotalEstadoValidado("",3,0).ToList().Count;
                }
                else return -1;
            }
        }
    }
}
