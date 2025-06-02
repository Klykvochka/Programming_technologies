using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTicket.Domain.ValueObjects.Validators;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations;
public class AirlinesConfiguration : IEntityTypeConfiguration<Airlines>
{
    public void Configure(EntityTypeBuilder<Airlines> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasConversion(name => name.Value, str => new Name(str))
            .HasMaxLength(NameValidator.MAX_LENGTH);

        builder.Property(x => x.Country)
            .IsRequired()
            .HasConversion(country => country.Value, str => new Country(str))
            .HasMaxLength(CountryValidator.MAX_LENGTH);

        builder.HasMany(a => a.Flights)
            .WithOne(f => f.Airline)
            .HasForeignKey("AirlineId")    
            .IsRequired();

        builder.HasMany(a => a.Tariffs)
            .WithOne(t => t.Airline)
            .HasForeignKey("AirlineId")     
            .IsRequired();
    }
}