
using ACC.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ACC.Application
{
    /// <summary>
    /// EF ModelBuilder
    /// </summary>
    public static class EntityBuilder
    {
        /// <summary>
        /// Add model with entity
        /// 需要创建的实体以及QueryFilter设置
        /// </summary>
        /// <param name="modelBuilder">salf</param>
        public static void AddModelBuilder(this ModelBuilder modelBuilder)
        {
            List<Type> implementationTypes = FindFromCompileLibraries();
            AddModelBuilder(modelBuilder, implementationTypes);
        }

        /// <summary>
        /// Find entity assembly
        /// </summary>
        /// <returns></returns>
        public static List<Type> FindFromCompileLibraries()
        {
            List<Type> ret = new List<Type>();
            List<Assembly> compileAssemblies = AssemblyHelper.LoadCompileAssemblies();
            foreach (var assembly in compileAssemblies)
            {
                ret.AddRange(AssemblyHelper.FindEntity(assembly));
            }
            return ret;
        }
        /// <summary>
        /// do add entity
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="implementationTypes"></param>
        public static void AddModelBuilder(ModelBuilder modelBuilder, List<Type> implementationTypes)
        {
            MethodInfo EntityMethod = typeof(ModelBuilder).GetTypeInfo().GetMethods().Single(x => x.Name == "Entity" && x.IsGenericMethod && x.GetParameters().Length == 0);
            
            foreach (Type implementationType in implementationTypes)
            {
                dynamic entityTypeBuilder = EntityMethod.MakeGenericMethod(implementationType).Invoke(modelBuilder, new object[0]);
                SetActiveableQueryFilter(entityTypeBuilder);
            }
        }
        /// <summary>
        /// 添加查询过滤
        /// IsDeleted==false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityTypeBuilder"></param>
        private static void SetActiveableQueryFilter<T>(this EntityTypeBuilder<T> entityTypeBuilder) where T : BaseEntity
        {
            entityTypeBuilder.HasQueryFilter(p => p.IsDeleted==false);
            /*不现式用这个*/
            //entityTypeBuilder.HasQueryFilter(p => EF.Property<bool>(p, "IsDeleted") == false);
        }

    }
}
