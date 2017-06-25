using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;

namespace RoutingAndHosting
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var sampleRouteHander = new RouteHandler(context =>
            {
                var routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync(
                $"Hello! From other route: {string.Join(", ", routeValues)}");
            });

            var rb = new RouteBuilder(app, sampleRouteHander);

            rb.MapRoute("testroute", "test/test2/{number:int}");

            RequestDelegate factorialRequestHandler = c => {
                var number = c.GetRouteValue("number") as string;

                int value;
                if (Int32.TryParse(number, out value))
                {
                    value = Math.Abs(value);
                    value++;
                    var results = value;
                    return c.Response.WriteAsync($"{number}! = {results}");
                }

                return c.Response.WriteAsync("${number} is not an integer.");
            };

            rb.MapGet("factorial/{number:int}", factorialRequestHandler);

            rb.MapGet("hello/{name}", context =>
            {
                var name = context.GetRouteValue("name");
                return context.Response.WriteAsync($"Hi, {name}!");
            });

            var routes = rb.Build();

            app.UseRouter(routes);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
