using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visit.Domain;

namespace Visit.DAL.Configuration;

public class AttributeValueConfiguration : IEntityTypeConfiguration<AttributeValue>
{
    public void Configure(EntityTypeBuilder<AttributeValue> builder)
    {
        builder.HasKey(av => av.Id);

        builder.HasOne(av => av.Attribute).WithMany();
        
        builder.HasOne(av => av.Place).WithMany(p => p.AttributeValues);

        builder.Property(av => av.StringValue).HasMaxLength(255);
        
        builder.HasIndex(av => av.PlaceId);
        builder.HasIndex(av => av.AttributeId);
        
        builder.HasIndex(av => av.IntValue);
        builder.HasIndex(av => av.StringValue);
        builder.HasIndex(av => av.DoubleValue);
    }
}