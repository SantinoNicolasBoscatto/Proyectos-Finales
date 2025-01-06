using Newtonsoft.Json;
using NotesApp.Application.Excepciones;
using System.Net;
using System.Text.Json;

namespace NotesApp.PresentationController.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var errorResponse = new { message = exception.Message }; var errorJson = JsonConvert.SerializeObject(errorResponse);
            return context.Response.WriteAsync(errorJson);
        }
    }
}
