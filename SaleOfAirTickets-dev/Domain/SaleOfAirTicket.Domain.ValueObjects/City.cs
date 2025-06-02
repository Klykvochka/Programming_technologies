using SaleOfAirTicket.Domain.ValueObjects.Base;
using SaleOfAirTicket.Domain.ValueObjects.Validators;


namespace SaleOfAirTicket.Domain.ValueObjects;

/// <summary>
/// Представляет собой тип Города.
/// </summary>
/// <param name="city">Город.</param>
public class City(string city) 
    : ValueObject<string>(new CityValidator(), city);

