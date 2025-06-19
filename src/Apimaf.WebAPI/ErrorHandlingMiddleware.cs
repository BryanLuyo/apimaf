using System.Net;
using System.Text.Json;

namespace Apimaf.WebAPI;

/// <summary>
/// Middleware para capturar excepciones y devolver un formato de error coherente.
/// </summary>
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var response = new ApiResponse<object>(5000, "Unexpected error", null);
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
