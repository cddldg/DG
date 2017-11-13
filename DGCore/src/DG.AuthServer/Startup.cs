using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace DG.AuthServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {    
            services.AddIdentityServer()
                .AddSigningCredential(new X509Certificate2(Path.Combine(Directory.GetCurrentDirectory(), "Configs", "dg.pfx"),"dldg"))
                .AddTestUsers(AuthConfig.Users().ToList())
                .AddInMemoryClients(AuthConfig.Clients())
                .AddInMemoryApiResources(AuthConfig.ApiResources());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {    
            app.UseDeveloperExceptionPage();
            /*1、管道添加支持*/
            app.UseIdentityServer(); //app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("DG AuthServer");
            });
        }
    }
}
