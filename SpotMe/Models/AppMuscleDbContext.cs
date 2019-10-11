using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Identity.Models
{
    public class AppMuscleDbContext : DbContext
    {
        public AppMuscleDbContext()
        {
        }

        public AppMuscleDbContext(DbContextOptions<AppMuscleDbContext> options)
       : base(options) { }
        public DbSet<MuscleGroup> MuscleGroup { get; set; }
        public IQueryable<WorkOuts> WorkOuts { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<MuscleGroup>()
                 .HasKey(m => m.muscleGroupID);
        }
    }
}