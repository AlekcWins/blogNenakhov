
using System;
using blogNenakhov.Domain.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication3.Infrastructure;
using WebApplication3.Infrastructure.Guarantors;

namespace blogNenakhov
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseNpgsql("Username= blogUser;Port=5432; database=blogNenakhov;Password=blogUser;Host=localhost");
            });
            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase= false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<BlogDbContext>();
            
            services.AddControllersWithViews();

            var serviceProvider = services.BuildServiceProvider();
            var guarantor = new SeedDataGuarantor(serviceProvider);

            guarantor.EnsureAsync();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var guarantors = scope.ServiceProvider.GetServices<IStartupPreConditionGuarantor>();
                try
                {
                    Console.WriteLine("Startup guarantors started");
                    foreach (var guarantor in guarantors)
                        guarantor.Ensure(scope.ServiceProvider);
                    Console.WriteLine("Startup guarantors executed successfully");
                }
                catch (StartupPreConditionException e)
                {
                    Console.WriteLine("Startup guarantors failed");
                    throw;
                }
            }

           
        }
    }
}