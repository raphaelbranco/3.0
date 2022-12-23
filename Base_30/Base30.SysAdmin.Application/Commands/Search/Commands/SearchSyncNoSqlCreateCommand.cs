using Base30.Core.Messages;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Base30.SysAdmin.Application.Commands.Search.Commands
{
    public class SearchSyncNoSqlCreateCommand : Command
    {
        public Guid Id { get; private set; }
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public SearchSyncNoSqlCreateCommand(Guid id, bool active, string name, string description)
        {
            Id = id;
            Active = active;
            Name = name;
            Description = description;
        }

        public override bool EhValido()
        {
            ValidationResult = new SearchSyncNoSqlCreateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class SearchSyncNoSqlCreateValidation : AbstractValidator<SearchSyncNoSqlCreateCommand>
        {
            public SearchSyncNoSqlCreateValidation()
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

