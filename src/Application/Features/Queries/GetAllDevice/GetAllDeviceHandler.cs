using MediatR;

namespace Application.Features.Queries.GetAllDevice
{
    public class GetAllDeviceHandler: IRequestHandler<GetAllDeviceQuery, List<Domain.Entities.Device>>
    {
        private readonly Interfaces.IUnitOfWork _unitOfWork;

        public GetAllDeviceHandler(Interfaces.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }   

        public async Task<List<Domain.Entities.Device>> Handle(GetAllDeviceQuery request, CancellationToken cancellationToken)
        {
            var devices = await _unitOfWork.DeviceRepository.GetDevice();
            return devices;
        }
    }
}
