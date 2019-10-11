using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class AppWorkOutsDbContext : DbContext
    {
        public AppWorkOutsDbContext(DbContextOptions<AppWorkOutsDbContext> options)
      : base(options) { }
        public DbSet<WorkOuts> WorkOuts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<WorkOuts>()
                 .HasKey(m => m.WorkOutsID);
        }
    }
}
