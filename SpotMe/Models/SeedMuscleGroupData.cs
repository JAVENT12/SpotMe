using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Identity.Models
{
    public class SeedMuscleGroupData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppMuscleDbContext context = app.ApplicationServices
            .GetRequiredService<AppMuscleDbContext>();
            context.Database.Migrate();
            if (!context.MuscleGroup.Any()) 
            {
                context.MuscleGroup.AddRange();


               context.SaveChanges();
            }
        }
    }
}

