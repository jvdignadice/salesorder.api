using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interfaces.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly ProducerConfig _config;

        public KafkaProducer(IConfiguration configuration)
        {
            _config = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092"
            };
        }

        public async Task ProduceAsync(string topic, string message)
        {
            using var producer = new ProducerBuilder<Null, string>(_config).Build();

            try
            {
                var deliveryResult = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
                Console.WriteLine($"✅ Delivered '{message}' to {deliveryResult.TopicPartitionOffset}");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"❌ Delivery failed: {e.Error.Reason}");
            }
        }
    }
}
