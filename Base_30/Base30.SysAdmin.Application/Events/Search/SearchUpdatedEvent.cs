using Base30.Core.Messages;

namespace Base30.SysAdmin.Application.Events.Search
{
    public class SearchUpdatedEvent : Event
    {
        public Guid Id { get; private set; }
        public Guid UserUpd { get; private set; }
        public Guid SysCustomer { get; private set; }
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }


        public SearchUpdatedEvent(Guid id, Guid userupd, Guid syscustomer, bool? active, string? name, string? description)
        {
            AggregateId = Id;
            Id = id;
            UserUpd = userupd;
            SysCustomer = syscustomer;
            Active = active;
            Name = name;
            Description = description;
        }
    }
}

