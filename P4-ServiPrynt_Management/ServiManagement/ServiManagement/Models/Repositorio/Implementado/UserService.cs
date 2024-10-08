using Microsoft.EntityFrameworkCore;
using ServiManagement.Models._Negocio;
using ServiManagement.Models.Repositorio.Abstracto;

namespace ServiManagement.Models.Repositorio.Implementado
{
    public class UserService : IUserService
    {
        private readonly Negocio negocio;

        public UserService(Negocio negocio)
        {
            this.negocio = negocio;
        }

        public async Task<(bool bolean, int id, bool admin)> Login(string username, string password)
        {
            try
            {
                var usuario = await negocio.Usuarios.Where(x => x.Name == username).FirstOrDefaultAsync();
                if (usuario == null) return (false,0, false);
                if (usuario.Pass != password) return (false, 0, false);
                return (true, usuario.Id, usuario.EsAdmin);
            }
            catch (Exception)
            {
                return (false, 0, false);
            }
        }
    }
}
