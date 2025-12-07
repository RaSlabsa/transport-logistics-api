using TransportLogistics.Core.Entities;

namespace TransportLogistics.Core.DTOs.Get
{
    public class VehicleDto : BaseDto
    {
        public string RegNumber { get; set; } = string.Empty;
        public VehicleType VehicleType { get; set; }
        public string BrandModel { get; set; } = string.Empty;
        public int PayLoadCapacity { get; set; }
        public int VolumeCapacity { get; set; }
        public int ProductionYear { get; set; }
    }
}
