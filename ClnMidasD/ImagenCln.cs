using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class ImagenCln
     {
         public static int insertar(Header header, Imagen imagen)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Imagen.Add(imagen);
                     contexto.SaveChanges();
                    //contexto.paAuditoriaRUD("Imagen", imagen.idImagen.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return imagen.idImagen;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Imagen imagen)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Imagen.Find(imagen.idImagen);
                     actual.idPersona = imagen.idPersona;
                     actual.imagen1 = imagen.imagen1;
                     actual.usuarioRegistro = imagen.usuarioRegistro;
                     contexto.SaveChanges();
                    //contexto.paAuditoriaRUD("Imagen", imagen.idImagen.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idImagen)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Imagen.Find(idImagen);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    //contexto.paAuditoriaRUD("Imagen", idImagen.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Imagen> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Imagen.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static Imagen get(Header header, int idImagen)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Imagen.Find(idImagen);
                 }
                 else return null;
             }
         }

        public static Imagen getidPersona(Header header, int idPersona)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Imagen.Where(x => x.idPersona == idPersona).FirstOrDefault();
                }
                else return null;
            }
        }
    }
}
