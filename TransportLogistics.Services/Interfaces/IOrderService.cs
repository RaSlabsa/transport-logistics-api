using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;
using TransportLogistics.Core.Entities;

namespace TransportLogistics.Services.Interfaces
{
    public interface IOrderService : IGenericService<Order, OrderDto, OrderCreateDto>
    {
    }
}