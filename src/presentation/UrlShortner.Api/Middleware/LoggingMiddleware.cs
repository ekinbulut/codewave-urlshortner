namespace UrlShortner.Api.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log the request
        _logger.LogInformation($"Received request: {context.TraceIdentifier} - {context.Request.Method} - {context.Request.Path}");

        // Call the next middleware in the pipeline
        await _next(context);

        // Log the response
        _logger.LogInformation($"Sending response: {context.TraceIdentifier} - {context.Response.StatusCode}");
    }
}
