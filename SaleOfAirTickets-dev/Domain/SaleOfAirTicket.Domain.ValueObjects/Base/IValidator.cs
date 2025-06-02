
namespace SaleOfAirTicket.Domain.ValueObjects.Base
{
    public interface IValidator
    {
        /// <summary>
        /// Определяет метод, который реализует проверку объекта.
        /// </summary>
        /// <typeparam name="T">Тип объекта проверки.</typeparam>
        public interface IValidator<T>
        {
            /// <summary>
            /// Проверяет данные.
            /// </summary>
            /// <param name="value">Проверенное значение</param>
            void Validate(T value);
        }
    }
}
