using Base30.Core.Messages;
using FluentValidation;

namespace Base30.SysAdmin.Application.Commands.Menu.Commands
{
    public class MenuUpdateCommand : Command
    {
        public Guid Id { get; private set; }
        public Guid? UserUpd { get; private set; }
        public Guid? SysCustomer { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public Guid? SourceMenu { get; private set; }
        public int? Order { get; private set; }

        public MenuUpdateCommand(Guid id, Guid? userUpd, string? name, string? description, Guid? sourceMenu, int? order)
        {
            Id = id;
            UserUpd = userUpd;
            Name = name;
            Description = description;
            SourceMenu = sourceMenu;
            Order = order;
        }

        public override bool EhValido()
        {
            ValidationResult = new MenuUpdateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class MenuUpdateValidation : AbstractValidator<MenuUpdateCommand>
        {
            public MenuUpdateValidation()
            {
                RuleFor(c => c.Name)
                    .NotEqual(string.Empty)
                    .WithMessage("Menu deve possuir um nome");
            }
        }
    }
}
