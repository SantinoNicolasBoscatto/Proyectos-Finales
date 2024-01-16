using ModeloDeDominio;
using System;
using System.Collections.Generic;


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
