namespace TransportLogistics.Core.Entities
{
    public enum ClientType
    {
        Person,
        Company
    }
    public class Client
    {
        public int ClientId { get; set; }
        public ClientType ClientType { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TextID { get; set; } = string.Empty;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
