using Base30.Core.Messages;
using Base30.Core.Messages.CommonMessages.Notifications;
using MediatR;

namespace Base30.Core.Communication.Mediator
{
    public class MediatRHandler : IMediatoRHandler
    {
        private readonly IMediator _mediator;

        public MediatRHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task SendCommand<T>(T comando) where T : Command
        {
            await _mediator.Send(comando);
        }

        public async Task PublishNotification<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }
    }

}
