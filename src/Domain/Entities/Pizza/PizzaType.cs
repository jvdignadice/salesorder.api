using Domain.Common.DomainAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pizza
{
    public class PizzaType
    {
        [CsvKey]
        public int Id { get; set; }
        public string pizza_type_id { get; set; }  
        public string name { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public string ingredients { get; set; } = string.Empty;
    }
}
