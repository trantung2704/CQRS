using Cqrs.Core;
using Cqrs.Core.Notification;

namespace Cqrs.Infrastructure.Notification
{
    public class OnBeforeHandle<TCommand> : INotification where TCommand : ICommand
    {
        public OnBeforeHandle(TCommand command)
        {
            Command = command;
        }

        public TCommand Command { get; private set; }

        public string Description
        {
            get { return string.Format("Before handle {0}", Command.GetType().Name); }
        }
    }
}