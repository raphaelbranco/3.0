using Base30.Core.Messages;
using Base30.Core.Messages.CommonMessages.Notifications;

namespace Base30.Core.Communication.Mediator
{
    public interface IMediatoRHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;

        Task SendCommand<T>(T command) where T : Command;

        Task PublishNotification<T>(T notificacao) where T : DomainNotification;
    }
}
