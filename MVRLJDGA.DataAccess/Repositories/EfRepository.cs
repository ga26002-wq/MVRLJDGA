using Microsoft.EntityFrameworkCore;
using MVRLJDGA.DataAccess.Database;
using MVRLJDGA.DataAccess.Interfaces;

namespace MVRLJDGA.DataAccess.Repositories
{
    public class EfRepository<T> : IEfRepository<T> where T : class
    {
        protected readonly LibraryContext _context;

        public EfRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(object id) => await _context.Set<T>().FindAsync(id);
        public async Task<IReadOnlyList<T>> ListAsync() => await _context.Set<T>().ToListAsync();
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}