using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.ValueObjects.Validators;
using SaleOfAirTicket.Domain.ValueObjects;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations;
public class AirportsConfiguration : IEntityTypeConfiguration<Airports>
{
    public void Configure(EntityTypeBuilder<Airports> builder)
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

        builder.Property(x => x.City)
            .IsRequired()
            .HasConversion(city => city.Value, str => new City(str))
            .HasMaxLength(CityValidator.MAX_LENGTH);
    }
}

