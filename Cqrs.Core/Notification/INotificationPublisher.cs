namespace Cqrs.Core.Notification
{
    public interface INotificationPublisher
    {
        void Send<TNotification>(TNotification notification) where TNotification : INotification;
    }
}