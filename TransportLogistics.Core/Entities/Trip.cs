namespace TransportLogistics.Core.Entities
{
    public enum TripStatus
    {
        Appointed,
        Delivering,
        Delivered,
        Completed,
        Canceled
    }
    public class Trip
    {
        public int TripId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
        public int PlannedDistance { get; set; }
        public int PlannedFuelConsumption { get; set; }
        public TripStatus TripStatus { get; set; }
        public int CostFuel { get; set; }
        public int CostOther { get; set; }
        public ICollection<TripLog> TripLogs { get; set; } = new List<TripLog>(); 
    }
}
