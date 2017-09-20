using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DG.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace DG.WebAdmin
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
            //Sqlite
            //services.AddDbContext<MyContext>(opt => opt.UseSqlite(Configuration["ConnectionStrings:Sqlite"]));
            //Mssql
            //services.AddDbContext<MyContext>(opt => opt.UseSqlServer(Configuration["ConnectionStrings:Mssql"]));
            //Mysql
            services.AddDbContext<MyContext>(opt => opt.UseMySQL(Configuration["ConnectionStrings:Mysql"]));

            AuthConfigurer.Configure(services, Configuration);
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
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
                ///webapi解耦（随时可以独立出去） 使用DG.Controllers.WebApi(引用就可以)有多种方法：采用中间件方式，Application Model等这里介绍用简单路由配置的方式：
                /// 1、使用路由：添加路由规则即可
                ///     首先
                ///     routes.MapRoute(
                ///        name: "api",
                ///        template: "api/{controller}/{action}/{id?}"
                ///        );
                ///     然后在控制器上添加标签关键是"api"前缀名称要相同
                ///     [Produces("application/json")]
                ///     [Route("api/[controller]/[action]")]
                ///     public class ApiBaseController : Controller
                ///     {
                ///     }
                /// 2、使用域
                ///     首先添域路由规则
                ///     routes.MapAreaRoute("api_route", "api","api/{controller}/{action}/{id?}");
                ///     然后在控制器添加标签关键是“api”域名称要相同
                ///     [Produces("application/json")]
                ///     [Area("api")]
                ///     public class ApiBaseController : Controller
                ///     {
                ///     }

                routes.MapAreaRoute("api_route", "api", "api/{controller}/{action}/{id?}");
            });


        }
    }
}
