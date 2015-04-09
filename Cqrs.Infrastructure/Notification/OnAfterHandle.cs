using Cqrs.Core;
using Cqrs.Core.Notification;

namespace Cqrs.Infrastructure.Notification
{
    public class OnAfterHandle<TCommand> : INotification where TCommand : ICommand
    {
        public OnAfterHandle(TCommand command)
        {
            Command = command;
        }

        public TCommand Command { get; private set; }

        public string Description
        {
            get { return string.Format("After handle {0}", Command.GetType().Name); }
        }
    }
}