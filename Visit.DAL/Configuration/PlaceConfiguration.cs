using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visit.Domain;

namespace Visit.DAL.Configuration;

public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
        
        builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);

        builder.HasMany(p => p.Categories)
            .WithMany(c => c.Places);

        builder.Property(p => p.AttributeValues).HasColumnType("jsonb");
    }
}