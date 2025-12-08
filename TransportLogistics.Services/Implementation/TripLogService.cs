using TransportLogistics.Services.Interfaces;
using AutoMapper;
using TransportLogistics.Repositories.Interfaces;
using TransportLogistics.Core.Entities;
using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;

namespace TransportLogistics.Services.Implementation
{
    public class TripLogService : GenericService<TripLog, TripLogDto, TripLogCreateDto>, ITripLogService
    {
        public TripLogService(IGenericRepository<TripLog> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

