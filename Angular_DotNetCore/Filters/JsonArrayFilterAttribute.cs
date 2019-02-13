using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using static System.Net.WebRequestMethods;

namespace PathFinder.Filters
{
    /// <summary>
    /// JsonArrayFilterAttribute wraps Json array to avoid potentional hijacking attack (<see href="Http://haacked.com/archive/2009/06/25/json-hijacking.aspx"/>).
    /// Apply to methods returning Json Array.
    /// </summary>
    public class JsonArrayFilterAttribute : Attribute, IAsyncResultFilter
    {
        /// <summary>
        /// Filter to wrap Json array to avoid potentional hijacking attack (<see href="http://haacked.com/archive/2009/06/25/json-hijacking.aspx"/>).
        /// </summary>
        /// <param name="context">ResultExecutingContext <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.filters.resultexecutingcontext?view=aspnetcore-2.1"/> for more information.</param>
        /// <param name="next">ResultExecutionDelegate <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.filters.resultexecutiondelegate?view=aspnetcore-2.1"/> for more information.</param>
        /// <returns>Task to continue request chain handling.</returns>
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var contentObject = context.Result as JsonResult;
            if (contentObject != null)
            {
                if ((contentObject.Value is IEnumerable<Object>) || (contentObject.Value is System.Data.DataTable))
                {
                    var proxy = new { Data = contentObject.Value };
                    var result = new JsonResult(proxy);
                    context.Result = result;
                }
            }
            await next();
        }
    }
}
