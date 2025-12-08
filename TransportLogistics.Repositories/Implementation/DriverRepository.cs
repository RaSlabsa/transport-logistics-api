using Microsoft.EntityFrameworkCore;
using TransportLogistics.Repositories.Data;
using TransportLogistics.Core.Entities;
using TransportLogistics.Repositories.Interfaces;

namespace TransportLogistics.Repositories.Implementation
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(TransportLogicDB context) : base(context)
        {
        }
        public async Task<bool> IsDriverBooked(int driverId, DateOnly departure, DateOnly arrival)
        {
            return await _context.Trips
                .AsNoTracking()
                .Include(trip => trip.Order)
                .AnyAsync(trip =>
                    trip.DriverId == driverId &&
                    trip.TripStatus != TripStatus.Canceled &&
                    (departure < trip.Order.RequiredArrivalTime && arrival > trip.Order.RequiredDepartureTime));
        }
    }
}
