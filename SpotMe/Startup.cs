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

            //services.AddDbContext<AppIdentityDbContext>(options =>
            // options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SpotIdentity;Trusted_Connection=True;MultipleActiveResultSets=true"));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SpotMe;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //services.AddTransient<IExcerciserRepository, EFExcerciserRepository>();

            //services.AddDbContext<AppMuscleDbContext>(options =>
            //options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SpotMe;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //services.AddTransient<IMuscleGroupRepository, EFMuscleGroupRepository>();

            //services.AddDbContext<AppWorkOutsDbContext>(options =>
            //options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SpotMe;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //services.AddTransient<IWorkOutsRepository, EFWorkOutsRepository>();
            
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer("Server=tcp:spotmedbserver.database.windows.net,1433;Initial Catalog=SpotIdentity;Persist Security Info=False;User ID=SpotAdmin;Password=sdJV23626??;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=tcp:spotmedbserver.database.windows.net,1433;Initial Catalog=SpotMe;Persist Security Info=False;User ID=SpotAdmin;Password=sdJV23626??;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddTransient<IExcerciserRepository, EFExcerciserRepository>();

            services.AddDbContext<AppMuscleDbContext>(options =>
            options.UseSqlServer("Server=tcp:spotmedbserver.database.windows.net,1433;Initial Catalog=SpotMe;Persist Security Info=False;User ID=SpotAdmin;Password=sdJV23626??;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddTransient<IMuscleGroupRepository, EFMuscleGroupRepository>();

            services.AddDbContext<AppWorkOutsDbContext>(options =>
            options.UseSqlServer("Server=tcp:spotmedbserver.database.windows.net,1433;Initial Catalog=SpotMe;Persist Security Info=False;User ID=SpotAdmin;Password=sdJV23626??;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddTransient<IWorkOutsRepository, EFWorkOutsRepository>();

            services.AddDbContext<RoutineDbContext>(options =>
            options.UseSqlServer("Server=tcp:spotmedbserver.database.windows.net,1433;Initial Catalog=SpotMe;Persist Security Info=False;User ID=SpotAdmin;Password=sdJV23626??;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddTransient<IRoutineRepository, EFRoutineRepository>();

            services.Configure<MvcOptions>(options =>
                         options.Filters.Add(new RequireHttpsAttribute()));

            services.AddScoped<Routine>(sp => SessionRoutine.GetRoutine(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMemoryCache(); // for session routines
            services.AddSession(); // for session routines

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSession(); // for session routines
            app.UseAuthentication();
           // app.UseMvcWithDefaultRoute();
            AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
            app.UseMvc(routes => {
                routes.MapRoute(
                name: "null",
                template: "{category}/ Page{productPage:int}",
                defaults: new { Controller = "MuscleGroups", action = "Excercises" });

                //routes.MapRoute(
                //name: null,
                //template: "Page{productPage:int}",
                //defaults: new
                //{
                //    controller = "MuscleGroups",
                //    action = "Excercises",
                //    productPage = 1
                //}
                //);
                //routes.MapRoute(
                //name: null,
                //template: "{category}",
                //defaults: new
                //{
                //    controller = "MuscleGroups",
                //    action = "Excercises",
                //    productPage = 1
                //}
                //);
                //routes.MapRoute(
                //name: null,
                //template: "",
                //defaults: new
                //{
                //    controller = "MuscleGroups",
                //    action = "Excercises",
                //    productPage = 1
                //});





                routes.MapRoute(
               name: "pagination2",
               template: "AppUsers/Page{productPage}",
               defaults: new { Controller = "Admin", action = "Index" });


                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });


            // SeedData.EnsurePopulated(app);// use for MuscleGroups
            // SeedMuscleGroupData.EnsurePopulated(app); // use for MuscleGroups
            // SeedWorkOutsData.EnsurePopulated(app); //use for WorkOuts
        }
    }
}
