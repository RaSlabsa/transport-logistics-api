using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Core.Entities;
using TransportLogistics.Repositories.Interfaces;

namespace TransportLogistics.Services.Interfaces
{
    public interface IOrderService : IGenericService<Order, OrderDto, OrderCreateDto>
    {
        public Task<IEnumerable<OrderDto>> GetDriverTripHistoryAsync(int driverId);
        public Task<bool> CompleteOrderAsync(int orderId);
        public Task<IEnumerable<OrderDto>> GetOrdersByPeriodAsync(DateTime startDate, DateTime endDate);
        public Task<bool> AssignVehicleAsync(int orderId, int vehicleId);
    }
}