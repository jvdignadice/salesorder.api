using MediatR;

namespace Application.Features.Queries.GetAllDevice
{
    public record GetAllDeviceQuery: IRequest<List<Domain.Entities.Device>>
    {
    }
}
