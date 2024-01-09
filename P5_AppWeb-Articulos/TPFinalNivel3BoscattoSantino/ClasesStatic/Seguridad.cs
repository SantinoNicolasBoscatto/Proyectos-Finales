using ModeloDeDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesStatic
{
    public static class Seguridad
    {
        public static bool VerificarAdmin(Usuario user)
        {
            if (user != null)
                return user.Permiso;
            else
                return false;
        }
    }
}
