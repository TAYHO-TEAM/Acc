using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectManager.CMD.Infrastructure;
using SendMailAppointmentService.JobProccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SendMailAppointmentService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ProjectManagerBaseContext _projectManagerBaseContext;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
           
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
                using var scope = _serviceScopeFactory.CreateScope();

                var dbContext = scope.ServiceProvider.GetRequiredService<ProjectManagerBaseContext>();
                MainProccess newProccess = new MainProccess();
                try
                {
                    _logger.LogInformation("Begin Run :" + DateTime.Now.ToString());
                    await newProccess.RunProccess(dbContext);
                    _logger.LogInformation("End Run :" + DateTime.Now.ToString());
                }
                catch(Exception ex)
                {
                    _logger.LogError("Error Run :" + DateTime.Now.ToString() );
                    _logger.LogError("Error Description :" + ex.ToString());
                }
              
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(24*60*60*1000, stoppingToken);
            }
        }
    }
}
