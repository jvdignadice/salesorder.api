using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interfaces.Kafka
{
    public interface IKafkaProducer
    {
        Task ProduceAsync(string topic, string message);
    }
}
