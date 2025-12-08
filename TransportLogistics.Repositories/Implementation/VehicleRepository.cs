using Microsoft.EntityFrameworkCore;
using TransportLogistics.Repositories.Data;
using TransportLogistics.Core.Entities;
using TransportLogistics.Repositories.Interfaces;

namespace TransportLogistics.Repositories.Implementation
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(TransportLogicDB context) : base(context)
        {
        }
        public async Task<bool> IsVehicleBooked(int vehicleId, DateOnly departure, DateOnly arrival)
        {
            return await _context.Trips
                .AsNoTracking()
                .Include(trip => trip.Order)
                .AnyAsync(trip =>
                    trip.DriverId == vehicleId &&
                    trip.TripStatus != TripStatus.Canceled &&
                    (departure < trip.Order.RequiredArrivalTime && arrival > trip.Order.RequiredDepartureTime));
        }
    }
}
