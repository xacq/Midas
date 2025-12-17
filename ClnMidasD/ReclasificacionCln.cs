using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class ReclasificacionCln
     {
         public static int insertar(Header header, Reclasificacion reclasificacion)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Reclasificacion.Add(reclasificacion);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Reclasificacion", reclasificacion.idReclasificacion.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return reclasificacion.idReclasificacion;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Reclasificacion reclasificacion)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                    var actual = contexto.Reclasificacion.Find(reclasificacion.idReclasificacion);
                    actual.idFianza = reclasificacion.idFianza;
                    actual.monto_727 = reclasificacion.monto_727;
                    actual.mes = reclasificacion.mes;
                    actual.anio = reclasificacion.anio;
                    actual.usuarioRegistro = reclasificacion.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Reclasificacion", reclasificacion.idReclasificacion.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idReclasificacion)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Reclasificacion.Find(idReclasificacion);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Reclasificacion", idReclasificacion.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Reclasificacion> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Reclasificacion.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

        public static Reclasificacion getidFianza(Header header,int idFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Reclasificacion.AsParallel().Where(x => x.idFianza == idFianza).FirstOrDefault();
                }
                else return null;
            }
        }

        public static Reclasificacion get(Header header, int idReclasificacion)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Reclasificacion.Find(idReclasificacion);
                 }
                 else return null;
             }
         }

        public static List<paListarFianzasReclasificacion_Result> paListarFianzasReclasificacion(Header header, string letra)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFianzasReclasificacion(letra).ToList();
                }
                else return null;
            }
        }

        public static List<paListarFianzasReclasificacionPendientes_Result> paListarFianzasReclasificacionendientes(Header header, string letra)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFianzasReclasificacionPendientes(letra).ToList();
                }
                else return null;
            }
        }


        public static List<paListarFianzasReclasificacionReporte_Result> paListarFianzasReclasificacionReporte(Header header, DateTime fecha1, DateTime fecha2)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFianzasReclasificacionReporte(fecha1, fecha2).ToList();
                }
                else return null;
            }
        }

    }
}
