using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cqrs.Core;

namespace Cqrs.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>
                        {
                            new Customer {Id = "1", Name = "Son", Location = "Hanoi"},
                            new Customer {Id = "2", Name = "Long", Location = "Hanoi"},
                        };
        }

        public IEnumerable<Customer> Get()
        {
            return new ReadOnlyCollection<Customer>(customers);
        }

        public void Update(Customer customer)
        {
            var originalCustomer = customers.Single(c => c.Id == customer.Id);

            originalCustomer.Name = customer.Name;
            originalCustomer.Location = customer.Location;
        }

        public void Dump()
        {
            var dumpedCustomers = customers.Select(c => c.ToString());

            Console.WriteLine(string.Join("\n", dumpedCustomers));
        }
    }
}