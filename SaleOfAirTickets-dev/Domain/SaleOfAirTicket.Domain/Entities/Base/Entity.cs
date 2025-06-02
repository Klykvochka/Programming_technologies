namespace SaleOfAirTicket.Domain.Entities.Base
{
    /// <summary>
    /// Представляет объект в системе.
    /// </summary>
    /// <typeparam name="TId">Тип идентификатора объекта.</typeparam>
    /// <param name="id">Идентификатор объекта.</param>
    /// <remarks>
    /// Инициализирует новый экземпляр <see cref="Entity{TId}"/> класса.
    /// </remarks>
    /// <param name="id">ID объекта.</param>
    public abstract class Entity<TId>(TId id) where TId : struct, IEquatable<TId>
    {
        /// <summary>
        /// Возвращает идентификатор объекта.
        /// </summary>
        public TId Id { get; } = id;
        /// <summary>
        /// Защищенный конструктор для entity framework, если это необходимо.
        /// </summary>
        protected Entity() : this(default!)
        {

        }
    }
}
