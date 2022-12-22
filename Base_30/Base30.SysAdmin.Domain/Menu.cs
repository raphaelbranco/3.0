using Base30.Core.Data;
using Base30.Core.DomainObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Base30.SysAdmin.Domain
{
    public class Menu : Entity, IAggregateRoot
    {
        public DateTime InsDt { get; private set; }
        public DateTime UpdDt { get; private set; }
        public Guid? UserUpd { get; private set; }
        public Guid? SysCustomer { get; private set; }
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public Guid? SourceMenu { get; private set; }
        public int? Order { get; private set; }

        
        public Menu(DateTime insDt, DateTime updDt, Guid? userUpd, Guid? sysCustomer, bool? active, string? name, string? description, int? order, Guid? sourceMenu)
        {
            InsDt = insDt;
            UpdDt = updDt;
            UserUpd = userUpd;
            SysCustomer = sysCustomer;
            Active = active;
            Name = name;
            Description = description;
            SourceMenu = sourceMenu;
            Order = order;
            
            Validate();
        }

        public void Inactivate() => Active = false;

        public void Validate()
        {
            Validation.ValidateIfNull(Name, "O campo Ordem não pode estar vazio");
            Validation.ValidateIfEmpty(Name!, "O campo Nome não pode estar vazio");
            Validation.ValidateIfNull(Order, "O campo Ordem não pode estar vazio");
        }

        public void UpdateData(string name, string description, int? order, bool active, Guid? sourceMenu)
        {
            Name = name;
            Description = description;
            Order = order;
            Active = active;
            SourceMenu = sourceMenu;
        }

    }

    public class MenuNoSql: Entity, IAggregateRoot
    {
        
        public Guid? SysCustomer { get; private set; }
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public Guid? SourceMenu { get; private set; }
        public int? Order { get; private set; }


        public MenuNoSql(Guid id, Guid? sysCustomer, bool? active, string? name, string? description, int? order, Guid? sourceMenu)
        {
            Id = id;
            SysCustomer = sysCustomer;
            Active = active;
            Name = name;
            Description = description;
            SourceMenu = sourceMenu;
            Order = order;
        }
    }

}
