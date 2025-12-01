using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging
{
    public class KafkaBackgroundConsumer : BackgroundService
    {
        private readonly ILogger<KafkaBackgroundConsumer> _logger;
        private readonly ConsumerConfig _config;
        private readonly string _topic;

        public KafkaBackgroundConsumer(IConfiguration configuration, ILogger<KafkaBackgroundConsumer> logger)
        {
            _logger = logger;

            _config = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092",
                GroupId = configuration["Kafka:GroupId"] ?? "default-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _topic = configuration["Kafka:Topic"] ?? "test-topic";
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Task.Run(() => ConsumeLoop(stoppingToken), stoppingToken);
            return Task.CompletedTask;
        }

        private void ConsumeLoop(CancellationToken stoppingToken)
        {
            using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
            consumer.Subscribe(_topic);

            _logger.LogInformation("🔄 Kafka consumer started for topic: {topic}", _topic);

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var cr = consumer.Consume(stoppingToken);
                    _logger.LogInformation("📩 Received: {message} @ {offset}", cr.Message.Value, cr.TopicPartitionOffset);
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Kafka consumer stopped.");
                consumer.Close();
            }
            catch (KafkaException ex)
            {
                _logger.LogError(ex, "Kafka consumer encountered an error.");
                _logger.LogWarning("Topic not available yet: {Topic}. Retrying...", _topic);
                Thread.Sleep(1000);
            }
        }
    }
}
