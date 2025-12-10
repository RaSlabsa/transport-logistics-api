using TransportLogistics.Core.Entities;

namespace TransportLogistics.Core.DTOs.Get
{
    public class OrderDto : BaseDto
    {
        public int ClientId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public DateTime CreationDate { get; set; }
        public string LoadAddress { get; set; } = string.Empty;
        public string UnloadAddress { get; set; } = string.Empty;
        public DateOnly RequiredDepartureTime { get; set; }
        public DateOnly RequiredArrivalTime { get; set; }
        public string CargoDescription { get; set; } = string.Empty;
        public OrderStatus OrderStatus { get; set; }
    }
}
