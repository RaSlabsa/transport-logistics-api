using TransportLogistics.Services.Interfaces;
using AutoMapper;
using TransportLogistics.Repositories.Interfaces;
using TransportLogistics.Core.Entities;
using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;

namespace TransportLogistics.Services.Implementation
{
    public class ClientService : GenericService<Client, ClientDto, ClientCreateDto>, IClientService
    {
        public ClientService(IGenericRepository<Client> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

