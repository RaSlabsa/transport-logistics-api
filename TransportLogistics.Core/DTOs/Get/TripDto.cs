using TransportLogistics.Core.Entities;

namespace TransportLogistics.Core.DTOs.Get
{
    public class TripDto : BaseDto
    {
        public int OrderId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public int PlannedDistance { get; set; }
        public int PlannedFuelConsumption { get; set; }
        public TripStatus TripStatus { get; set; }
        public int CostFuel { get; set; }
        public int CostOther { get; set; }
    }
}
