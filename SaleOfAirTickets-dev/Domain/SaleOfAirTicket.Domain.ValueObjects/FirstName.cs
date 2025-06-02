using SaleOfAirTicket.Domain.ValueObjects.Base;
using SaleOfAirTicket.Domain.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.ValueObjects;

/// <summary>
/// Представляет собой тип имени.
/// </summary>
/// <param name="firstName">Имя.</param>
public class FirstName(string firstName) 
    : ValueObject<string>(new FirstNameValidator(), firstName);

