using SaleOfAirTicket.Domain.Entities;


namespace SaleOfAirTicket.Domain.Exceptions
{
    internal class TariffAlreadyExistException(Tariffs tariff)
        : InvalidOperationException($"Такой тариф (id = {tariff.Id}) уже существует.")
    {
        public Tariffs Tariff => tariff;
    }
}
