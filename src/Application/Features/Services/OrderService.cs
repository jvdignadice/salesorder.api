using Application.Features.Interfaces.Kafka;
using Domain.Entities;
using Domain.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Features.Services
{
    public class OrderService
    {
        private readonly IKafkaProducer _producer;

        public OrderService(IKafkaProducer producer)
        {
            _producer = producer;
        }

        public async Task PlaceOrderAsync(Order order)
        {
            // 1️⃣ Business logic
            order.MarkAsPlaced();

            // 2️⃣ Publish event
            var @event = new OrderPlacedEvent(order.OrderId, DateTime.UtcNow);
            await _producer.ProduceAsync("orders", JsonSerializer.Serialize(@event));
        }
    }

}
