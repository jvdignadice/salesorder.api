using Domain.Common.DomainAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SalesOrder
{
    public class OrderDetails
    {
        [CsvKey]
        public int Id{ get; set; }
        public int order_id { get; set; }
        public string pizza_id { get; set; }
        public int quantity { get; set; }
    }
}
