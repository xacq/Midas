using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class TipoFianzaCln
     {
         public static int insertar(Header header, TipoFianza tipoFianza)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.TipoFianza.Add(tipoFianza);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("TipoFianza", tipoFianza.idTipoFianza.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return tipoFianza.idTipoFianza;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, TipoFianza tipoFianza)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                    var actual = contexto.TipoFianza.Find(tipoFianza.idTipoFianza);
                    actual.descripcion_Fianza = tipoFianza.descripcion_Fianza;
                    actual.usuarioRegistro = tipoFianza.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("TipoFianza", tipoFianza.idTipoFianza.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idTipoFianza)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.TipoFianza.Find(idTipoFianza);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("TipoFianza", idTipoFianza.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<TipoFianza> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.TipoFianza.AsParallel().Where(x => x.registroActivo == true).OrderBy(x=>x.idTipoFianza).ToList();
                 }
                 else return null;
             }
         }

         public static TipoFianza get(Header header, int idTipoFianza)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.TipoFianza.Find(idTipoFianza);
                 }
                 else return null;
             }
         }
     }
}
