using Cqrs.Core;

namespace CqrsConsoleApplication
{
    public class CustomerController
    {
        private readonly ICommandDispatcher commandDispatcher;

        public CustomerController(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public void MoveCustomer(MoveCustomerCommand command)
        {
            commandDispatcher.Dispatch(command);
        }
    }
}