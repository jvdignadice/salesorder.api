using Application.Features.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateDevice
{
    public record CreateDeviceCommand(DeviceDto deviceDto): IRequest<Device>
    {
    }
}
