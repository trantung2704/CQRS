using System;
using System.Diagnostics;
using System.Linq;
using Cqrs.Core;
using Cqrs.Core.Notification;
using Cqrs.Infrastructure;
using Cqrs.Infrastructure.CommandHandler;
using Cqrs.Infrastructure.Notification;
using Cqrs.Infrastructure.Validator;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Extensions;

namespace CompositionRoot
{
    public static class DependencyRegistrationExtensions
    {
        public static Container RegisterDependencies(this Container container)
        {
            var infrastructureAssembly = typeof (CommandDispatcher).Assembly;

            container.RegisterSingle<ICustomerRepository, CustomerRepository>();
            container.RegisterManyForOpenGeneric(typeof (ICommandHandler<>), infrastructureAssembly);
            container.Register<ICommandDispatcher, CommandDispatcher>();

            // notification
            container.RegisterManyForOpenGeneric(typeof (ISubscriber<>), container.RegisterAll, infrastructureAssembly);
            container.Register<INotificationPublisher, NotificationPublisher>();
            container.RegisterDecorator(typeof (ICommandHandler<>), typeof (NotificationCommandHandlerDecorator<>));

            // asynchrony
            container.RegisterSingleDecorator(typeof (ICommandHandler<>),
                                              typeof (AsyncCommandHandlerDecorator<>),
                                              context => context.ImplementationType.Name.StartsWith("Async"));

            // validation
            container.RegisterOpenGeneric(typeof (IValidator<>), typeof (NullValidator<>));
            container.RegisterManyForOpenGeneric(typeof (IValidator<>), infrastructureAssembly);
            container.Register<IAppConfig, AppConfig>();
            container.RegisterDecorator(typeof (ICommandHandler<>), typeof (ValidationCommandHandlerDecorator<>));

            return container;
        }

        public static Container EnsureNoRegistrationConflict(this Container container)
        {
            container.Verify();

            var results = Analyzer.Analyze(container);

            Debug.Assert(!results.Any(), Environment.NewLine + string.Join(Environment.NewLine, results.Select(r => r.Description)));

            return container;
        }
    }
}