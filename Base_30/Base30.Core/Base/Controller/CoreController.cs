using Base30.Core.Communication.Mediator;
using Base30.Core.Messages.CommonMessages.Notifications;
using MediatR;

namespace Base30.Core.Base.Controller
{
    public class CoreController: ICoreController
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatoRHandler _mediatorHandler;

        public CoreController(INotificationHandler<DomainNotification> notifications,
                                 IMediatoRHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }

        public bool OperationIsValid()
        {
            return !_notifications.HasNotification();
        }

        public IEnumerable<string> GetErrorMessage()
        {
            return _notifications.GetNotification().Select(c => c.Value).ToList();
        }

        public void NotifyError(string codigo, string mensagem)
        {
            _mediatorHandler.PublishNotification(new DomainNotification(codigo, mensagem));
        }

        public void Dispose()
        {
            _notifications?.Dispose();            
        }
    }
}
