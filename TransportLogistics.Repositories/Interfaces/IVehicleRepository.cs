using TransportLogistics.Core.Entities;

namespace TransportLogistics.Repositories.Interfaces
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        public Task<bool> IsVehicleBooked(int vehicleId, DateOnly departure, DateOnly arrival);
    }
}
