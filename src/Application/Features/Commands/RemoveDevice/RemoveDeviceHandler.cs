using Application.Features.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.RemoveDevice
{
    public class RemoveDeviceHandler : IRequestHandler<RemoveDeviceCommand, Device>
    {

        private readonly IUnitOfWork _unitOfWork;
        public RemoveDeviceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Device> Handle(RemoveDeviceCommand request, CancellationToken cancellationToken)
        {
            
            var res =  await _unitOfWork.DeviceRepository.RemoveDevice(request.DeviceId);
            return res;
        }
    }
}
