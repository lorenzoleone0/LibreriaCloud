

namespace Libreria.Middleware
{
    public static class MiddlewareExtension
    {
        public static WebApplication? AddApplicationMiddleware(this WebApplication? app)
        {
            app.UseMiddleware<MiddlewareExample>();
            return app;
        }
    }
}
