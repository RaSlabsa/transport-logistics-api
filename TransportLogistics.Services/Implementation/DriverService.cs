using AutoMapper;
using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Core.Entities;
using TransportLogistics.Repositories.Implementation;
using TransportLogistics.Repositories.Interfaces;
using TransportLogistics.Services.Interfaces;

namespace TransportLogistics.Services.Implementation
{
    public class DriverService : GenericService<Driver, DriverDto, DriverCreateDto>, IDriverService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDriverRepository _driverRepository;
        public DriverService(IGenericRepository<Driver> repository, IMapper mapper, IOrderRepository orderRepository, IDriverRepository driverRepository) : base(repository, mapper)
        {
            _orderRepository = orderRepository;
            _driverRepository = driverRepository;
        }
        public override async Task<DriverDto> AddAsync(DriverCreateDto dto)
        {
            var entity = _mapper.Map<Driver>(dto);

            entity.HiredDate = DateOnly.FromDateTime(DateTime.Now);

            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();

            return _mapper.Map<DriverDto>(entity);
        }

        public override async Task<bool> Delete(int driverId)
        {
            var hasOrders = await _orderRepository.GetAllAsync();

            if (hasOrders.Any())
            {
                throw new InvalidOperationException("Cannot delete driver; this driver is assigned to one or more existing orders.");
            }

            var driverToDelete = await _driverRepository.GetByIdAsync(driverId);

            if (driverToDelete == null) return false;

            await _driverRepository.Delete(driverId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

