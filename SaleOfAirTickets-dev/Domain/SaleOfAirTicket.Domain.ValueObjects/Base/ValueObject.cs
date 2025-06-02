using SaleOfAirTicket.Domain.ValueObjects.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SaleOfAirTicket.Domain.ValueObjects.Base.IValidator;

namespace SaleOfAirTicket.Domain.ValueObjects.Base
{
    /// <summary>
    /// Абстрактный класс, представляющий объект значения.
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
    {
        /// <summary>
        /// Значение объекта.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Конструктор класса ValueObject.
        /// </summary>
        /// <param name="validator">Валидатор для проверки значения.</param>
        /// <param name="value">Значение объекта.</param>
        protected ValueObject(IValidator<T> validator, T value)
        {
            // Проверяем, что валидатор не равен null
            if (validator == null)
                throw new ValidatorNullException(GetType().FullName ?? String.Empty, ExceptionMessages.VALIDATOR_MUST_BE_SPECIFIED);

            // Валидируем значение
            validator.Validate(value);
            Value = value;
        }

        /// <summary>
        /// Возвращает строковое представление объекта.
        /// </summary>
        /// <returns>Строка, представляющая объект.</returns>
        public override string ToString()
            => Value!.ToString() ?? GetType().ToString();

        /// <summary>
        /// Получает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
            => Value!.GetHashCode();

        /// <summary>
        /// Определяет, равен ли текущий объект другому объекту.
        /// </summary>
        /// <param name="other">Другой объект для сравнения.</param>
        /// <returns>true, если объекты равны; в противном случае — false.</returns>
        public override bool Equals(object? other)
            => Equals(other as ValueObject<T>);

        /// <summary>
        /// Определяет, равен ли текущий объект другому объекту значения.
        /// </summary>
        /// <param name="other">Другой объект значения для сравнения.</param>
        /// <returns>true, если объекты равны; в противном случае — false.</returns>
        public bool Equals(ValueObject<T>? other)
        {
            // Проверяем, является ли другой объект null
            if (other is null)
                return false;

            // Проверяем, ссылаются ли оба объекта на один и тот же экземпляр
            if (ReferenceEquals(this, other))
                return true;

            // Проверяем, являются ли объекты одного типа
            if (GetType() != other.GetType())
                return false;

            // Сравниваем значения объектов
            return other.Value!.Equals(Value);
        }

        /// <summary>
        /// Оператор равенства для объектов значения.
        /// </summary>
        /// <param name="left">Левый объект.</param>
        /// <param name="right">Правый объект.</param>
        /// <returns>true, если объекты равны; в противном случае — false.</returns>
        public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right)
            => Equals(left, right);

        /// <summary>
        /// Оператор неравенства для объектов значения.
        /// </summary>
        /// <param name="left">Левый объект.</param>
        /// <param name="right">Правый объект.</param>
        /// <returns>true, если объекты не равны; в противном случае — false.</returns>
        public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right)
            => !(left == right);
    }

}
