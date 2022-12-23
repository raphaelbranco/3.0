﻿using Base30.Core.DomainObjects;

namespace Base30.SysAdmin.Domain
{
    public class Search : Entity, IAggregateRoot
    {
        public DateTime InsDt { get; private set; }
        public DateTime UpdDt { get; private set; }
        public Guid UserUpd { get; private set; }
        public Guid SysCustomer { get; private set; }
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }

        public Search(DateTime insdt, DateTime upddt, Guid userupd, Guid syscustomer, bool active, string name, string description)
        {
            InsDt = insdt;
            UpdDt = upddt;
            UserUpd = userupd;
            SysCustomer = syscustomer;
            Active = active;
            Name = name;
            Description = description;

            Validate();
        }
        public void Update(bool active, string name, string description)
        {
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

        public DateTime InsDt { get; private set; }
        public DateTime UpdDt { get; private set; }
        public Guid UserUpd { get; private set; }
        public Guid SysCustomer { get; private set; }
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }

        public SearchNoSql(DateTime insdt, DateTime upddt, Guid userupd, Guid syscustomer, bool active, string name, string description)
        {
            InsDt = insdt;
            UpdDt = upddt;
            UserUpd = userupd;
            SysCustomer = syscustomer;
            Active = active;
            Name = name;
            Description = description;


        }
    }
}

