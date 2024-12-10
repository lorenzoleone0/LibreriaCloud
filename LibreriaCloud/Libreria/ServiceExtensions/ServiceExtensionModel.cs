using Microsoft.EntityFrameworkCore;
using Libreria.Database;
using Libreria.Repositories;


namespace Libreria.ServiceExtensions
{
    public static class ServiceExtensionModel
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurazione del DbContext per utilizzare SQL Server
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"))
                .EnableSensitiveDataLogging()  // Attiva il logging dei dati sensibili
                .LogTo(Console.WriteLine, LogLevel.Information); // Log della query su console
                //.EnableSensitiveDataLogging(false);

            });

            // Registrazione dei repository per l'accesso ai dati
            services.AddScoped<UtenteRepository>();       // Repository per la gestione degli utenti
            services.AddScoped<LibroRepository>();       // Repository per la gestione dei libri
            
            

            return services;
        }
    }
}