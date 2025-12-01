using Domain.Entities;

namespace Application.Features.DTOs
{
    public class DeviceDto
    {
        public string? DeviceName { get; set; }
        public DeviceType DeviceType { get; set; }
        public string? SSID { get; set; }
    }
}
