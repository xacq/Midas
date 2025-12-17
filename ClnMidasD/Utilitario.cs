using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadMidasD;

namespace ClnMidasD
{
    public class Utilitario
    {
        public static DateTime fechaActual()
        {
            using (var contexto = new MidasDEntities())
            {
                return contexto.paFechaActual().FirstOrDefault().Value;
            }
        }
    }
}
