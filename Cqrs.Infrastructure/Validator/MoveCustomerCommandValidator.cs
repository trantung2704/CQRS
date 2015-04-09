using System.ComponentModel.DataAnnotations;
using Cqrs.Core;

namespace Cqrs.Infrastructure.Validator
{
    public class MoveCustomerCommandValidator : IValidator<MoveCustomerCommand>
    {
        public void Validate(MoveCustomerCommand instance)
        {
            if (instance.NewLocation.Length < 3)
            {
                throw new ValidationException("New location length should be at least 3 characters.");
            }
        }
    }
}