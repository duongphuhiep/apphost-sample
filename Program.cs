using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.Threading.Tasks;
using ToolsPack.NLog;

namespace magdo
{
    class Program
    {
        static void Main(string[] args)
        {
            LogQuickConfig.SetupFileAndConsole("./logs/magdo.log");
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<MainWorker>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
            })
            .UseNLog();
    }
}
