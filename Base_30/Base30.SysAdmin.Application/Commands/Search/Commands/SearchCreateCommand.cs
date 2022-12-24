﻿using Base30.Core.Messages;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Base30.SysAdmin.Application.Commands.Search.Commands
{
    public class SearchCreateCommand : Command
    {
        public DateTime InsDt { get; private set; }
        public DateTime UpdDt { get; private set; }
        public Guid UserUpd { get; private set; }
        public Guid SysCustomer { get; private set; }
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public SearchCreateCommand(DateTime insdt, DateTime upddt, Guid userupd, Guid syscustomer, bool? active, string? name, string? description)
        {

            InsDt = insdt;
            UpdDt = upddt;
            UserUpd = userupd;
            SysCustomer = syscustomer;
            Active = active;
            Name = name;
            Description = description;
        }

        public override bool EhValido()
        {
            ValidationResult = new SearchCreateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class SearchCreateValidation : AbstractValidator<SearchCreateCommand>
        {
            public SearchCreateValidation()
            {
                RuleFor(c => c.Name)
                .MaximumLength(50)
                .WithMessage("Search Name  Max length 50 ");

                RuleFor(c => c.Description)
                .MaximumLength(100)
                .WithMessage("Search Description  Max length 100 ");

            }
        }
    }
}

