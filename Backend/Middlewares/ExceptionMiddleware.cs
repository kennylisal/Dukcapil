using System;
using Backend.DTO.Response;

namespace Backend.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Unexpected Error ocured");
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var ErrorResponse = new ControllerErrorResponse(ex.Message);
            await context.Response.WriteAsJsonAsync(ErrorResponse);
        }
    }
}
