using DG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DG.Infrastructure
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> option):base(option)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }

}
