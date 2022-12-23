using Base30.Core.Messages;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Base30.SysAdmin.Application.Commands.Search.Commands
{
    public class SearchSyncNoSqlUpdateCommand : Command
    {
        public Guid Id { get; private set; }
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public SearchSyncNoSqlUpdateCommand(Guid id, bool active, string name, string description)
        {
            Id = id;
            Active = active;
            Name = name;
            Description = description;
        }

        public override bool EhValido()
        {
            ValidationResult = new SearchSyncNoSqlUpdateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class SearchSyncNoSqlUpdateValidation : AbstractValidator<SearchSyncNoSqlUpdateCommand>
        {
            public SearchSyncNoSqlUpdateValidation()
            {
                RuleFor(c => c.Name)
                .MaximumLength(50)
                .WithMessage("Search  Max length 50 ");

                RuleFor(c => c.Description)
                .MaximumLength(100)
                .WithMessage("Search  Max length 100 ");

            }
        }
    }
}

