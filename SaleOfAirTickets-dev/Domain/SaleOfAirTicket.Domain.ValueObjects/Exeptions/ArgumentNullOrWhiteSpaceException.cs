

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
/// <summary>
/// Исключение, которое возникает, когда один из строковых аргументов равен нулю, пуст или состоит только из пробелов.
/// </summary>
/// <param name="message">Сообщение об ошибке, объясняющее причину исключения.</param>
/// <param name="paramName">Имя параметра, вызвавшего текущее исключение.</param>
internal class ArgumentNullOrWhiteSpaceException(string paramName, string message)
    : ArgumentNullException(paramName, message);
