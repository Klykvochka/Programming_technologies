using SaleOfAirTicket.Domain.ValueObjects.Base;
using SaleOfAirTicket.Domain.ValueObjects.Validators;
namespace SaleOfAirTicket.Domain.ValueObjects
{

    /// <summary>
    /// Представляет собой тип цены.
    /// </summary>
    /// <param name="priceInRub">Цена в рублях.</param>
    public class Price(decimal priceInRub) : ValueObject<decimal>(
            new PriceValidator(), Math.Round(priceInRub, 2, MidpointRounding.AwayFromZero))
    {
        public static Price operator +(Price m1, Price m2)
            => new(m1.Value + m2.Value);

        public static Price operator -(Price m1, Price m2)
            => new(m1.Value - m2.Value);

        public static bool operator >(Price m1, Price m2)
            => m1.Value > m2.Value;

        public static bool operator <(Price m1, Price m2)
            => m1.Value < m2.Value;

        public static bool operator >=(Price m1, Price m2)
            => m1.Value >= m2.Value;

        public static bool operator <=(Price m1, Price m2)
            => m1.Value <= m2.Value;

    }
}
