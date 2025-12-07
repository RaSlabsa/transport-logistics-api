namespace TransportLogistics.Core.DTOs.Post
{
    public class DriverCreateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string LicenseCategories { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
    }
}
