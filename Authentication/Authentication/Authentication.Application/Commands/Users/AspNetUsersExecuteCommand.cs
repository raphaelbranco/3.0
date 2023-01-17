using Authentication.Application.Commands.Users.Command;
using AutoMapper;
using Azure.Core;
using Base30.Authentication.Application.Commands.AspNetUsers.Commands;
using Base30.Authentication.Application.Events.AspNetUsers;
using Base30.Authentication.Application.Queries.AspNetUsers;
using Base30.Authentication.Data.Repository;
using Base30.Authentication.Domain;
using Base30.Core.Communication.Mediator;
using Base30.Core.Messages.CommonMessages.Notifications;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Base30.Authentication.Application.Commands.AspNetUsers
{
    public class AspNetUsersExecuteCommand : IAspNetUsersExecuteCommand
    {
        private readonly IAspNetUsersRepository _aspnetusersRepository;
        private readonly IMapper _mapper;
        private readonly IMediatoRHandler _mediatoRHandler;

        public AspNetUsersExecuteCommand(IAspNetUsersRepository aspnetusersRepository, IMediatoRHandler mediatoRHandler)
        {
            _aspnetusersRepository = aspnetusersRepository;
            _mediatoRHandler = mediatoRHandler;
        }

        public async Task<bool> Create(AspNetUsersCreateCommand message, CancellationToken cancellationToken)
        {

            Domain.AspNetUsers aspnetusers =
                                            new(
                                                message.InsDt,
                                                message.UpdDt,
                                                message.UserUpd,
                                                message.SysCustomer,
                                                message.UserName,
                                                message.NormalizedUserName,
                                                message.Email,
                                                message.NormalizedEmail,
                                                message.EmailConfirmed,
                                                message.PasswordHash,
                                                message.SecurityStamp,
                                                message.ConcurrencyStamp,
                                                message.PhoneNumber,
                                                message.PhoneNumberConfirmed,
                                                message.TwoFactorEnabled,
                                                message.LockoutEnd,
                                                message.LockoutEnabled,
                                                message.AccessFailedCount
        );

            IdentityUser<Guid> userDb = new IdentityUser<Guid> { UserName = aspnetusers.UserName, Email = aspnetusers.Email, PhoneNumber = aspnetusers.PhoneNumber, PasswordHash = aspnetusers.PasswordHash};

            await _aspnetusersRepository.Create(userDb);

            if (userDb.Id == Guid.Empty) return false;

            AspNetUsersCreatedEvent newAspNetUsersEvent = new(userDb.Id, aspnetusers.SysCustomer, aspnetusers.UserName, aspnetusers.NormalizedUserName, aspnetusers.Email, aspnetusers.NormalizedEmail, aspnetusers.EmailConfirmed, aspnetusers.PasswordHash, aspnetusers.SecurityStamp, aspnetusers.ConcurrencyStamp, aspnetusers.PhoneNumber, aspnetusers.PhoneNumberConfirmed, aspnetusers.TwoFactorEnabled, aspnetusers.LockoutEnd, aspnetusers.LockoutEnabled, aspnetusers.AccessFailedCount);
            aspnetusers.AddEvent(newAspNetUsersEvent);

            await _mediatoRHandler.PublishEvent(newAspNetUsersEvent);

            return true;
        }

       
        public Task<bool> SyncNoSqlCreate(AspNetUsersSyncNoSqlCreateCommand message, CancellationToken cancellationToken)
        {
            AspNetUsersNoSql aspnetusers = new(message.Id, message.InsDt, message.UpdDt, message.UserUpd, message.SysCustomer, message.UserName, message.NormalizedUserName, message.Email, message.NormalizedEmail, message.EmailConfirmed, message.PasswordHash, message.SecurityStamp, message.ConcurrencyStamp, message.PhoneNumber, message.PhoneNumberConfirmed, message.TwoFactorEnabled, message.LockoutEnd, message.LockoutEnabled, message.AccessFailedCount);
            _aspnetusersRepository.SyncCreate(aspnetusers);

            return Task.FromResult(true);
        }
       
        private async Task<bool> CommitCommand(Domain.AspNetUsers aspnetusers)
        {
            bool sucess = await _aspnetusersRepository.UnitOfWork.Commit() == false;
            if (!sucess)
            {
                AspNetUsersFailedEvent newAspNetUsersFailedEvent = new("Error creating AspNetUsers on DB");
                aspnetusers.AddEvent(newAspNetUsersFailedEvent);
            }

            return sucess;
        }

        public async Task<bool> Login(LoginCommand message, CancellationToken cancellationToken)
        {
            IdentityUser<Guid>? user = _aspnetusersRepository.GetUserByEmail(message.Email!);

            //Can't find user
            if (user == null)
            {
                await _mediatoRHandler.PublishNotification(new DomainNotification("Login failed", "Login failed"));
                return false;
            }

            SignInResult resLogin = await _aspnetusersRepository.Login(user!, message.PasswordHash!);

            //Wrong password
            if (!resLogin.Succeeded)
            {
                await _mediatoRHandler.PublishNotification(new DomainNotification("Login failed", "Login failed"));                
                return false;
            }

            return true;
        }

        public async Task<bool> LogOut(LogOutCommand message, CancellationToken cancellationToken)
        {
            if (!_aspnetusersRepository.LogOut()) 
            {
                await _mediatoRHandler.PublishNotification(new DomainNotification("LogOut failed", "LogOut failed"));
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            _aspnetusersRepository?.Dispose();
        }

    }
}

