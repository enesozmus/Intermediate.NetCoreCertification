using Intermediate.Application.IRepositories;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Intermediate.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
     private readonly IntermediateContext _context;

     public WriteRepository(IntermediateContext context)
     {
          _context = context ?? throw new ArgumentNullException(nameof(context));
     }

     #region IRepository(Tables)

     public virtual IQueryable<T> Table => _context.Set<T>();
     public virtual IQueryable<T> TableNoTracking => _context.Set<T>().AsNoTracking();

     #endregion

     #region Save

     public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

     #endregion

     #region Insert

     public async Task<T> AddAsync(T entity)
     {
          _context.Set<T>().Add(entity);
          await _context.SaveChangesAsync();
          return entity;
     }

     public virtual async Task AddRangeAsync(IEnumerable<T> entities)
     {
          await _context.Set<T>().AddRangeAsync(entities);
          await _context.SaveChangesAsync();
     }

     #endregion

     #region Update
     public async Task UpdateAsync(T entity)
     {
          _context.Entry(entity).State = EntityState.Modified;
          await _context.SaveChangesAsync();
     }

     public async Task UpdateRangeAsync(IEnumerable<T> entities)
     {
          _context.Entry(entities).State = EntityState.Modified;
          await _context.SaveChangesAsync();
     }

     #endregion

     #region Delete
     public async Task RemoveAsync(T entity)
     {
          _context.Set<T>().Remove(entity);
          await _context.SaveChangesAsync();
     }

     public async Task RemoveRangeAsync(IEnumerable<T> entities)
     {
          _context.Set<T>().RemoveRange(entities);
          await _context.SaveChangesAsync();
     }

     #endregion
}
