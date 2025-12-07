using TransportLogistics.Services.Interfaces;
using AutoMapper;

namespace TransportLogistics.Services.Implementation
{
    public class GenericService<TEntity, TViewDto, TCreateDto>: IGenericService<TEntity, TViewDto, TCreateDto>
        where TEntity : class
        where TViewDto : class
        where TCreateDto : class
    {

    }
}
