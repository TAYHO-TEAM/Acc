using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
//using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectManager.CMD.Infrastructure;
using Serilog;
using Services.Common.Options;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Serilog.Events;
using AppWFGenProject.Commons;
//using System.Configuration;

namespace AppWFGenProject
{
    static class Program
    {
        
        //public static IConfiguration _configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //var provider = new PhysicalFileProvider(@"\Content\Config");
            var currentDirectory = Directory.GetCurrentDirectory();

            //_configuration = new ConfigurationBuilder()
            //                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            //                .AddJsonFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Content\Config\appsettings.json", true, true)
            //                .Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GenProject(_configuration));
            var host = CreateHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
               .Enrich.FromLogContext()
               .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();
                try
                {
                    Log.Information("Application Starting.");
                    //DevExpress.UserSkins.BonusSkins.Register();
                    //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("TayHoDevApp");
                    var form1 = services.GetRequiredService<GenProject>();
                    Application.Run(form1);
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

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    // Configure the app here.
                    config
                       .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .AddJsonFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\Content\\Config\\appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                       .AddJsonFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Content\Config\appsettings.json", true, true);
                    config.AddEnvironmentVariables();
                })
               .ConfigureServices((hostContext, services) =>
               {
                   IConfiguration configuration = hostContext.Configuration;
                   services.Configure<ProfileMailOptions>(configuration.GetSection("ProfileMailOptions"));
                   services.Configure<Common>(configuration.GetSection("Common"));
                   services.Configure<LDAPConfig>(configuration.GetSection("LDAPConfig"));
                   services.AddDbContext<ProjectManagerBaseContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("TayHoConnection"))
                                                                                .EnableSensitiveDataLogging()
                                                                                .EnableDetailedErrors());
                   services.AddScoped<GenProject>();
                   //services.AddScoped<TayHoDevApp>(); 
                   //services.AddScoped<testApp>();
               })
               .UseSerilog();
    }
    public static class ConfigExtenstions
    {
        public static T GetValue<T>(this IConfiguration configuration, string configSection, string keyName)
        {
            return (T)Convert.ChangeType(configuration[$"{configSection}:{keyName}"], typeof(T));
        }
        //private static T GetValue<T>(string configSection, string configSubSection, string keyName)
        //{
        //    return (T)Convert.ChangeType(Configuration[$"{configSection}:{configSubSection}:{keyName}"], typeof(T));
        //}
    }

}
