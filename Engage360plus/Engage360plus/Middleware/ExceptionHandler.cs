namespace Engage360plus.Middleware
{
    using System.Net;
    public class ExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> log;
        private readonly RequestDelegate next;

        public ExceptionHandler(ILogger<ExceptionHandler> log,
            RequestDelegate next)
        {
            this.log = log;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                //Log this Exception
                log.LogError(ex,$"{errorId} : {ex.Message}");
                //Return a custom error response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! We are looking into resolving this"
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
