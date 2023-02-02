using Costumer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costumer.Infraestructure.Maps;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name);
        builder.Property(p => p.Email);

        builder.OwnsOne(a => a.Address,
            b =>
            {
                b.Property(a => a.City);
                b.Property(a => a.Country);
                b.Property(a => a.State);
                b.Property(a => a.Street);
                b.Property(a => a.ZipCode);
                b.Property(a => a.Neighborhood);
                b.Property(a => a.Number);
                b.Property(a => a.Complement);
            });
        builder.Navigation(e => e.Address).IsRequired();
    }
}