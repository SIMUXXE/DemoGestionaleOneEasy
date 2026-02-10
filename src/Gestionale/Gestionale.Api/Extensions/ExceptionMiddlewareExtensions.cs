namespace Gestionale.Api.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        // Log dell'eccezione
                        Console.WriteLine($"[ERROR] {contextFeature.Error}");

                        // Response standard
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            KeyNotFoundException => StatusCodes.Status404NotFound,
                            ArgumentException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        });
                    }
                });
            });
        }
    }
}
