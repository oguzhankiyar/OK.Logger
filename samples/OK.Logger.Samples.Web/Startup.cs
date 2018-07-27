using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using OK.Logger;
using OK.Logger.SqlServer;

namespace OK.Logger.Samples.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.UseOKLogger((config) =>
            {
                config.UseSqlServer("Server=OKCOMPUTER;Database=OK.Logger;Trusted_Connection=True;MultipleActiveResultSets=True;")
                      .EnableInternalLog("C:\\oklogger-internal.txt");
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            logger.Add("App is configuring.");

            app.Run(async (context) =>
            {
                logger.Add("App is requested.", new { Url = context.Request.GetDisplayUrl() });

                await context.Response.WriteAsync("Hello World!");
            });

            logger.Add("App is configured.");
        }
    }
}