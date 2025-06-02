using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTickets.Application.Models.Tickets;
using SaleOfAirTickets.Application.Services.Abstractions;

namespace SaleOfAirTickets.Application.Services;
public class SaleOfTicketApplicationService(
    IFlightsRepository flightRepository,
    IAirportsRepository airportRepository,
    IRepository<Airlines, Guid> airlineRepository,
    IRepository<Customers, Guid> customerRepository,
    IRepository<Passengers, Guid> passengerRepository,
    IMapper mapper)
    : ISaleOfTicketApplicationService
    {
    public async Task<bool> SaleOfAirTicketAsync(TicketSaleInfoModel information, CancellationToken cancellationToken)
    {
        // Получаем данные по авиакомпании, аэропорту, покупателю и пассажиру
        var airline = await airlineRepository.GetByIdAsync(information.AirlineId, cancellationToken);
        if (airline is null)
            return false;

        var airport = await airportRepository.GetByIdAsync(information.DepartureAirportId, cancellationToken);
        if (airport is null)
            return false;

        var customer = await customerRepository.GetByIdAsync(information.CustomerId, cancellationToken);
        if (customer is null)
            return false;

        // Проверяем, что рейс с данным идентификатором отсутствует, чтобы избежать дублирования
        if (await flightRepository.GetByIdAsync(information.FlightId, cancellationToken) is not null)
            return false;

        // Получаем доступные рейсы по заданным параметрам (городам и времени)
        var availableFlights = await flightRepository.GetFlightByFromWhereToWhereWhenAsync(
            information.DepartureCity,
            information.ArrivalCity,
            information.DepartureDate,
            cancellationToken);

        if (availableFlights == null || !availableFlights.Any())
            return false;


        var departureCity = new City(information.DepartureCity);
        var arrivalCity = new City(information.ArrivalCity);
        var nameTariff = new Name(information.NameTariff);
        var seatNumber = new SeatNumber(information.SeatNumber);
        var passengerFirstName = new FirstName(information.PassengerFirstName);
        var passengerLastName = new LastName(information.PassengerLastName);
        var AvailableFlights = availableFlights
    .Where(flight => flight is not null) 
    .Select(flight => flight!)           
    .ToList()
    .AsReadOnly();

       
        bool isPurchased = customer.PurchaseTicket(
            departureCity,
            arrivalCity,
            information.DepartureDate,
            nameTariff,
            seatNumber,
            passengerFirstName,
            passengerLastName,
            AvailableFlights);

        return isPurchased;
    }
}

