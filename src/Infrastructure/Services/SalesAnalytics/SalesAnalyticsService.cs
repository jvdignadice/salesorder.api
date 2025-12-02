using Application.Features.DTOs;
using Application.Features.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Services.SalesAnalytics
{
    public class SalesAnalyticsService : ISalesAnalyticsService
    {
        private readonly TestAppDbContext _db;

        public SalesAnalyticsService(TestAppDbContext db)
        {
            _db = db;
        }

        public async Task<string> GetTotalRevenueAsync()
        {
            var totalRevenue = await _db.OrderDetails
                .Join(_db.Pizza,
                      od => od.pizza_id,
                      p => p.pizza_id,
                      (od, p) => od.quantity * p.price)
                .SumAsync();

            return totalRevenue.ToString("N0"); 
        }

        public async Task<List<PizzaSalesDto>> GetTopSellingPizzasAsync(int top = 5)
        {
            var data = await _db.OrderDetails
            .Join(_db.Pizza,
                  od => od.pizza_id,
                  p => p.pizza_id,
                  (od, p) => new { od.quantity, p.pizza_type_id })
            .Join(_db.PizzaType,
                  x => x.pizza_type_id,
                  pt => pt.pizza_type_id,
                  (x, pt) => new { pt.name, x.quantity })
            .GroupBy(x => x.name)
            .Select(g => new { PizzaName = g.Key, QuantitySold = g.Sum(x => x.quantity) })
            .OrderByDescending(x => x.QuantitySold)
            .Take(top)
            .ToListAsync();

            return data.Select(x => new PizzaSalesDto
            {
                PizzaName = x.PizzaName,
                QuantitySold = x.QuantitySold.ToString("N0")
            }).ToList();
        }



        public async Task<Dictionary<string, string>> GetRevenueByPizzaTypeAsync()
        {
            var result = await _db.OrderDetails
                .Join(_db.Pizza,
                      od => od.pizza_id,
                      p => p.pizza_id,
                      (od, p) => new { p.pizza_type_id, Revenue = od.quantity * p.price })
                .Join(_db.PizzaType,
                      p => p.pizza_type_id,
                      pt => pt.pizza_type_id,
                      (p, pt) => new { pt.name, p.Revenue })
                .GroupBy(x => x.name)
                .Select(g => new { PizzaType = g.Key, Revenue = g.Sum(x => x.Revenue) })
                .ToDictionaryAsync(x => x.PizzaType, x => x.Revenue.ToString("N0"));

            return result;
        }


        public async Task<string> GetAverageOrderValueAsync()
        {
            var totalRevenue = await _db.OrderDetails
                .Join(_db.Pizza,
                      od => od.pizza_id,
                      p => p.pizza_id,
                      (od, p) => od.quantity * p.price)
                .SumAsync();

            var totalOrders = await _db.Orders.CountAsync();
            var average = totalOrders == 0 ? 0 : totalRevenue / totalOrders;

            return average.ToString("N0");
        }
    }
}
