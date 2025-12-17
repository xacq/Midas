using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;

namespace ClnMidasD
{
    public class RolMenuCln
    {
        public static int insertar(Header header, RolMenu rolMenu)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    contexto.RolMenu.Add(rolMenu);
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("RolMenu", rolMenu.idRolMenu.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int editar(Header header, RolMenu rolMenu)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.RolMenu.Find(rolMenu.idRolMenu);
                    actual.idRol = rolMenu.idRol;
                    actual.idMenu = rolMenu.idMenu;
                    actual.usuarioRegistro = rolMenu.usuarioRegistro;
                    actual.fechaRegistro = rolMenu.fechaRegistro;
                    actual.registroActivo = rolMenu.registroActivo;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("RolMenu", rolMenu.idRolMenu.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int eliminar(Header header, int idRolMenu)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.RolMenu.Find(idRolMenu);
                    actual.registroActivo = false;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("RolMenu", idRolMenu.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static List<RolMenu> listar(Header header)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.RolMenu.AsParallel().Where(x => x.registroActivo == true).ToList();
                }
                else return null;
            }
        }

        public static RolMenu get(Header header, int idRolMenu)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.RolMenu.Find(idRolMenu);
                }
                else return null;
            }
        }

        public static List<Menu> listarPorRol(Header header, int idRol)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return (from rm in contexto.RolMenu
                            join m in contexto.Menu
                            on rm.idMenu equals m.idMenu
                            where rm.idRol == idRol & rm.registroActivo == true
                            select m).ToList();
                }
                else return null;
            }
        }
        public static int eliminarMenu(Header header, int idRol)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var rm = contexto.RolMenu.AsEnumerable().Where(x => x.idRol == idRol).ToList();
                    contexto.RolMenu.RemoveRange(rm);
                    return contexto.SaveChanges();
                }
                else return 0;
            }
        }
    }
}
