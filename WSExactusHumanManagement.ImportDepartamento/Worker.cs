
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

using System.Threading;
using System.Threading.Tasks;
using WSHumanManagement.Application.Exactus.Departamento.IServices;


namespace WSExactusHumanManagement.ImportDepartamento
{

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IExactusDepartamentoLogic exactusDepartamentoLogic;
        public Worker(ILogger<Worker> logger,
                        IServiceProvider serviceProvider)
        {
            _logger = logger;
            exactusDepartamentoLogic = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IExactusDepartamentoLogic>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            await base.StopAsync(stoppingToken);

            try
            {
                
                exactusDepartamentoLogic.Import();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            finally
            {
                await Task.Delay(600000);
                await base.StartAsync(stoppingToken);
                
            }
        }

    }
}
