using GradeBookMicroservice.Application.Models.Base;


namespace SaleOfAirTickets.Application.Models.Passengers;
public record class PassengerCreateModel(
    Guid Id,
    string FirstName,
    string LastName,
    string? Email,
    string? PhoneNumber,
    string Passport,
    DateTime Birthday) : ICreateModel;
