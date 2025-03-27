using EventBus.EventQueue;
using EventBus.Implements;
using EventBus.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaMicroservicios.Libro.Application.Interfaces;
using PruebaMicroservicios.Libro.Infrastructure.Context;
using PruebaMicroservicios.Libro.Infrastructure.IntegrationEvents;
using PruebaMicroservicios.Libro.Infrastructure.Interceptors;

namespace PruebaMicroservicios.Libro.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly("PruebaMicroservicios.Libro.Presentation")));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>()!);
            services.AddSingleton<IRabbitEventBus, RabbitEventBus>(sp =>
            {
                // Configurare las Dependencias que requiere el constructor del RabbitEventBus
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var configuration = sp.GetRequiredService<IConfiguration>();
                return new RabbitEventBus(sp.GetRequiredService<IMediator>(), scopeFactory, configuration);
            });

            services.AddTransient<TestEventHandler>();
            services.AddTransient<IEventHandler<TestEventQueue>, TestEventHandler>();

            return services;
        }
    }
}
