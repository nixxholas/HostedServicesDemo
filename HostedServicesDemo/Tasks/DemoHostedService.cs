using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

// QueueBackgroundWorkItem from .NET 4.x TBD in .NET Core 3.0
namespace HostedServicesDemo.Tasks
{
    public class DemoHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        
        public DemoHostedService()
        {
            // Perform DI here
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, 
                TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }
        
        private void DoWork(object state)
        {
            Console.WriteLine($"Background Service is working. {DateTime.Now.TimeOfDay}");
            
            // Perform operations here
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}