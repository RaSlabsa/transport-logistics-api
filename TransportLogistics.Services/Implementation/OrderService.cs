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
        private readonly IOrderRepository _orderRepository;
        public OrderService(IGenericRepository<Order> repository, IMapper mapper, IOrderRepository orderRepository) : base(repository, mapper)
        {
            _orderRepository = orderRepository;
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
        public async Task<IEnumerable<OrderDto>> GetDriverTripHistoryAsync(int driverId)
        {
            var orders = await _orderRepository.GetDriverTripHistoryAsync(driverId);

            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
        public async Task<bool> CompleteOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order == null)
            {
                return false;
            }

            if (order.OrderStatus == OrderStatus.Canceled)
            {
                throw new InvalidOperationException("Cannot complete canceled order");
            }

            order.OrderStatus = OrderStatus.Completed;

            await _orderRepository.Update(order);
            await _orderRepository.SaveChangesAsync();

            return true;
        }
        public async Task<IEnumerable<OrderDto>> GetOrdersByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date cannot be after end date.");
            }

            var orders = await _orderRepository.GetOrdersByPeriodAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
    }
}

