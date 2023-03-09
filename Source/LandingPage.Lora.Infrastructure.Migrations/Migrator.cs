using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace LandingPage.Lora.Infrastructure.Migrations;

public class Migrator
{
    private readonly string _connectionString;
    private readonly bool _showLogs;

    public Migrator(string connectionString, bool showLogs)
    {
        _connectionString = connectionString;
        _showLogs = showLogs;
    }

    public void Run()
    {
        var serviceProvider = CreateServices(this._connectionString);

        // Put the database update into a scope to ensure
        // that all resources will be disposed.
        using (var scope = serviceProvider.CreateScope())
        {
            UpdateDatabase(scope.ServiceProvider);
        }
    }

    /// <summary>
    /// Configure the dependency injection services
    /// </summary>
    private IServiceProvider CreateServices(string connectionString)
    {
        IServiceCollection serviceCollection = new ServiceCollection()
            // Add common FluentMigrator services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => {

            rb.AddMySql5();

            // Set the connection string
            rb.WithGlobalConnectionString(connectionString);
            });

            if (_showLogs)
            {
                // Enable logging to console in the FluentMigrator way
                serviceCollection.AddLogging(lb => lb.AddFluentMigratorConsole());
            }

        // Build the service provider
        return serviceCollection.BuildServiceProvider(false);
    }

    /// <summary>
    /// Update the database
    /// </summary>
    private void UpdateDatabase(IServiceProvider serviceProvider)
    {
        // Instantiate the runner
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        // Execute the migrations
        runner.MigrateUp();
    }
}
