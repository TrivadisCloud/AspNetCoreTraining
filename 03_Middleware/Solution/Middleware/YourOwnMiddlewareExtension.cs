using Microsoft.AspNetCore.Builder;

namespace Middleware
{
    public static class YourOwnMiddlewareExtensions
    {
        public static IApplicationBuilder UseOwnMiddleware(
        this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<YourOwnMiddleware>();
        }
    }

}
