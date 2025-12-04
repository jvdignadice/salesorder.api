using Domain.Common.DomainAttribute;
using System.Drawing;

namespace Domain.Entities.Pizza
{
    public class Pizza
    {
        [CsvKey]
        public int Id { get; set; }
        public string pizza_id { get; set; }
        public string pizza_type_id { get; set; }
        public string size { get; set; }
        public decimal price { get; set; }
    }

}
