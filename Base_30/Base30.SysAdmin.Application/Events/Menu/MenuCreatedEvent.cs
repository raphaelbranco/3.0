using Base30.Core.Messages;

namespace Base30.SysAdmin.Application.Events.Menu
{
    public class MenuCreatedEvent : Event
    {
        public Guid MenuId { get; private set; }
        public string Name { get; set; }
        public Guid? SysCustomer { get; private set; }
        public bool? Active { get; private set; }
        public string? Description { get; private set; }
        public Guid? SourceMenu { get; private set; }
        public int? Order { get; private set; }


        public MenuCreatedEvent(Guid menuId, string name, Guid? sourceMenu, Guid? sysCustomer, bool? active, string? description, int? order)
        {
            MenuId = menuId;
            AggregateId = menuId;
            Name = name;
            SourceMenu = sourceMenu;
            SysCustomer = sysCustomer;
            Active = active;
            Description = description;
            Order = order;
        }
    }
}
