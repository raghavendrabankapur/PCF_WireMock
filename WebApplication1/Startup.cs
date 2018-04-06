using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using WireMock.Net.StandAlone;
using WireMock.Server;
using WireMock.Settings;

namespace WebApplication1
{
    public class Startup
    {
        private static bool started = false;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMockService, MockService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IMockService service)
        {
            //var rewrite = new RewriteOptions()
            //    .AddRedirect("films", "movies")
            //    .AddRewrite("actors", "stars", true);

            //app.UseRewriter(rewrite);

            //app.Run(async context =>
            //{
            //    var path = context.Request.Path;
            //    var query = context.Request.QueryString;
            //    await context.Response.WriteAsync($"New URL: {path}{query}");
            //});
        }
    }

    public interface IMockService
    {
        void start();
    }

    public class MockService : IMockService
    {
        public void start()
        {

        }

        public MockService()
        {
            StandAloneApp.Start(new FluentMockServerSettings() { StartAdminInterface = true , Port=1111});
        }
    }
}
