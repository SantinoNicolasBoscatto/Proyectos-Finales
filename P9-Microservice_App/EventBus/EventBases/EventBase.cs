namespace EventBus.EventBase
{
    public abstract class EventBase
    {
        public DateTime TimeStamp { get; protected set; }
        protected EventBase()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
