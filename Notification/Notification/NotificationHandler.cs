using Base30.Core.Messages.IntegrationEvents;
using MassTransit;
using Notification.Service;

namespace Notification
{
    public class NotificationHandler : IConsumer<SendEmailEvent>
    {

        private readonly ISendMailService _sendMailService;

        public NotificationHandler(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }

        public Task Consume(ConsumeContext<SendEmailEvent> context)
        {
            if (_sendMailService.SendAsync(context.Message).Result == false)
            {
                //launch failed event
            } 
            
            return Task.CompletedTask;
        }
    }
}
