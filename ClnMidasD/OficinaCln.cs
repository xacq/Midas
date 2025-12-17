using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class OficinaCln
     {
         public static int insertar(Header header, Oficina oficina)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Oficina.Add(oficina);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Oficina", oficina.idOficina.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return oficina.idOficina;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Oficina oficina)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                    var actual = contexto.Oficina.Find(oficina.idOficina);
                    actual.oficina1 = oficina.oficina1;
                    actual.codigo_Distrito = oficina.codigo_Distrito;
                    actual.codigo_Zeus = oficina.codigo_Zeus;
                    actual.idZeus = oficina.idZeus;
                    actual.idUnidadEjecutora = oficina.idUnidadEjecutora;
                    actual.cuantia = oficina.cuantia;
                    actual.porcentaje_Descuento = oficina.porcentaje_Descuento;
                    actual.usuarioRegistro = oficina.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Oficina", oficina.idOficina.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idOficina)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Oficina.Find(idOficina);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Oficina", idOficina.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Oficina> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Oficina.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }


        public static List<paListaOficinaUnidadEjecutora_Result> listarUnidadEjecutora(Header header,int idUnidadEjecutora)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListaOficinaUnidadEjecutora(idUnidadEjecutora).ToList();
                }
                else return null;
            }
        }

        public static List<paOficinasListar_Result> oficinasListarBuscar(Header header, string letra)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paOficinasListar(letra).ToList();
                }
                else return null;
            }
        }

        public static Oficina get(Header header, int idOficina)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Oficina.Find(idOficina);
                 }
                 else return null;
             }
         }

        public static List<paOficinaBuscar_Result> paoficinaBuscar(Header header, string letra,int idUnidadEjecutora)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paOficinaBuscar(letra,idUnidadEjecutora).ToList();
                }
                else return null;
            }
        }
    }
}
