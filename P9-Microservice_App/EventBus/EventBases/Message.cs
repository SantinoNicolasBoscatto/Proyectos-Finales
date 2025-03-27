using MediatR;

namespace EventBus.EventBases
{
    public abstract class Message : IRequest<bool>
    {
        public string? MessageType { get; protected set; }
        protected Message()
        {
            MessageType = this.GetType().Name;
        }
    }
}
