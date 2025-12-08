using System.Data;
using TransportLogistics.Core.Entities;

namespace TransportLogistics.Repositories.Interfaces
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        public Task<bool> IsDriverBooked(int driverId, DateOnly DepartureTime, DateOnly ArrivalTime);
    }
}
