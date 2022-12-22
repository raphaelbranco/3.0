using Base30.Core.Communication.Mediator;
using Base30.SysAdmin.Application.Commands.Menu.Commands;
using Base30.SysAdmin.Application.Events.Menu;
using MediatR;

namespace Base30.SysAdmin.Application.Events
{
    public class SysAdminEventHandler :
            INotificationHandler<MenuCreatedEvent>,
            INotificationHandler<MenuFailedEvent>,
            INotificationHandler<MenuUpdatedEvent>
            
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
        public Task Handle(MenuFailedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(MenuUpdatedEvent notification, CancellationToken cancellationToken)
        {
            //Sync Query Base
            return Task.CompletedTask;
        }
    }
}
