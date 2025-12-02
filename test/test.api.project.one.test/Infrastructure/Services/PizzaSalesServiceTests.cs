//using Domain.Entities;
//using Domain.Entities.Pizza;
//using Domain.Entities.SalesOrder;
//using FakeItEasy;
//using Infrastructure.Persistence;
//using Infrastructure.Services.SalesAnalytics;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//namespace test.api.project.one.test.Infrastructure.Services
//{
//    public class PizzaSalesServiceTests
//    {
//        [Fact]
//        public async Task GetTotalRevenueAsync_ReturnsCorrectValue()
//        {
//            // Arrange - use EF Core InMemory database
//            var options = new DbContextOptionsBuilder<TestAppDbContext>()
//                .UseInMemoryDatabase(databaseName: "PizzaDb")
//                .Options;

//            using var db = new TestAppDbContext(options);

//            // Seed pizzas
//            var pizzas = new List<Pizza>
//            {
//                new Pizza { PizzaId = "1", Price = 100 },
//                new Pizza { PizzaId = "2", Price = 200 }
//            };
//            db.Pizzas.AddRange(pizzas);

//            // Seed orders
//            var orders = new List<Orders>
//            {
//                new Orders { Id = 1 },
//                new Orders { Id = 2 }
//            };
//            db.Orders.AddRange(orders);

//            // Seed order details
//            var orderDetails = new List<OrderDetails>
//            {
//                new OrderDetails { PizzaId = "1", Quantity = 2, OrderId = 1 },
//                new OrderDetails { PizzaId = "2", Quantity = 3, OrderId = 2 }
//            };
//            db.OrderDetails.AddRange(orderDetails);

//            await db.SaveChangesAsync();

//            var service = new SalesAnalyticsService(db);

//            // Act
//            var result = await service.GetTotalRevenueAsync();

//            // Assert
//            Assert.Equal("800", result.Replace(",", ""));
//        }
//    }
//}
