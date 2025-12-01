using Application.Features.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UpdateDevice
{
    public class UpdateDeviceHandler : IRequestHandler<UpdateDeviceCommand, Device>
    {
        public readonly IUnitOfWork _unitOfWork;

        public UpdateDeviceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Device> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            var created = await _unitOfWork.DeviceRepository.UpdateDevice(request.DeviceDto, request.DeviceId);
            return created;
        }
    }
}
