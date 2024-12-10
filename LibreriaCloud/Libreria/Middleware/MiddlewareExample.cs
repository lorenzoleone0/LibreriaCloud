using Libreria.Abstractions.IService;

namespace Libreria.Middleware
{
    public class MiddlewareExample 
    {
        private RequestDelegate _next;
        public MiddlewareExample(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context
            , IUtenteService utenteService
            , ILibroService libroService
            , IConfiguration configuration
            )
        {
            context.RequestServices.GetRequiredService<IUtenteService>();
            context.RequestServices.GetRequiredService<ILibroService>();
           
            
           
            await _next.Invoke(context);
        }
    }
}

