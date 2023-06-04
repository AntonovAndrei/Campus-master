using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Serilog;
using Serilog.Events;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Log.Logger = new LoggerConfiguration()
            //     .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            //     .WriteTo.File("CampusWebAppLog-.txt", rollingInterval:
            //         RollingInterval.Day)
            //     .CreateLogger();
            
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            
            try 
            {
                var context = services.GetRequiredService<CampusContext>();
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await context.Database.MigrateAsync();
                await Seed.SeedData(context, userManager, roleManager);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An error occured during migraiton");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
