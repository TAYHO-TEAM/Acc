using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectManager.CMD.Infrastructure;
using Serilog;
using Serilog.Events;
using Services.Common.Options;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendMailAppointmentService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft",LogEventLevel.Warning)
               .Enrich.FromLogContext()
               .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();
            try
            {
                Log.Information("Application Starting.");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Console.ReadLine();
                Log.Fatal(ex, "The Application failed to start.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((hostContext, config) =>
                 {
                     // Configure the app here.
                     config
                         .SetBasePath(Environment.CurrentDirectory)
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                     config.AddEnvironmentVariables();
                 })
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    ProfileMailOptions profileMailoptions = configuration.GetSection("ProfileMailOptions").Get<ProfileMailOptions>();
                    services.AddDbContext<ProjectManagerBaseContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("TayHoConnection")));
                    services.AddHostedService<Worker>();
                })
                .UseSerilog();
    }
}
