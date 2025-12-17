using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class TransferenciaCln
     {
         public static int insertar(Header header, Transferencia transferencia)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Transferencia.Add(transferencia);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Transferencia", transferencia.idTransferencia.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return transferencia.idTransferencia;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Transferencia transferencia)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                    var actual = contexto.Transferencia.Find(transferencia.idTransferencia);
                    actual.idFianza = transferencia.idFianza;
                    actual.idFuncionario = transferencia.idFuncionario;
                    actual.idCargoAnterior = transferencia.idCargoAnterior;
                    actual.numero_Memorando_Anterior = transferencia.numero_Memorando_Anterior;
                    actual.fecha_Memorando_Anterior = transferencia.fecha_Memorando_Anterior;
                    actual.tipo_Contrato_item_Anterior = transferencia.tipo_Contrato_item_Anterior;
                    actual.vigencia_Contrato_Anterior = transferencia.vigencia_Contrato_Anterior;
                    actual.idTipoFianzaAnterior = transferencia.idTipoFianzaAnterior;
                    actual.idOficinaAnterior = transferencia.idOficinaAnterior;
                    actual.idSueldoSueldoMensual = transferencia.idSueldoSueldoMensual;
                    actual.fecha_LimiteFianza_Anterior = transferencia.fecha_LimiteFianza_Anterior;
                    actual.resolucion_Administrativa_Anterior = transferencia.resolucion_Administrativa_Anterior;
                    actual.usuario_RRHH_Anterior = transferencia.usuario_RRHH_Anterior;
                    actual.fecha_RRHH_Anterior = transferencia.fecha_RRHH_Anterior;
                    actual.usuario_Resolucion_Anterior = transferencia.usuario_Resolucion_Anterior;
                    actual.fecha_Resolucion_Anterior = transferencia.fecha_Resolucion_Anterior;
                    actual.usuario_Impresa_Anterior = transferencia.usuario_Impresa_Anterior;
                    actual.fecha_Impresa_Anterior = transferencia.fecha_Impresa_Anterior;
                    actual.observacion_Anterior = transferencia.observacion_Anterior;
                    actual.monto_Fianza_Transferir = transferencia.monto_Fianza_Transferir;
                    actual.resolucion_Administrativa_Transferencia = transferencia.resolucion_Administrativa_Transferencia;
                    actual.usuario_Contabilidad_Transferencia = transferencia.usuario_Contabilidad_Transferencia;
                    actual.fecha_Contabilidad_Transferencia = transferencia.fecha_Contabilidad_Transferencia;
                    actual.mes_Transferencia = transferencia.mes_Transferencia;
                    actual.anio_Tranferencia = transferencia.anio_Tranferencia;
                    actual.observacion_Transferencia = transferencia.observacion_Transferencia;
                    actual.usuarioRegistro = transferencia.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Transferencia", transferencia.idTransferencia.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                 else return -1;
             }
         }

         public static int eliminar(Header header, int idTransferencia)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Transferencia.Find(idTransferencia);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Transferencia", idTransferencia.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Transferencia> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Transferencia.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static Transferencia get(Header header, int idTransferencia)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Transferencia.Find(idTransferencia);
                 }
                 else return null;
             }
         }

        public static List<paListarFuncionariosFianzaTranferencias_Result> paListarFuncionariosFianzaTranferencias(Header header, string letra, string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFuncionariosFianzaTranferencias(letra).ToList();
                }
                else return null;
            }
        }


        public static List<paListarFuncionariosFianzaTranferenciasReporte_Result> paListarFuncionariosFianzaTranferenciasReporte(Header header, DateTime fecha1, DateTime fecha2)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paListarFuncionariosFianzaTranferenciasReporte(fecha1, fecha2).ToList();
                }
                else return null;
            }
        }
    }
}
