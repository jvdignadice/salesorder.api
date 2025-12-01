using Application.Features.DTOs;
using MediatR;

namespace Application.Features.Commands.UpdateDevice
{
    public record UpdateDeviceCommand(DeviceDto DeviceDto, Guid DeviceId): IRequest<Domain.Entities.Device>
    {
    }
}
