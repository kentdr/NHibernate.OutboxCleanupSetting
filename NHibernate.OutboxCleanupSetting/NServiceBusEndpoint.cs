using Microsoft.Extensions.Hosting;

using NServiceBus;
using NServiceBus.Persistence;

using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace NHibernate.OutboxCleanupSetting
{
    internal class NServiceBusEndpoint : IHostedService
    {
        private IEndpointInstance _endpoint;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var endpointConfiguration = new EndpointConfiguration("no-cleanup-setting");
            endpointConfiguration.SetDiagnosticsPath(Directory.GetCurrentDirectory());
            endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.EnableOutbox();
            var persistence = endpointConfiguration.UsePersistence<NHibernatePersistence>();
            persistence.ConnectionString(@"Data Source=(LocalDb)\MSSQLLocalDB;Integrated Security=true");
            System.Diagnostics.Debug.WriteLine($"Test: {ConfigurationManager.AppSettings.Get("Test")}");
            _endpoint = await Endpoint.Start(endpointConfiguration);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _endpoint.Stop();
        }
    }
}