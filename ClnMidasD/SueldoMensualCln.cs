using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class SueldoMensualCln
     {
         public static int insertar(Header header, SueldoMensual sueldoMensual)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.SueldoMensual.Add(sueldoMensual);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("SueldoMensual", sueldoMensual.idSueldoMensual.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return sueldoMensual.idSueldoMensual;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, SueldoMensual sueldoMensual)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {

                    var actual = contexto.SueldoMensual.Find(sueldoMensual.idSueldoMensual);
                    actual.monto = sueldoMensual.monto;
                    actual.gestion = sueldoMensual.gestion;
                    actual.incremento = sueldoMensual.incremento;
                    actual.usuarioRegistro = sueldoMensual.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("SueldoMensual", sueldoMensual.idSueldoMensual.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idSueldoMensual)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.SueldoMensual.Find(idSueldoMensual);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("SueldoMensual", idSueldoMensual.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<SueldoMensual> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.SueldoMensual.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static SueldoMensual get(Header header, int idSueldoMensual)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.SueldoMensual.Find(idSueldoMensual);
                 }
                 else return null;
             }
         }


        public static List<paSueldosMensuales_Result> paSueldosMensuales(Header header, int anio)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paSueldosMensuales(anio).ToList();
                }
                else return null;
            }
        }

        public static int activar(Header header, int idSueldoMensual)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var sueldoMensual = contexto.SueldoMensual.Find(idSueldoMensual);
                    sueldoMensual.registroActivo = true;
                    return contexto.SaveChanges();
                }
                else return 0;
            }
        }

        public static SueldoMensual validarNuevo(Header header, Double monto)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.SueldoMensual.Where(u => u.monto == monto).FirstOrDefault();
                }
                else return null;
            }
        }
    }
}
