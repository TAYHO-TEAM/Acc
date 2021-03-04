using AppWFGenProject.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
//using System.Configuration;

namespace AppWFGenProject
{
    static class Program
    {
        public static IConfiguration _configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //var provider = new PhysicalFileProvider(@"\Content\Config");
            var currentDirectory = Directory.GetCurrentDirectory();
            _configuration = new ConfigurationBuilder()
                            .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                            .AddJsonFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Content\Config\appconfig.json", true, true)
                            .Build();
            //var hostBuilder = Host.CreateDefaultBuilder()
            //                        .ConfigureAppConfiguration((context, builder) =>
            //                        {
            //                            builder.AddJsonFile("/Content/Config/appconfig.json", optional: true);
            //                        })
            //                        .ConfigureServices((hostContext, services) => { 
            //                            services.AddTransient<MyApplication>();
            //                        }).UseConsoleLifetime();

            //var builderDefault = hostBuilder.Build();

            //using (var serviceScope = builderDefault.Services.CreateScope())
            //{
            //    var services = serviceScope.ServiceProvider;
            //    try
            //    {
            //        var myService = services.GetRequiredService<MyApplication>();
            //    }
            //    catch(Exception ex)
            //    {

            //    }
            //}


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GenProject(_configuration));

        }

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
