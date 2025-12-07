namespace TransportLogistics.Services.Interfaces
{
    public interface IGenericService<TEntity, TViewDto, TCreateDto>
        where TEntity : class
        where TViewDto : class
        where TCreateDto : class
    {
        Task<TViewDto?> GetByIdAsync();
        Task<IEnumerable<TViewDto>>GetAllAsync();
        Task<TViewDto> AddAsync(TCreateDto dto);
        Task<bool> Update(int id, TCreateDto dto);
        Task<bool> Delete(int id);
    }
}
