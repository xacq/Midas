using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class DireccionAdministrativaCln
     {
         public static int insertar(Header header, DireccionAdministrativa direccionAdministrativa)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.DireccionAdministrativa.Add(direccionAdministrativa);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("DireccionAdministrativa", direccionAdministrativa.idDireccionAdministrativa.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return direccionAdministrativa.idDireccionAdministrativa;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, DireccionAdministrativa direccionAdministrativa)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.DireccionAdministrativa.Find(direccionAdministrativa.idDireccionAdministrativa);
                     actual.codigo = direccionAdministrativa.codigo;
                     actual.descripcion = direccionAdministrativa.descripcion;
                     actual.usuarioRegistro = direccionAdministrativa.usuarioRegistro;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("DireccionAdministrativa", direccionAdministrativa.idDireccionAdministrativa.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idDireccionAdministrativa)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.DireccionAdministrativa.Find(idDireccionAdministrativa);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("DireccionAdministrativa", idDireccionAdministrativa.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<DireccionAdministrativa> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.DireccionAdministrativa.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static DireccionAdministrativa get(Header header, int idDireccionAdministrativa)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.DireccionAdministrativa.Find(idDireccionAdministrativa);
                 }
                 else return null;
             }
         }
     }
}
