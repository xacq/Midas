using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class SolicitudesCln
     {
         public static int insertar(Header header, Solicitudes solicitudes)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Solicitudes.Add(solicitudes);
                     contexto.SaveChanges();
                     contexto.paAuditoriaRUD("Solicitudes", solicitudes.idSolicitud.ToString(), header.hostName, header.macAddress, header.applitation);
                     contexto.SaveChanges();
                     return solicitudes.idSolicitud;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Solicitudes solicitudes)
         {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.Solicitudes.Find(solicitudes.idSolicitud);
                    actual.tipo_Solicitud_Fianza = solicitudes.tipo_Solicitud_Fianza;
                    actual.numero_memorando = solicitudes.numero_memorando;
                    actual.fecha_Memorando = solicitudes.fecha_Memorando;
                    actual.numero_Fianza_Solicitud = solicitudes.numero_Fianza_Solicitud;
                    actual.gestion = solicitudes.gestion;
                    actual.fecha_limite_presentacion = solicitudes.fecha_limite_presentacion;
                    actual.usuario_RRHH = solicitudes.usuario_RRHH;
                    actual.fecha_Registro_RRHH = solicitudes.fecha_Registro_RRHH;
                    actual.usuario_Asesor_Acepta = solicitudes.usuario_Asesor_Acepta;
                    actual.solicitud_Aceptada = solicitudes.solicitud_Aceptada;
                    actual.fecha_Aceptacion = solicitudes.fecha_Aceptacion;
                    actual.idPersona = solicitudes.idPersona;
                    actual.idCargo = solicitudes.idCargo;
                    actual.idOficina = solicitudes.idOficina;
                    actual.idEscalaSalarial = solicitudes.idEscalaSalarial;
                    actual.idSueldoMensual = solicitudes.idSueldoMensual;
                    actual.tipo_Contrato_Item = solicitudes.tipo_Contrato_Item;
                    actual.vigencia_Contrato = solicitudes.vigencia_Contrato;
                    actual.idFianza_Transferir = solicitudes.idFianza_Transferir;
                    actual.monto_Fianza_Transferir = solicitudes.monto_Fianza_Transferir;
                    actual.idFianza_Nueva = solicitudes.idFianza_Nueva;
                    actual.idTipoFianza = solicitudes.idTipoFianza;
                    actual.idDevolucion_Registro = solicitudes.idDevolucion_Registro;
                    actual.idTransferencia_Nueva = solicitudes.idTransferencia_Nueva;
                    actual.observacion = solicitudes.observacion;
                    actual.usuarioRegistro = solicitudes.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Solicitudes", solicitudes.idSolicitud.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

         public static int eliminar(Header header, int idSolicitud)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Solicitudes.Find(idSolicitud);
                     actual.registroActivo = false;
                    actual.numero_Fianza_Solicitud = 0;
                    contexto.SaveChanges();
                     contexto.paAuditoriaRUD("Solicitudes", idSolicitud.ToString(), header.hostName, header.macAddress, header.applitation);
                     return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Solicitudes> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Solicitudes.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static Solicitudes get(Header header, int idSolicitud)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Solicitudes.Find(idSolicitud);
                 }
                 else return null;
             }
         }

        public static List<paListarSolicitudesFianza_Result> palistarSolicitudesFianzaBuscar(Header header, string letra, string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarSolicitudesFianza(letra, usuario).ToList();
                }
                else return null;
            }
        }

        public static int ultimoNumeroSolicitud(Header header,int gestion)
        {
            try
            {
                using (var contexto = new MidasDEntities())
                {
                    if (header.token.Equals(Utils.Utils.token()))
                    {
                        return (int)contexto.Solicitudes.Where(q => q.gestion == gestion).Max(p => p.numero_Fianza_Solicitud);
                    }
                    else return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static List<paListarSolicitudesFianzaDiasRestantes_Result> paListarSolicitudesFianzaDiasRestantes(Header header, string letra, int dia1, int dia2, string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarSolicitudesFianzaDiasRestantes(letra, dia1, dia2, usuario).ToList();
                }
                else return null;
            }
        }

        public static List<paListarSolicitudesFianzaDiasRestantesReporte_Result> paListarSolicitudesFianzaDiasRestantesReporte(Header header, string letra, int dia1, int dia2, string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarSolicitudesFianzaDiasRestantesReporte(letra, dia1, dia2, usuario).ToList();
                }
                else return null;
            }
        }


        public static List<paReporteSolDevolucion_Result> paReporteSolDevolucion(Header header, int idSolicitud)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paReporteSolDevolucion(idSolicitud).ToList();
                }
                else return null;
            }
        }

        public static List<paReporteSolFianEconomica_Result> paFuncionarioFianzaActpaReporteSolFianEconomica(Header header, int idSolicitud)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paReporteSolFianEconomica(idSolicitud).ToList();
                }
                else return null;
            }
        }

        public static List<paReporteSolFianEconomicaTotal_Result> paFuncionarioFianzaActpaReporteSolFianEconomicaTotal(Header header, int idSolicitud)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paReporteSolFianEconomicaTotal(idSolicitud).ToList();
                }
                else return null;
            }
        }


        public static List<paReporteSolFianEconomicaNoRequiereFianza_Result> paFuncionarioFianzaActpaReporteSolNoRequiereFianza(Header header, int idSolicitud)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paReporteSolFianEconomicaNoRequiereFianza(idSolicitud).ToList();
                }
                else return null;
            }
        }

        public static List<paValidacionRegistroSolicitudes_Result> paValidacionRegistroSolicitudes(Header header, string numeroDocumento)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paValidacionRegistroSolicitudes(numeroDocumento).ToList();
                }
                else return null;
            }
        }
    }
}
