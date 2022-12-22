using Base30.Core.Base.Controller;
using Base30.Core.Communication.Mediator;
using Base30.Core.Messages.CommonMessages.Notifications;
using Base30.SysAdmin.Application.Commands.Menu;
using Base30.SysAdmin.Application.Commands.Menu.Commands;
using Base30.SysAdmin.Application.Events;
using Base30.SysAdmin.Application.Events.Menu;
using Base30.SysAdmin.Application.Queries.Menu;
using Base30.SysAdmin.Data.Repository;
using Base30.SysAdmin.Domain;
using MediatR;

namespace Base30.SysAdmin.Application.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped<DomainNotificationHandler, DomainNotificationHandler>();


            //Mediator
            services.AddScoped<IMediatoRHandler, MediatRHandler>();

            //***
            //Adiciona o serviço no container
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuExecuteCommand, MenuExecuteCommand>();
            services.AddScoped<IMenuQueries, MenuQueries>();

            //aki
            //services.AddScoped<MenuRepositoryNoSQL, MenuRepositoryNoSQL>();


            //CoreBase
            services.AddScoped<ICoreController, CoreController>();

            //Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Commands
            services.AddScoped<IRequestHandler<MenuCreateCommand, bool>,MenuCommandHandler>();
            services.AddScoped<IRequestHandler<MenuSyncNoSqlCreateCommand, bool>, MenuCommandHandler>();

            services.AddScoped<IRequestHandler<MenuUpdateCommand, bool>, MenuCommandHandler>();

            //Events
            services.AddScoped<INotificationHandler<MenuCreatedEvent>, SysAdminEventHandler>();
            services.AddScoped<INotificationHandler<MenuUpdatedEvent>, SysAdminEventHandler>();
            services.AddScoped<INotificationHandler<MenuFailedEvent>, SysAdminEventHandler>();

        }
    }
}
