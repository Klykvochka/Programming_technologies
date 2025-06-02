using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.ValueObjects.Validators;
using SaleOfAirTicket.Domain.ValueObjects;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations;
public class CustomerConfiguration : IEntityTypeConfiguration<Customers>
{
    public void Configure(EntityTypeBuilder<Customers> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasConversion(firstname => firstname.Value, str => new FirstName(str))
            .HasMaxLength(FirstNameValidator.MAX_LENGTH);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasConversion(lastName => lastName.Value, str => new LastName(str))
            .HasMaxLength(LastNameValidator.MAX_LENGTH);

        builder.Property(x => x.Email)
            .IsRequired(false)
            .HasConversion(email => email.Value, str => new Email(str))
            .HasMaxLength(EmailValidator.MAX_LENGTH);

        builder.Property(x => x.PhoneNumber)
            .IsRequired(false)
             .HasConversion(phoneNumber => phoneNumber.Value, str => new PhoneNumber(str))
            .HasMaxLength(PhoneNumberValidator.MAX_LENGTH);

        builder.Ignore(x => x.Booking);
        builder.Ignore(x => x.Passenger);
        builder.Ignore(x => x.Ticket);
    }
}

