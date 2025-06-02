using SaleOfAirTicket.Domain.ValueObjects.Base;
using SaleOfAirTicket.Domain.ValueObjects.Validators;


namespace SaleOfAirTicket.Domain.ValueObjects;

/// <summary>
/// Представляет собой тип Количества мест.
/// </summary>
/// <param name="countSeats">количество мест.</param>
public class CountSeats(int countSeats)
    : ValueObject<int>(new CountSeatsValidator(), countSeats)
{
    public static CountSeats operator +(CountSeats m1, CountSeats m2)
    => new(m1.Value + m2.Value);

    public static CountSeats operator -(CountSeats m1, CountSeats m2)
        => new(m1.Value - m2.Value);

    public static bool operator >(CountSeats m1, CountSeats m2)
        => m1.Value > m2.Value;

    public static bool operator <(CountSeats m1, CountSeats m2)
        => m1.Value < m2.Value;

    public static bool operator >=(CountSeats m1, CountSeats m2)
        => m1.Value >= m2.Value;

    public static bool operator <=(CountSeats m1, CountSeats m2)
        => m1.Value <= m2.Value;

    public static bool operator !=(CountSeats s1, CountSeats s2)
            => s1.Value != s2.Value;

    public static bool operator ==(CountSeats s1, CountSeats s2)
        => s1.Value == s2.Value;

    /// <summary>
    /// Переопределение метода Equals для сравнения объектов CountSeats.
    /// </summary>
    /// <param name="obj">Объект, который нужно сравнить с текущим.</param>
    public override bool Equals(object? obj)
    {

        if (obj is null || !(obj is CountSeats other))
        {
            return false;
        }

        return Value == other.Value;
    }

    /// <summary>
    /// Переопределение метода GetHashCode для получения хеш-кода объекта CountSeats.
    /// </summary>
    public override int GetHashCode() => Value.GetHashCode();
}