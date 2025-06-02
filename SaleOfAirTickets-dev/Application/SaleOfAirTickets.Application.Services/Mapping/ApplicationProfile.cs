using SaleOfAirTickets.Application.Models.Airports;
using AutoMapper;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTickets.Application.Models.Airlines;
using SaleOfAirTickets.Application.Models.Customer;
using SaleOfAirTickets.Application.Models.Tariffs;
using SaleOfAirTickets.Application.Models.Seats;
using SaleOfAirTickets.Application.Models.Flights;
using SaleOfAirTickets.Application.Models.Passengers;

namespace AuctionTrading.Application.Services.Mapping;
public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {

        CreateMap<Price, decimal>().ConvertUsing(x => x.Value);
        CreateMap<Airports, AirportModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Value))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Value));

        CreateMap<Passengers, PassengerModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.Value))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.Value))
            .ForMember(dest => dest.Email, opt => opt.MapFrom((opt, dest) => opt.Email?.Value ?? null))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom((opt, dest) => opt.PhoneNumber?.Value ?? null))
            .ForMember(dest => dest.Passport, opt => opt.MapFrom(src => src.Passport.Value));

        CreateMap<Airlines, AirlineModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Value))
            .ForMember(dest => dest.Tariffs, opt => opt.MapFrom(src => src.Tariffs));

        CreateMap<Tariffs, TariffModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value));

        CreateMap<Seats, SeatModel>()
            .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.SeatNumber.Value));

        CreateMap<Flights, FlightModel>()
            .ForMember(dest => dest.DepartureAirportId, opt => opt.MapFrom(src => src.DepartureAirport.Id))
            .ForMember(dest => dest.ArrivalAirportId, opt => opt.MapFrom(src => src.ArrivalAirport.Id))
            .ForMember(dest => dest.CountSeats, opt => opt.MapFrom(src => src.CountSeats.Value))
            .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

        CreateMap<Customers, CustomerModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.Value))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.Value))
            .ForMember(dest => dest.Email, opt => opt.MapFrom((opt, dest) => opt.Email?.Value ?? null))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom((opt, dest) => opt.PhoneNumber?.Value ?? null))
            .ForMember(dest => dest.Ticket, opt => opt.MapFrom(src => src.Ticket))
            .ForMember(dest => dest.Booking, opt => opt.MapFrom(src => src.Booking));

    }
}
