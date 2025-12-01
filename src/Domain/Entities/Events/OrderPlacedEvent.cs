using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Events
{
    public class OrderPlacedEvent
    {
        public Guid OrderId { get; }
        public DateTime PlacedAt { get; }

        public OrderPlacedEvent(Guid orderId, DateTime placedAt)
        {
            OrderId = orderId;
            PlacedAt = placedAt;
        }
    }
}
