using ElasticsearchTest.Middleware.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ElasticsearchTest.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        #region Variables

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        #endregion

        #region Constructor

        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<ExceptionHandlingMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        #endregion

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpStatusCodeException ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogError($"Urota se dogodila: {ex}");
                    throw;
                }
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogError($"Urota se dogodila: {ex}");
                    throw;
                }
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            LogError(exception);

            context.Response.Clear();
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var errorMessage = JsonConvert.SerializeObject(new { Errors = new string[] { exception.Message } });
            await context.Response.WriteAsync(errorMessage);

            return;
        }

        private async Task HandleExceptionAsync(HttpContext context, HttpStatusCodeException exception)
        {
            LogError(exception);

            context.Response.Clear();
            context.Response.StatusCode = exception.StatusCode;
            context.Response.ContentType = exception.ContentType;

            await context.Response.WriteAsync(exception.Message);

            return;
        }

        private void LogError(Exception exception)
        {

        }

        #endregion
    }

    public static class HttpStatusCodeExceptionMiddlewareExtensions
    {
        #region Methods

        public static IApplicationBuilder UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        #endregion
    }
}
