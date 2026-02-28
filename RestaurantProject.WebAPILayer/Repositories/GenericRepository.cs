
using Microsoft.EntityFrameworkCore;
using RestaurantProject.WebAPILayer.Context;
using System.Linq.Expressions;

namespace RestaurantProject.WebAPILayer.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApiContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(ApiContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
           await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
           _table.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}
