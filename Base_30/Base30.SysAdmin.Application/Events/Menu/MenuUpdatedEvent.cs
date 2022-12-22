using Base30.Core.Messages;

namespace Base30.SysAdmin.Application.Events.Menu
{
    public class MenuUpdatedEvent : Event
    {
        public Guid MenuId { get; private set; }
        public string Name { get; set; }

        public string Source { get; set; }

        public MenuUpdatedEvent(Guid menuId, string name, string source)
        {
            MenuId = menuId;
            AggregateId = menuId;
            Name = name;
            Source = source;
        }
    }
}
