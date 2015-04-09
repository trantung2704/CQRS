using System;
using System.Threading;
using System.Threading.Tasks;
using Cqrs.Core;

namespace Cqrs.Infrastructure.CommandHandler
{
    public class AsyncCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public AsyncCommandHandlerDecorator(Func<ICommandHandler<TCommand>> commandHandlerFactory)
        {
            this.commandHandlerFactory = commandHandlerFactory;
        }

        public void Execute(TCommand command)
        {
            Console.WriteLine("Main thread: {0}", Thread.CurrentThread.ManagedThreadId);

            Task.Run(() =>
                     {
                         Console.WriteLine("Background thread: {0}", Thread.CurrentThread.ManagedThreadId);

                         var commandHandler = commandHandlerFactory.Invoke();

                         commandHandler.Execute(command);
                     });
        }

        private readonly Func<ICommandHandler<TCommand>> commandHandlerFactory;
    }
}