using TransportLogistics.Services.Interfaces;
using AutoMapper;
using TransportLogistics.Repositories.Interfaces;
using TransportLogistics.Core.Entities;
using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;

namespace TransportLogistics.Services.Implementation
{
    public class OrderService : GenericService<Order, OrderDto, OrderCreateDto>, IOrderService
    {
        public OrderService(IGenericRepository<Order> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public override async Task<OrderDto> AddAsync(OrderCreateDto dto)
        {
            var entity = _mapper.Map<Order>(dto);

            entity.CreationDate = DateTime.Now;

            entity.OrderStatus = OrderStatus.New;

            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();

            return _mapper.Map<OrderDto>(entity);
        }
    }
}

