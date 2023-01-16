using Base30.Core.DomainObjects;
using System.Collections.Generic;

namespace Base30.Authentication.Domain
{
    public class AspNetUsers : Entity, IAggregateRoot
    {
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


        public AspNetUsers(DateTime insDt, DateTime updDt, Guid userUpd, Guid sysCustomer, string? username, string? normalizedusername, string? email, string? normalizedemail, bool emailconfirmed, string? passwordhash, string? securitystamp, string? concurrencystamp, string? phonenumber, bool phonenumberconfirmed, bool twofactorenabled, string? lockoutend, bool lockoutenabled, int accessfailedcount)
        {
           
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
            SysCustomer = sysCustomer;

            Validate();
        }
        public void Update(string? username, string? normalizedusername, string? email, string? normalizedemail, bool emailconfirmed, string? passwordhash, string? securitystamp, string? concurrencystamp, string? phonenumber, bool phonenumberconfirmed, bool twofactorenabled, string? lockoutend, bool lockoutenabled, int accessfailedcount)
        {
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
        public void Validate()
        {
            if (UserName != null) Validation.ValidateSize(UserName, 0, 256, "Field UserName max length 256 ");

            if (NormalizedUserName != null) Validation.ValidateSize(NormalizedUserName, 0, 256, "Field NormalizedUserName max length 256 ");

            if (Email != null) Validation.ValidateSize(Email, 0, 256, "Field Email max length 256 ");

            if (NormalizedEmail != null) Validation.ValidateSize(NormalizedEmail, 0, 256, "Field NormalizedEmail max length 256 ");

            Validation.ValidateIfNull(EmailConfirmed, "Field EmailConfirmed required ");

            Validation.ValidateIfNull(PhoneNumberConfirmed, "Field PhoneNumberConfirmed required ");

            Validation.ValidateIfNull(TwoFactorEnabled, "Field TwoFactorEnabled required ");

            Validation.ValidateIfNull(LockoutEnabled, "Field LockoutEnabled required ");

            Validation.ValidateIfNull(AccessFailedCount, "Field AccessFailedCount required ");

        }
    }
    public class AspNetUsersNoSql : Entity, IAggregateRoot
    {

        public Guid AspNetUsersId { get; private set; }
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
        public DateTime InsDt { get; private set; }
        public DateTime UpdDt { get; private set; }
        public Guid? UserUpd { get; private set; }
        public Guid? SysCustomer { get; private set; }

        public AspNetUsersNoSql(Guid aspnetusersid, DateTime insDt, DateTime updDt, Guid userUpd, Guid sysCustomer, string? username, string? normalizedusername, string? email, string? normalizedemail, bool emailconfirmed, string? passwordhash, string? securitystamp, string? concurrencystamp, string? phonenumber, bool phonenumberconfirmed, bool twofactorenabled, string? lockoutend, bool lockoutenabled, int accessfailedcount)
        {
            AspNetUsersId = aspnetusersid;
            InsDt = insDt;
            UpdDt = updDt;
            UserUpd = userUpd;
            SysCustomer = sysCustomer;
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
        public void UpdateNoSql(string? username, string? normalizedusername, string? email, string? normalizedemail, bool emailconfirmed, string? passwordhash, string? securitystamp, string? concurrencystamp, string? phonenumber, bool phonenumberconfirmed, bool twofactorenabled, string? lockoutend, bool lockoutenabled, int accessfailedcount)
        {
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
    }
}

