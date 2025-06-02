using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.ValueObjects.Validators;
using SaleOfAirTicket.Domain.ValueObjects;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations;
internal class TariffsConfiguration : IEntityTypeConfiguration<Tariffs>
{
    public void Configure(EntityTypeBuilder<Tariffs> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasConversion(name => name.Value, str => new Name(str))
            .HasMaxLength(NameValidator.MAX_LENGTH);

        builder.Property(x => x.Price)
             .IsRequired()
             .HasConversion(
                 startPrice => startPrice.Value,
                 d => new Price(d));

        builder.HasOne(t => t.Airline)
             .WithMany(a => a.Tariffs)
             .HasForeignKey("AirlineId")  
             .IsRequired();
    }
}


