using Microsoft.EntityFrameworkCore;
using ServiPryntWeb.Models._Negocio;
using ServiPryntWeb.Models.Repositorio.Abstractas;

namespace ServiPryntWeb.Models.Repositorio.Implementadas
{
    public class UserServices : IUserService
    {
        private readonly Negocio negocio;

        public UserServices(Negocio negocio)
        {
            this.negocio = negocio;
        }
        public async Task<(bool bolean, int id)> VerificarUsuario(string usuario, string password)
        {
            try
            {
                var user = await negocio.Usuarios.FirstOrDefaultAsync(x => x.Nombre == usuario);
                if (user == null) return (false,0);
                if (user.Password != password) return (false, 0);
                return (true, user.IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
