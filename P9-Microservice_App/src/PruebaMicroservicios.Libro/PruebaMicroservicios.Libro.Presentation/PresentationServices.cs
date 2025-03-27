using System.Reflection;

namespace PruebaMicroservicios.Libro.Presentation
{
    public static class PresentationServices
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            return service;
        }
    }
}
