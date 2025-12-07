using System.ComponentModel.DataAnnotations;

namespace TransportLogistics.Core.Entities
{
    public enum EventType
    {
        Sent,
        Arrived,
        Stoped,
        Customs
    }
    public class TripLog
    {
        [Key]
        public int LogId { get; set; }
        public int TripId { get; set; }
        public DateTime EventTime { get; set; }
        public EventType EventType { get; set; }
        public string GPSLocation { get; set; } = string.Empty;
        public string DriverComment { get; set; } = string.Empty;
        public int FuelConsumed { get; set; }
    }
}
