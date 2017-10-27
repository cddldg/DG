using ACC.Application;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace ACC.Common
{
    public static class AssemblyHelper
    {
        public static List<Assembly> LoadCompileAssemblies()
        {
            List<CompilationLibrary> libs = DependencyContext.Default.CompileLibraries.Where(lib => !lib.Serviceable && lib.Type != "package").ToList();
            List<Assembly> ret = new List<Assembly>();
            foreach (var lib in libs)
            {
                Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                ret.Add(assembly);
            }
            return ret;
        }
        public static List<Type> FindService(Assembly assembly)
        {
            IEnumerable<Type> allTypes = assembly.GetTypes();
            allTypes = allTypes.Where(a =>
            {
                var b = a.IsAbstract == false && a.IsClass && typeof(IAppService).IsAssignableFrom(a) && (a.GetConstructor(Type.EmptyTypes) != null|| a.GetConstructors().Any());
                return b;
            });

            List<Type> ret = allTypes.ToList();
            return ret;
        }

        /// <summary>
        /// 找到实体codefist
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static List<Type> FindEntity(Assembly assembly)
        {
            IEnumerable<Type> allTypes = assembly.GetTypes();
            allTypes = allTypes.Where(a =>
            {
                var b = a.FullName.EndsWith("Entity") && a.IsAbstract == false && a.IsClass && a.IsSubclassOf(typeof(BaseEntity))  && (a.GetConstructor(Type.EmptyTypes) != null || a.GetConstructors().Any());
                return b;
            });

            List<Type> ret = allTypes.ToList();
            return ret;
        }
    }
}
