using AutoMapper;
using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Core.Entities;
using TransportLogistics.Repositories.Implementation;
using TransportLogistics.Repositories.Interfaces;
using TransportLogistics.Services.Interfaces;

namespace TransportLogistics.Services.Implementation
{
    public class VehicleService : GenericService<Vehicle, VehicleDto, VehicleCreateDto>, IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleService(IGenericRepository<Vehicle> repository, IMapper mapper, IVehicleRepository vehicleRepository) : base(repository, mapper)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<IEnumerable<VehicleDto>> GetAvailableVehiclesAsync()
        {
            var vehicles = await _vehicleRepository.GetAvailableVehiclesAsync();

            return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        }
    }
}
