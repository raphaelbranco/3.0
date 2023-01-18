using Base30.Authentication.Domain;
using Base30.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MongoDB.Driver;
using Authentication.Data;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Base30.Core.DomainObjects;
using Base30.Core.Messages.CommonMessages.Notifications;
using Base30.Core.Communication.Mediator;
using MediatR;
using System.Collections.Generic;
using FluentResults;

namespace Base30.Authentication.Data.Repository
{
    public class AspNetUsersRepository : IAspNetUsersRepository
    {
        private readonly AuthenticationDBContext _context;
        private readonly AuthenticationNoSQLContext _contextNoSql;
        private UserManager<IdentityUser<Guid>> _userManager;
        private SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly IMediatoRHandler _mediatorHandler;


        public AspNetUsersRepository(AuthenticationDBContext context, IOptions<NoSqlSettings> settingsNoSql, UserManager<IdentityUser<Guid>> userManager, 
                                     IMediatoRHandler mediatorHandler, SignInManager<IdentityUser<Guid>> signInManager)
        {
            _context = context;
            _contextNoSql = new AuthenticationNoSQLContext(settingsNoSql);
            _userManager = userManager;
            _mediatorHandler = mediatorHandler;
            _signInManager = signInManager;
        }

        public IUnitOfWork UnitOfWork => _context;
        public IUnitOfWorkNoSql UnitOfWorkNoSql => _contextNoSql;

        public async Task Create(IdentityUser<Guid> aspnetusers)
        {
            IdentityUser<Guid> userIdentity = aspnetusers;

            IdentityResult resIdentity = _userManager.CreateAsync(aspnetusers, aspnetusers.PasswordHash).Result;

            if (resIdentity.Succeeded)
            {
                Task<string>? code = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
                return;
            }

            await _mediatorHandler.PublishNotification(new DomainNotification("Failed creating user", resIdentity.ToString()));
        }

        public async void SyncCreate(AspNetUsersNoSql aspnetusersNoSql)
        {
            await _contextNoSql.AspNetUsersNoSql.InsertOneAsync(aspnetusersNoSql);
        }
               
        public AspNetUsersNoSql? LoadByIdNoSql(Guid id)
        {
            Task<AspNetUsersNoSql>? aspnetusersNosqlTask = _contextNoSql.AspNetUsersNoSql?.Find(item => item.AspNetUsersId == id).FirstOrDefaultAsync();
            AspNetUsersNoSql? aspnetusersNosql = aspnetusersNosqlTask?.Result;

            return aspnetusersNosql;
        }

        public IdentityUser<Guid>? GetUserByEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }

        public Task<SignInResult> Login(IdentityUser<Guid> user, string password)
        {
            return _signInManager.PasswordSignInAsync(user, password, false, false);
        }

        public bool LogOut()
        {
            Task? resLogOut = _signInManager.SignOutAsync();

            if (resLogOut.IsCompletedSuccessfully) return true;

            return false;
        }

        public void Dispose()
        {
            _context?.Dispose();
            _contextNoSql?.Dispose();
            _userManager?.Dispose();            
        }

        
        
    }
}

