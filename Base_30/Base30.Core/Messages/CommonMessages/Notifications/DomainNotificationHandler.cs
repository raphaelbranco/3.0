﻿using MediatR;

namespace Base30.Core.Messages.CommonMessages.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotification()
        {
            return _notifications;
        }

        public virtual bool HasNotification()
        {
            return GetNotification().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}