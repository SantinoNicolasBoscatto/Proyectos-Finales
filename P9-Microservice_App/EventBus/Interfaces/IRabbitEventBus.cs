using EventBus.Commands;

namespace EventBus.Interfaces
{
    public interface IRabbitEventBus
    {
        Task EnviarComando<T>(T comando) where T : Command;
        Task Publish<T>(T @evento) where T : EventBase.EventBase;
        Task Suscribe<T, TH>() where T : EventBase.EventBase
                               where TH : IEventHandler<T>;
    }
}
