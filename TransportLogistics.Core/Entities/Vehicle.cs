namespace TransportLogistics.Core.Entities
{
    public enum VehicleType
    {
        CurtainSider,
        Refrigerator,
        Platform,
        Van,
        TankTruck,
    }
    public enum VehicleStatus
    {
        Available,
        Busy,
        Maintenance
    }
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public string RegNumber { get; set; } = string.Empty;
        public VehicleType VehicleType { get; set; }
        public string BrandModel { get; set; } = string.Empty;
        public int PayLoadCapacity { get; set; }
        public int VolumeCapacity { get; set; }
        public int ProductionYear { get; set; }

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
