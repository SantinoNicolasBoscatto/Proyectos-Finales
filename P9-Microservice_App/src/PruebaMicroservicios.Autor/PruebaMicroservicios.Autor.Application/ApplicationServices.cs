using EventBus.Implements;
using EventBus.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaMicroservicios.Autor.Application.Common.Validators;
using System.Reflection;

namespace PruebaMicroservicios.Autor.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddSingleton<IRabbitEventBus, RabbitEventBus>(sp =>
            {
                // Configurare las Dependencias que requiere el constructor del RabbitEventBus
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var configuration = sp.GetRequiredService<IConfiguration>();
                return new RabbitEventBus(sp.GetRequiredService<IMediator>(), scopeFactory, configuration);
            });
            return services;
        }
    }
}
