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
using NLog.Extensions.Logging;
using NLog.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;

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

            //services.RegisterAppServices(); /* 注册应用服务 */
            /***********HttpContext相关设置（没搞懂现在不需要任何注入也TM有了。。。）************/
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            /* 缓存 */
            //services.AddMemoryCache();

            //services.AddSession();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //}).AddCookie();

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            //}).AddControllersAsServices();


            services.AddMvc();
            
            //services.AddDbContextPool<MySqlDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySQL")));
            services.AddDbContext<DGDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySQL")));
            services.AddScoped<IMemberService, MemberService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            /* NLog */
            env.ConfigureNLog("nlog.config");
            loggerFactory.AddNLog();
            app.AddNLogWeb();

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
                /****api路由****
                webapi解耦（随时可以独立出去） 使用DG.Controllers.Api(引用就可以)有多种方法：采用中间件方式，Application Model等这里介绍用简单路由配置的方式：
                 1、使用路由：添加路由规则即可
                     首先
                     routes.MapRoute(
                        name: "api",
                        template: "api/{controller}/{action}/{id?}"
                        );
                     然后在控制器上添加标签关键是"api"前缀名称要相同
                     [Produces("application/json")]
                     [Route("api/[controller]/[action]")]
                     public class ApiBaseController : Controller
                     {
                     }
                 2、使用域
                     首先添域路由规则
                     routes.MapAreaRoute("api_route", "api","api/{controller}/{action}/{id?}");
                     然后在控制器添加标签关键是“api”域名称要相同
                     [Produces("application/json")]
                     [Area("api")]
                     public class ApiBaseController : Controller
                     {
                     }
                ****/
                routes.MapAreaRoute(
                    "area_api",
                    "api",
                    "api/{controller}/{action}/{id?}");
            });
        }
    }
}
