using FluentValidation.AspNetCore;
using Libreria.JwtAuthentication;
using Libreria.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Libreria.ServiceExtensions
{
    public static class ServiceExtensionWeb
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurazione dei controller e della validazione dei modelli
            services.AddControllers()
                .ConfigureApiBehaviorOptions(opt =>
                {
                    opt.InvalidModelStateResponseFactory = (context) =>
                    {
                        return new BadRequestResultFactory(context); // Personalizzazione del messaggio di errore
                    };
                });


            // Configurazione di Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Gestione Libreria",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Inserisci 'Bearer' seguito dal token JWT",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            // Aggiunge FluentValidation per la validazione automatica dei modelli
            services.AddFluentValidationAutoValidation();

            // Configurazione JWT Authentication
            var jwtAuthenticationOption = new JwtAuthenticationOption();    
            configuration.GetSection("JwtAuthentication")
                .Bind(jwtAuthenticationOption);

            services.AddAuthentication(options =>
            {
                //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//autenticazione tramite JWT
            .AddJwtBearer(options =>
            {
                string key = jwtAuthenticationOption.Key;
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtAuthenticationOption.Issuer,
                    IssuerSigningKey = securityKey
                };
            });

            // Configura le opzioni personalizzate 
            services.AddOptions(configuration);

            return services;
        }

        private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            

            // Configurazione delle opzioni per l'autenticazione JWT
            services.Configure<JwtAuthenticationOption>(configuration.GetSection("JwtAuthentication"));

            return services;
        }
    }
}

