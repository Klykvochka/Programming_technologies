using SaleOfAirTicket.Domain.Entities.Base;
using SaleOfAirTicket.Domain.Enums;
using SaleOfAirTicket.Domain.Exceptions;
using SaleOfAirTicket.Domain.Handler;
using SaleOfAirTicket.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SaleOfAirTicket.Domain.Entities;

public class Customers : Entity<Guid>
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email? Email { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }

    private readonly ICollection<TicketRegistrationProcess> _booking = [];
    public IReadOnlyCollection<TicketRegistrationProcess> Booking => _booking.ToList().AsReadOnly();

    private readonly ICollection<Passengers> _passenger = [];
    public IReadOnlyCollection<Passengers> Passenger => _passenger.ToList().AsReadOnly();
    private readonly ICollection<Tickets> _ticket = [];
    public IReadOnlyCollection<Tickets> Ticket => _ticket.ToList().AsReadOnly();

    protected Customers()
    {

    }
    protected Customers(Guid id,
        FirstName firstName,
        LastName lastName, PhoneNumber
        phoneNumber, Email email)
        : base(id)
    {

        FirstName = firstName ?? throw new ArgumentNullValueException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullValueException(nameof(lastName));
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public Customers(FirstName
        firstName,
        LastName lastName,
        PhoneNumber phoneNumber,
        Email email)
        : this(Guid.NewGuid(), firstName, lastName, phoneNumber, email)
    {

    }

    public bool ChangeFirstName(FirstName newFirstName)
    {
        if (FirstName == newFirstName) return false;
        FirstName = newFirstName;
        return true;
    }

    public bool ChangeLastName(LastName newLastName)
    {
        if (LastName == newLastName) return false;
        LastName = newLastName;
        return true;
    }

    public bool ChangeEmail(Email newEmaile)
    {
        if (Email == newEmaile) return false;
        Email = newEmaile;
        return true;
    }

    public bool ChangePhoneNumber(PhoneNumber newPhoneNumber)
    {
        if (PhoneNumber == newPhoneNumber) return false;
        PhoneNumber = newPhoneNumber;
        return true;
    }

    public bool PurchaseTicket(
        City departureCity,
        City arrivalCity,
        DateTime departureDate,
        Name NameTariff,
        SeatNumber SeatNumber,
        FirstName passengerFirstName,
        LastName passengerLastName,
        IReadOnlyCollection<Flights> availableFlights
        )
    {
        if (availableFlights == null || !availableFlights.Any())
            throw new ArgumentNullException(nameof(availableFlights));

        var record = new Record(this, departureCity, arrivalCity, departureDate, NameTariff, passengerFirstName, passengerLastName);

        var flightSelectionHandler = new FlightSelectionHandler(availableFlights);
        var tariffSelectionHandler = new TariffSelectionHandler();
        var seatSelectionHandler = new SeatSelectionHandler(SeatNumber);
        var passengerSelectorHandler = new PassengerSelectorHandler(_passenger.ToList());



        flightSelectionHandler
            .SetNext(tariffSelectionHandler)
            .SetNext(seatSelectionHandler)
            .SetNext(passengerSelectorHandler);

        flightSelectionHandler.Handle(record);
        tariffSelectionHandler.Handle(record);

        record.Ticket = this.MakeTicket(record);


        if (record.Ticket == null)
            throw new CouldNotCreateTicketException();
        if (!MakePurchaseProcess(record))
            throw new CouldNotSaleOfTheTicketException();

        return true;
    }


    private Tickets MakeTicket(Record record)
    {
        if (record == null)
            throw new ArgumentNullException(nameof(record));

        if (record.Customer != this)
            throw new AnotherCustomerMakeTicketException(record.Customer);

        if (record.Flight == null)
        {
            throw new ThereAreNoAvailableFlightsException();
        }

        if (record.Seat == null)
        {
            throw new ThereAreNoEmptySeatsException(record.Flight);
        }

        if (record.Passenger == null)
        {
            throw new ThereAreNoThisPassengerException();
        }

        var ticket = new Tickets(this, record.Passenger, record.Seat);

        //record.Seat.TakeTheSeat();

        if (_ticket.Contains(ticket))
            throw new TicketAlreadyCreateExseption(ticket);


        _ticket.Add(ticket);

        return ticket;
    }
    private bool MakePurchaseProcess(Record record)
    {
        if (record == null)
            throw new ArgumentNullException(nameof(record));

        if (record.Customer != this)
            throw new AnotherCustomerMakeTicketException(record.Customer);

        if (record.Flight == null)
            throw new ThereAreNoAvailableFlightsException();

        if (record.Tariff == null)
            throw new ThereIsNoSuchTariffException(record.Flight);

        if (record.Seat == null)
            throw new ThereAreNoEmptySeatsException(record.Flight);

        if (record.Passenger == null)
            throw new ThereAreNoThisPassengerException();

        if (record.Ticket == null)
            throw new ThereAreNoTicketException();

        var process = new TicketRegistrationProcess(record.Ticket, record.Flight, record.Seat, this, DateTime.UtcNow);

        if (!process.SetBought(this))
            return false;
        if (_booking.Contains(process))
            throw new BookingAlredyBoughtException(process);

        _booking.Add(process);

        return true;
    }
    public Passengers CreatePassanger(FirstName firstName, LastName lastName, PhoneNumber phoneNumber, Email email, Passport passport, DateTime birthday)
    {
        if (firstName == null)
            throw new ArgumentNullException(nameof(firstName));

        if (lastName == null)
            throw new ArgumentNullException(nameof(lastName));

        if (phoneNumber == null)
            throw new ArgumentNullException(nameof(phoneNumber));

        if (email == null)
            throw new ArgumentNullException(nameof(email));

        if (passport == null)
            throw new ArgumentNullException(nameof(passport));

        var passenger = new Passengers(firstName, lastName, phoneNumber, email, passport, birthday);

        if (_passenger.Contains(passenger))
            throw new PassengerAlreadyExistException(passenger);

        _passenger.Add(passenger);
        return passenger;
    }
    public bool AddPassenger(Passengers passengers)
    {
        if (passengers == null)
            throw new ArgumentNullException(nameof(passengers));
        if (_passenger.Contains(passengers))
            throw new PassengerAlreadyExistException(passengers);

        _passenger.Add(passengers);
        return true;
    }

    public IReadOnlyCollection<Tickets> CheckPassengerTickets(Passengers passenger)
    {
        if (passenger == null)
        {
            throw new ArgumentNullException(nameof(passenger));
        }
        if (!_passenger.Contains(passenger))
            throw new ThereIsNoSuchPassengerException(this, passenger);

        var passengerTickets = _ticket.Where(ticket => ticket.Passenger == passenger).ToList();
        return passengerTickets;
    }

    public Tickets CheckTicketByPassengerAndDate(Passengers passenger, Flights flight)
    {
        var passengerTickets = _booking.FirstOrDefault(ticket => ticket.Ticket.Passenger == passenger && ticket.Flight == flight);
        if (passengerTickets == null)
            throw new ArgumentNullException(nameof(passengerTickets));
        
        return passengerTickets.Ticket;
    }
    public bool CancelTicket(Tickets ticket)
    {
        if (ticket == null)
            throw new ArgumentNullException(nameof(ticket));

        var booking = _booking.FirstOrDefault(t => t.Ticket == ticket);

        if (booking == null)
            throw new ArgumentNullException(nameof(booking));

        if (!_booking.Contains(booking))
            throw new InvalidBookingException(this, booking);

        booking.SetCancel(this);

        return true;
    }
}
