namespace ServiPryntWeb.Models.Repositorio.Abstractas
{
    public interface IUserService
    {
        Task<(bool bolean, int id)> VerificarUsuario(string usuario, string password);
    }
}
