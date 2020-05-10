using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace magdo
{
    internal class MainWorker : IHostedService
    {
        private ILogger<MainWorker> log;
        public MainWorker(ILogger<MainWorker> log)
        {
            this.log = log;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            log.LogInformation("Start main worker");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            log.LogInformation("Stop main worker");
            return Task.CompletedTask;
        }
    }
}