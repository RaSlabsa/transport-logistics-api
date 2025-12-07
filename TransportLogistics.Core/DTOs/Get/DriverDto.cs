namespace TransportLogistics.Core.DTOs.Get
{
    public class DriverDto : BaseDto
    {
        public string FullName { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string LicenseCategories { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public DateOnly HiredDate { get; set; }
    }
}
