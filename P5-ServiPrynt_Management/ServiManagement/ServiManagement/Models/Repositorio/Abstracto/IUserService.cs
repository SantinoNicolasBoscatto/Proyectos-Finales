namespace ServiManagement.Models.Repositorio.Abstracto
{
    public interface IUserService
    {
        Task<(bool bolean, int id, bool admin)> Login(string username, string password);
    }
}
