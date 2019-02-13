using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PathFinder.Exceptions;
using PathFinder.Services;
using System;

namespace PathFinder
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddMvc(options =>
            {
                options.Filters.Add<ApiExceptionFilter>();
            });

            services.AddScoped<IFlightsService, FlightsService>();
            services.AddScoped<IPathFinder, PathFinderSevice>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseWebpackDevMiddleware(new Microsoft.AspNetCore.SpaServices.Webpack.WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });

                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.UseMvc();
                app.Run(async (context) =>
                {
                    context.Response.ContentType = "text/html";
                    await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
                });
            }
        }
    }
}
