using ApplicationCore.Interfaces;
using Infraestructure.Services;
using Infraestructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Persistence
{
    public static class Startup
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            // Obtiene las configuraciones de la base de datos
            var databaseSettings = config.GetSection(nameof(DataBaseSetting)).Get<DataBaseSetting>();
            string? rootConnectionString = databaseSettings.ConnectionString;
            if (string.IsNullOrEmpty(rootConnectionString))
            {
                throw new InvalidOperationException("DB ConnectionString no está configurado.");
            }

            // Configura el contexto de base de datos con EnableRetryOnFailure para manejar errores transitorios
            services
                .Configure<DataBaseSetting>(config.GetSection(nameof(DataBaseSetting)))
                .AddDbContext<ApplicationDbContext>(m =>
                    m.UseSqlServer(rootConnectionString, sqlOptions =>
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,           // Número máximo de reintentos
                            maxRetryDelay: TimeSpan.FromSeconds(10), // Tiempo máximo de espera entre intentos
                            errorNumbersToAdd: null     // Puedes agregar números de error específicos si lo deseas
                        )
                    )
                )
                .AddTransient<IDatabaseInitializer, DatabaseInitializer>()
                .AddTransient<ApplicationDbInitializer>();

            // Agrega otros servicios
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IEstudiantesService, EstudiantesService>();
            services.AddTransient<IColaboradorService, ColaboradorService>();

            return services;
        }
    }
}
