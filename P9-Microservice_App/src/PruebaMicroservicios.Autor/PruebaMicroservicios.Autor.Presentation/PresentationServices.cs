using PruebaMicroservicios.Autor.Presentation.Common.Exceptions;
using System.Reflection;

namespace PruebaMicroservicios.Autor.Presentation
{
    public static class PresentationServices
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddGrpc(opt =>
            {
                opt.Interceptors.Add<GlobalExceptionHandler>();
            });
            return service;
        }
    }
}
