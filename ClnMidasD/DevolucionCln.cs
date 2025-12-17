using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class DevolucionCln
     {
         public static int insertar(Header header, Devolucion devolucion)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Devolucion.Add(devolucion);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Devolucion", devolucion.idDevolucion.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return devolucion.idDevolucion;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Devolucion devolucion)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                    var actual = contexto.Devolucion.Find(devolucion.idDevolucion);
                    actual.idFianza = devolucion.idFianza;
                    actual.idFuncionario = devolucion.idFuncionario;
                    actual.resolucion_Administrativa = devolucion.resolucion_Administrativa;
                    actual.c31 = devolucion.c31;
                    actual.nro_Cheque = devolucion.nro_Cheque;
                    actual.t727 = devolucion.t727;
                    actual.monto_Devolucion = devolucion.monto_Devolucion;
                    actual.mes = devolucion.mes;
                    actual.anio = devolucion.anio;
                    actual.observacion = devolucion.observacion;
                    actual.usuarioRegistro = devolucion.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Devolucion", devolucion.idDevolucion.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idDevolucion)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Devolucion.Find(idDevolucion);
                    actual.registroActivo = false;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Devolucion", idDevolucion.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Devolucion> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Devolucion.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static Devolucion get(Header header, int idDevolucion)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Devolucion.Find(idDevolucion);
                 }
                 else return null;
             }
         }

        public static Devolucion getidFianza(Header header, int idFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Devolucion.AsParallel().Where(x => x.idFianza == idFianza).FirstOrDefault();
                }
                else return null;
            }
        }

        public static List<paListarFuncionariosFianzaDevolucionContabilidadReporte_Result> paListarFuncionariosFianzaDevolucionContabilidadReporte(Header header, DateTime fecha1 , DateTime fecha2)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFuncionariosFianzaDevolucionContabilidadReporte(fecha1,fecha2).ToList();
                }
                else return null;
            }
        }

    }
}
