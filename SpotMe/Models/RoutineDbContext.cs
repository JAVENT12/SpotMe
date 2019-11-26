using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Identity.Models
{
    public class RoutineDbContext : DbContext
    {
        public RoutineDbContext()
        {

        }
        public RoutineDbContext(DbContextOptions<RoutineDbContext> options)
      : base(options) { }
        public DbSet<Routine> Routines { get; set; }
       // public IQueryable<WorkOuts> WorkOuts { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Routine>()
                 .HasKey(m => m.routineID);
        }
    }
}