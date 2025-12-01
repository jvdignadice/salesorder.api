using Domain.Common.DomainAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SalesOrder
{
    public class Orders
    {

        [CsvKey]
       public int Id { get; set; }
       public DateOnly Date { get; set; }
       public TimeOnly Time { get; set; }
    }
}
