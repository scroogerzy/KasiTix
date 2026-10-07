using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace KasiTix.Api.Middleware;

public class ApiExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var statusCode = exception switch
        {
            var ex when ex.GetType().Name == "ValidationException" => 400,
            var ex when ex.GetType().Name == "NotFoundException" => 404,
            var ex when ex.GetType().Name == "ConflictException" => 409,
            var ex when ex.GetType().Name == "UnprocessableEntityException" => 422,
            _ => 500
        };

        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = exception.Message
        };

        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(
            problem,
            cancellationToken);

        return true;
    }
}
