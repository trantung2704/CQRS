using Cqrs.Core;

namespace Cqrs.Infrastructure.Validator
{
    public class NullValidator<T> : IValidator<T>
    {
        public void Validate(T instance)
        {
            // do nothing
        }
    }
}