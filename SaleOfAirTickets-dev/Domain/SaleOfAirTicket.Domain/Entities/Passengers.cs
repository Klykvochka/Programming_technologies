using SaleOfAirTicket.Domain.Entities.Base;
using SaleOfAirTicket.Domain.Exceptions;
using SaleOfAirTicket.Domain.ValueObjects;



namespace SaleOfAirTicket.Domain.Entities;

public class Passengers : Entity<Guid>
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email? Email { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public Passport Passport { get; private set; }
    public DateTime Birthday { get; }


    protected Passengers()
    {

    }
    protected Passengers(Guid id, FirstName firstName, LastName lastName, PhoneNumber phoneNumber, Email email, Passport passport, DateTime birthday) : base(id)
    {

        FirstName = firstName ?? throw new ArgumentNullValueException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullValueException(nameof(lastName));
        Passport = passport ?? throw new ArgumentNullValueException(nameof(passport));
        PhoneNumber = phoneNumber;
        Email = email;
        Birthday = birthday;
    }

    public Passengers(FirstName firstName, LastName lastName, PhoneNumber phoneNumber, Email email, Passport passport, DateTime birthday)
        : this(Guid.NewGuid(), firstName, lastName, phoneNumber, email, passport, birthday)
    {

    }
    internal bool ChangeFirstName(FirstName newFirstName)
    {
        if (FirstName == newFirstName) return false;
        FirstName = newFirstName;
        return true;
    }
    internal bool ChangePassport(Passport newPassport)
    {
        if (Passport == newPassport) return false;
        Passport = newPassport;
        return true;
    }
    internal bool ChangeLastName(LastName newLastName)
    {
        if (LastName == newLastName) return false;
        LastName = newLastName;
        return true;
    }
    internal bool ChangeEmail(Email newEmaile)
    {
        if (Email == newEmaile) return false;
        Email = newEmaile;
        return true;
    }
    internal bool ChangePhoneNumber(PhoneNumber newPhoneNumber)
    {
        if (PhoneNumber == newPhoneNumber) return false;
        PhoneNumber = newPhoneNumber;
        return true;
    }
}

