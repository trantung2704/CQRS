using Cqrs.Core;
using SimpleInjector;

namespace Cqrs.Infrastructure
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public CommandDispatcher(Container container)
        {
            this.container = container;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = container.GetInstance<ICommandHandler<TCommand>>();

            handler.Execute(command);
        }

        private readonly Container container;
    }
}