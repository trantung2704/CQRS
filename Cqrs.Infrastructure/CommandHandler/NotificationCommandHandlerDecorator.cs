using Cqrs.Core;
using Cqrs.Core.Notification;
using Cqrs.Infrastructure.Notification;

namespace Cqrs.Infrastructure.CommandHandler
{
    public class NotificationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public NotificationCommandHandlerDecorator(INotificationPublisher notificationPublisher, ICommandHandler<TCommand> nextHandler)
        {
            this.notificationPublisher = notificationPublisher;
            this.nextHandler = nextHandler;
        }

        public void Execute(TCommand command)
        {
            notificationPublisher.Send(new OnBeforeHandle<TCommand>(command));

            nextHandler.Execute(command);

            notificationPublisher.Send(new OnAfterHandle<TCommand>(command));
        }

        private readonly INotificationPublisher notificationPublisher;
        private readonly ICommandHandler<TCommand> nextHandler;
    }
}