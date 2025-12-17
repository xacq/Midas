using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class DescuentoCln
     {
         public static int insertar(Header header, Descuento descuento)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Descuento.Add(descuento);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Descuento", descuento.idDescuento.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return descuento.idDescuento;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Descuento descuento)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                    var actual = contexto.Descuento.Find(descuento.idDescuento);
                    actual.idFianza = descuento.idFianza;
                    actual.monto_Beneficiario = descuento.monto_Beneficiario;
                    actual.t727 = descuento.t727;
                    actual.t727_Fianza_Real = descuento.t727_Fianza_Real;
                    actual.c21 = descuento.c21;
                    actual.mes = descuento.mes;
                    actual.anio = descuento.anio;
                    actual.validado = descuento.validado;
                    actual.validado_Por = descuento.validado_Por;
                    actual.observacion = descuento.observacion;
                    actual.usuarioRegistro = descuento.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Descuento", descuento.idDescuento.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idDescuento)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Descuento.Find(idDescuento);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Descuento", idDescuento.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Descuento> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Descuento.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

        public static Descuento getIdFianzaReclasificacion(Header header, int idFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Descuento.AsParallel().Where(x => x.idFianza == idFianza && x.t727>0).FirstOrDefault();
                }
                else return null;
            }
        }

        public static Descuento get(Header header, int idDescuento)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Descuento.Find(idDescuento);
                 }
                 else return null;
             }
         }

        public static int eliminarfisico(Header header, int idFianza,int mes,int anio)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    contexto.paDescuentoEditarEliminarFisico(idFianza,mes,anio);
                    contexto.SaveChanges();
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int eliminarfisicoEditar(Header header, int idFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    contexto.paDescuentoEditarEliminarFisicoEditar(idFianza);
                    contexto.SaveChanges();
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static Descuento verificarFianzaDescuentoMesRegistrado(Header header, int idfianza, int mes, int anio)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Descuento.Where(p => p.idFianza == idfianza && p.mes == mes && p.anio == anio).FirstOrDefault();
                }
                else return null;
            }
        }
    }
}
