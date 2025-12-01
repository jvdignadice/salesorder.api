using Application.Features.Interfaces.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Services
{
    public class ShippingConsumer : BackgroundService
    {
        private readonly IKafkaConsumer _consumer;
        private readonly ILogger<ShippingConsumer> _logger;

        public ShippingConsumer(IKafkaConsumer consumer, ILogger<ShippingConsumer> logger)
        {
            _consumer = consumer;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Run the consuming loop in a background task
            Task.Run(() => ConsumeLoop(stoppingToken), stoppingToken);
            return Task.CompletedTask;
        }

        private void ConsumeLoop(CancellationToken stoppingToken)
        {
            // Assume IKafkaConsumer exposes a Consume(topic, action) method
            _consumer.Consume("orders", (message, offset) =>
            {
                _logger.LogInformation("📩 Received: {Message} @ {Offset}", message, offset);
                // TODO: Trigger Application logic, e.g., shipping workflow
            });
        }
    }
}
