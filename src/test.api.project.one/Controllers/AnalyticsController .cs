using Application.Features.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace test.api.project.one.Controllers
{
    [ApiController]
    [Route("api/analytics")]
    public class AnalyticsController : ControllerBase
    {
        private readonly ISalesAnalyticsService _analytics;

        public AnalyticsController(ISalesAnalyticsService analytics)
        {
            _analytics = analytics;
        }

        [HttpGet("total-revenue")]
        public async Task<ActionResult<decimal>> GetTotalRevenue() =>
            Ok(await _analytics.GetTotalRevenueAsync());

        [HttpGet("top-pizzas")]
        public async Task<ActionResult> GetTopPizzas(int top = 5) =>
            Ok(await _analytics.GetTopSellingPizzasAsync(top));

        [HttpGet("revenue-by-type")]
        public async Task<ActionResult> GetRevenueByType() =>
            Ok(await _analytics.GetRevenueByPizzaTypeAsync());

        [HttpGet("average-order-value")]
        public async Task<ActionResult<decimal>> GetAverageOrderValue() =>
            Ok(await _analytics.GetAverageOrderValueAsync());
    }

}
