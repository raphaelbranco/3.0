using Base30.Core.Messages;

namespace Base30.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        private List<Event>? _notificationsEvent;

        public IReadOnlyCollection<Event>? Notifications => _notificationsEvent?.AsReadOnly();

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public void AddEvent(Event eventItem)
        {
            _notificationsEvent ??= new List<Event>();
            _notificationsEvent.Add(eventItem);
        }

        public void RemoveEvent(Event eventItem)
        {
            _notificationsEvent?.Remove(eventItem);
        }

        public void ClearEvent()
        {
            _notificationsEvent?.Clear();
        }

        public List<Event>? ListAllEvent()
        {
            return _notificationsEvent;
        }
    }
}
