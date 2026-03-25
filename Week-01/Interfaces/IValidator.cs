namespace FirstBank.Core.Domain.Interfaces
{
    /// <summary>
    /// Defines a generic validator interface.
    /// </summary>
    public interface IValidator<T>
    {
        Results.ValidationResult Validate(T item);
    }
}