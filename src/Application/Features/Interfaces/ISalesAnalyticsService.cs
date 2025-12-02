using Application.Features.DTOs;

namespace Application.Features.Interfaces
{
    public interface ISalesAnalyticsService
    {
        Task<string> GetTotalRevenueAsync();
        Task<List<PizzaSalesDto>> GetTopSellingPizzasAsync(int top = 5);
        Task<Dictionary<string, string>> GetRevenueByPizzaTypeAsync();
        Task<string> GetAverageOrderValueAsync();
      
    }
}
