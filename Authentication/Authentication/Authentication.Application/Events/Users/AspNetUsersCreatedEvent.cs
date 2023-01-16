using Base30.Core.Messages;

namespace Base30.Authentication.Application.Events.AspNetUsers
{
    public class AspNetUsersCreatedEvent : Event
    {
        public Guid Id { get; private set; }
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
        public Guid SysCustomer { get; private set; }
        public Guid UserUpd { get; private set; }


        public AspNetUsersCreatedEvent(Guid id, Guid syscustomer, string? username, string? normalizedusername, string? email, string? normalizedemail, bool emailconfirmed, string? passwordhash, string? securitystamp, string? concurrencystamp, string? phonenumber, bool phonenumberconfirmed, bool twofactorenabled, string? lockoutend, bool lockoutenabled, int accessfailedcount)
        {
            AggregateId = id;
            Id = id;
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
            SysCustomer = syscustomer;
        }
    }
}

