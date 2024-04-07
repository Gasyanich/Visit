using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Visit.DAL.Repository;
using Visit.Domain.BL.Abstractions.Repository;

namespace Visit.DAL;

public static class Entry
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IAttributeRepository, AttributeRepository>();
        services.AddScoped<IPlaceRepository, PlaceRepository>();
        services.AddMemoryCache();

        services.AddDbContext<DataContext>(builder =>
            builder.UseNpgsql(
                new NpgsqlDataSourceBuilder(configuration["App:DbConnectionString"])
                    .ConfigureJsonOptions(new JsonSerializerOptions
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                    })
                    .EnableDynamicJson()
                    .Build()
            )
        );

        return services;
    }
}