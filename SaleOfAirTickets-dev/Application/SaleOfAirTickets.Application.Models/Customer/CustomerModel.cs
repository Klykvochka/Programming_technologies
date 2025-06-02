using GradeBookMicroservice.Application.Models.Base;
using SaleOfAirTickets.Application.Models.Passengers;
using SaleOfAirTickets.Application.Models.TicketRegistrationProcess;
using SaleOfAirTickets.Application.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Models.Customer;
public record class CustomerModel(
    Guid Id,
    string FirstName,
    string LastName,
    string? Email,
    string? PhoneNumber) : IModel<Guid>
{
    public IEnumerable<TicketRegistrationProcessModel> Booking { get; init; }
    public IEnumerable<TicketModel> Ticket { get; init; }
    public IEnumerable<PassengerModel> Passengers { get; init; }

}