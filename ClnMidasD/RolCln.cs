using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
    public class RolCln
    {
        public static int insertar(Header header, Rol rol)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    contexto.Rol.Add(rol);
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Rol", rol.idRol.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int editar(Header header, Rol rol)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.Rol.Find(rol.idRol);
                    actual.rol1 = rol.rol1;
                    actual.usuarioRegistro = rol.usuarioRegistro;
                    actual.fechaRegistro = rol.fechaRegistro;
                    actual.registroActivo = rol.registroActivo;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Rol", rol.idRol.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int eliminar(Header header, int idRol)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.Rol.Find(idRol);
                    actual.registroActivo = false;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Rol", idRol.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static List<Rol> listar(Header header)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var a = contexto.Rol.AsParallel().AsOrdered().Where(x => x.registroActivo == true).ToList();
                    return a;
                }
                else return null;
            }
        }

        public static Rol get(Header header, int idRol)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Rol.Find(idRol);
                }
                else return null;
            }
        }

        public static Rol validarNuevo(Header header, string rol)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Rol.Where(u => u.rol1 == rol).FirstOrDefault();
                }
                else return null;
            }
        }

        public static int activar(Header header, int idRol)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var rol = contexto.Usuario.Find(idRol);
                    rol.registroActivo = true;
                    return contexto.SaveChanges();
                }
                else return 0;
            }
        }
    }
}
