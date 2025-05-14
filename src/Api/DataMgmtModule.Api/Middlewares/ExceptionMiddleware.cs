using System.Net;
using DataMgmtModule.Application.Exceptions;

namespace DataMgmtModule.Api.Middlewares
{
    public class ExceptionMiddleware
    {


        readonly RequestDelegate _next;
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
        public static async Task<Task> HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (ex)
            {
                //Add Exception Cases
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case InActiveUserException inActiveUserException:
                    statusCode = HttpStatusCode.Forbidden;
                    break;
            }
            context.Response.StatusCode = (int)statusCode;
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            };
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
