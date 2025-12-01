using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class OrderDto
    {

        public Guid OrderId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public OrderDto(Guid orderId, string? name, string? description)
        {
            OrderId = orderId;
            Name = name;
            Description = description;
        }
    }
}
