using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
    internal class PassengerAlreadyExistException(Passengers passenger)
        : InvalidOperationException($"Такой пассажир (id = {passenger.Id}) уже существует.")
    {
        public Passengers Passenger => passenger;
    }

