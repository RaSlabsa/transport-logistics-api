using TransportLogistics.Core.Entities;

namespace TransportLogistics.Core.DTOs.Post
{
    public class ClientCreateDto
    {
        public ClientType ClientType { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TextID { get; set; } = string.Empty;
    }
}
