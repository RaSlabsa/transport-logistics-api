namespace TransportLogistics.Core.DTOs.Post
{
    public class OrderCreateDto
    {
        public int ClientId { get; set; }
        public string LoadAddress { get; set; } = string.Empty;
        public string UnloadAddress { get; set; } = string.Empty;
        public DateOnly RequiredDepartureTime { get; set; }
        public DateOnly RequiredArrivalTime { get; set; }
        public string CargoDescription { get; set; } = string.Empty;
    }
}
