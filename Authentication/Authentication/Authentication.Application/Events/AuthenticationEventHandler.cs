using Base30.Core.Communication.Mediator;
using Base30.Authentication.Application.Commands.AspNetUsers.Commands;
using Base30.Authentication.Application.Events.AspNetUsers;
using MediatR;


namespace Authentication.Application.Events
{
    public class AuthenticationEventHandler:
        INotificationHandler<AspNetUsersCreatedEvent>,
        INotificationHandler<AspNetUsersFailedEvent>
    {
        private readonly IMediatoRHandler _mediatoRHandler;

        public AuthenticationEventHandler(IMediatoRHandler mediatoRHandler)
        {
            _mediatoRHandler = mediatoRHandler;
        }

        public async Task Handle(AspNetUsersCreatedEvent notification, CancellationToken cancellationToken)
        {
            AspNetUsersSyncNoSqlCreateCommand command = new AspNetUsersSyncNoSqlCreateCommand(notification.Id, DateTime.Now, DateTime.Now, notification.UserUpd, notification.SysCustomer, notification.UserName, notification.NormalizedUserName, notification.Email, notification.NormalizedEmail, notification.EmailConfirmed, notification.PasswordHash, notification.SecurityStamp, notification.ConcurrencyStamp, notification.PhoneNumber, notification.PhoneNumberConfirmed, notification.TwoFactorEnabled, notification.LockoutEnd, notification.LockoutEnabled, notification.AccessFailedCount);
            await _mediatoRHandler.SendCommand(command);
        }
        public Task Handle(AspNetUsersFailedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
