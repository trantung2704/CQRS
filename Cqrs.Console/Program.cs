using System;
using CompositionRoot;
using Cqrs.Core;
using SimpleInjector;

namespace CqrsConsoleApplication
{
    internal static class Program
    {
        private static void Main()
        {
            Program.BuildContainer()
                   .EnsureNoRegistrationConflict()
                   .Run();

            Console.ReadLine();
        }

        private static Container BuildContainer()
        {
            var container = new Container();

            return container.RegisterDependencies();
        }

        private static void Run(this Container container)
        {
            var controller = container.GetInstance<CustomerController>();
            var repository = container.GetInstance<ICustomerRepository>();

            repository.Dump();

            controller.MoveCustomer(new MoveCustomerCommand
                                    {
                                        CustomerId = "1",
                                        NewLocation = "Ohio"
                                    });

            repository.Dump();
        }
    }
}