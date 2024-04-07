using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Visit.API.Mapping;
using Visit.DAL;
using Visit.Domain.BL;
using Visit.Domain.BL.Mapping;

namespace Visit.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddEnvironmentVariables(prefix: "ENV_");
            
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Visit.Contracts.xml"));
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Visit.API.xml"));
            });
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new ApiMappingProfile());
                cfg.AddProfile(new DomainMappingProfile());
            });
            services.AddValidatorsFromAssembly(typeof(Program).Assembly).AddFluentValidationAutoValidation(opt =>
            {
                opt.DisableBuiltInModelValidation = true;
            });

            services.AddMvc()
                .AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

            services.AddDomain()
                .AddDataAccess(configuration);

            var app = builder.Build();

            var db = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>().Database;
            db.Migrate();

            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.MapControllers();

            app.Run();
        }
    }
}