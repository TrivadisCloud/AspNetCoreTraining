using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;

namespace Middleware
{
    public class YourOwnMiddleware
    {
        private readonly RequestDelegate _next;
        public YourOwnMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context)
        {

            var parametersToAdd = new Dictionary<string, string> { { "test", "testvalue" } };
            context.Request.Path = QueryHelpers.AddQueryString(context.Request.Path, parametersToAdd);
            return this._next(context);
        }
    }

}
