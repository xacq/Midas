using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class UnidadEjecutoraCln
     {
         public static int insertar(Header header, UnidadEjecutora unidadEjecutora)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.UnidadEjecutora.Add(unidadEjecutora);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("UnidadEjecutora", unidadEjecutora.idUnidadEjecutora.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return unidadEjecutora.idUnidadEjecutora;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, UnidadEjecutora unidadEjecutora)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.UnidadEjecutora.Find(unidadEjecutora.idUnidadEjecutora);
                     actual.codigo = unidadEjecutora.codigo;
                     actual.descripcion = unidadEjecutora.descripcion;
                     actual.idDireccionAdministrativa = unidadEjecutora.idDireccionAdministrativa;
                     actual.usuarioRegistro = unidadEjecutora.usuarioRegistro;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("UnidadEjecutora", unidadEjecutora.idUnidadEjecutora.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idUnidadEjecutora)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.UnidadEjecutora.Find(idUnidadEjecutora);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("UnidadEjecutora", idUnidadEjecutora.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<UnidadEjecutora> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.UnidadEjecutora.AsParallel().Where(x => x.registroActivo == true).OrderBy(x => x.idUnidadEjecutora).ToList();
                 }
                 else return null;
             }
         }

         public static UnidadEjecutora get(Header header, int idUnidadEjecutora)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.UnidadEjecutora.Find(idUnidadEjecutora);
                 }
                 else return null;
             }
         }
     }
}
