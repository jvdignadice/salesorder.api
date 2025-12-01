using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class OrdersDetailDto
    {
        public int order_id { get; set; }
        public string pizza_id { get; set; }
        public int quantity { get; set; }
    }
}
