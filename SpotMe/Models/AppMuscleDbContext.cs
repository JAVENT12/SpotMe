using Microsoft.EntityFrameworkCore;

namespace Identity.Models
{
    public class AppMuscleDbContext : DbContext
    {
        public AppMuscleDbContext(DbContextOptions<AppMuscleDbContext> options)
       : base(options) { }
        public DbSet<MuscleGroup> MuscleGroup { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<MuscleGroup>()
                 .HasKey(m => m.muscleGroupID);
        }
    }
}