using FluentValidation;
using Libreria.Abstractions.IService;
using Libreria.Abstractions.Service;
using Libreria.Application.Services;


namespace Libreria.ServiceExtensions
{
    public static class ServiceExtensionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Aggiunta di tutti i validatori FluentValidation dall'assembly corrente
            services.AddValidatorsFromAssembly(
                AppDomain.CurrentDomain.GetAssemblies()
                    .SingleOrDefault(assembly => assembly.GetName().Name == "LibreriaBackend")
            );

            // Registrazione dei servizi dell'applicazione
            services.AddScoped<IUtenteService, UtenteService>();  // Servizio per la gestione degli utenti
            services.AddScoped<ILibroService, LibroService>();  // Servizio per la gestione dei libri
            services.AddScoped<ITokenService, TokenService>();  // Servizio per la gestione dei token JWT

            return services;
        }

    }
}

