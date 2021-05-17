using Guiado.API.Extensions;
using Guiado.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.IO;

namespace Guiado.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Info("Application Starting Up");
                var configuration = GetConfiguration();
                var host = CreateHostBuilder(configuration);

                logger.Info("Applying migrations...");
                host.MigrateDbContext<GuiadoContext>();

                logger.Info("Starting web host...");
                host.Run();
            }
            catch(Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHost CreateHostBuilder(IConfiguration configuration) =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseConfiguration(configuration);
                    webBuilder.ConfigureLogging(logging => logging.ClearProviders());
                    webBuilder.UseNLog();
                    webBuilder.UseKestrel(options =>
                    {
                        options.Listen(System.Net.IPAddress.Any, GetConfiguredPorts(configuration), config => config.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2);
                    });
                    webBuilder.UseStartup<Startup>();
                })
                .Build();

        private static IConfiguration GetConfiguration()
            => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                         .AddJsonFile("appsettings.json")
                                         .Build();

        private static int GetConfiguredPorts(IConfiguration configuration)
            => configuration.GetValue("Port", 9001);
    }
}
