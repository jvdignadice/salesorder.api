namespace Domain.Entities
{
    public class Device
    {
        public Guid DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public DeviceType DeviceType { get; set; }
        public string? SSID { get; set; }
    }

    public enum DeviceType
    {
        Laptop = 1,
        MoBilePhone = 2,
        Tablet = 3,
        Desktop = 4,
        Modem = 5
    }
}
