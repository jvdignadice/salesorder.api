using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.RemoveDevice
{
    public record RemoveDeviceCommand(Guid DeviceId) : IRequest<Device>
    {
    }
}
