using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Identity.Models;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Internal;

namespace Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
          Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordValidator<AppUser>, // From infrastructure
            CustomPasswordValidator>();

            //services.AddTransient<IUserValidator<AppUser>, //just a way of validating what you want
            //CustomUserValidator>();

            services.AddDbContext<AppIdentityDbContext>(options =>
             options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SpotIdentity;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SpotMe;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddTransient<IExcerciserRepository, EFExcerciserRepository>();

            services.AddDbContext<AppMuscleDbContext>(options =>
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SpotMe;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddTransient<IMuscleGroupRepository, EFMuscleGroupRepository>();


            //options.UseSqlServer(Configuration["Data:SportStoreIdentity:ConnectionString"]));

            services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Users/Login");
          
            services.AddIdentity<AppUser, IdentityRole>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppIdentityDbContext>()

               //services.AddDbContext<ApplicationDbContext>(options =>
               //options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SpotMee;Trusted_Connection=True;MultipleActiveResultSets=true"));
               //services.AddTransient<IExcerciserRepository, EFExcerciserRepository>();

               .AddDefaultTokenProviders();

            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();

            // SeedData.EnsurePopulated(app);// use for MuscleGroups
           // SeedMuscleGroupData.EnsurePopulated(app); // use for MuscleGroups
        }
    }
}
