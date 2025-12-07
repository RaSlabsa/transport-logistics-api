using TransportLogistics.Services.Interfaces;
using AutoMapper;
using TransportLogistics.Repositories.Interfaces;

namespace TransportLogistics.Services.Implementation
{
    public class GenericService<TEntity, TViewDto, TCreateDto>: IGenericService<TEntity, TViewDto, TCreateDto>
        where TEntity : class
        where TViewDto : class
        where TCreateDto : class
    {
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<TViewDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<TViewDto>(entity);
        }
        public async Task<IEnumerable<TViewDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TViewDto>>(entities);
        }
        public virtual async Task<TViewDto> AddAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();

            return _mapper.Map<TViewDto>(entity);
        }
        public async Task<bool> Update(int id, TCreateDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);

            if (existingEntity == null)
            {
                return false;
            }

            _mapper.Map(dto, existingEntity);

            await _repository.Update(existingEntity);

            var rowsAffected = await _repository.SaveChangesAsync();

            return rowsAffected > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var entityToDelete = await _repository.GetByIdAsync(id);

            if (entityToDelete == null)
            {
                return false;
            }

            await _repository.Delete(entityToDelete);

            var rowsAffected = await _repository.SaveChangesAsync();

            return rowsAffected > 0;
        }
    }
}
