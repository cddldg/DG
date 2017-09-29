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
        //public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        //{
        //    log = new LoggerFactory().CreateLogger<MySqlDbContext>();
        //    Database.EnsureCreated();

        //}
        public DGDbContext(DbContextOptions<DGDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            log = loggerFactory.CreateLogger<DGDbContext>();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<MenuEntity>();
            modelBuilder.Entity<MemberEntity>(); 
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var entities=ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);
            foreach (var entry in entities)
            {
                string name = entry.State.ToString();
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreateTime").CurrentValue = DateTime.UtcNow;
                    entry.Property("ID").CurrentValue = ACC.Common.ID.CreateSnowflakeId;
                    name = "添加";
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdateTime").CurrentValue = DateTime.UtcNow;
                    name = "修改";
                }
                if (entry.State == EntityState.Deleted)
                {
                    name = "删除";
                }
                log.LogDebug($"[State:{entry.State.ToString()}]{name}{entry.Entity.GetType()}数据[key:{entry.Property("ID").CurrentValue}]");
            }
            return base.SaveChanges();
        }

        
        //public DbSet<MenuEntity> Menu { get; set; }
        //public DbSet<MemberEntity> Member { get; set; }
    }
}
