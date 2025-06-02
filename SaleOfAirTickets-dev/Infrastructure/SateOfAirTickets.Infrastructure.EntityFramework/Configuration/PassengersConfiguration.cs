using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.ValueObjects.Validators;
using SaleOfAirTicket.Domain.ValueObjects;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations;
public class PassengersConfiguration : IEntityTypeConfiguration<Passengers>
{
    public void Configure(EntityTypeBuilder<Passengers> builder)
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

        builder.Property(x => x.Passport)
            .IsRequired()
            .HasConversion(lastName => lastName.Value, str => new Passport(str))
            .HasMaxLength(PassportValidator.MAX_LENGTH);

        builder.Property(f => f.Birthday).IsRequired().HasConversion(
            src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
            dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
            );
        builder.HasMany<Tickets>()
            .WithOne(t => t.Passenger)
            .HasForeignKey("PassengerId");
    }
}

