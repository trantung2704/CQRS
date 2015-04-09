namespace Cqrs.Core
{
    public class MoveCustomerCommand : ICommand
    {
        public string CustomerId { get; set; }

        public string NewLocation { get; set; }
    }
}