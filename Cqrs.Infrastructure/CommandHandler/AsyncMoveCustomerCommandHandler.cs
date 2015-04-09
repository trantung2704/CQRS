using System.Linq;
using Cqrs.Core;

namespace Cqrs.Infrastructure.CommandHandler
{
    public class AsyncMoveCustomerCommandHandler : ICommandHandler<MoveCustomerCommand>
    {
        public AsyncMoveCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Execute(MoveCustomerCommand command)
        {
            var originalCustomer = customerRepository.Get().Single(c => c.Id == command.CustomerId);

            originalCustomer.Location = command.NewLocation;

            customerRepository.Update(originalCustomer);
        }

        private readonly ICustomerRepository customerRepository;
    }
}