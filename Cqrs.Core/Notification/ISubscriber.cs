namespace Cqrs.Core.Notification
{
    public interface ISubscriber<in TNotification> where TNotification : INotification
    {
        void Handle(TNotification e);
    }
}