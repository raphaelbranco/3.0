using Base30.Core.Base.Controller;
using Base30.Core.Communication.Mediator;
using Base30.Core.Messages.CommonMessages.Notifications;
using Base30.SysAdmin.Application.Commands.Menu;
using Base30.SysAdmin.Application.Commands.Menu.Commands;
using Base30.SysAdmin.Application.Commands.Search.Commands;
using Base30.SysAdmin.Application.Commands.Search;
using Base30.SysAdmin.Application.Events;
using Base30.SysAdmin.Application.Events.Menu;
using Base30.SysAdmin.Application.Queries.Menu;
using Base30.SysAdmin.Data.Repository;
using Base30.SysAdmin.Domain;
using MediatR;
using Base30.SysAdmin.Application.Events.Search;
using Base30.SysAdmin.Application.Queries.Search;

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
            services.AddScoped<ISearchRepository, SearchRepository>();

            //**** Queries ****
            services.AddScoped<IMenuQueries, MenuQueries>();
            services.AddScoped<ISearchQueries, SearchQueries>();


            //**** Commands **** /
            //Menu
            services.AddScoped<IMenuExecuteCommand, MenuExecuteCommand>();
            services.AddScoped<IRequestHandler<MenuCreateCommand, bool>,MenuCommandHandler>();
            services.AddScoped<IRequestHandler<MenuSyncNoSqlCreateCommand, bool>, MenuCommandHandler>();
            services.AddScoped<IRequestHandler<MenuUpdateCommand, bool>, MenuCommandHandler>();
            //Search
            services.AddScoped<ISearchExecuteCommand, SearchExecuteCommand>();
            services.AddScoped<IRequestHandler<SearchCreateCommand, bool>, SearchCommandHandler>();
            services.AddScoped<IRequestHandler<SearchSyncNoSqlCreateCommand, bool>, SearchCommandHandler>();
            services.AddScoped<IRequestHandler<SearchUpdateCommand, bool>, SearchCommandHandler>();
            services.AddScoped<IRequestHandler<SearchSyncNoSqlUpdateCommand, bool>, SearchCommandHandler>();


            //**** Events **** /
            //Menu
            services.AddScoped<INotificationHandler<MenuCreatedEvent>, SysAdminEventHandler>();
            services.AddScoped<INotificationHandler<MenuUpdatedEvent>, SysAdminEventHandler>();
            services.AddScoped<INotificationHandler<MenuFailedEvent>, SysAdminEventHandler>();
            //Search
            services.AddScoped<INotificationHandler<SearchCreatedEvent>, SysAdminEventHandler>();
            services.AddScoped<INotificationHandler<SearchUpdatedEvent>, SysAdminEventHandler>();
            services.AddScoped<INotificationHandler<SearchFailedEvent>, SysAdminEventHandler>();

        }
    }
}
