using SaleOfAirTicket.Domain.ValueObjects.Base;
using SaleOfAirTicket.Domain.ValueObjects.Validators;



namespace SaleOfAirTicket.Domain.ValueObjects;

/// <summary>
/// Представляет собой тип номера телефона.
/// </summary>
/// <param name="phineNumber">Номер телефона.</param>
public class PhoneNumber(string phineNumber)
    :ValueObject<string>(new PhoneNumberValidator(),phineNumber);

