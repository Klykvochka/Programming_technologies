

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions
{
    /// <summary>
    /// Исключение, которое возникает, когда для данного типа не указан метод проверки.
    /// </summary>
    /// <param name="paramName">Имя типа объекта, в котором произошло текущее исключение</param>
    /// <param name="message">Сообщение об ошибке, объясняющее причину исключения.</param>
    internal class ValidatorNullException(string paramName, string message)
        : ArgumentNullException(paramName, message);
}
