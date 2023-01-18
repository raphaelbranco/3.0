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
            services.AddScoped<DomainNotificationHandler, DomainNotificationHandler>();
            
            //CoreBase
            services.AddScoped<ICoreController, CoreController>();

            //Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Mediator
            services.AddScoped<IMediatoRHandler, MediatRHandler>();


            //**** Repository ****
            services.AddScoped<IMenuRepository, MenuRepository>();

            //**** Queries ****
            services.AddScoped<IMenuQueries, MenuQueries>();


            //**** Commands **** /
            //Menu
            services.AddScoped<IMenuExecuteCommand, MenuExecuteCommand>();
            services.AddScoped<IRequestHandler<MenuCreateCommand, bool>,MenuCommandHandler>();
            services.AddScoped<IRequestHandler<MenuSyncNoSqlCreateCommand, bool>, MenuCommandHandler>();
            services.AddScoped<IRequestHandler<MenuUpdateCommand, bool>, MenuCommandHandler>();


            //**** Events **** /
            //Menu
            services.AddScoped<INotificationHandler<MenuCreatedEvent>, SysAdminEventHandler>();
            services.AddScoped<INotificationHandler<MenuUpdatedEvent>, SysAdminEventHandler>();
            services.AddScoped<INotificationHandler<MenuFailedEvent>, SysAdminEventHandler>();
        }
    }
}
