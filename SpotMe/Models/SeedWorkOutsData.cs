using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class SeedWorkOutsData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppWorkOutsDbContext context = app.ApplicationServices
            .GetRequiredService<AppWorkOutsDbContext>();
            context.Database.Migrate();
            if (!context.WorkOuts.Any())
            {
                context.WorkOuts.AddRange();


                context.SaveChanges();
            }
        }
    }
}
