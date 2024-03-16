using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visit.Domain;

namespace Visit.DAL.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).HasMaxLength(255).IsRequired();

        builder.HasMany(c => c.Places)
            .WithMany(p => p.Categories);

        builder.HasMany(a => a.Attributes)
            .WithMany(a => a.Categories);
    }
}