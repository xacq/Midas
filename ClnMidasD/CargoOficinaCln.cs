using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class CargoOficinaCln
     {
         public static int insertar(Header header, CargoOficina cargoOficina)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.CargoOficina.Add(cargoOficina);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("CargoOficina", cargoOficina.idCargoOficina.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return cargoOficina.idCargoOficina;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, CargoOficina cargoOficina)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.CargoOficina.Find(cargoOficina.idCargoOficina);
                     actual.idCargo = cargoOficina.idCargo;
                     actual.idOficina = cargoOficina.idOficina;
                     actual.usuarioRegistro = cargoOficina.usuarioRegistro;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("CargoOficina", cargoOficina.idCargoOficina.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idCargoOficina)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.CargoOficina.Find(idCargoOficina);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("CargoOficina", idCargoOficina.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<CargoOficina> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.CargoOficina.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static CargoOficina get(Header header, int idCargoOficina)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.CargoOficina.Find(idCargoOficina);
                 }
                 else return null;
             }
         }
     }
}
