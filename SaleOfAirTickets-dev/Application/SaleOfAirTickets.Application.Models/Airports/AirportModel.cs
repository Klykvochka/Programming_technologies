using GradeBookMicroservice.Application.Models.Base;


namespace SaleOfAirTickets.Application.Models.Airports;
public record class AirportModel(
    Guid Id,
    string Name,
    string Country,
    string City) : IModel<Guid>;
