using TransportLogistics.Core.Entities;

namespace TransportLogistics.Core.DTOs.Post
{
    public class TripCreateDto
    {
        public int OrderId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public int PlannedDistance { get; set; }
        public int PlannedFuelConsumption { get; set; }
    }
}
