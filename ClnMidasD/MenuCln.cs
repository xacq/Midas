using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadMidasD;


namespace ClnMidasD
{
    public class MenuCln
    {
        public static int insertar(Header header, Menu menu)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    contexto.Menu.Add(menu);
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Menu", menu.idMenu.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int editar(Header header, Menu menu)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.Menu.Find(menu.idMenu);
                    actual.menu1 = menu.menu1;
                    actual.nombre_Elemento = menu.nombre_Elemento;
                    actual.usuarioRegistro = menu.usuarioRegistro;
                    actual.fechaRegistro = menu.fechaRegistro;
                    actual.registroActivo = menu.registroActivo;
                    contexto.SaveChanges();
                    contexto.paAuditoriaRUD("Menu", menu.idMenu.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static int eliminar(Header header, int idMenu)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var actual = contexto.Menu.Find(idMenu);
                    actual.registroActivo = false;
                    contexto.SaveChanges();
                    //contexto.paAuditoriaRUD("Menu", idMenu.ToString(), header.hostName, header.macAddress, header.applitation);
                    return contexto.SaveChanges();
                }
                else return -1;
            }
        }

        public static List<Menu> listar(Header header)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Menu.AsParallel().Where(x => x.registroActivo == true).ToList();
                }
                else return null;
            }
        }

        public static Menu get(Header header, int idMenu)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Menu.Find(idMenu);
                }
                else return null;
            }
        }

        public static Menu validarNuevo(Header header, string menu)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    return contexto.Menu.Where(u => u.menu1 == menu).FirstOrDefault();
                }
                else return null;
            }
        }

        public static int activar(Header header, int idMenu)
        {
            using (var contexto = new MidasDEntities())
            {
                if (header.token.Equals(Utils.Utils.token()))
                {
                    var menu = contexto.Menu.Find(idMenu);
                    menu.registroActivo = true;
                    return contexto.SaveChanges();
                }
                else return 0;
            }
        }
    }
}
