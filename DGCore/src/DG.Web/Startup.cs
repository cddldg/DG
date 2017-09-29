using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DG.EntityFramework;
using Microsoft.EntityFrameworkCore;
using DG.Application;
using Microsoft.Extensions.Logging;
using DG.Application.Member;
using ACC.Application;

namespace DG.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddDbContextPool<MySqlDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySQL")));
            services.AddDbContext<DGDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySQL")));
            services.AddScoped<IMemberService, MemberService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapAreaRoute(
                    "area_api",
                    "api",
                    "api/{controller}/{action}/{id?}");
            });
        }
    }
}
