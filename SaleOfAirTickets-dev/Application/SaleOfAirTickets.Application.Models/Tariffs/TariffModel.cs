using GradeBookMicroservice.Application.Models.Base;
using SaleOfAirTickets.Application.Models.Airlines;


namespace SaleOfAirTickets.Application.Models.Tariffs;
public record class TariffModel(
    Guid Id,
    string Name,
    decimal Price,
    Guid AirlineId)
        : IModel<Guid>;


