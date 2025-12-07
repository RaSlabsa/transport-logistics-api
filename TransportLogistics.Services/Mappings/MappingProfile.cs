using AutoMapper;
using TransportLogistics.Core.Entities;
using TransportLogistics.Core.DTOs.Get;
using TransportLogistics.Core.DTOs.Post;

namespace TransportLogistics.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientCreateDto, Client>();

            CreateMap<Driver, DriverDto>();
            CreateMap<DriverCreateDto, Driver>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderCreateDto, Order>();

            CreateMap<Trip, TripDto>();
            CreateMap<TripCreateDto, Trip>();

            CreateMap<TripLog, TripLogDto>();
            CreateMap<TripLogCreateDto, TripLog>();

            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleCreateDto, Vehicle>();
        }
    }
}
