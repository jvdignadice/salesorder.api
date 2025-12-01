using Application.Features.DTOs;
using Domain.Entities.Pizza;
using MediatR;

namespace Application.Features.Queries.GetAllPizza
{
    public class GetAllPizzaQuery : IRequest<PagedResult<Pizza>>
    {
        public int PageNumber { get; set; } = 1;  
        public int PageSize { get; set; } = 10;   
    }
}
