using TransportLogistics.Services.Interfaces;
using AutoMapper;
using TransportLogistics.Repositories.Interfaces;
using TransportLogistics.Core.Entities;
using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;

namespace TransportLogistics.Services.Implementation
{
    public class TripService : GenericService<Trip, TripDto, TripCreateDto>, ITripService
    {
        private readonly IOrderService _orderService;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IDriverRepository _driverRepository;
        public TripService(IGenericRepository<Trip> repository, IMapper mapper, IVehicleRepository vehicleRepository,  IOrderService orderService, IDriverRepository driverRepository) : base(repository, mapper)
        {
            _orderService = orderService;
            _vehicleRepository = vehicleRepository;
            _driverRepository = driverRepository;
        }
        public override async Task<TripDto> AddAsync(TripCreateDto dto)
        {
            var entity = _mapper.Map<Trip>(dto);

            entity.TripStatus = TripStatus.Appointed;

            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();

            return _mapper.Map<TripDto>(entity);
        }
        public async Task ValidateDriverAvailability(int driverId, int orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);
            
            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            var isDriveBooked = await _driverRepository.IsDriverBooked(
                driverId,
                order.RequiredDepartureTime,
                order.RequiredArrivalTime
                );

            if (!isDriveBooked)
            {
                throw new ArgumentException("Driver is not avaible");
            }

        }
        public async Task ValidateVehicleAvailabiliry(int vehicleId, int orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);

            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            var isVehicleBooked = await _vehicleRepository.IsVehicleBooked(
                vehicleId,
                order.RequiredDepartureTime,
                order.RequiredArrivalTime
                );

            if (!isVehicleBooked)
            {
                throw new ArgumentException("Vehicle is not avaible");
            }
        }
    }
}

