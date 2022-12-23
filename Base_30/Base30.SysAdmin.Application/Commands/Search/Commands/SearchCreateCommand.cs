using Base30.Core.Messages;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Base30.SysAdmin.Application.Commands.Search.Commands
{
    public class SearchCreateCommand : Command
    {
        public bool? Active { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public SearchCreateCommand(bool active, string name, string description)
        {

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
                .WithMessage("Search  Max length 50 ");

                RuleFor(c => c.Description)
                .MaximumLength(100)
                .WithMessage("Search  Max length 100 ");

            }
        }
    }
}

