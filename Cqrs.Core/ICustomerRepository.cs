using System.Collections.Generic;

namespace Cqrs.Core
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Get();

        void Update(Customer customer);

        void Dump();
    }
}