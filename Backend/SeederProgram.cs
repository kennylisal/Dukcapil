using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backend;

public static class SeederProgram
{
    public static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        // Parse --seed argument
        int count = 10; // Default
        if (
            args.Length > 0
            && args[0] == "--seed"
            && args.Length > 1
            && int.TryParse(args[1], out int parsedCount)
        )
        {
            count = parsedCount;
        }
        else if (!args.Contains("--seed"))
        {
            Console.WriteLine("Use: dotnet run --seed <count>");
            return;
        }

        // Set up dependency injection
        var services = new ServiceCollection();
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );
        services.AddScoped<DataSeeder>();

        var serviceProvider = services.BuildServiceProvider();

        try
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
                Console.WriteLine($"Starting seeding of {count} Data");
                await seeder.SeedDatabase(count);
                Console.WriteLine("Seeding completed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during seeding: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
            Environment.Exit(1);
        }
    }
}
