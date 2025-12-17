using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
    public class RolUsuarioCln
    {
        public static int insertar(Header header, RolUsuario rolUsuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    contexto.RolUsuario.Add(rolUsuario);
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("RolUsuario", rolUsuario.idRolUsuario.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int editar(Header header, RolUsuario rolUsuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.RolUsuario.Find(rolUsuario.idRolUsuario);
                    actual.idRol = rolUsuario.idRol;
                    actual.idUsuario = rolUsuario.idUsuario;
                    actual.usuarioRegistro = rolUsuario.usuarioRegistro;
                    actual.fechaRegistro = rolUsuario.fechaRegistro;
                    actual.registroActivo = rolUsuario.registroActivo;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("RolUsuario", rolUsuario.idRolUsuario.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int eliminar(Header header, int idRolUsuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.RolUsuario.Find(idRolUsuario);
                    actual.registroActivo = false;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("RolUsuario", idRolUsuario.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static List<RolUsuario> listar(Header header)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.RolUsuario.AsParallel().Where(x => x.registroActivo == true).ToList();
                }
                else return null;
            }
        }

        public static RolUsuario get(Header header, int idRolUsuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.RolUsuario.Find(idRolUsuario);
                }
                else return null;
            }
        }

        public static RolUsuario getUsuarioRol(Header header, int idUsuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.RolUsuario.Find(Convert.ToInt32(contexto.RolUsuario.Where(u => u.idUsuario == idUsuario && u.registroActivo==true).FirstOrDefault().idRolUsuario.ToString()));
                }
                else return null;
            }
        }

        public static List<viRolUsuarioListar> listarRoles(Header header, int idUsuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.viRolUsuarioListar
                        .Where(p => p.idUsuario == idUsuario)
                        .ToList();
                }
                else return null;
            }
        }
    }
}
