using EventBus.EventQueue;
using EventBus.Interfaces;
using Microsoft.Extensions.Logging;

namespace PruebaMicroservicios.Libro.Infrastructure.IntegrationEvents
{
    public class TestEventHandler : IEventHandler<TestEventQueue>
    {
        private readonly ILogger<TestEventHandler> _logger;
        public TestEventHandler(ILogger<TestEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TestEventQueue @event)
        {
            _logger.LogWarning($"Soy el mensaje: {@event.Mensaje}");
            return Task.CompletedTask;
        }
    }
}
