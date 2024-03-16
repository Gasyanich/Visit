using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Visit.Domain;
using Attribute = Visit.Domain.Attribute;

namespace Visit.DAL.Configuration;

public class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
{
    public void Configure(EntityTypeBuilder<Attribute> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name).IsRequired().HasMaxLength(255);

        builder.Property(a => a.PredefinedValues)
            .HasColumnType("jsonb");

        builder.Property(a => a.Type)
            .HasConversion<EnumToStringConverter<AttributeType>>()
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(a => a.ControlType)
            .HasConversion<EnumToStringConverter<AttributeControlType>>()
            .HasMaxLength(255)
            .IsRequired();

        builder.HasMany(a => a.Categories)
            .WithMany(c => c.Attributes);
    }
}