using Serilog.Context;

namespace HospitalManagement.API.Middleware
{
    public class CorrelationIdMiddleware
    {
        private const string HeaderKey = "X-Corerelation-ID";
        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(RequestDelegate next )
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var correlationId = context.Request.Headers[HeaderKey].FirstOrDefault()
                                ?? Guid.NewGuid().ToString();

            context.Response.Headers[HeaderKey] = correlationId;

            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                await _next(context);
            }
        }
    }
}
