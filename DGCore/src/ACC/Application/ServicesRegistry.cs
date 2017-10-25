using ACC.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ACC.Application
{
    /// <summary>
    /// 注册服务
    /// </summary>
    public static class ServicesRegistry
    {
        #region AddServices
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            List<Type> implementationTypes = FindFromCompileLibraries();
            AddServices(services, implementationTypes);
        }
        public static List<Type> FindFromCompileLibraries()
        {
            List<Type> ret = new List<Type>();
            List<Assembly> compileAssemblies = AssemblyHelper.LoadCompileAssemblies();
            foreach (var assembly in compileAssemblies)
            {
                ret.AddRange(AssemblyHelper.FindService(assembly));
            }

            return ret;
        }
        public static void AddServices(IServiceCollection services, List<Type> implementationTypes)
        {
            Type appServiceType = typeof(IAppService);
            foreach (Type implementationType in implementationTypes)
            {
                var implementedAppServiceTypes = implementationType.GetTypeInfo().ImplementedInterfaces.Where(a => a != appServiceType && appServiceType.IsAssignableFrom(a));

                foreach (Type implementedAppServiceType in implementedAppServiceTypes)
                {
                    if (typeof(IDisposable).IsAssignableFrom(implementationType))
                        services.AddScoped(implementedAppServiceType, implementationType);
                    else
                        services.AddTransient(implementedAppServiceType, implementationType);
                }
            }
        }
        #endregion
    }
}
