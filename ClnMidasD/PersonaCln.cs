using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
     public class PersonaCln
     {
         public static int insertar(Header header, Persona persona)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     contexto.Persona.Add(persona);
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Persona", persona.idPersona.ToString(), header.hostName, header.macAddress, header.applitation);
                    contexto.SaveChanges();
                     return persona.idPersona;
                 }
                 else return -1;
             }
         }

         public static int editar(Header header, Persona persona)
         {
             using (var contexto = new MidasDEntities())
             {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.Persona.Find(persona.idPersona);
                    actual.idTipoDocumento = persona.idTipoDocumento;
                    actual.numero_Documento = persona.numero_Documento;
                    actual.pais_Nacimiento = persona.pais_Nacimiento;
                    actual.departamento_Nacimiento = persona.departamento_Nacimiento;
                    actual.localidad_Nacimiento = persona.localidad_Nacimiento;
                    actual.provincia_Nacimiento = persona.provincia_Nacimiento;
                    actual.paterno = persona.paterno;
                    actual.materno = persona.materno;
                    actual.nombres = persona.nombres;
                    actual.domicilio = persona.domicilio;
                    actual.profesion = persona.profesion;
                    actual.sexo = persona.sexo;
                    actual.estado_Civil = persona.estado_Civil;
                    actual.fecha_Nacimiento = persona.fecha_Nacimiento;
                    actual.usuarioRegistro = persona.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Persona", persona.idPersona.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
         }

         public static int eliminar(Header header, int idPersona)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var actual = contexto.Persona.Find(idPersona);
                     actual.registroActivo = false;
                     contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Persona", idPersona.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                 }
                 else return -1;
             }
         }

         public static List<Persona> listar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Persona.AsParallel().Where(x => x.registroActivo == true).ToList();
                 }
                 else return null;
             }
         }

         public static Persona get(Header header, int idPersona)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Persona.Find(idPersona);
                 }
                 else return null;
             }
         }


         public static List<viPersonaListar> personaListar(Header header)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {

                    return contexto.viPersonaListar.AsParallel().ToList();
                 }
                 else return null;
             }
         }

         public static Persona validarNuevo(Header header, string nroDocumento)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Persona.Where(p => p.numero_Documento == nroDocumento).FirstOrDefault();
                 }
                 else return null;
             }
         }

         public static int activar(Header header, int idPersona)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     var persona = contexto.Persona.Where(u => u.idPersona == idPersona).FirstOrDefault();
                     persona.registroActivo = true;
                     return contexto.SaveChanges();
                 }
                 else return 0;
             }
         }
         public static Persona getPorNumeroDocumento(Header header, string numeroDocumento)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.Persona.Where(p => p.numero_Documento == numeroDocumento).FirstOrDefault();
                 }
                 else return null;
             }
         }

         public static List<paPersonaBuscar_Result> personaBuscar(Header header, string personabuscar)
         {
             using (var contexto = new MidasDEntities())
             {
                 if (header.token.Equals(Utils.Utils.token()))
                 {
                     return contexto.paPersonaBuscar(personabuscar).AsParallel().ToList();
                 }
                 else return null;
             }
         }


        
     }
}
