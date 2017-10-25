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
using System.IO;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ACC.Common;

namespace DG.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(env.ContentRootPath)
                     .AddJsonFile(Path.Combine("Configs", "appsettings.json"), optional: true, reloadOnChange: true)  
                     .AddJsonFile(Path.Combine("Configs", $"appsettings.{env.EnvironmentName}.json"), optional: true, reloadOnChange: true)
                     //.AddJsonFile(Path.Combine("Configs", "bundleconfig.json"), optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables();                                              
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /***********HttpContext相关设置（没搞懂现在不需要任何注入也TM有了。。。）************/
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region MyRegion
            /* MemoryCache */
            //services.AddMemoryCache();
            /* Session */
            //services.AddSession();
            /* Cookie */
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //}).AddCookie();

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            //}).AddControllersAsServices(); 
            #endregion

            
            services.AddDbContext<DGDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySQL")));

            /* 注册服务 */
            services.AddServices();
            //var audienceConfig = Configuration.GetSection("Audience");
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(options =>
            //        {
            //            options.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidateAudience = true,
            //                ValidateLifetime = true,
            //                ValidateIssuerSigningKey = true,

            //                ValidIssuer = audienceConfig["Issuer"],
            //                ValidAudience = audienceConfig["Audience"],
            //                IssuerSigningKey = BearerHelper.Create(audienceConfig["Secret"])
            //            };

            //            options.Events = new JwtBearerEvents
            //            {
            //                OnAuthenticationFailed = context =>
            //                {
            //                    Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
            //                    return Task.CompletedTask;
            //                },
            //                OnTokenValidated = context =>
            //                {
            //                    Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
            //                    return Task.CompletedTask;
            //                }
            //            };
            //        });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Member",policy => policy.RequireClaim("MembershipId"));
            //});

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            /* NLog */
            env.ConfigureNLog(Path.Combine("Configs", "nlog.config"));
            loggerFactory.AddNLog();
            app.AddNLogWeb();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            #region JWT
            //var audienceConfig = Configuration.GetSection("Audience");
            //var symmetricKeyAsBase64 = audienceConfig["Secret"];
            //var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            //var signingKey = new SymmetricSecurityKey(keyByteArray);
            //var SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            //app.UseAuthentication(new TokenProviderOptions
            //{
            //    Audience = audienceConfig["Audience"],
            //    Issuer = audienceConfig["Issuer"],
            //    SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            //}); 
            app.UseAuthentication();
            #endregion

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

                #region api路由
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
                #endregion

                routes.MapAreaRoute(
                    "area_api",
                    "api",
                    "api/{controller}/{action}/{id?}");
            });
        }
    }
}
