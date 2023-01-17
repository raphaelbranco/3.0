using FluentValidation;

namespace Authentication.Application.Commands.Users.Command
{
    public class LoginCommand : Base30.Core.Messages.Command
    {
        public string? Email { get; private set; }
        public string? PasswordHash { get; private set; }

        public LoginCommand(string? email, string? passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;    
        }
        public override bool EhValido()
        {
            ValidationResult = new LoginValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class LoginValidation : AbstractValidator<LoginCommand>
        {
            public LoginValidation()
            {
                RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email can't be null");

                RuleFor(c => c.PasswordHash)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password can't be null");

            }
        }
    }
}
