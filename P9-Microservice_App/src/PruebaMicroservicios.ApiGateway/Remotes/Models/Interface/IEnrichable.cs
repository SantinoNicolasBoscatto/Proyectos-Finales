namespace PruebaMicroservicios.ApiGateway.Remotes.Models.Interface
{
    public interface IEnrichable<T>
    {
        Task EnrichAsync();
    }
}
