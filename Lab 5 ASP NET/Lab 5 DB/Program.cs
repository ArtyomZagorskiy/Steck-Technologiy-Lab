using Lab_5_ASP_NET.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Lab_5_DB;
using Microsoft.Extensions.Logging;

class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<CookbookContext>();
                SampleData.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
         .ConfigureServices((context, services) =>
         {
             string connectionString = "Server=(localdb)\\mssqllocaldb;Database=CookbookDB;Trusted_Connection=True;";

             services.AddDbContext<CookbookContext>(options =>
                 options.UseSqlServer(connectionString));

             services.AddLogging();
         });

}