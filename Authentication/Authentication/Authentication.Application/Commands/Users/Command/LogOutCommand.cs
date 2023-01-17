using FluentValidation;

namespace Authentication.Application.Commands.Users.Command
{
    public class LogOutCommand : Base30.Core.Messages.Command
    {
        public string? Email { get; private set; }

        public LogOutCommand(string? email)
        {
            Email = email;
        }
        public override bool EhValido()
        {
            ValidationResult = new LogOutValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class LogOutValidation : AbstractValidator<LogOutCommand>
        {
            public LogOutValidation()
            {
                RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email can't be null");

               
            }
        }
    }
}
