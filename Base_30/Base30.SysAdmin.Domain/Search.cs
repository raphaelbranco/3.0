using Base30.Core.DomainObjects;

namespace Base30.SysAdmin.Domain
{//
    public class Search : Entity, IAggregateRoot
    {
        public DateTime InsDt { get; private set; }
        public DateTime UpdDt { get; private set; }
        public Guid UserUpd { get; private set; }
        public Guid SysCustomer { get; private set; }
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }

        public Search(DateTime insDt, DateTime updDt, Guid userUpd, Guid sysCustomer, bool? active, string? name, string? description)
        {
            InsDt = insDt;
            UpdDt = updDt;
            UserUpd = userUpd;
            SysCustomer = sysCustomer;
            Active = active;
            Name = name;
            Description = description;

            Validate();
        }
        public void Update(Guid userupd, bool? active, string? name, string? description)
        {
            UserUpd = userupd;
            Active = active;
            Name = name;
            Description = description;
        }
        public void Validate()
        {
            if (Name != null) Validation.ValidateSize(Name, 0, 50, "Field Name max length 50 ");

            if (Description != null) Validation.ValidateSize(Description, 0, 100, "Field Description max length 100 ");

        }
    }
    public class SearchNoSql : Entity, IAggregateRoot
    {

        public Guid SearchId { get; private set; }
        public DateTime InsDt { get; private set; }
        public DateTime UpdDt { get; private set; }
        public Guid UserUpd { get; private set; }
        public Guid SysCustomer { get; private set; }
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }

        public SearchNoSql(Guid searchid, DateTime insDt, DateTime updDt, Guid userUpd, Guid sysCustomer, bool? active, string? name, string? description)
        {
            SearchId = searchid;

            InsDt = insDt;
            UpdDt = updDt;
            UserUpd = userUpd;
            SysCustomer = sysCustomer;
            Active = active;
            Name = name;
            Description = description;


        }
        public void UpdateNoSql(Guid userupd, bool? active, string? name, string? description)
        {
            UserUpd = userupd;
            Active = active;
            Name = name;
            Description = description;

        }
    }
}

