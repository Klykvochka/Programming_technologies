using GradeBookMicroservice.Application.Models.Base;


namespace SaleOfAirTickets.Application.Models.Tariffs;
public record class TariffCreateModel(
    Guid Id,
    string Name,
    decimal Price,
    Guid AirlineId) : ICreateModel;

