using GradeBookMicroservice.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Models.Airports;
    public record class AirportCreateModel(
        Guid Id,
        string Name,
        string Country,
        string City) : ICreateModel;
