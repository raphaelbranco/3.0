using Base30.Core.Messages;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Base30.SysAdmin.Application.Commands.Menu.Commands
{
    public class MenuCreateCommand : Command
    {
        public Guid? UserUpd { get; private set; }
        public Guid? SysCustomer { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public Guid? SourceMenu { get; private set; }
        public int? Order { get; private set; }

        public MenuCreateCommand(Guid? userUpd, Guid? sysCustomer, string? name, string? description, Guid? sourceMenu, int? order)
        {
            UserUpd = userUpd;
            SysCustomer = sysCustomer;
            Name = name;
            Description = description;
            SourceMenu = sourceMenu;
            Order = order;
        }

        public override bool EhValido()
        {
            ValidationResult = new MenuCreateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class MenuCreateValidation : AbstractValidator<MenuCreateCommand>
        {
            public MenuCreateValidation()
            {
                RuleFor(c => c.Name)
                    .NotEqual(string.Empty)
                    .WithMessage("Menu deve possuir um nome");
            }
        }
    }
}
