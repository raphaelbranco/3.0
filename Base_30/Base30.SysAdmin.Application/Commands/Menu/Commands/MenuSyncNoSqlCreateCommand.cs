using Base30.Core.Messages;
using FluentValidation;

namespace Base30.SysAdmin.Application.Commands.Menu.Commands
{
    public class MenuSyncNoSqlCreateCommand : Command
    {
        public Guid Id { get; private set; }
        public Guid? SysCustomer { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public Guid? SourceMenu { get; private set; }
        public int? Order { get; private set; }

        public MenuSyncNoSqlCreateCommand(Guid id, Guid? sysCustomer, string? name, string? description, Guid? sourceMenu, int? order)
        {
            Id = id;
            SysCustomer = sysCustomer;
            Name = name;
            Description = description;
            SourceMenu = sourceMenu;
            Order = order;
        }
        public override bool EhValido()
        {
            ValidationResult = new MenuSyncNoSqlCreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class MenuSyncNoSqlCreateCommandValidation : AbstractValidator<MenuSyncNoSqlCreateCommand>
        {
            public MenuSyncNoSqlCreateCommandValidation()
            {
                RuleFor(c => c.Name)
                    .NotEqual(string.Empty)
                    .WithMessage("Menu deve possuir um nome");
            }
        }
    }
}
