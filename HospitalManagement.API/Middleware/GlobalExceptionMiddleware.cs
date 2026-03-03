using Azure;
using HospitalManagement.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace HospitalManagement.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                StatusCode = 500,
                Message = "An unexpected error occurred"
            };

            switch (ex)
            {
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    response = new
                    {
                        StatusCode = 404,
                        Message = ex.Message
                    };
                    break;

                case BadRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    response = new
                    {
                        StatusCode = 400,
                        Message = ex.Message
                    };
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
           
        }
    }
}
