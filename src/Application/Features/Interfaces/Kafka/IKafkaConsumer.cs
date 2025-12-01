using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interfaces.Kafka
{
    public interface IKafkaConsumer
    {
        void Consume(string topic, Action<string, string> onMessageReceived);
    }
}
