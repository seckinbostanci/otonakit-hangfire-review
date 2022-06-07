using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;



var hostBuilder = Host.CreateDefaultBuilder(args);

hostBuilder.ConfigureServices((context, services) =>
{
    
});

var configuration =  new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.json");
var config = configuration.Build();

var connectionString = config.GetConnectionString("HangfireConnection");

GlobalConfiguration.Configuration.UsePostgreSqlStorage(connectionString);

using var server = new BackgroundJobServer(new BackgroundJobServerOptions()
{
    ServerName = "Server1-" + Environment.MachineName,
    WorkerCount = 1
});

var host = hostBuilder.Build();
await host.RunAsync();