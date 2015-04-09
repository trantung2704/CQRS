namespace Cqrs.Core
{
    public interface IValidator<T>
    {
        void Validate(T instance);
    }
}