using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class FuncionarioCln
     {
         public static int insertar(Header header, Funcionario Funcionario)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Funcionario.Add(Funcionario);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Funcionario", Funcionario.idFuncionario.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return Funcionario.idFuncionario;
                 }
                 else return -1;
             }
         }

        public static int editar(Header header, Funcionario funcionario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.Funcionario.Find(funcionario.idFuncionario);
                    actual.idPersona = funcionario.idPersona;
                    actual.numero_Memorando = funcionario.numero_Memorando;
                    actual.tipo_Contrato_Item = funcionario.tipo_Contrato_Item;
                    actual.vigencia_Contrato = funcionario.vigencia_Contrato;
                    actual.idCargo = funcionario.idCargo;
                    actual.idOficina = funcionario.idOficina;
                    actual.codigo_Distrito = funcionario.codigo_Distrito;
                    actual.fecha_Memorando = funcionario.fecha_Memorando;
                    actual.usuarioRegistro = funcionario.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Funcionario", funcionario.idFuncionario.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int eliminar(Header header, int idFuncionario)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Funcionario.Find(idFuncionario);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Funcionario", idFuncionario.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Funcionario> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Funcionario.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static Funcionario get(Header header, int idFuncionario)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Funcionario.Find(idFuncionario);
                 }
                 else return null;
             }
         }

        public static Funcionario validarNuevoFuncionario(Header header, string nroDocumento)//Verificamos si el funcionario esta registrado...Solo se registra si el funcionario esta dado de baja
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                   return  contexto.Funcionario.Where(p =>p.idPersona== (contexto.Persona.Where(pe => pe.numero_Documento == nroDocumento).FirstOrDefault().idPersona) && p.registroActivo==true).FirstOrDefault();
                }
                else return null;
            }
        }

        public static List<paFuncionarioFianzaActualBuscar_Result> paFuncionarioFianzaActualBuscar(Header header,string letra, int idUnidadEjecutora,int idTipoFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFuncionarioFianzaActualBuscar(letra, idUnidadEjecutora,idTipoFianza).ToList();
                }
                else return null;
            }
        }

        public static List<paFuncionarioFianzaActualBuscarGeneral_Result> paFuncionarioFianzaActualBuscarGeneral(Header header, string letra, int idTipoFianza1, int idTipoFianza2)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFuncionarioFianzaActualBuscarGeneral(letra, idTipoFianza1, idTipoFianza2).ToList();
                }
                else return null;
            }
        }

        public static List<paFuncionarioFianzaActualBuscarGeneralAdministrador_Result> paFuncionarioFianzaActualBuscarGeneralAdministrador(Header header, string letra, int idTipoFianza1, int idTipoFianza2)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFuncionarioFianzaActualBuscarGeneralAdministrador(letra, idTipoFianza1, idTipoFianza2).ToList();
                }
                else return null;
            }
        }

        public static List<paFuncionarioFianzaActualBuscarBaja_Result> paFuncionarioFianzaActualBuscarBaja(Header header, string letra, int idUnidadEjecutora, int idTipoFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFuncionarioFianzaActualBuscarBaja(letra, idUnidadEjecutora, idTipoFianza).ToList();
                }
                else return null;
            }
        }

        public static List<paFuncionarioFianzaActualBuscarCartilla_Result> paFuncionarioFianzaActualBuscarCartilla(Header header, string letra, int idUnidadEjecutora, int idTipoFianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFuncionarioFianzaActualBuscarCartilla(letra, idUnidadEjecutora, idTipoFianza).ToList();
                }
                else return null;
            }
        }




        public static List<paFuncionarioFianzaActualBuscarContaVali_Result> paFuncionarioFianzaActualBuscarContaVali(Header header, string letra, int idUnidadEjecutora, int idTipoFianza,int mes,int anio)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFuncionarioFianzaActualBuscarContaVali(letra, idUnidadEjecutora, idTipoFianza,mes, anio).ToList();
                }
                else return null;
            }
        }

        public static List<paFuncionarioFianzaActualBuscaridFianza_Result> paFuncionarioFianzaActualBuscaridFianza(Header header, int idUnidadEjecutora,int idfianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFuncionarioFianzaActualBuscaridFianza( idUnidadEjecutora,idfianza).ToList();
                }
                else return null;
            }
        }


        public static List<paFuncionarioVerificaridFianzaCompleta_Result> paFuncionarioVerificaridFianzaCompleta(Header header, int idUnidadEjecutora, int idfianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paFuncionarioVerificaridFianzaCompleta(idUnidadEjecutora, idfianza).ToList();
                }
                else return null;
            }
        }

        public static List<paReporteFuncionarioCertificadoidFianza_Result> paReporteCertificadoidFianza(Header header, int idUnidadEjecutora, int idfianza)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paReporteFuncionarioCertificadoidFianza(idUnidadEjecutora, idfianza).ToList();
                }
                else return null;
            }
        }
    }
}
