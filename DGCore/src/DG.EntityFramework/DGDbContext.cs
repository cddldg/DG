using ACC.Application;
using DG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.EntityFramework
{
    public class DGDbContext: DbContext
    {
        private ILogger log ;
        public DGDbContext(DbContextOptions<DGDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            log = loggerFactory.CreateLogger<DGDbContext>();
            //没有就创建数据库
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region 需要创建的实体以及QueryFilter设置
            modelBuilder.AddModelBuilder();
            #endregion
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var entities=ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);
            foreach (var entry in entities)
            {
                #region 自动生成增删改的基础数据：id，time
                string name = entry.State.ToString();
                string userId = "0";
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreateTime").CurrentValue = DateTime.Now;
                    entry.Property("ID").CurrentValue = ACC.Common.ID.CreateSnowflakeId;
                    entry.Property("IsDeleted").CurrentValue = false; 
                    userId = entry.Property("CreateUserID").CurrentValue.ToString();
                    name = "添加";
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdateTime").CurrentValue = DateTime.Now;
                    userId = entry.Property("UpdateUserID").CurrentValue.ToString();
                    name = "修改";
                }
                if (entry.State == EntityState.Deleted)
                {
                    userId = entry.Property("UpdateUserID").CurrentValue.ToString();
                    name = "删除";
                } 
                #endregion

                log.LogInformation($"用户[{userId}]于[{DateTime.Now}][{name}][{entry.Entity.GetType()}]数据[{entry.Entity.ToString()}]");
            }
            return base.SaveChanges();
        }


        //public DbSet<MenuEntity> Menu { get; set; }
        //public DbSet<MemberEntity> Member { get; set; }
    }
}
