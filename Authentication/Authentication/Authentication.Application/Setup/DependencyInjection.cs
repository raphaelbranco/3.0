using Base30.Authentication.Application.Commands.AspNetUsers.Commands;
using Base30.Authentication.Application.Commands.AspNetUsers;
using Base30.Authentication.Application.Events.AspNetUsers;
using Base30.Authentication.Application.Queries.AspNetUsers;
using Base30.Authentication.Data.Repository;
using Base30.Authentication.Domain;
using MediatR;
using Base30.Core.Messages.CommonMessages.Notifications;
using Base30.Core.Base.Controller;
using Authentication.Application.Events;
using Base30.Core.Communication.Mediator;
using Microsoft.AspNetCore.Identity;
using Authentication.Application.Commands.Users.Command;

namespace Authentication.Application.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DomainNotificationHandler, DomainNotificationHandler>();

            //CoreBase
            services.AddScoped<ICoreController, CoreController>();

            //Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Mediator
            services.AddScoped<IMediatoRHandler, MediatRHandler>();
                        

            //**** Repository ****
            services.AddScoped<IAspNetUsersRepository, AspNetUsersRepository>();

            //**** Queries ****
            services.AddScoped<IAspNetUsersQueries, AspNetUsersQueries>();


            //****Commands * *** /
            //AspNetUsers
            services.AddScoped<IAspNetUsersExecuteCommand, AspNetUsersExecuteCommand>();
            services.AddScoped<IRequestHandler<AspNetUsersCreateCommand, bool>, AspNetUsersCommandHandler>();
            services.AddScoped<IRequestHandler<AspNetUsersSyncNoSqlCreateCommand, bool>, AspNetUsersCommandHandler>();
            services.AddScoped<IRequestHandler<LoginCommand, bool>, AspNetUsersCommandHandler>();
            services.AddScoped<IRequestHandler<LogOutCommand, bool>, AspNetUsersCommandHandler>();

            //****Events * *** /
            //AspNetUsers
            services.AddScoped<INotificationHandler<AspNetUsersCreatedEvent>, AuthenticationEventHandler>();
            services.AddScoped<INotificationHandler<AspNetUsersFailedEvent>, AuthenticationEventHandler>();
        }
    }

}
