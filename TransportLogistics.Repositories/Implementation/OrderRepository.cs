using Microsoft.EntityFrameworkCore;
using TransportLogistics.Repositories.Data;
using TransportLogistics.Core.Entities;
using TransportLogistics.Repositories.Interfaces;

namespace TransportLogistics.Repositories.Implementation
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(TransportLogicDB context) : base(context)
        {
        }
        public async Task<IEnumerable<Order>> GetDriverTripHistoryAsync(int driverId)
        {
            return await _context.Orders
                .Where(o => o.DriverId == driverId && o.OrderStatus == OrderStatus.Completed)
                .ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Orders
                .Where(o => o.CreationDate >= startDate && o.CreationDate <= endDate)
                .ToListAsync();
        }
    }
}
