using SaleOfAirTicket.Domain.ValueObjects.Base;
using SaleOfAirTicket.Domain.ValueObjects.Validators;

namespace SaleOfAirTicket.Domain.ValueObjects
{
    /// <summary>
    /// Класс SeatNumber представляет номер места как объект значения.
    /// </summary>
    public class SeatNumber(int seatNumber) : ValueObject<int>(new SeatNumberValidator(), seatNumber)
    {
        public static bool operator !=(SeatNumber s1, SeatNumber s2)
            => s1.Value != s2.Value;

        public static bool operator ==(SeatNumber s1, SeatNumber s2)
            => s1.Value == s2.Value;

        /// <summary>
        /// Переопределение метода Equals для сравнения объектов SeatNumber.
        /// </summary>
        /// <param name="obj">Объект, который нужно сравнить с текущим.</param>
        public override bool Equals(object? obj)
        {

            if (obj is null || !(obj is SeatNumber other))
            {
                return false;
            }

            return Value == other.Value;
        }

        /// <summary>
        /// Переопределение метода GetHashCode для получения хеш-кода объекта SeatNumber.
        /// </summary>
        public override int GetHashCode() => Value.GetHashCode();
    }
}
