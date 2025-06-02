using GradeBookMicroservice.Application.Models.Base;


namespace SaleOfAirTickets.Application.Models.Airlines;
public record class AirlineCreateModel(
    Guid Id,
    string Name,
    string Country) : ICreateModel;

