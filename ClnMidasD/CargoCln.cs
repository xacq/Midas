using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class CargoCln
     {
         public static int insertar(Header header, Cargo cargo)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Cargo.Add(cargo);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Cargo", cargo.idCargo.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                    return cargo.idCargo;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Cargo cargo)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                    var actual = contexto.Cargo.Find(cargo.idCargo);
                    actual.denominacion_Puesto = cargo.denominacion_Puesto;
                    actual.descripcion_Puesto = cargo.descripcion_Puesto;
                    actual.tipo_Personal = cargo.tipo_Personal;
                    actual.idEscalaSalarial = cargo.idEscalaSalarial;
                    actual.sigla = cargo.sigla;
                    actual.usuarioRegistro = cargo.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Cargo", cargo.idCargo.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idCargo)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Cargo.Find(idCargo);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Cargo", idCargo.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Cargo> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Cargo.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

        public static List<paListaCargoOficina_Result> listarOficinaCargos(Header header,int idOficina,int gestion)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListaCargoOficina(idOficina,gestion).ToList();
                }
                else return null;
            }
        }

        public static List<paListaCargoOficinaAdmin_Result> listarOficinaCargosAdmin(Header header, int idOficina, int gestion)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListaCargoOficinaAdmin(idOficina, gestion).ToList();
                }
                else return null;
            }
        }

        public static Cargo get(Header header, int idCargo)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Cargo.Find(idCargo);
                 }
                 else return null;
             }
         }
     }
}
