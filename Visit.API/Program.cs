using System.Text.Json.Serialization;
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
            
            services.AddSwaggerGen();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new ApiMappingProfile());
            });

            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddDomain()
                .AddDataAccess(configuration);

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}