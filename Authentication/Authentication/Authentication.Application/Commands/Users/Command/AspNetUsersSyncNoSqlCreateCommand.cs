using Base30.Core.Messages;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

namespace Base30.Authentication.Application.Commands.AspNetUsers.Commands
{
    public class AspNetUsersSyncNoSqlCreateCommand : Command
    {
        public Guid Id { get; private set; }        
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
        
        public AspNetUsersSyncNoSqlCreateCommand(Guid id, DateTime insdt, DateTime upddt, Guid userupd, Guid syscustomer, string? username, string? normalizedusername, string? email, string? normalizedemail, bool emailconfirmed, string? passwordhash, string? securitystamp, string? concurrencystamp, string? phonenumber, bool phonenumberconfirmed, bool twofactorenabled, string? lockoutend, bool lockoutenabled, int accessfailedcount)
        {
            Id = id;
            InsDt = insdt;
            UpdDt = upddt;
            UserUpd = userupd;
            SysCustomer = syscustomer;
            UserName = username;
            NormalizedUserName = normalizedusername;
            Email = email;
            NormalizedEmail = normalizedemail;
            EmailConfirmed = emailconfirmed;
            PasswordHash = passwordhash;
            SecurityStamp = securitystamp;
            ConcurrencyStamp = concurrencystamp;
            PhoneNumber = phonenumber;
            PhoneNumberConfirmed = phonenumberconfirmed;
            TwoFactorEnabled = twofactorenabled;
            LockoutEnd = lockoutend;
            LockoutEnabled = lockoutenabled;
            AccessFailedCount = accessfailedcount;
        }

        public override bool EhValido()
        {
            ValidationResult = new AspNetUsersSyncNoSqlCreateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AspNetUsersSyncNoSqlCreateValidation : AbstractValidator<AspNetUsersSyncNoSqlCreateCommand>
        {
            public AspNetUsersSyncNoSqlCreateValidation()
            {
                RuleFor(c => c.UserName)
                .MaximumLength(256)
                .WithMessage("AspNetUsers UserName  Max length 256 ");

                RuleFor(c => c.NormalizedUserName)
                .MaximumLength(256)
                .WithMessage("AspNetUsers NormalizedUserName  Max length 256 ");

                RuleFor(c => c.Email)
                .MaximumLength(256)
                .WithMessage("AspNetUsers Email  Max length 256 ");

                RuleFor(c => c.NormalizedEmail)
                .MaximumLength(256)
                .WithMessage("AspNetUsers NormalizedEmail  Max length 256 ");

                
            }
        }
    }
}

