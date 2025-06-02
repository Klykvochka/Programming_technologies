using GradeBookMicroservice.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Models.Customer;
public record class CustomerCreateModel(
    Guid Id,
    string FirstName,
    string LastName,
    string? Email,
    string? PhoneNumber) : ICreateModel;
