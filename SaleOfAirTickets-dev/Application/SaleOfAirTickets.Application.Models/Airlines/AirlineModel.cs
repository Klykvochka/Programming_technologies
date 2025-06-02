using GradeBookMicroservice.Application.Models.Base;
using SaleOfAirTickets.Application.Models.Flights;
using SaleOfAirTickets.Application.Models.Tariffs;


namespace SaleOfAirTickets.Application.Models.Airlines;
public record class AirlineModel(
    Guid Id,
    string Name,
    string Country) : IModel<Guid>
{
    public IEnumerable<TariffModel> Tariffs { get; init; }
    public IEnumerable<FlightModel> Flights { get; init; }

}

