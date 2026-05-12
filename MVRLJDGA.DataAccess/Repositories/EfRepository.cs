using Microsoft.EntityFrameworkCore;
using MVRLJDGA.DataAccess.Database;
using MVRLJDGA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

      
        public async Task<IReadOnlyList<T>> ListAsync(object spec)
        {
            var query = _context.Set<T>().AsQueryable();

            if (spec != null)
            {
               
                var criteriaProp = spec.GetType().GetProperty("Criteria");
                var includesProp = spec.GetType().GetProperty("Includes");

                if (criteriaProp != null)
                {
                    var criteria = criteriaProp.GetValue(spec) as System.Linq.Expressions.Expression<Func<T, bool>>;
                    if (criteria != null)
                    {
                        query = query.Where(criteria);
                    }
                }

                if (includesProp != null)
                {
                    var includes = includesProp.GetValue(spec) as System.Collections.IEnumerable;
                    if (includes != null)
                    {
                        foreach (var include in includes)
                        {
                            var expr = include as System.Linq.Expressions.Expression<Func<T, object>>;
                            if (expr != null)
                            {
                                query = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.Include(query, expr);
                            }
                        }
                    }
                }
            }

            var result = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(query);
            return result.AsReadOnly();
        }
    }
}