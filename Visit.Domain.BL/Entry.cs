using Microsoft.Extensions.DependencyInjection;
using Visit.Domain.BL.Abstractions;

namespace Visit.Domain.BL;

public static class Entry
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAttributeService, AttributeService>();

        return services;
    }
}