namespace EventBus.Interfaces
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : EventBus.EventBase.EventBase
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    { }
}
