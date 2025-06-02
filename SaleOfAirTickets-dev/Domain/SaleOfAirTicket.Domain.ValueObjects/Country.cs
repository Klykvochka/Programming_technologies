using SaleOfAirTicket.Domain.ValueObjects.Validators;
using SaleOfAirTicket.Domain.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.ValueObjects;


/// <summary>
/// Представляет собой тип Страны.
/// </summary>
/// <param name="country">Страна.</param>
public class Country(string country) 
    : ValueObject<string>(new CountryValidator(), country);

