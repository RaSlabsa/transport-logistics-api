using System.Diagnostics;

namespace transport_logistics_api.Data.Entities
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
        public int LogId { get; set; }
        public int Tripid { get; set; }
        public DateTime EventTime { get; set; }
        public EventType EventType { get; set; }
        public string GPSLocation { get; set; } = string.Empty;
        public string DriverComment { get; set; } = string.Empty;
        public int FuelConsumed { get; set; }
    }
}
