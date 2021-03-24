using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SendMailAppointmentService.JobProccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SendMailAppointmentService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                MainProccess newProccess = new MainProccess();
                newProccess.RunProccess();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(24*60*60*1000, stoppingToken);
            }
        }
    }
}
