using Application.Features.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateDevice
{
    public class CreateDeviceHandler : IRequestHandler<CreateDeviceCommand, Device>
    {

        private readonly IUnitOfWork unitOfWork;

        public CreateDeviceHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Device> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var deviceCreated = new Device();
            var device = request.deviceDto;
            await unitOfWork.DeviceRepository.CreateDevice(device);
            return deviceCreated;
        }

    }
}
