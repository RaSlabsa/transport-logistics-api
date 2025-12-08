using AutoMapper;
using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Core.Entities;
using TransportLogistics.Repositories.Interfaces;
using TransportLogistics.Services.Interfaces;

namespace TransportLogistics.Services.Implementation
{
    public class VehicleService : GenericService<Vehicle, VehicleDto, VehicleCreateDto>, IVehicleService
    {
        public VehicleService(IGenericRepository<Vehicle> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
