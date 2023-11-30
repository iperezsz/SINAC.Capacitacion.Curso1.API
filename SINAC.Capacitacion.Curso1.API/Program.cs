using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using SINAC.Capacitacion.Curso1.API.Data.Interfaces;
using SINAC.Capacitacion.Curso1.API.Data.Repositorios;
using SINAC.Capacitacion.Curso1.API.Models;

namespace SINAC.Capacitacion.Curso1.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddOData(options => options.AddRouteComponents("odata", GetEdmModel()).Select().Expand().Filter().OrderBy().Count().SetMaxTop(50));

            builder.Services.AddDbContext<CapacitacionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("capacitacion")));

            builder.Services.AddScoped<IAgenteRepository, AgentesRepository>();

            builder.Services.AddCors(options =>
                options.AddDefaultPolicy(policy =>
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7215")
                )
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();


            app.MapControllers();

            app.Run();
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Agents>("Agentes").EntityType.HasKey(x => x.AgentCode);

            return builder.GetEdmModel();
        }
    }
}