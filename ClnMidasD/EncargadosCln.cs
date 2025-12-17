using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class EncargadosCln
     {
         public static int insertar(Header header, Encargados encargados)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Encargados.Add(encargados);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Encargados", encargados.idEncargado.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return encargados.idEncargado;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Encargados encargados)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Encargados.Find(encargados.idEncargado);
                     actual.idPersona = encargados.idPersona;
                     actual.idCargo = encargados.idCargo;
                     actual.usuarioRegistro = encargados.usuarioRegistro;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Encargados", encargados.idEncargado.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idEncargado)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Encargados.Find(idEncargado);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Encargados", idEncargado.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Encargados> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Encargados.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static Encargados get(Header header, int idEncargado)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Encargados.Find(idEncargado);
                 }
                 else return null;
             }
         }

        public static Encargados getIdEncargadoFinanciero(Header header, int idCargo)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Encargados.Where(x => x.idCargo == idCargo && x.registroActivo==true).FirstOrDefault();
                }
                else return null;
            }
        }
    }
}
