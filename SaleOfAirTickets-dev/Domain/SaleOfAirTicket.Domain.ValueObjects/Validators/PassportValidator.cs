using SaleOfAirTicket.Domain.ValueObjects.Exeptions;
using static SaleOfAirTicket.Domain.ValueObjects.Base.IValidator;

namespace SaleOfAirTicket.Domain.ValueObjects.Validators;

/// <summary>
/// Определяет метод, который реализует проверку строки.
/// </summary>
public class PassportValidator : IValidator<string>
{
    /// <summary>
    /// Максимальная длина.
    /// </summary>
    public static int MAX_LENGTH => 9;
    /// <summary>
    /// Минимальная длина.
    /// </summary>
    public static int MIN_LENGTH => 9;

    /// <summary>
    /// Проверяет строку, чтобы убедиться, что она не является нулевой, пустой или не состоит только из пробелов.
    /// </summary>
    /// <param name="value">Строка, содержащая данные.</param>
    /// <exception cref="ArgumentNullOrWhiteSpaceException"></exception>
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(ExceptionMessages.PASSPORT_NOT_NULL_OR_WHITE_SPACE, nameof(value));
        if (value.Length < MAX_LENGTH)
            throw new PassportLongValueException(value, MAX_LENGTH);
        if (value.Length < MIN_LENGTH)
            throw new PassportShortValueException(value, MIN_LENGTH);
    }
}
