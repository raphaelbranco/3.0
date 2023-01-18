using Base30.Core.Messages.IntegrationEvents;

namespace Notification.Service
{
    public interface ISendMailService
    {
        Task<bool> SendAsync(SendEmailEvent mailEvent);
    }
}
