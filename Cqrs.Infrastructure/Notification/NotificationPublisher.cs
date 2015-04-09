using Brick.MiscUtil.Extensions;
using Cqrs.Core.Notification;
using SimpleInjector;

namespace Cqrs.Infrastructure.Notification
{
    public class NotificationPublisher : INotificationPublisher
    {
        public NotificationPublisher(Container container)
        {
            this.container = container;
        }

        public void Send<TNotification>(TNotification notification) where TNotification : INotification
        {
            var subscribers = container.GetAllInstances<ISubscriber<TNotification>>();

            subscribers.ForEach(subscriber => subscriber.Handle(notification));
        }

        private readonly Container container;
    }
}