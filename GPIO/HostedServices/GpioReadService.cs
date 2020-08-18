using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GPIO.HostedServices
{
    public class GpioReadService : IHostedService
    {
        private readonly ILogger<GpioReadService> _logger;
        private Timer _timer;
        private IGpioManager gpioManager;
        public GpioReadService(ILogger<GpioReadService> logger, IServiceProvider provider)
        {
            gpioManager = provider.GetRequiredService<IGpioManager>();
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(ReadFromGpio, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void ReadFromGpio(object state)
        {
            _logger.LogInformation("Read from every pin!");
            foreach (var pin in gpioManager.GpioPins)
            {
                _logger.LogInformation($"Read from pin: {pin.GpioAddress}");
                gpioManager.ReadPin();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
