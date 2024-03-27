using System.Text.Json.Serialization;
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Visit.API.Mapping;
using Visit.DAL;
using Visit.Domain.BL;

namespace Visit.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Visit.Contracts.xml"));
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Visit.API.xml"));
            });
            services.AddAutoMapper(cfg => { cfg.AddProfile(new ApiMappingProfile()); });
            services.AddValidatorsFromAssembly(typeof(Program).Assembly).AddFluentValidationAutoValidation(opt =>
            {
                opt.DisableBuiltInModelValidation = true;
            });

            services.AddMvc()
                .AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

            services.AddDomain()
                .AddDataAccess(configuration);

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.MapControllers();

            app.Run();
        }
    }
}