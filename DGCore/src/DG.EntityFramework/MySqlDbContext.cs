using DG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.EntityFramework
{
    public class MySqlDbContext:DbContext
    {
        private ILogger log = new LoggerFactory().CreateLogger<MySqlDbContext>();
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Menu>();
            modelBuilder.Entity<Member>();


            
            
        }
        public override int SaveChanges()
        {
            
            ChangeTracker.DetectChanges();
            
            UpdateUpdatedProperty<Menu>();
            UpdateUpdatedProperty<Member>();
            return base.SaveChanges();
        }


        private void UpdateUpdatedProperty<T>() where T : BaseEntiy
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified|| e.State == EntityState.Detached);



            foreach (var entry in modifiedSourceInfo)
            {
                if(entry.State== EntityState.Added)
                {
                    entry.Property("CreateTime").CurrentValue = DateTime.UtcNow;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdateTime").CurrentValue = DateTime.UtcNow;
                }
                log.LogInformation($"{entry.State.ToString()}[{entry.Entity.ID}]");

            }
        }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Member> Member { get; set; }
    }
}
