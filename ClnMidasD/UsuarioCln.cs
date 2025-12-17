using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
    public class UsuarioCln
    {
        public static int insertar(Header header, Usuario usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    contexto.Usuario.Add(usuario);
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Usuario", usuario.idUsuario.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int editar(Header header, Usuario usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.Usuario.Find(usuario.idUsuario);
                    actual.nombre_Usuario = usuario.nombre_Usuario;
                    actual.clave = usuario.clave;
                    actual.idPersona = usuario.idPersona;
                    actual.rol = usuario.rol;
                    actual.idCodigoZeus = usuario.idCodigoZeus;
                    actual.usuarioRegistro = usuario.usuarioRegistro;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Usuario", usuario.idUsuario.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int eliminar(Header header, int idUsuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.Usuario.Find(idUsuario);
                    actual.registroActivo = false;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Usuario", idUsuario.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static List<Usuario> listar(Header header)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Usuario.AsParallel().AsOrdered().Where(x => x.registroActivo == true).ToList();
                }
                else return null;
            }
        }

        public static Usuario get(Header header, int idUsuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Usuario.Find(idUsuario);
                }
                else return null;
            }
        }


        public static Usuario getUsuarioPersona(Header header, int idPersona)
        {
            using (var contexto = new MidasDEntities())
            {
                try
                {
                    if (header.token.Equals(Utils.Utils.token()))
                    {
                        return contexto.Usuario.Find(Convert.ToInt32(contexto.Usuario.Where(u => u.idPersona == idPersona).FirstOrDefault().idUsuario.ToString()));
                    }
                    else return null;
                }
                catch
                {
                    return null;
                }
               
            }
        }

        public static Usuario getId(Header header, string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    try
                    {
                        return contexto.Usuario.Find(Convert.ToInt32(contexto.Usuario.Where(u => u.nombre_Usuario == usuario && u.registroActivo == true).FirstOrDefault().idUsuario.ToString()));
                    }
                    catch (Exception)
                    {
                        
                        return null;
                    }
                }
                else return null;
            }
        }

      


       
        public static int cambiarClave(Header header, int idUsuario, string clave)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.Usuario.Find(idUsuario);
                    actual.clave = clave;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Usuario", idUsuario.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static List<viUsuarioMenu> usuarioListarMenu(Header header, int idUsuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.viUsuarioMenu.Where(u => u.idUsuario == idUsuario).ToList();
                }
                else return null;
            }
        }
        public static List<viUsuarioListarDatos> listarDatosUsuario(Header header)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.viUsuarioListarDatos.AsParallel().AsOrdered().ToList();
                }
                else return null;
            }
        }
        public static Usuario validarNuevo(Header header, int idPersona, string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Usuario.Where(u => u.idPersona == idPersona || u.nombre_Usuario == usuario).FirstOrDefault();
                }
                else return null;
            }
        }


        public static Usuario validarUsuario(Header header, string usuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Usuario.Where(u => u.nombre_Usuario == usuario).FirstOrDefault();
                }
                else return null;
            }
        }

        public static int activar(Header header, int idUsuario)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var usuario = contexto.Usuario.Where(u => u.idUsuario == idUsuario).FirstOrDefault();
                    usuario.registroActivo = true;
                    return contexto.SaveChanges();
                }
                else return 0;
            }
        }

        public static List<paUsuarioBuscar_Result> buscar(Header header, string parametro)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.paUsuarioBuscar(parametro).AsParallel().ToList();
                }
                else return null;
            }
        }

        public static int idUsuarioClave(Header header,string usuario,string clave)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Usuario.Where(u => u.clave == clave && u.nombre_Usuario==usuario).FirstOrDefault().idUsuario;
                }
                else return -1;
            }
        }
    }
}
