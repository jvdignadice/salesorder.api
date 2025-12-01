using Application.Features.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly TestAppDbContext _context;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public UnitOfWork(TestAppDbContext context)
        {
            _context = context;
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_departmentRepository == null)
                {
                    return new DepartmentRepository(_context);
                }
                return _departmentRepository;
            }
        }

        public IPizzaRepository PizzaRepository
        {
            get
            {
                if (_pizzaRepository == null)
                {
                    return new PizzaRepository(_context);
                }
                return _pizzaRepository;
            }
        }

        public IOrderDetailsRepository OrderDetailsRepository
        {
            get
            {
                if (_orderDetailsRepository == null)
                {
                    return new OrderDetailsRepository(_context);
                }
                return _orderDetailsRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    return new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public IDeviceRepository DeviceRepository
        {
            get
            {
                if (_deviceRepository == null)
                {
                    return new DeviceRepository(_context);
                }
                return _deviceRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
