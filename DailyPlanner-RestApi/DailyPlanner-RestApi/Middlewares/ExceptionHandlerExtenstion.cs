using DailyPlanner.Services.Exceptions;
using System.Net;

namespace DailyPlanner_RestApi.Middlewares
{
    public static class ExceptionHandlerExtenstion
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandler>();
        }
    }
    public class ExceptionHandler : IMiddleware
    {
        private HttpContext _context;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _context = context;

            try
            {
                await next(context);
            }
            catch (ValidationException validationException)
            {
                await Handle(validationException);
            }
            catch (NotFoundException notFoundException)
            {
                await Handle(notFoundException);
            }
        }

        private async Task Handle(ValidationException validationException)
        {
            _context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            await _context.Response.WriteAsJsonAsync(new
            {
                validationException.Message,
                validationException.UIMessage,
                validationException.ValidationSource
            });
        }

        private async Task Handle(NotFoundException validationException)
        {
            _context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            await _context.Response.WriteAsJsonAsync(new
            {
                validationException.Message,
                validationException.UIMessage,
                validationException.Id,
            });
        }
    }
}
