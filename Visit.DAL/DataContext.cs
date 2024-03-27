using Microsoft.EntityFrameworkCore;
using Visit.Domain;
using Attribute = Visit.Domain.Attribute;

namespace Visit.DAL;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Attribute> Attributes { get; set; }

    public DbSet<Place> Places { get; set; }

    public DbSet<AttributeValue> AttributeValues { get; set; }
}