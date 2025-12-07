using TransportLogistics.Services.Interfaces;
using AutoMapper;
using TransportLogistics.Repositories.Interfaces;
using TransportLogistics.Core.Entities;
using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;

namespace TransportLogistics.Services.Implementation
{
    public class DriverService : GenericService<Driver, DriverDto, DriverCreateDto>, IDriverService
    {
        public DriverService(IGenericRepository<Driver> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public override async Task<DriverDto> AddAsync(DriverCreateDto dto)
        {
            var entity = _mapper.Map<Driver>(dto);

            entity.HiredDate = DateOnly.FromDateTime(DateTime.Now);

            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();

            return _mapper.Map<DriverDto>(entity);
        }
    }
}

