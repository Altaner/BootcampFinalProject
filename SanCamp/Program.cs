using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;
using System;

namespace SanCamp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Log levels read from appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console()
                .WriteTo.File(new JsonFormatter(), "logs-{Date}.json", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                // Writing meaningful messages are very important for logging
                // with this tiny message we can get when our web app starts
                Log.Information("Application Starting Up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application failed to start correctlu.");
            }
            finally
            {
                //cleaning the logs. If we didn't this logs stay on our RAM and keep to consume our resources.
                Log.CloseAndFlush();
            }


            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog() //declerating that we want to use Serilog for logging
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
