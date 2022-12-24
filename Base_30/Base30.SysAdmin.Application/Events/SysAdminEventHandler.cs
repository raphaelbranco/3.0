using Base30.Core.Communication.Mediator;
using Base30.SysAdmin.Application.Commands.Menu.Commands;
using Base30.SysAdmin.Application.Commands.Search.Commands;
using Base30.SysAdmin.Application.Events.Menu;
using Base30.SysAdmin.Application.Events.Search;
using MediatR;

namespace Base30.SysAdmin.Application.Events
{
    public class SysAdminEventHandler :
            INotificationHandler<MenuCreatedEvent>,
            INotificationHandler<MenuFailedEvent>,
            INotificationHandler<MenuUpdatedEvent>,
            INotificationHandler<SearchCreatedEvent>,
            INotificationHandler<SearchUpdatedEvent>,
            INotificationHandler<SearchFailedEvent>


    {
        private readonly IMediatoRHandler _mediatoRHandler;

        public SysAdminEventHandler(IMediatoRHandler mediatoRHandler)
        {
            _mediatoRHandler = mediatoRHandler;
        }

        public async Task Handle(MenuCreatedEvent notification, CancellationToken cancellationToken)
        {
            //Tratar chamada dupla - problema do mediator
            
            //Sync Query Base
            MenuSyncNoSqlCreateCommand command = new MenuSyncNoSqlCreateCommand(notification.MenuId, notification.SysCustomer, notification.Name, notification.Description, notification.SourceMenu, notification.Order);
            await _mediatoRHandler.SendCommand(command);
        }        
        public Task Handle(MenuUpdatedEvent notification, CancellationToken cancellationToken)
        {
            //Sync Query Base
            return Task.CompletedTask;
        }
        public Task Handle(MenuFailedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task Handle(SearchCreatedEvent notification, CancellationToken cancellationToken)
        {
            SearchSyncNoSqlCreateCommand command = new SearchSyncNoSqlCreateCommand(notification.Id, DateTime.Now, DateTime.Now, notification.UserUpd, notification.SysCustomer, notification.Active, notification.Name, notification.Description);
            await _mediatoRHandler.SendCommand(command);
        }
        public async Task Handle(SearchUpdatedEvent notification, CancellationToken cancellationToken)
        {
            SearchSyncNoSqlUpdateCommand command = new SearchSyncNoSqlUpdateCommand(notification.Id, DateTime.Now, DateTime.Now, notification.UserUpd, notification.SysCustomer, notification.Active, notification.Name, notification.Description);
            await _mediatoRHandler.SendCommand(command);
        }
        public Task Handle(SearchFailedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
