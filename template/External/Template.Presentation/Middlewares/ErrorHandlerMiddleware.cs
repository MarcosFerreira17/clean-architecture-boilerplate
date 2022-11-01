using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Template.Application.Exceptions;
using Template.Application.Exceptions.Model;

namespace Template.Presentation.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "Template.Application/json";
            var responseModel = new Response<string>(error.Message);
            response.StatusCode = error switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                NotFoundException => (int)HttpStatusCode.NotFound,
                ForbiddenAccessException => (int)HttpStatusCode.Forbidden,
                _ => (int)HttpStatusCode.InternalServerError,
            };
            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }
}
