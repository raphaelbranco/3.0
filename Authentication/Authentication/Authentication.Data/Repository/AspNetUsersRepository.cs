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

namespace Base30.Authentication.Data.Repository
{
    public class AspNetUsersRepository : IAspNetUsersRepository
    {
        private readonly AuthenticationDBContext _context;
        private readonly AuthenticationNoSQLContext _contextNoSql;
        private UserManager<IdentityUser<Guid>> _userManager;
        private readonly IMediatoRHandler _mediatorHandler;


        public AspNetUsersRepository(AuthenticationDBContext context, IOptions<NoSqlSettings> settingsNoSql, UserManager<IdentityUser<Guid>> userManager, IMediatoRHandler mediatorHandler)
        {
            _context = context;
            _contextNoSql = new AuthenticationNoSQLContext(settingsNoSql);
            _userManager = userManager;
            _mediatorHandler = mediatorHandler;
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
                //Result resEnvioEmail = _emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de Ativação", usuarioIdentity.Id, code.Result);
                return;
            }

            await _mediatorHandler.PublishNotification(new DomainNotification("Falha ao cadastrar usuário", resIdentity.ToString()));
        }

        public async void SyncCreate(AspNetUsersNoSql aspnetusersNoSql)
        {
            await _contextNoSql.AspNetUsersNoSql.InsertOneAsync(aspnetusersNoSql);
        }

        public AspNetUsers LoadById(Guid id)
        {
            //AspNetUsers? aspnetusers = _context.AspNetUsers?.AsNoTracking().Where(m => m.AspNetUsersId == id).SingleOrDefault();
            return null;
        }

       
        public AspNetUsersNoSql? LoadByIdNoSql(Guid id)
        {
            Task<AspNetUsersNoSql>? aspnetusersNosqlTask = _contextNoSql.AspNetUsersNoSql?.Find(item => item.AspNetUsersId == id).FirstOrDefaultAsync();
            AspNetUsersNoSql? aspnetusersNosql = aspnetusersNosqlTask?.Result;

            return aspnetusersNosql;
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        
        
    }
}

