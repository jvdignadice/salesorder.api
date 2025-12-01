using Domain.Entities.Pizza;
using Domain.Entities.SalesOrder;

namespace Infrastructure.Services.CsvReader
{
    public static class CsvHeaderRegistry
    {
        public static readonly Dictionary<Type, string[]> Headers = new()
    {
        {
            typeof(OrderDetails),
            new[] { "order_details_id", "order_id", "pizza_id", "quantity" }
        },
        {
            typeof(Orders),
            new[] { "order_id", "date", "time" }
        },
        {
            typeof(PizzaType),
            new[] { "pizza_type_id", "name", "category", "ingredients" }
        },
        {
            typeof(Pizza),
            new[] { "pizza_id", "pizza_type_id", "size", "price" }
        }
    };
    }
}
