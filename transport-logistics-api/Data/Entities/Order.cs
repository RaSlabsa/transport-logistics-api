namespace transport_logistics_api.Data.Entities
{
    public enum OrderStatus
    {
        New,
        Processing,
        Delivering,
        Completed,
        Canceled
    }
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public string LoadAddress { get; set; } = string.Empty;
        public string UnloadAddress { get; set; } = string.Empty;
        public DateOnly RequiredDepartureTime { get; set; }
        public DateOnly RequiredArrivalTime { get; set; }
        public string CargoDescription { get; set; } = string.Empty;
        public OrderStatus OrderStatus { get; set; }
        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
