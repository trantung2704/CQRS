using Cqrs.Core;

namespace Cqrs.Infrastructure.CommandHandler
{
    public class ValidationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public ValidationCommandHandlerDecorator(IValidator<TCommand> validator, ICommandHandler<TCommand> nextHandler)
        {
            this.validator = validator;
            this.nextHandler = nextHandler;
        }

        public void Execute(TCommand command)
        {
            validator.Validate(command);

            nextHandler.Execute(command);
        }

        private readonly IValidator<TCommand> validator;
        private readonly ICommandHandler<TCommand> nextHandler;
    }
}