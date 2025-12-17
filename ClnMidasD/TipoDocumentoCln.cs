using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class TipoDocumentoCln
     {
         public static int insertar(Header header, TipoDocumento tipoDocumento)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.TipoDocumento.Add(tipoDocumento);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("TipoDocumento", tipoDocumento.idTipoDocumento.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return tipoDocumento.idTipoDocumento;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, TipoDocumento tipoDocumento)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.TipoDocumento.Find(tipoDocumento.idTipoDocumento);
                     actual.descripcion = tipoDocumento.descripcion;
                     actual.usuarioRegistro = tipoDocumento.usuarioRegistro;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("TipoDocumento", tipoDocumento.idTipoDocumento.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idTipoDocumento)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.TipoDocumento.Find(idTipoDocumento);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("TipoDocumento", idTipoDocumento.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<TipoDocumento> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.TipoDocumento.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static TipoDocumento get(Header header, int idTipoDocumento)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.TipoDocumento.Find(idTipoDocumento);
                 }
                 else return null;
             }
         }
     }
}
