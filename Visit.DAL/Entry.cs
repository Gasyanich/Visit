using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Visit.DAL;

public static class Entry
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(builder => builder.UseNpgsql(configuration["App:DbConnectionString"]));

        return services;
    }
}