using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interfaces.Kafka
{
    public class KafkaConsumer : IKafkaConsumer
    {
        private readonly ConsumerConfig _config;

        public KafkaConsumer(IConfiguration configuration)
        {
            _config = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092",
                GroupId = configuration["Kafka:GroupId"] ?? "default-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        public void Consume(string topic, Action<string, string> onMessageReceived)
        {
            using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
            consumer.Subscribe(topic);

            try
            {
                while (true)
                {
                    var cr = consumer.Consume();
                    onMessageReceived?.Invoke(cr.Message.Value, cr.TopicPartitionOffset.ToString());
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }
        }
    }
}
