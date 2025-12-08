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
            CreateMap<Client, ClientDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.ClientId)
                );
            CreateMap<ClientCreateDto, Client>();

            CreateMap<Driver, DriverDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.DriverId)
                );
            CreateMap<DriverCreateDto, Driver>();

            CreateMap<Order, OrderDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.OrderId)
                );
            CreateMap<OrderCreateDto, Order>();

            CreateMap<Trip, TripDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.TripId)
                );
            CreateMap<TripCreateDto, Trip>();

            CreateMap<TripLog, TripLogDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.LogId)
                );
            CreateMap<TripLogCreateDto, TripLog>();

            CreateMap<Vehicle, VehicleDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.VehicleId)
                );
            CreateMap<VehicleCreateDto, Vehicle>();
        }
    }
}
