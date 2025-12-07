namespace TransportLogistics.Core.Entities
{
    public enum TripStatus
    {
        Appointed,
        Delivering,
        Delivered,
        Completed,
    }
    public class Trip
    {
        public int TripId { get; set; }
        public int OrderId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public int PlannedDistance { get; set; }
        public int PlannedFuelConsumption { get; set; }
        public TripStatus TripStatus { get; set; }
        public int CostFuel { get; set; }
        public int CostOther { get; set; }
        public ICollection<TripLog> TripLogs { get; set; } = new List<TripLog>(); 
    }
}
