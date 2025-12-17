using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class EscalaSalarialCln
     {
         public static int insertar(Header header, EscalaSalarial escalaSalarial)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.EscalaSalarial.Add(escalaSalarial);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("EscalaSalarial", escalaSalarial.idEscalaSalarial.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return escalaSalarial.idEscalaSalarial;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, EscalaSalarial escalaSalarial)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                    var actual = contexto.EscalaSalarial.Find(escalaSalarial.idEscalaSalarial);
                    actual.categoria = escalaSalarial.categoria;
                    actual.clase = escalaSalarial.clase;
                    actual.nivel_Salarial = escalaSalarial.nivel_Salarial;
                    actual.denominacion_Puesto = escalaSalarial.denominacion_Puesto;
                    actual.numero_Items = escalaSalarial.numero_Items;
                    actual.idSueldoMensual = escalaSalarial.idSueldoMensual;
                    actual.usuarioRegistro = escalaSalarial.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("EscalaSalarial", escalaSalarial.idEscalaSalarial.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idEscalaSalarial)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.EscalaSalarial.Find(idEscalaSalarial);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("EscalaSalarial", idEscalaSalarial.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<EscalaSalarial> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.EscalaSalarial.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static EscalaSalarial get(Header header, int idEscalaSalarial)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.EscalaSalarial.Find(idEscalaSalarial);
                 }
                 else return null;
             }
         }

        public static EscalaSalarial idEscalaSalarial(Header header, int idsueldoMensual)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.EscalaSalarial.Where(x => x.idSueldoMensual  == (contexto.SueldoMensual.Where(xp => xp.idSueldoMensual  == idsueldoMensual).FirstOrDefault().idSueldoMensual)).FirstOrDefault();
                }
                else return null;
            }
        }


        public static List<paEscalaSalarialGestion_Result> paEscalaSalarialGestion(Header header, int gestion)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paEscalaSalarialGestion(gestion).ToList();
                }
                else return null;
            }
        }

        public static int activar(Header header, int idEscalaSalarial)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var escalaSalarial = contexto.EscalaSalarial.Find(idEscalaSalarial);
                    escalaSalarial.registroActivo = true;
                    return contexto.SaveChanges();
                }
                else return 0;
            }
        }
    }
}
