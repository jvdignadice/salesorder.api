namespace Application.Features.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository DepartmentRepository { get; }
        IUserRepository UserRepository { get; }
        IDeviceRepository DeviceRepository { get; }
        IPizzaRepository PizzaRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        void Save();
        void Dispose();
    }
}
