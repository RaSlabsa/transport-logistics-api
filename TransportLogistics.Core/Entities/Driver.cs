namespace TransportLogistics.Core.Entities
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string LicenseCategories { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public DateOnly HiredDate { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
