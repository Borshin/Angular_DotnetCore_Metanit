using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace PathFinder.Exceptions
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private ILogger _logger;

        /// <summary>
        /// Initialization.
        /// </summary>
        /// <param name="loggerFactory">Factory for log service.</param>
        public ApiExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(ApiExceptionFilter));
        }

        /// <summary>
        /// Runs asynchronously after an action has thrown an <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="context">Current exception context.</param>
        public override void OnException(ExceptionContext context)
        {
            ApiError apiError = new ApiError(context.Exception.GetBaseException().Message)
            {
#if DEBUG
                Detail = context.Exception.StackTrace
#endif
            };

            _logger.LogError(context.Exception, context.Exception.Message);
            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(apiError);

            base.OnException(context);
        }
    }
}
