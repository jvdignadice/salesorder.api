using Application.Features.DTOs;
using Domain.Entities;

namespace Application.Features.Interfaces
{
    public interface IDeviceRepository
    {
        Task<Device> CreateDevice(DeviceDto device);
        Task<List<Device>> GetDevice();
        Task<Device> UpdateDevice(DeviceDto device, Guid Id);
        Task<Device> RemoveDevice(Guid Id);
    }
}
