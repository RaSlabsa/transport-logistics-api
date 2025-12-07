using TransportLogistics.Core.Entities;

namespace TransportLogistics.Core.DTOs.Get
{
    public class TripLogDto : BaseDto
    {
        public int TripId { get; set; }
        public DateTime EventTime { get; set; }
        public EventType EventType { get; set; }
        public string GPSLocation { get; set; } = string.Empty;
        public string DriverComment { get; set; } = string.Empty;
        public int FuelConsumed { get; set; }
    }
}
