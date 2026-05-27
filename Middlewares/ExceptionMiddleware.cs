namespace BackEcommerce.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Error de validación: {Message}", ex.Message);
                await RespuestaHttp(context, StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Acceso no autorizado: {Message}", ex.Message);
                await RespuestaHttp(context, StatusCodes.Status401Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado: {Message}", ex.Message);
                await RespuestaHttp(context, StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }

        private static async Task RespuestaHttp(HttpContext context, int statusCode, string mensaje)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var respuesta = new
            {
                status = statusCode,
                message = mensaje,
                timestamp = DateTime.Now
            };

            await context.Response.WriteAsJsonAsync(respuesta);
        }
    }
}
