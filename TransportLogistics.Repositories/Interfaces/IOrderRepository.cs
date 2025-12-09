using TransportLogistics.Core.Entities;

namespace TransportLogistics.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<IEnumerable<Order>> GetDriverTripHistoryAsync(int driverId);
        public Task<IEnumerable<Order>> GetOrdersByPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
