using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Exceptions;

namespace SaleOfAirTicket.Domain.Handler;
internal class TariffSelectionHandler : BookingHandler
{

    public TariffSelectionHandler()
    {
        
    }

    public override void Handle(Record record)
    {
        if (record == null)
            throw new ArgumentNullException(nameof(record));

        if (record.Flight == null)
            throw new ThereAreNoAvailableFlightsException();

        Tariffs? selectedTariff = record.Flight.Airline.Tariffs.FirstOrDefault(t => t.Name.Value == record.TariffName.Value);

        if (selectedTariff != null)
        {
            record.Tariff = selectedTariff;
            NextHandler?.Handle(record);
        }
        else
        {
            throw new ThereIsNoSuchTariffException(record.Flight);
        }

    }
}
