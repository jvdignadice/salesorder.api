using Application.Features.DTOs;
using Application.Features.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly TestAppDbContext _dbContext;

        public DeviceRepository(TestAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Device> CreateDevice(DeviceDto device)
        {

            var deviceToSave = new Device
            {
                DeviceId = Guid.NewGuid(),
                DeviceName = device.DeviceName,
                DeviceType = device.DeviceType,
                SSID = device.SSID,

            };

            await _dbContext.Devices.AddAsync(deviceToSave);
            await _dbContext.SaveChangesAsync();
            return deviceToSave;
        }

        public async Task<List<Device>> GetDevice()
        {
            var deviceToUpdate = _dbContext.Devices.ToList();


            return deviceToUpdate;
        }

        public async Task<Device> UpdateDevice(DeviceDto device, Guid Id)
        {
            var deviceToUpdate = await _dbContext.Devices.FindAsync(Id);

            deviceToUpdate.DeviceName = device.DeviceName;
            deviceToUpdate.DeviceType = device.DeviceType;
            deviceToUpdate.SSID = device.SSID;


            await _dbContext.SaveChangesAsync();
            return deviceToUpdate;
        }

        public async Task<Device> RemoveDevice(Guid Id)
        {
            var deviceToRemove = await _dbContext.Devices.FindAsync(Id);

            if (deviceToRemove != null)
            {
                _dbContext.Devices.Remove(deviceToRemove);
                await _dbContext.SaveChangesAsync();
            }
            return deviceToRemove;
        }


    }
}
