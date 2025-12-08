using Microsoft.EntityFrameworkCore;
using TransportLogistics.Repositories.Interfaces;
using TransportLogistics.Repositories.Data;

namespace TransportLogistics.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TransportLogicDB _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(TransportLogicDB context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public Task Update (T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public async Task<bool> Delete (int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete == null)
            {
                return false;
            }
            _dbSet.Remove(entityToDelete);

            return true;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
