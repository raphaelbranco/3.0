using Base30.Core.Messages;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

namespace Base30.Authentication.Application.Commands.AspNetUsers.Commands
{
    public class AspNetUsersCreateCommand : Command
    {
        public DateTime InsDt { get; private set; }
        public DateTime UpdDt { get; private set; }
        public Guid UserUpd { get; private set; }
        public Guid SysCustomer { get; private set; }
        public string? UserName { get; private set; }
        public string? NormalizedUserName { get; private set; }
        public string? Email { get; private set; }
        public string? NormalizedEmail { get; private set; }
        public bool EmailConfirmed { get; private set; }
        public string? PasswordHash { get; private set; }
        public string? SecurityStamp { get; private set; }
        public string? ConcurrencyStamp { get; private set; }
        public string? PhoneNumber { get; private set; }
        public bool PhoneNumberConfirmed { get; private set; }
        public bool TwoFactorEnabled { get; private set; }
        public string? LockoutEnd { get; private set; }
        public bool LockoutEnabled { get; private set; }
        public int AccessFailedCount { get; private set; }
        public AspNetUsersCreateCommand(DateTime insdt, DateTime upddt, Guid syscustomer, string? username, string? email, string? passwordhash, string? phonenumber)
        {
            InsDt = insdt;
            UpdDt = upddt;
            SysCustomer = syscustomer;
            UserName = username;
            Email = email;
            PasswordHash = passwordhash;
            PhoneNumber = phonenumber;
        }

        public override bool EhValido()
        {
            ValidationResult = new AspNetUsersCreateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AspNetUsersCreateValidation : AbstractValidator<AspNetUsersCreateCommand>
        {
            public AspNetUsersCreateValidation()
            {
                RuleFor(c => c.UserName)
                .MaximumLength(256)
                .WithMessage("AspNetUsers UserName  Max length 256 ");

                RuleFor(c => c.Email)
                .MaximumLength(256)
                .WithMessage("AspNetUsers Email  Max length 256 ");

                RuleFor(c => c.PasswordHash)
                .NotEmpty()
                .NotNull()
                .WithMessage("AspNetUsers Password can't be null");

            }
        }
    }
}

